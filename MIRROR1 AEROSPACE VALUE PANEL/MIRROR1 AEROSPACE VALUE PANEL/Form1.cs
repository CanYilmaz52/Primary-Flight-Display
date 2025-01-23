using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MIRROR1_AEROSPACE_VALUE_PANEL
{
    public partial class Form1 : Form
    {

        private Dictionary<string, string> valuesDictionary = new Dictionary<string, string>();

        private Dictionary<string, List<string>> aircraftTypeToModels = new Dictionary<string, List<string>>
        {
            { "Boeing 737", new List<string> { "737-700", "737-800", "737-900" } },
            { "Airbus A320", new List<string> { "A320neo", "A321neo", "A318" } },
            { "Boeing 787 Dreamliner", new List<string> { "787-8", "787-9", "787-10" } },
            { "Cessna 172", new List<string> { "Cessna 172 Skyhawk" } },
            { "Embraer E-Jet", new List<string> { "E170", "E175", "E190", "E195" } },
            { "Bombardier CRJ", new List<string> { "CRJ200", "CRJ700", "CRJ900", "CRJ1000" } },
        };

        private List<string> cabinStatusOptions = new List<string>
        {
        "Half Full",
        "Empty",
        "Boarding",
        "Deboarding",
        "Cleaning",
        "Emergency",
        "Maintenance",
        "In-Flight",
        "Closed",
        "Overcrowded"
        };

        private List<string> weatherOptions = new List<string>
        {
        "Sunny",
        "Partly Cloudy",
        "Cloudy",
        "Rainy",
        "Snowy",
        "Sleet",
        "Stormy",
        "Hail",
        "Windy"
        };

        public Form1()
        {
            InitializeComponent();

            txtBoxAltitude.Text = "0";
            txtBoxTemperature.Text = "0";
            txtBoxFuelLevel.Text = "0";
            txtBoxSpeed.Text = "0";
            txtNumberPassengers.Text = "0";
            txtBoxHeading.Text = "0";
            txtBoxPitch.Text = "0";
            txtBoxRoll.Text = "0";
            txtBoxSlipSkidValue.Text = "0";

            txtBoxWindInfo.Text = "14 knots from west";  
            txtFlightRoute.Text = "NYC to LAX";   


            txtBoxHeadingExp.Text = "Expressed in degrees relative to North. 0 to 360";
            txtBoxWindExp.Text = "Exp: The wind is blowing at 14 knots coming from the west";
            txtBoxFlightRouteExp.Text = "This example contains: New York to Los Angeles.";


            txtBoxHeadingExp.Enabled = false;
            txtBoxWindExp.Enabled = false;
            txtBoxFlightRouteExp.Enabled = false;

            comboBoxAircraftType.Items.AddRange(aircraftTypeToModels.Keys.ToArray());
            comboBoxAircraftType.SelectedIndexChanged += comboBoxAircraftType_SelectedIndexChanged;
            comboBoxAircraftModel.DropDownStyle = ComboBoxStyle.DropDownList; 

            comboBoxCabinStatus.Items.AddRange(cabinStatusOptions.ToArray());
            comboBoxWeather.Items.AddRange(weatherOptions.ToArray());

            Random random = new Random();
            int randomIndex = random.Next(comboBoxCabinStatus.Items.Count);
            int randomIndex2 = random.Next(comboBoxWeather.Items.Count);
            int randomIndex3 = random.Next(comboBoxAircraftType.Items.Count);   
            comboBoxAircraftType.SelectedIndex = randomIndex3;
            comboBoxWeather.SelectedIndex = randomIndex2;
            comboBoxCabinStatus.SelectedIndex = randomIndex;

        }

        private void txtBoxTemperature_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxAltitude_TextChanged(object sender, EventArgs e)
        {
            UpdateAltitudeValueRangeMessage();

            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxFuelLevel_TextChanged(object sender, EventArgs e)
        {
            UpdateFuelLevelValueRangeMessage();
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxSpeed_TextChanged(object sender, EventArgs e)
        {
            UpdateSpeedValueRangeMessage();

            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxHeading_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxWindInfo_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }



        private void txtFlightRoute_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtNumberPassengers_TextChanged(object sender, EventArgs e)
        {
            UpdateNumberPassengersValueRangeMessage();
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }

        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            bool hasInvalidInput = false;
            StringBuilder missingFields = new StringBuilder();

            foreach (var textBox in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    hasInvalidInput = true;
                    missingFields.AppendLine($"- {textBox.Name}");
                }
                else
                {
                    textBox.ForeColor = Color.Black;
                }
            }

            if (hasInvalidInput)
            {
                MessageBox.Show($"Please fill in the blanks below:\n\n{missingFields}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int fileCount = 1;
            string basePath = @"C:\Users\cangu\OneDrive\Masaüstü\VALUES\";
            string fileName = $"Aircraft_Information{fileCount}.txt";
            string filePath = Path.Combine(basePath, fileName);

            while (File.Exists(filePath))
            {
                fileCount++;
                fileName = $"Aircraft_Information{fileCount}.txt";
                filePath = Path.Combine(basePath, fileName);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in valuesDictionary)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }

            MessageBox.Show("Information saved to file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxCabinStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedText = comboBox.SelectedItem.ToString();
                valuesDictionary[comboBox.Name] = selectedText;
            }
        }

        private void comboBoxWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedText = comboBox.SelectedItem.ToString();
                valuesDictionary[comboBox.Name] = selectedText;
            }
        }

        private void comboBoxAircraftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAltitudeValueRangeMessage();
            UpdateTempValueRangeMessage();
            UpdateFuelLevelValueRangeMessage();
            UpdateSpeedValueRangeMessage();
            UpdateNumberPassengersValueRangeMessage();

            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (aircraftTypeToModels.ContainsKey(selectedAircraftType))
                {
                    List<string> correspondingModels = aircraftTypeToModels[selectedAircraftType];

                    comboBoxAircraftModel.Items.Clear();
                    comboBoxAircraftModel.Items.AddRange(correspondingModels.ToArray());

                    if (correspondingModels.Count > 0)
                    {
                        comboBoxAircraftModel.SelectedIndex = 0;
                    }

                    // Set the selected values in the dictionary when the type is changed
                    valuesDictionary["comboBoxAircraftType"] = selectedAircraftType;
                    valuesDictionary["comboBoxAircraftModel"] = correspondingModels[0];
                }

            }
        }

        private void btnIncreaseTemp_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxTemperature.Text, out int temperature))
            {
                temperature++;
                txtBoxTemperature.Text = temperature.ToString();
            }
            else
            {
                MessageBox.Show("Invalid temperature value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseTemp_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxTemperature.Text, out int temperature))
            {
                temperature--;
                txtBoxTemperature.Text = temperature.ToString();
            }
            else
            {
                MessageBox.Show("Invalid temperature value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonIncreaseAltitude_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxAltitude.Text, out int altitude))
            {
                altitude++;
                txtBoxAltitude.Text = altitude.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Altitude value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseAltitude_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxAltitude.Text, out int altitude))
            {
                altitude--;
                txtBoxAltitude.Text = altitude.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Altitude value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseFuelLevel_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtBoxFuelLevel.Text, out int fuelLevel))
            {
                fuelLevel++;
                txtBoxFuelLevel.Text = fuelLevel.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Fuel Level value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseFuelLevel_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxFuelLevel.Text, out int fuelLevel))
            {
                fuelLevel--;
                txtBoxFuelLevel.Text = fuelLevel.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Fuel Level value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseSpeed_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxSpeed.Text, out int speed))
            {
                speed++;
                txtBoxSpeed.Text = speed.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Speed value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseSpeed_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxSpeed.Text, out int speed))
            {
                speed--;
                txtBoxSpeed.Text = speed.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Speed value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseNumberPassengers_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumberPassengers.Text, out int passengers))
            {
                passengers++;
                txtNumberPassengers.Text = passengers.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Speed value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseNumberPassengers_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumberPassengers.Text, out int passengers))
            {
                passengers--;
                txtNumberPassengers.Text = passengers.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Speed value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseHeading_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtBoxHeading.Text, out int heading))
            {
                heading++;
                txtBoxHeading.Text = heading.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Heading value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseHeading_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxHeading.Text, out int heading))
            {
                heading--;
                txtBoxHeading.Text = heading.ToString();
            }
            else
            {
                MessageBox.Show("Inavlid Heading value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxTempValueRange_TextChanged(object sender, EventArgs e)
        {
            UpdateTempValueRangeMessage();
            txtBoxTempValueRange.Enabled = false;
        }

        private void UpdateTempValueRangeMessage()
        {
            ComboBox comboBox = comboBoxAircraftType; 
            if (comboBox.SelectedItem != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (selectedAircraftType == "Airbus A320")
                {
                    txtBoxTempValueRange.Text = "Please enter between -40°C to 52°C";
                }
                else if (selectedAircraftType == "Boeing 737")
                {
                    txtBoxTempValueRange.Text = "Please enter between -40°C to 50°C";
                }
                else if (selectedAircraftType == "Boeing 787 Dreamliner")
                {
                    txtBoxTempValueRange.Text = "Please enter between -55°C to 51°C";
                }
                else if (selectedAircraftType == "Embraer E-Jet")
                {
                    txtBoxTempValueRange.Text = "Please enter between -55°C to 50°C";
                }
                else if (selectedAircraftType == "Bombardier CRJ")
                {
                    txtBoxTempValueRange.Text = "Please enter between -54°C to 49°C";
                }
                else if (selectedAircraftType == "Cessna 172")
                {
                    txtBoxTempValueRange.Text = "Please enter between -40°C to 52°C";
                }
                else
                {
                    txtBoxTempValueRange.Text = ""; 
                }
            }
            else
            {
                txtBoxTempValueRange.Text = ""; 
            }
        }


        private void UpdateAltitudeValueRangeMessage()
        {
            ComboBox comboBox = comboBoxAircraftType;
            if (comboBox.SelectedItem != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (selectedAircraftType == "Airbus A320")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 30,000 feet to 40,000 feet";
                }
                else if (selectedAircraftType == "Boeing 737")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 30,000 feet to 40,000 feet";
                }
                else if (selectedAircraftType == "Boeing 787 Dreamliner")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 30,000 feet to 40,000 feet";
                }
                else if (selectedAircraftType == "Embraer E-Jet")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 30,000 feet to 40,000 feet";
                }
                else if (selectedAircraftType == "Bombardier CRJ")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 30,000 feet to 40,000 feet";
                }
                else if (selectedAircraftType == "Cessna 172")
                {
                    txtBoxAltitudeValueRange.Text = "Please enter between 5,000 feet to 15,000 feet";
                }
                else
                {
                    txtBoxAltitudeValueRange.Text = "";
                }
            }
            else
            {
                txtBoxAltitudeValueRange.Text = "";
            }
        }

        private void txtBoxAltitudeValueRange_TextChanged(object sender, EventArgs e)
        {
            UpdateAltitudeValueRangeMessage();
            txtBoxAltitudeValueRange.Enabled = false;
        }


        private void UpdateFuelLevelValueRangeMessage()
        {
            ComboBox comboBox = comboBoxAircraftType;
            if (comboBox.SelectedItem != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (selectedAircraftType == "Airbus A320")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 23,860 kg";
                }
                else if (selectedAircraftType == "Boeing 737")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 20,000 kg";
                }
                else if (selectedAircraftType == "Boeing 787 Dreamliner")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 126,000 kg";
                }
                else if (selectedAircraftType == "Embraer E-Jet")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 10,400 kg";
                }
                else if (selectedAircraftType == "Bombardier CRJ")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 4,600 kg";
                }
                else if (selectedAircraftType == "Cessna 172")
                {
                    txtBoxFuelLevelValueRange.Text = "Maximum fuel level: 150 lt";
                }
                else
                {
                    txtBoxFuelLevelValueRange.Text = "";
                }
            }
            else
            {
                txtBoxFuelLevelValueRange.Text = "";
            }
        }


        private void txtBoxFuelLevelValueRange_TextChanged(object sender, EventArgs e)
        {
            UpdateFuelLevelValueRangeMessage();
            txtBoxFuelLevelValueRange.Enabled = false;
        }

        private void UpdateSpeedValueRangeMessage()
        {
            ComboBox comboBox = comboBoxAircraftType;
            if (comboBox.SelectedItem != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (selectedAircraftType == "Airbus A320")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 530 knots";
                }
                else if (selectedAircraftType == "Boeing 737")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 544 knots";
                }
                else if (selectedAircraftType == "Boeing 787 Dreamliner")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 567 knots";
                }
                else if (selectedAircraftType == "Embraer E-Jet")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 488 knots";
                }
                else if (selectedAircraftType == "Bombardier CRJ")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 461 knots";
                }
                else if (selectedAircraftType == "Cessna 172")
                {
                    txtBoxSpeedValueRange.Text = "Maximum speed: 122 knots";
                }
                else
                {
                    txtBoxSpeedValueRange.Text = "";
                }
            }
            else
            {
                txtBoxSpeedValueRange.Text = "";
            }
        }

        private void txtBoxSpeedValueRange_TextChanged(object sender, EventArgs e)
        {
            UpdateSpeedValueRangeMessage();
            txtBoxSpeedValueRange.Enabled = false;
        }

        private void UpdateNumberPassengersValueRangeMessage()
        {
            ComboBox comboBox = comboBoxAircraftType;
            if (comboBox.SelectedItem != null)
            {
                string selectedAircraftType = comboBox.SelectedItem.ToString();

                if (selectedAircraftType == "Airbus A320")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 240 person";
                }
                else if (selectedAircraftType == "Boeing 737")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 230 person";
                }
                else if (selectedAircraftType == "Boeing 787 Dreamliner")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 330 person";
                }
                else if (selectedAircraftType == "Embraer E-Jet")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 130 person";
                }
                else if (selectedAircraftType == "Bombardier CRJ")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 104 person";
                }
                else if (selectedAircraftType == "Cessna 172")
                {
                    txtBoxNumberPassengersValueRange.Text = "Maximum passenger: 4 person";
                }
                else
                {
                    txtBoxNumberPassengersValueRange.Text = "";
                }
            }
            else
            {
                txtBoxNumberPassengersValueRange.Text = "";
            }
        }

        private void txtBoxNumberPassengersValueRange_TextChanged(object sender, EventArgs e)
        {
            UpdateNumberPassengersValueRangeMessage();
            txtBoxNumberPassengersValueRange.Enabled = false;
        }

        private void txtBoxSlipSkidValue_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxRoll_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txtBoxPitch_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                valuesDictionary[textBox.Name] = textBox.Text;
                textBox.ForeColor = Color.Black;
            }
        }
    }
}
