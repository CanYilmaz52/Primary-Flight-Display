using System;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace deneme
{
    public partial class Form1 : Form
    {
        private float altitude = 0;
        private float speed = 0;
        private float temperature = 0;
        private float fuelLevel = 0;
        private float numberOfPassengers = 0;
        private float headingValue = 0;
        private float windInfo = 0;
        private string flightRoute = null;
        private string weather = null;
        private string cabinStatus = null;
        private string aircraftType = null;
        private string aircraftModel = null;

        private readonly AttitudeSlipSkidIndicator attitudeSlipSkidControl;
        private readonly RadarForm radarForm;

        private float pitchValue = 0;
        private float rollValue = 0;
        private float slipSkidValue = 0;

        public Form1()
        {
            InitializeComponent();
            attitudeSlipSkidControl = new AttitudeSlipSkidIndicator();
            radarForm = new RadarForm();    
        }

        private void DrawAltimeterIndicator(Graphics g, float altitude)
        {
            int centerX = pictureBoxAltimeter.Width / 2;
            int centerY = pictureBoxAltimeter.Height / 2;
            int indicatorHeight = Math.Min(centerX, centerY) - 20; // Indicator height
            int indicatorWidth = 20; // Indicator width
            int indicatorX = centerX - indicatorWidth / 2;
            int indicatorY = centerY + indicatorHeight;

            // Draw indicator rectangle
            g.FillRectangle(Brushes.LightGray, indicatorX, centerY, indicatorWidth, -indicatorHeight);
            g.DrawRectangle(Pens.Black, indicatorX, centerY, indicatorWidth, -indicatorHeight);

            // Altitude indicator line
            float scaleFactor = indicatorHeight / 20000.0f; // Scale factor
            for (int i = 0; i <= 20000; i += 1000)
            {
                int markY = centerY - (int)(i * scaleFactor);
                g.DrawLine(Pens.Black, indicatorX - 5, markY, indicatorX + 5, markY);
                if (i % 5000 == 0) // Label every 5000 feet
                {
                    string ValueText = (i / 1000).ToString();
                    SizeF textSize = g.MeasureString(ValueText, Font);
                    g.DrawString(ValueText, Font, Brushes.Black, indicatorX - textSize.Width - 10, markY - textSize.Height / 2);
                    g.DrawString("K ft", Font, Brushes.Black, indicatorX + 10, markY - textSize.Height / 2);
                }
            }

            int altitudeIndicatorY = centerY - (int)(altitude * scaleFactor);
            g.DrawLine(Pens.Red, indicatorX, altitudeIndicatorY, indicatorX + indicatorWidth, altitudeIndicatorY);
        }

        private void DrawAltitudeValueLabel(Graphics g, float altitude)
        {
            int centerX = pictureBoxAltimeter.Width / 2;
            int centerY = pictureBoxAltimeter.Height / 2;

            // Calculate position for the label
            int labelX = centerX;
            int labelY = centerY + 20; // Adjust the position as needed

            int labelWidth = 140;
            int labelHeight = 20;

            // Create and draw the label
            string altitudeText = $"Altitude: {altitude} ft ";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);

            Rectangle labelRect = new Rectangle(labelX - labelWidth / 2, labelY - labelHeight / 2, labelWidth, labelHeight);
            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(altitudeText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void pictureBoxAltimeter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawAltimeterIndicator(g, altitude);

            DrawAltitudeValueLabel(g, altitude);
        }



        private int aircraftNumber = 1;
        private Dictionary<string, int> aircraftNumberPerType = new Dictionary<string, int>();


        private Dictionary<string, Queue<string>> testMessagesQueues = new Dictionary<string, Queue<string>>();
        private Dictionary<string, int> currentAircraftTestMessagesIndices = new Dictionary<string, int>();

        private string GetTestMessageForAircraft(string dataType)
        {
            string testMessagesFolderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\TEST_Messages";
            string[] testMessagesFilePaths = Directory.GetFiles(testMessagesFolderPath, "Aircraft*_TestMessages.txt");

            if (testMessagesFilePaths.Length > 0)
            {
                // Check if we have a stored index for the current dataType
                if (!currentAircraftTestMessagesIndices.ContainsKey(dataType))
                {
                    currentAircraftTestMessagesIndices[dataType] = 0;
                }

                // Get the index for the current dataType and TestMessages file
                int currentAircraftIndex = currentAircraftTestMessagesIndices[dataType];

                // Iterate through all test message files
                for (int i = 0; i < testMessagesFilePaths.Length; i++)
                {
                    int currentIndex = (currentAircraftIndex + i) % testMessagesFilePaths.Length;
                    string currentTestMessagesFilePath = testMessagesFilePaths[currentIndex];

                    // Read the lines from the current file
                    string[] testMessageLines = File.ReadAllLines(currentTestMessagesFilePath);

                    foreach (string line in testMessageLines)
                    {
                        string[] parts = line.Split(':');

                        if (parts.Length == 2)
                        {
                            string testDataType = parts[0].Trim();
                            string testData = parts[1].Trim();

                            if (string.Equals(testDataType, dataType, StringComparison.OrdinalIgnoreCase))
                            {
                                // If the dataType matches, return the test message for this dataType
                                currentAircraftTestMessagesIndices[dataType] = (currentIndex + 1) % testMessagesFilePaths.Length;
                                return $"{testDataType}: {testData}";
                            }
                        }
                    }
                }
            }

            return $"{dataType} gözlemlenmeli."; // Return a default message if no matching message is found
        }

        private void ProcessReceivedData(string dataType, int receivedValue)
        {
            if (!aircraftNumberPerType.ContainsKey(dataType))
            {
                aircraftNumberPerType[dataType] = 1;
            }

            switch (dataType)
            {
                case "altitude":
                    altitude = receivedValue;
                    pictureBoxAltimeter.Invalidate();
                    DrawAltitudeValueLabel(pictureBoxAltimeter.CreateGraphics(), altitude);
                    break;
                case "speed":
                    speed = receivedValue;
                    AirSpeed.Invalidate();
                    DrawAirspeedIndicator(AirSpeed.CreateGraphics(), speed);
                    break;
                case "temperature":
                    temperature = receivedValue;
                    pictureBoxTemperature.Invalidate();
                    DrawTemperatureIndicator(pictureBoxTemperature.CreateGraphics(), temperature);
                    break;
                case "fuelLevel":
                    fuelLevel = receivedValue;
                    pictureBoxFuelLevel.Invalidate();
                    DrawFuelLevelIndicator(pictureBoxFuelLevel.CreateGraphics(), fuelLevel);
                    break;
                case "numberOfPassengers":
                    numberOfPassengers = receivedValue;
                    pictureBoxNumberPassengers.Invalidate();
                    break;
                case "headingValue":
                    headingValue = receivedValue;
                    pictureBoxHeading.Invalidate();
                    DrawHeadingGauge(pictureBoxHeading.CreateGraphics(), headingValue);
                    break;
                case "windInfo":
                    windInfo = receivedValue;
                    pictureBoxWindInfo.Invalidate();
                    DrawWindDirection(pictureBoxWindInfo.CreateGraphics(), windInfo);
                    break;
                case "pitchValue":
                    pitchValue = receivedValue;
                    attitudeSlipSkidControl.Invalidate();
                    DrawPitchIndicator(pictureBoxAttitudeSlipSkid.CreateGraphics(), pitchValue); // Update values in the control
                    break;
                case "rollValue":
                    rollValue = receivedValue;
                    attitudeSlipSkidControl.Invalidate();
                    DrawRollIndicator(pictureBoxAttitudeSlipSkid.CreateGraphics(), rollValue); // Update values in the control
                    break;
                case "slipSkidValue":
                    slipSkidValue = receivedValue;
                    attitudeSlipSkidControl.Invalidate();
                    DrawSlipSkidIndicator(pictureBoxAttitudeSlipSkid.CreateGraphics(), slipSkidValue); // Update values in the control
                    break;
                default:
                    Console.WriteLine("Unknown data type: " + dataType);
                    break;
            }

            // Get the test message from the TestMessages file
            string testMessage = GetTestMessageForAircraft(dataType);

            // Display the test message and get user confirmation
            string testMessageWithConfirmation = $"{testMessage}{Environment.NewLine}?";

            DialogResult result = MessageBox.Show(testMessageWithConfirmation, "Received Test Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string yesNo = (result == DialogResult.Yes) ? "Y" : "N";
            string logFileName = $"Aircraft {aircraftNumberPerType[dataType]}_ServerMessages.txt";
            WriteToLogFile(logFileName, $"{testMessage} {yesNo}");
            aircraftNumberPerType[dataType]++;
        }


        private void ProcessReceivedStringData(string dataType, string dataValue)
        {
            // aircraftNumberPerType sözlüğünü başlat
            if (!aircraftNumberPerType.ContainsKey(dataType))
            {
                aircraftNumberPerType[dataType] = 1;
            }

            switch (dataType)
            {
                case "flighRoute":
                    flightRoute = dataValue;
                    pictureBoxFlightRoute.Invalidate();
                    ShowFlightRouteLabel(pictureBoxFlightRoute.CreateGraphics(), flightRoute);
                    break;
                case "weather":
                    weather = dataValue;
                    pictureBoxWeather.Invalidate();
                    ShowWeatherLabel(pictureBoxWeather.CreateGraphics(), weather);
                    break;
                case "cabinStatus":
                    cabinStatus = dataValue;
                    pictureBoxCabinStatus.Invalidate();
                    ShowCabinStatusLabel(pictureBoxCabinStatus.CreateGraphics(), cabinStatus);
                    break;
                case "aircraftType":
                    aircraftType = dataValue;
                    pictureBoxAircraftType.Invalidate();
                    ShowAircraftTypeLabel(pictureBoxAircraftType.CreateGraphics(), aircraftType);
                    break;
                case "aircraftModel":
                    aircraftModel = dataValue;
                    pictureBoxAircraftModel.Invalidate();
                    ShowAircraftModelLabel(pictureBoxAircraftModel.CreateGraphics(), aircraftModel);
                    break;
                default:
                    Console.WriteLine("Unknown data type: " + dataType);
                    break;
            }
            // Get the test message from the TestMessages file
            string testMessage = GetTestMessageForAircraft(dataType);

            // Display the test message and get user confirmation
            string testMessageWithConfirmation = $"{testMessage}{Environment.NewLine}?";

            DialogResult result = MessageBox.Show(testMessageWithConfirmation, "Received Test Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string yesNo = (result == DialogResult.Yes) ? "Y" : "N";
            string logFileName = $"Aircraft {aircraftNumberPerType[dataType]}_ServerMessages.txt";
            WriteToLogFile(logFileName, $"{testMessage} {yesNo}");
            aircraftNumberPerType[dataType]++;
        }



        private void WriteToLogFile(string fileName, string message)
        {
            string logFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerMessages");
            Directory.CreateDirectory(logFolderPath);

            string logFilePath = Path.Combine(logFolderPath, fileName);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(message);
            }
        }


        private bool shouldStop = false;

        private void btnReceive_Click(object sender, EventArgs e)
        {
            IPAddress serverIpAddress = IPAddress.Any;
            int serverPortNum = 50000;
            UdpServer udpServer = new UdpServer(serverIpAddress, serverPortNum);

            shouldStop = false;

            while (!shouldStop)
            {
                byte[] receivedBytes = udpServer.ReceiveFromClient();

                string receivedDataText = Encoding.ASCII.GetString(receivedBytes).Trim();
                string[] dataParts = receivedDataText.Split(',');

                foreach (string dataPart in dataParts)
                {
                    string[] keyValue = dataPart.Split(':');
                    if (keyValue.Length == 2)
                    {
                        string dataType = keyValue[0].Trim();
                        string dataValue = keyValue[1].Trim();

                        if (!testMessagesQueues.ContainsKey(dataType))
                        {
                            testMessagesQueues[dataType] = new Queue<string>(); // Her veri türü için yeni bir kuyruk oluşturuluyor.
                        }

                        if (int.TryParse(dataValue, out int receivedIntValue))
                        {
                            ProcessReceivedData(dataType, receivedIntValue);
                        }
                        else
                        {
                            ProcessReceivedStringData(dataType, dataValue);
                        }

                        testMessagesQueues[dataType].Enqueue(dataValue); // Doğru veri türüne ait kuyruğa veri ekleniyor.
                    }
                    else
                    {
                        Console.WriteLine("Received data format is invalid.");
                    }
                }




                if (receivedDataText == "STOP_STREAMING")
                {
                    shouldStop = true;
                }
            }

            udpServer.Close();
        }


        private void DrawValueLabel(Graphics g, float value, string labelText, int x, int y)
        {
            int labelWidth = 140;
            int labelHeight = 20;

            // Create and draw the label
            string text = $"{labelText}: {value}";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);

            Rectangle labelRect = new Rectangle(x - labelWidth / 2, y - labelHeight / 2, labelWidth, labelHeight);
            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(text, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void AirSpeed_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawAirspeedIndicator(g, speed);
            DrawSpeedValueLabel(g, speed);
        }

        private void DrawAirspeedIndicator(Graphics g, float airspeed)
        {
            int centerX = AirSpeed.Width / 2;
            int centerY = AirSpeed.Height / 2;
            int indicatorLength = Math.Min(centerX, centerY) - 20; // İşaretçi uzunluğu // buraya çak
            int indicatorX = centerX;
            int indicatorY = centerY;

            // İşaretçi çizgisi ve işaretini çiz
            g.DrawLine(Pens.Black, indicatorX, indicatorY, indicatorX, indicatorY - indicatorLength -160);

            float scaleFactor = indicatorLength / 200.0f; // Ölçek faktörü // buranın üstüne %sel değer belirle 
            for (int i = 0; i < 500; i += 20)
            {
                int markY = indicatorY - (int)(i * scaleFactor);
                g.DrawLine(Pens.Black, indicatorX - 5, markY, indicatorX + 5, markY);
                string valueText = i.ToString();
                SizeF textSize = g.MeasureString(valueText, Font);
                g.DrawString(valueText, Font, Brushes.Black, indicatorX + 10, markY - textSize.Height / 2);
                g.DrawString("Kts", Font, Brushes.Black, indicatorX + 20 + textSize.Width, markY - textSize.Height / 2);
            }

            int triangleHeight = 10;
            int triangleWidth = 20;

            int airspeedIndicatorY = centerY - (int)(airspeed * scaleFactor);


            g.FillPolygon(Brushes.Red, new Point[]
            {
                new Point(indicatorX - triangleWidth / 2, airspeedIndicatorY),
                new Point(indicatorX + triangleWidth / 2, airspeedIndicatorY),
                new Point(indicatorX, airspeedIndicatorY - triangleHeight)
            });
        }

        private void DrawSpeedValueLabel(Graphics g, float speed)
        {
            int centerX = AirSpeed.Width / 2;
            int centerY = AirSpeed.Height / 2;

            // Calculate position for the label
            int labelX = centerX;
            int labelY = centerY + 20; // Adjust the position as needed

            DrawValueLabel(g, speed, "Speed", labelX, labelY);
        }

        private void DrawTemperatureIndicator(Graphics g, float temperature)
        {
            int centerX = pictureBoxTemperature.Width / 2;
            int centerY = pictureBoxTemperature.Height / 2;
            int frameWidth = 20;
            int frameHeight = 20;
            int innerWidth = pictureBoxTemperature.Width - frameWidth * 4;
            int innerHeight = pictureBoxTemperature.Height - frameHeight * 2;

            g.FillRectangle(Brushes.LightGray, frameWidth * 2, frameHeight, innerWidth - 40, innerHeight - 40);

            float scaleFactor = innerHeight / 100.0f;
            int temperatureIndicatorY = centerY - (int)(temperature * scaleFactor);

            // Çizginin sol tarafını başlangıç noktasına kaydırarak çizgiyi kısaltma
            int startX = frameWidth + (innerWidth - 40) / 2; // Sol kenar + iç kısım genişliğinin yarısı
            int endX = startX + 40; // Başlangıç noktasına 40 piksel ekleyerek çizgiyi kısalt

            // Daha ince bir kalem oluşturarak kırmızı çizgiyi çizin
            using (Pen thinRedPen = new Pen(Color.Red, 2))
            {
                g.DrawLine(thinRedPen, startX, temperatureIndicatorY, endX, temperatureIndicatorY);
            }
        }

        private void DrawTemperatureValueLabel(Graphics g, float temperature)
        {
            int centerX = pictureBoxTemperature.Width / 2;
            int centerY = pictureBoxTemperature.Height / 2;

            // Etiket için pozisyonu hesapla
            int labelX = centerX;
            int labelY = centerY + pictureBoxTemperature.Height / 4; // İstenilen pozisyona göre ayarlayın

            // Etiket boyutları
            int labelWidth = 140;
            int labelHeight = 20;

            // Etiket oluştur ve çiz
            string temperatureText = $"Temperature: {temperature} °C";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);

            Rectangle labelRect = new Rectangle(labelX - labelWidth / 2, labelY - labelHeight / 2, labelWidth, labelHeight);
            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(temperatureText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void pictureBoxTemperature_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawTemperatureIndicator(g, temperature);

            DrawTemperatureValueLabel(g, temperature);
        }

        private void DrawFuelLevelIndicator(Graphics g, float fuelLevel)
        {
            int centerX = pictureBoxFuelLevel.Width / 2;
            int centerY = pictureBoxFuelLevel.Height / 2;
            int frameWidth = 20;
            int frameHeight = 20;
            int innerWidth = pictureBoxFuelLevel.Width - frameWidth * 4;
            int innerHeight = pictureBoxFuelLevel.Height - frameHeight * 2;

            // Değer sınırlama
            fuelLevel = Math.Min(fuelLevel, 30000);

            // Çerçeve çizimi
            g.DrawRectangle(Pens.Black, frameWidth, frameHeight, innerWidth, innerHeight);

            // İç kısmı temsil eden dikdörtgenin çizimi
            float filledHeight = innerHeight * fuelLevel / 30000;

            // Taşma kontrolü
            if (filledHeight > innerHeight)
            {
                filledHeight = innerHeight;
            }

            g.FillRectangle(Brushes.LightGreen, frameWidth, frameHeight + innerHeight - filledHeight, innerWidth, filledHeight);

            // Fuel Level değerini çiz
            string fuelLevelText = $"{fuelLevel}%";
            Font textFont = new Font("Arial", 11, FontStyle.Bold);
            SizeF textSize = g.MeasureString(fuelLevelText, textFont);

            float textX = centerX - textSize.Width / 2;
            float textY = centerY + innerHeight / 2 + frameHeight;

            g.DrawString(fuelLevelText, textFont, Brushes.Black, textX, textY);
        }

        private void DrawFuelLevelValueLabel(Graphics g, float fuelLevel)
        {
            int centerX = pictureBoxFuelLevel.Width / 2;
            int centerY = pictureBoxFuelLevel.Height / 2;

            // Etiket için pozisyonu hesapla
            int labelX = centerX;
            int labelY = (centerY + pictureBoxFuelLevel.Height / 2) - 10; // İstenilen pozisyona göre ayarlayın

            // Etiket boyutları
            int labelWidth = 140;
            int labelHeight = 15;

            // Etiket oluştur ve çiz
            string fuelLevelText = $"Fuel Level: {fuelLevel} ";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);

            Rectangle labelRect = new Rectangle(labelX - labelWidth / 2, labelY - labelHeight / 2, labelWidth, labelHeight);
            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(fuelLevelText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void pictureBoxFuelLevel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawFuelLevelIndicator(g, fuelLevel);
            DrawFuelLevelValueLabel(g, fuelLevel);
        }

        private void ShowNumberOfPassengers(Graphics g, float numberOfPassengers)
        {
            Label numberOfPassengersLabel = new Label
            {
                Text = $"Number of Passengers: {numberOfPassengers}",
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true
            };

            int labelX = 10; // Örnek olarak 20 piksel içeriden başlayacak şekilde ayarlandı
            int labelY = pictureBoxNumberPassengers.Height - 20; // Örnek olarak en altta 40 piksel içeriden başlayacak şekilde ayarlandı

            numberOfPassengersLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxNumberPassengers.Width, pictureBoxNumberPassengers.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(numberOfPassengersLabel.Text, numberOfPassengersLabel.Font, new SolidBrush(numberOfPassengersLabel.ForeColor),
                        numberOfPassengersLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxNumberPassengers_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowNumberOfPassengers(g, numberOfPassengers);
        }

        private void DrawHeadingGauge(Graphics g, float headingValue)
        {
            int centerX = pictureBoxHeading.Width / 2;
            int centerY = pictureBoxHeading.Height / 2;
            int radius = Math.Min(centerX, centerY) - 100;

            // Çizelge dairesi
            g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

            // Yön ve dereceleri çiz
            Font textFont = new Font("Arial", 8, FontStyle.Regular);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            for (int degree = 0; degree <= 360; degree += 45)
            {
                float angle = -90 + degree;
                int textX = (int)(centerX + (radius + 20) * Math.Cos(angle * Math.PI / 180));
                int textY = (int)(centerY + (radius + 20) * Math.Sin(angle * Math.PI / 180));

                if (degree == 0) g.DrawString("N", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 45) g.DrawString("NE", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 90) g.DrawString("E", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 135) g.DrawString("SE", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 180) g.DrawString("S", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 225) g.DrawString("SW", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 270) g.DrawString("W", textFont, Brushes.Black, textX, textY, format);
                else if (degree == 315) g.DrawString("NW", textFont, Brushes.Black, textX, textY, format);

                g.DrawString(degree.ToString(), textFont, Brushes.Black, textX, textY + 15, format);
            }

            // İbre
            float indicatorAngle = -90 + headingValue;
            float indicatorLength = radius * 0.8f;
            int indicatorX = (int)(centerX + indicatorLength * Math.Cos(indicatorAngle * Math.PI / 180));
            int indicatorY = (int)(centerY + indicatorLength * Math.Sin(indicatorAngle * Math.PI / 180));
            g.DrawLine(Pens.Red, centerX, centerY, indicatorX, indicatorY);

            // Heading label oluştur
            int labelX = centerX;
            int labelY = centerY + radius + 60; // Altındaki label için ayar yapabilirsiniz
            DrawValueLabel(g, headingValue, "Heading", labelX, labelY);
        }

        private void pictureBoxHeading_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawHeadingGauge(g, headingValue);
        }


        private void DrawWindDirection(Graphics g, float windInfo)
        {
            int centerX = pictureBoxWindInfo.Width / 2;
            int centerY = pictureBoxWindInfo.Height / 2;
            int radius = Math.Min(centerX, centerY) - 30;

            // Çizelge dairesi
            g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

            // Rüzgar yönünü gösteren ok
            float angle = -90 + windInfo; // Dereceden açıyı hesapla
            int arrowLength = radius * 3 / 4; // Ok uzunluğu

            int arrowX = centerX + (int)(arrowLength * Math.Cos(angle * Math.PI / 180));
            int arrowY = centerY + (int)(arrowLength * Math.Sin(angle * Math.PI / 180));

            g.DrawLine(Pens.Blue, centerX, centerY, arrowX, arrowY);

            // Ok ucuna küçük üçgen şeklinde ok çiz
            int triangleSize = 8; // Üçgen boyutu
            Point[] trianglePoints = new Point[3];
            trianglePoints[0] = new Point(arrowX, arrowY);
            trianglePoints[1] = new Point(arrowX - triangleSize / 2, arrowY + triangleSize);
            trianglePoints[2] = new Point(arrowX + triangleSize / 2, arrowY + triangleSize);
            g.FillPolygon(Brushes.Blue, trianglePoints);

            // Rüzgar yönü metni
            string directionText = GetDirectionFromDegree(windInfo);
            Font textFont = new Font("Arial", 10, FontStyle.Regular);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(directionText, textFont, Brushes.Black, centerX, centerY + radius + 15, format);

            // Wind Direction label
            int labelX = centerX ;
            int labelY = centerY + radius + 13; // Okun altına biraz mesafe bırakmak için
            DrawValueLabel(g, windInfo, "Wind Direction", labelX, labelY);
        }

        private string GetDirectionFromDegree(float windDegree)
        {
            if (windDegree >= 337.5 || windDegree < 22.5) return "N";
            if (windDegree >= 22.5 && windDegree < 67.5) return "NE";
            if (windDegree >= 67.5 && windDegree < 112.5) return "E";
            if (windDegree >= 112.5 && windDegree < 157.5) return "SE";
            if (windDegree >= 157.5 && windDegree < 202.5) return "S";
            if (windDegree >= 202.5 && windDegree < 247.5) return "SW";
            if (windDegree >= 247.5 && windDegree < 292.5) return "W";
            if (windDegree >= 292.5 && windDegree < 337.5) return "NW";

            return "";
        }

        private void pictureBoxWindInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawWindDirection(g, windInfo);
        }

        private void ShowFlightRouteLabel(Graphics g, string flightRoute)
        {
            Label flightRouteLabel = new Label();
            flightRouteLabel.Text = "Flight Route: " + flightRoute;
            flightRouteLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            flightRouteLabel.ForeColor = Color.Black;
            flightRouteLabel.AutoSize = true;

            int labelX = 10; 
            int labelY = pictureBoxFlightRoute.Height - 20;

            flightRouteLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxFlightRoute.Width, pictureBoxFlightRoute.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(flightRouteLabel.Text, flightRouteLabel.Font, new SolidBrush(flightRouteLabel.ForeColor),
                        flightRouteLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxFlightRoute_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowFlightRouteLabel(g, flightRoute);
        }

        private void ShowWeatherLabel(Graphics g, string weather)
        {
            Label weatherLabel = new Label();
            weatherLabel.Text = "Weather: " + weather;
            weatherLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            weatherLabel.ForeColor = Color.Black;
            weatherLabel.AutoSize = true;

            int labelX = 10; 
            int labelY = pictureBoxWeather.Height - 20;

            weatherLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxWeather.Width, pictureBoxWeather.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(weatherLabel.Text, weatherLabel.Font, new SolidBrush(weatherLabel.ForeColor),
                        weatherLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxWeather_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowWeatherLabel(g, weather);
        }

        private void ShowCabinStatusLabel(Graphics g, string cabinStatus)
        {
            Label cabinStatusLabel = new Label();
            cabinStatusLabel.Text = "Cabin Status: " + cabinStatus;
            cabinStatusLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            cabinStatusLabel.ForeColor = Color.Black;
            cabinStatusLabel.AutoSize = true;

            // İstenilen konuma ayarlayın
            int labelX = 10; // Örnek olarak 20 piksel içeriden başlayacak şekilde ayarlandı
            int labelY = pictureBoxCabinStatus.Height - 20; // Örnek olarak en altta 20 piksel içeriden başlayacak şekilde ayarlandı

            cabinStatusLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxCabinStatus.Width, pictureBoxCabinStatus.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(cabinStatusLabel.Text, cabinStatusLabel.Font, new SolidBrush(cabinStatusLabel.ForeColor),
                        cabinStatusLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxCabinStatus_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowCabinStatusLabel(g, cabinStatus);
        }

        private void ShowAircraftTypeLabel(Graphics g, string aircraftType)
        {
            Label aircraftTypeLabel = new Label();
            aircraftTypeLabel.Text = "Aircraft Type: " + aircraftType;
            aircraftTypeLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            aircraftTypeLabel.ForeColor = Color.Black;
            aircraftTypeLabel.AutoSize = true;

            // İstenilen konuma ayarlayın
            int labelX = 10; // Örnek olarak 20 piksel içeriden başlayacak şekilde ayarlandı
            int labelY = pictureBoxAircraftType.Height - 20; // Örnek olarak en altta 20 piksel içeriden başlayacak şekilde ayarlandı

            aircraftTypeLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxAircraftType.Width, pictureBoxAircraftType.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(aircraftTypeLabel.Text, aircraftTypeLabel.Font, new SolidBrush(aircraftTypeLabel.ForeColor),
                        aircraftTypeLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxAircraftType_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowAircraftTypeLabel(g, aircraftType);
        }

        private void ShowAircraftModelLabel(Graphics g, string aircraftModel)
        {
            Label aircraftModelLabel = new Label();
            aircraftModelLabel.Text = "Aircraft Model: " + aircraftModel;
            aircraftModelLabel.Font = new Font("Arial", 11, FontStyle.Bold);
            aircraftModelLabel.ForeColor = Color.Black;
            aircraftModelLabel.AutoSize = true;

            // İstenilen konuma ayarlayın
            int labelX = 10; // Örnek olarak 20 piksel içeriden başlayacak şekilde ayarlandı
            int labelY = pictureBoxAircraftModel.Height - 20; // Örnek olarak en altta 20 piksel içeriden başlayacak şekilde ayarlandı

            aircraftModelLabel.Location = new Point(labelX, labelY);

            using (Bitmap bmp = new Bitmap(pictureBoxAircraftModel.Width, pictureBoxAircraftModel.Height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    bmpGraphics.Clear(Color.LightGray);

                    bmpGraphics.DrawString(aircraftModelLabel.Text, aircraftModelLabel.Font, new SolidBrush(aircraftModelLabel.ForeColor),
                        aircraftModelLabel.Location);

                    g.DrawImage(bmp, Point.Empty);
                }
            }
        }

        private void pictureBoxAircraftModel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ShowAircraftModelLabel(g, aircraftModel);
        }

        private void DrawPitchIndicator(Graphics g, float pitch)
        {
            int centerX = pictureBoxAttitudeSlipSkid.Width / 2;
            int centerY = pictureBoxAttitudeSlipSkid.Height / 2;
            int horizonWidth = pictureBoxAttitudeSlipSkid.Width;
            int horizonHeight = pictureBoxAttitudeSlipSkid.Height / 2;

            // Draw the attitude indicator background (horizon line)
            g.FillRectangle(Brushes.LightBlue, 0, centerY - horizonHeight, horizonWidth, 2 * horizonHeight);

            // Draw the pitch lines (reference lines)
            for (int i = -90; i <= 90; i += 10)
            {
                int pitchY = centerY + i * horizonHeight / 90;
                g.DrawLine(Pens.Black, centerX - 10, pitchY, centerX + 10, pitchY);
            }

            // Draw the pitch indicator line
            int pitchIndicatorY = centerY - (int)(pitch * horizonHeight / 90);
            g.DrawLine(Pens.Red, centerX - 20, pitchIndicatorY, centerX + 20, pitchIndicatorY);

            // Create and draw the label
            string pitchText = $"Pitch: {pitchValue:F1}°";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);
            SizeF textSize = g.MeasureString(pitchText, labelFont);

            int labelX = centerX - 160;
            int labelY = pitchIndicatorY - (int)(textSize.Height / 2);
            Rectangle labelRect = new Rectangle(labelX, labelY, (int)textSize.Width, (int)textSize.Height);

            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(pitchText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }


        private void DrawRollIndicator(Graphics g, float roll)
        {
            int centerX = pictureBoxAttitudeSlipSkid.Width / 2;
            int centerY = pictureBoxAttitudeSlipSkid.Height / 2;
            int symbolWidth = 20;
            int symbolHeight = 40;

            // Draw the aircraft symbol (simple rectangle)
            int symbolX = centerX - symbolWidth / 2;
            int symbolY = centerY - symbolHeight / 2;
            g.FillRectangle(Brushes.White, symbolX, symbolY, symbolWidth, symbolHeight);

            // Rotate the aircraft symbol based on the roll angle
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(roll); // Use the roll parameter
            g.FillRectangle(Brushes.White, -symbolWidth / 2, -symbolHeight / 2, symbolWidth, symbolHeight);
            g.ResetTransform();

            // Draw the pitch lines (reference lines)
            int horizonHeight = pictureBoxAttitudeSlipSkid.Height / 2;
            for (int i = -90; i <= 90; i += 10)
            {
                int pitchY = centerY + i * horizonHeight / 90;
                g.DrawLine(Pens.Black, centerX - 10, pitchY, centerX + 10, pitchY);
            }

            // Draw the pitch indicator line using class-level pitchY
            int pitchIndicatorY = centerY - (int)(pitchValue * horizonHeight / 90);
            g.DrawLine(Pens.Red, centerX - 20, pitchIndicatorY, centerX + 20, pitchIndicatorY);

            // Draw numerical pitch and roll values
            string pitchText = $"Pitch: {pitchValue:F1}°";
            string rollText = $"Roll: {rollValue:F1}°";
            Font font = new Font("Arial", 10, FontStyle.Bold);
            Brush textBrush = Brushes.White;
            int textX = centerX + symbolWidth / 2 + 10;
            int textY = centerY - symbolHeight / 2;
            g.DrawString(pitchText, font, textBrush, textX, textY);
            g.DrawString(rollText, font, textBrush, textX, textY + 20);

            // Create and draw the label for roll
            string rollLabelText = $"Roll: {rollValue:F1}°";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);
            SizeF labelSize = g.MeasureString(rollLabelText, labelFont);

            int labelX = centerX + symbolWidth / 2 - 160;
            int labelY = textY + 40; // Adjust the position as needed
            Rectangle labelRect = new Rectangle(labelX, labelY, (int)labelSize.Width, (int)labelSize.Height);

            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(rollLabelText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void DrawSlipSkidIndicator(Graphics g, float slipSkidValue)
        {
            int centerX = pictureBoxAttitudeSlipSkid.Width / 2;
            int centerY = pictureBoxAttitudeSlipSkid.Height / 2;
            int ballSize = 20;

            // Draw the pitch lines (reference lines)
            int horizonHeight = pictureBoxAttitudeSlipSkid.Height / 2;
            for (int i = -90; i <= 90; i += 10)
            {
                int pitchY = centerY + i * horizonHeight / 90;
                g.DrawLine(Pens.Black, centerX - 10, pitchY, centerX + 10, pitchY);
            }

            // Calculate the position of the slip/skid indicator ball
            int ballX = centerX + (int)(slipSkidValue * 50);
            int ballY = centerY + 100; // Adjust the vertical position of the ball

            // Draw the slip/skid ball
            g.FillEllipse(Brushes.Blue, ballX - ballSize / 2, ballY - ballSize / 2, ballSize, ballSize);

            // Draw a reference line for the slip/skid indicator
            g.DrawLine(Pens.Red, centerX, centerY, ballX, ballY);

            // Create and draw the label for slip/skid
            string slipSkidLabelText = $"Slip/Skid: {slipSkidValue:F1}";
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);
            SizeF labelSize = g.MeasureString(slipSkidLabelText, labelFont);

            int labelX = centerX + ballSize / 2 + 10; // Adjust the horizontal position as needed
            int labelY = ballY + ballSize / 2; // Adjust the vertical position as needed
            Rectangle labelRect = new Rectangle(labelX, labelY, (int)labelSize.Width + 10, (int)labelSize.Height);

            g.FillRectangle(Brushes.White, labelRect);
            g.DrawRectangle(Pens.Black, labelRect);
            g.DrawString(slipSkidLabelText, labelFont, Brushes.Black, labelRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }



        private void pictureBoxAttitudeSlipSkid_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawSlipSkidIndicator(g, slipSkidValue);
            DrawPitchIndicator(g, pitchValue);
            DrawRollIndicator(g, rollValue);
        }


        private bool isRadioOn = false;
        private int currentFrequency = 100;
        private bool dataStreamingActive = false;

        private void trackBarFrequency_Scroll(object sender, EventArgs e)
        {
            currentFrequency = trackBarFrequency.Value;
        }

        private void BtnToggleRadio_Click(object sender, EventArgs e)
        {
            if (isRadioOn)
            {
                // Radyo kapatılıyor
                isRadioOn = false;
                StopDataStreaming();
                BtnToggleRadio.Text = "ON";
            }
            else
            {
                // Radyo açılıyor
                isRadioOn = true;
                StartDataStreaming();
                BtnToggleRadio.Text = "OFF"; 
            }
        }

        private void StartDataStreaming()
        {
            dataStreamingActive = true;
            StartDataReceiver();

            UpdateFrequencyLabel();
        }

        private void StopDataStreaming()
        {
            dataStreamingActive = false;
            StopDataReceiver();

            ClearFrequencyLabel();
        }

        private void StartDataReceiver()
        {

        }
        private void StopDataReceiver()
        {

        }

        private void UpdateFrequencyLabel()
        {
            frequencyLabel.Text = "Frequency: " + currentFrequency.ToString("F2") + " MHz";
        }

        private void ClearFrequencyLabel()
        {
            frequencyLabel.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBarFrequency.Minimum = 50;
            trackBarFrequency.Maximum = 200;
            trackBarFrequency.Value = (int)currentFrequency;

            ClearFrequencyLabel();

            if (isRadioOn)
            {
                StartDataStreaming();
                UpdateFrequencyLabel();
            }
        }

        private void trackBarFrequency_ValueChanged(object sender, EventArgs e)
        {
            currentFrequency = trackBarFrequency.Value;

            UpdateFrequencyLabel();
        }

    }

    class UdpServer
    {
        private const int BufferSize = 2048;
        private readonly Socket serverSocket;

        public UdpServer(IPAddress serverIpAddress, int serverPortNum)
        {
            serverSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(serverIpAddress, serverPortNum);
            serverSocket.Bind(serverEndPoint);
        }

        public byte[] ReceiveFromClient()
        {
            byte[] receivedBytes = new byte[BufferSize];
            EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            int bytesRead = 0;
            try
            {
                bytesRead = serverSocket.ReceiveFrom(receivedBytes, ref clientEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Create a new byte array with the exact size of the received data
            byte[] trimmedBytes = new byte[bytesRead];
            Array.Copy(receivedBytes, trimmedBytes, bytesRead);

            return trimmedBytes;
        }

        public void Close()
        {
            serverSocket.Close();
        }
    }
}
