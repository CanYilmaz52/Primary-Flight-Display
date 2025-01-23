using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace denemeClient
{
    public partial class Form1 : Form
    {

        private readonly List<DataProcessor> dataProcessors = new List<DataProcessor>();


        public Form1()
        {
            InitializeComponent();
            InitializeDataProcessors();
            InitializeTreeViewContextMenu();
        }

        private void InitializeTreeViewContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            // Sağ tıklama menüsüne bir öğe ekleyin
            ToolStripMenuItem rxEkleMenuItem = new ToolStripMenuItem("Add Test Node");
            rxEkleMenuItem.Click += rxEkleToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(rxEkleMenuItem);

            // TreeView kontrolünün ContextMenuStrip özelliğine atayın
            treeView.ContextMenuStrip = contextMenuStrip;
        }


        private void InitializeDataProcessors()
        {
            dataProcessors.Add(new DataProcessor("altitude", checkBoxAltitude, "txtBoxAltitude"));
            dataProcessors.Add(new DataProcessor("speed", checkBoxSpeed, "txtBoxSpeed"));
            dataProcessors.Add(new DataProcessor("temperature", checkBoxTemperature, "txtBoxTemperature"));
            dataProcessors.Add(new DataProcessor("fuelLevel", checkBoxFuelLevel, "txtBoxFuelLevel"));
            dataProcessors.Add(new DataProcessor("numberOfPassengers", checkBoxNumberOfPassengers, "txtNumberPassengers"));
            dataProcessors.Add(new DataProcessor("headingValue", checkBoxHeading, "txtBoxHeading"));
            dataProcessors.Add(new DataProcessor("windInfo", checkBoxWindInfo, "txtBoxWindInfo"));
            dataProcessors.Add(new DataProcessor("flightRoute", checkBoxFlightRoute, "txtFlightRoute"));
            dataProcessors.Add(new DataProcessor("aircraftType", checkBoxAircraftType, "comboBoxAircraftType"));
            dataProcessors.Add(new DataProcessor("aircraftModel", checkBoxAircraftModel, "comboBoxAircraftModel"));
            dataProcessors.Add(new DataProcessor("weather", checkBoxWeather, "comboBoxWeather"));
            dataProcessors.Add(new DataProcessor("cabinStatus", checkBoxCabinStatus, "comboBoxCabinStatus"));
            dataProcessors.Add(new DataProcessor("pitch", checkBoxPitch, "txtBoxPitch"));
            dataProcessors.Add(new DataProcessor("roll", checkBoxRoll, "txtBoxRoll"));
            dataProcessors.Add(new DataProcessor("slipSkidValue", checkBoxSlipSkid, "txtBoxSlipSkidValue"));
        }

        private void AddDataFromFile(string filePath, List<string> selectedData)
        {
            if (File.Exists(filePath))
            {
                if (checkBoxAltitude.Checked)
                {
                    int altitudeValue = ReadAltitudeValueFromFile(filePath);

                    selectedData.Add($"altitude:{altitudeValue}");
                }

                if (checkBoxSpeed.Checked)
                {
                    int speedValue = ReadSpeedValueFromFile(filePath);
                    selectedData.Add($"speed:{speedValue}");
                }

                if (checkBoxTemperature.Checked)
                {
                    int temperatureValue = ReadTemperatureValueFromFile(filePath);
                    selectedData.Add($"temperature:{temperatureValue}");
                }

                if (checkBoxFuelLevel.Checked)
                {
                    int fuelLevelValue = ReadFuelLevelValueFromFile(filePath);
                    selectedData.Add($"fuelLevel:{fuelLevelValue}");
                }

                if (checkBoxNumberOfPassengers.Checked)
                {
                    int numberOfPassengers = ReadNumberOfPassengersValueFromFile(filePath);
                    selectedData.Add($"numberOfPassengers:{numberOfPassengers}");
                }

                if (checkBoxHeading.Checked)
                {
                    int headingValue = ReadHeadingValueFromFile(filePath);
                    selectedData.Add($"headingValue:{headingValue}");
                }

                if (checkBoxWindInfo.Checked)
                {
                    int windInfo = ReadWindValueFromFile(filePath);
                    selectedData.Add($"windInfo:{windInfo}");
                }

                if (checkBoxFlightRoute.Checked)
                {
                    string flightRoute = ReadFlightRouteFromFile(filePath);
                    selectedData.Add($"flightInfo:{flightRoute}");
                }

                if (checkBoxWeather.Checked)
                {
                    string weather = ReadWeatherFromFile(filePath);
                    selectedData.Add($"weather:{weather}");
                }

                if (checkBoxCabinStatus.Checked)
                {
                    string cabinStatus = ReadCabinStatusFromFile(filePath);
                    selectedData.Add($"cabinStatus:{cabinStatus}");
                }

                if (checkBoxAircraftType.Checked)
                {
                    string aircraftType = ReadAircraftTypeFromFile(filePath);
                    selectedData.Add($"aircraftType:{aircraftType}");
                }

                if (checkBoxAircraftModel.Checked)
                {
                    string aircraftModel = ReadAircraftModelFromFile(filePath);
                    selectedData.Add($"aircraftModel:{aircraftModel}");
                }

                if (checkBoxPitch.Checked)
                {
                    int pitchValue = ReadPitchValueFromFile(filePath);
                    selectedData.Add($"pitchValue:{pitchValue}");
                }

                if (checkBoxRoll.Checked)
                {
                    int rollValue = ReadRollValueFromFile(filePath);
                    selectedData.Add($"rollValue:{rollValue}");
                }

                if (checkBoxSlipSkid.Checked)
                {
                    int slipSkidValue = ReadSlipSkidValueFromFile(filePath);
                    selectedData.Add($"slipSkidValue:{slipSkidValue}");
                }
            }
        }

        private void SendData(string data)
        {
            IPAddress serverIpAddress = IPAddress.Parse("127.0.0.1");
            int serverPortNum = 50000;

            UdpClient udpClient = new UdpClient();

            try
            {
                byte[] dataBytes = Encoding.ASCII.GetBytes(data);
                udpClient.SendToServer(serverIpAddress, serverPortNum, dataBytes);

                MessageBox.Show("Data Sent to Server", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"An error occurred while sending data to the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                udpClient.Close();
            }
        }

        private int ReadValueFromFile(string filePath, string controlName)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && parts[0].Trim() == controlName)
                    {
                        if (int.TryParse(parts[1].Trim(), out int value))
                        {
                            return value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading value from {controlName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }

        private string ReadStringValueFromFile(string filePath, string controlName)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && parts[0].Trim() == controlName)
                    {
                        return parts[1].Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading value from {controlName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }

        private int ReadSpeedValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxSpeed");
        }

        private int ReadFuelLevelValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxFuelLevel");
        }

        private int ReadHeadingValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxHeading");
        }

        private int ReadNumberOfPassengersValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtNumberPassengers");
        }

        private int ReadTemperatureValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxTemperature");
        }

        private int ReadWindValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxWindInfo");
        }

        private string ReadFlightRouteFromFile(string filePath)
        {
            return ReadStringValueFromFile(filePath, "txtFlightRoute");
        }

        private string ReadAircraftTypeFromFile(string filePath)
        {
            return ReadStringValueFromFile(filePath, "comboBoxAircraftType");
        }

        private string ReadAircraftModelFromFile(string filePath)
        {
            return ReadStringValueFromFile(filePath, "comboBoxAircraftModel");
        }

        private string ReadCabinStatusFromFile(string filePath)
        {
            return ReadStringValueFromFile(filePath, "comboBoxCabinStatus");
        }

        private string ReadWeatherFromFile(string filePath)
        {
            return ReadStringValueFromFile(filePath, "comboBoxWeather");
        }

        private int ReadAltitudeValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxAltitude");
        }

        private int ReadPitchValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxPitch");
        }

        private int ReadSlipSkidValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxSlipSkidValue");
        }

        private int ReadRollValueFromFile(string filePath)
        {
            return ReadValueFromFile(filePath, "txtBoxRoll");
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkStatus = checkBoxSelectAll.Checked;

            checkBoxAltitude.Checked = checkStatus;
            checkBoxSpeed.Checked = checkStatus;
            checkBoxTemperature.Checked = checkStatus;
            checkBoxFuelLevel.Checked = checkStatus;
            checkBoxNumberOfPassengers.Checked = checkStatus;
            checkBoxHeading.Checked = checkStatus;
            checkBoxWindInfo.Checked = checkStatus;
            checkBoxFlightRoute.Checked = checkStatus;
            checkBoxWeather.Checked = checkStatus;
            checkBoxCabinStatus.Checked = checkStatus;
            checkBoxAircraftType.Checked = checkStatus;
            checkBoxAircraftModel.Checked = checkStatus;
            checkBoxPitch.Checked = checkStatus;
            checkBoxRoll.Checked = checkStatus;
            checkBoxSlipSkid.Checked = checkStatus;
        }






        private void BtnRun_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\VALUES\";
            int fileNumber = 1;
            bool foundFiles = true;

            while (foundFiles)
            {
                string fileName = Path.Combine(directoryPath, $"Aircraft_Information{fileNumber}.txt");

                if (File.Exists(fileName))
                {
                    List<string> selectedData = new List<string>();
                    AddDataFromFile(fileName, selectedData);

                    if (selectedData.Count > 0)
                    {
                        string dataToSend = string.Join(",", selectedData);
                        SendData(dataToSend);
                    }
                    else
                    {
                        MessageBox.Show($"No data selected to send from {fileName}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    fileNumber++;
                }
                else
                {
                    foundFiles = false;
                }
            }
        }

        private Dictionary<string, TreeNode> aircraftNodes = new Dictionary<string, TreeNode>();


        private void btnLoad_Click(object sender, EventArgs e)
        {
            string directoryPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\VALUES\";

            string serverMessagesFolderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\ServerMessages"; // ServerMessages klasörünün yolu

            string[] filePaths = Directory.GetFiles(directoryPath, "Aircraft_Information*.txt");

            treeView.Nodes.Clear(); // Ağaç düğümlerini temizleyin
            aircraftNodes.Clear(); // Uçak düğümlerini temizleyin

            foreach (string filePath in filePaths)
            {
                string realAircraftName = Path.GetFileNameWithoutExtension(filePath); // Gerçek dosya adı
                string sanitizedAircraftName = realAircraftName.Replace("Aircraft_Information", "").Replace(" ", "");
                string displayedAircraftName = "Aircraft " + sanitizedAircraftName;



                TreeNode aircraftNode = new TreeNode(displayedAircraftName); // Kullanıcıya gösterilen ad
                aircraftNode.Name = sanitizedAircraftName; // Gerçek dosya adı

                // Okuma işlemi
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        // Düğüm için bir child düğüm oluştur ve içeriğini ayarla
                        TreeNode dataNode = new TreeNode($"{key}: {value}");

                        // Düğüme child düğümü ekle
                        aircraftNode.Nodes.Add(dataNode);
                    }
                }

                // Uçağı ağaca ekle
                treeView.Nodes.Add(aircraftNode);

                // Uçak düğümünü dictionary'e ekleyin
                aircraftNodes[sanitizedAircraftName] = aircraftNode;


                string serverMessagesFileName = $"{displayedAircraftName}_ServerMessages.txt";
                string serverMessagesFilePath = Path.Combine(serverMessagesFolderPath, serverMessagesFileName);
                if (File.Exists(serverMessagesFilePath))
                {
                    TreeNode serverMessagesNode = new TreeNode("Server Messages");
                    string[] serverMessages = File.ReadAllLines(serverMessagesFilePath);
                    foreach (string serverMessage in serverMessages)
                    {
                        TreeNode serverMessageNode = new TreeNode(serverMessage);
                        serverMessagesNode.Nodes.Add(serverMessageNode);
                    }
                    aircraftNode.Nodes.Add(serverMessagesNode);
                }

            }
        }

        private void SaveRxMessageToFile(string rxMessage, string aircraftName)
        {
            string folderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\TEST_Messages";
            string fileName = $"{aircraftName}_TestMessages.txt"; // Uçağın adını dosya adı ile birleştir
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(rxMessage);
                }

                MessageBox.Show("Test message saved to file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the test message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Dictionary<string, List<string>> aircraftRxMessages = new Dictionary<string, List<string>>();

        private TreeNode currentSelectedNode;
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentSelectedNode = e.Node;

                if (currentSelectedNode != null && currentSelectedNode.Parent == null)
                {
                    // Check if the clicked node is the "Test Messages" node
                    if (currentSelectedNode.Name != "TestMessagesNode")
                    {
                        TreeNode rxMessagesNode = new TreeNode("TestMessages");
                        rxMessagesNode.Name = "TestMessagesNode";
                        treeView.Nodes.Insert(currentSelectedNode.Index + 1, rxMessagesNode);
                        ShowRxMessagesForAircraft(currentSelectedNode.Text, rxMessagesNode);
                    }
                }
            }
        }


        private void ShowRxMessagesForAircraft(string aircraftName, TreeNode rxMessageContentNode)
        {
            using (InputBoxForm inputBox = new InputBoxForm())
            {
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    string rxMessage = inputBox.EnteredText;

                    if (!string.IsNullOrWhiteSpace(rxMessage))
                    {

                        string rxWithConfirmation = $"{rxMessage}";

                        if (!aircraftRxMessages.ContainsKey(aircraftName))
                        {
                            aircraftRxMessages[aircraftName] = new List<string>();
                        }
                        aircraftRxMessages[aircraftName].Add(rxWithConfirmation);

                        TreeNode rxMessageNode = new TreeNode(rxWithConfirmation);
                        rxMessageContentNode.Nodes.Add(rxMessageNode);

                        // RX mesajını dosyaya kaydet
                        SaveRxMessageToFile(rxWithConfirmation, aircraftName);
                    }
                }
            }
        }


        private void rxEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSelectedNode != null && currentSelectedNode.Parent != null && currentSelectedNode.Parent.Name != "TestMessagesNode")
            {
                string rxMessage = GetRxMessageFromUser();

                if (!string.IsNullOrWhiteSpace(rxMessage))
                {
                    DialogResult userChoice = MessageBox.Show($"Test Message: {rxMessage}\n\nHave you verified your Test message?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    string rxWithConfirmation = $"{rxMessage}";

                    if (!aircraftRxMessages.ContainsKey(currentSelectedNode.Text))
                    {
                        aircraftRxMessages[currentSelectedNode.Text] = new List<string>();
                    }
                    aircraftRxMessages[currentSelectedNode.Text].Add(rxWithConfirmation);
                }
            }
        }

        private string GetRxMessageFromUser()
        {
            using (InputBoxForm inputBox = new InputBoxForm())
            {
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    return inputBox.UserInput;
                }
            }
            return null;
        }

        private string GetAircraftNameFromTreeNode(TreeNode node)
        {
            // TreeNode'ın ebeveynlerini dolaşarak uçağın adını bul
            TreeNode parentNode = node;

            while (parentNode != null)
            {
                if (parentNode.Text.StartsWith("Aircraft "))
                {
                    return parentNode.Text;
                }
                else if (parentNode.Text == "TestMessages")
                {
                    // "Test Messages" düğümünü geç ve üst düğüme git
                    parentNode = parentNode.PrevNode;
                }
                else
                {
                    // Diğer düğümlerde durumu kontrol et
                    parentNode = parentNode.Parent;
                }
            }

            return null; // Uçağın adını bulamazsa null döndür
        }

        private void UpdateTextFile(string aircraftName, string oldMessage, string newMessage)
        {
            try
            {
                // Mevcut test mesajının bağlı olduğu uçağın adını al

                if (aircraftName != null)
                {
                    string folderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\TEST_Messages";
                    string filePath = Path.Combine(folderPath, $"{aircraftName}_TestMessages.txt");

                    // Dosyadaki tüm mesajları okuyun
                    List<string> allMessages = File.ReadAllLines(filePath).ToList();

                    // Güncellemek istediğiniz mesajı bulun ve güncelleyin
                    int indexToUpdate = allMessages.IndexOf(oldMessage);
                    if (indexToUpdate >= 0)
                    {
                        allMessages[indexToUpdate] = newMessage;
                    }

                    // Tüm mesajları dosyaya tekrar yazın
                    File.WriteAllLines(filePath, allMessages);

                    if (File.Exists(filePath))
                    {
                        MessageBox.Show($"Test messages updated for {aircraftName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update test messages for {aircraftName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Aircraft name not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating test messages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private TextBox editTextBox;
        private TreeNode editedNode; // Düzenleme yapılan düğümü tutmak için

        private void treeView_AfterLabelEdit_1(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Text == "Test Messages")
            {
                if (!string.IsNullOrEmpty(e.Label))
                {
                    string newText = e.Label;

                    // Update the message in the list
                    int editedMessageIndex = aircraftRxMessages[e.Node.Parent.Parent.Text].IndexOf(e.Node.Text);
                    aircraftRxMessages[e.Node.Parent.Parent.Text][editedMessageIndex] = newText;

                    // Update the message in the corresponding text file
                    string aircraftName = e.Node.Parent.Parent.Text;
                    string oldMessage = e.Node.Text;
                    UpdateTextFile(aircraftName, oldMessage, newText);

                    // Update the node's text with the new message
                    e.Node.Text = newText;
                }
                else
                {
                    // If the edited text is empty, cancel the edit
                    e.CancelEdit = true;
                }
            }
        }

        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Text == "TestMessages")
            {
                // Sadece RX Messages altındaki düğümlere düzenleme izni ver
                e.CancelEdit = false;
            }
            else
            {
                // Diğer düğümlerde düzenlemeyi engelle
                e.CancelEdit = true;
            }
        }

        private TreeNode FindTestMessagesNode(TreeNode editedNode)
        {
            TreeNode parentNode = editedNode.Parent;

            while (parentNode != null)
            {
                if (parentNode.Text == "TestMessages")
                {
                    // "Test Messages" düğümünü bulduk
                    return parentNode.PrevNode;
                }
                else if (parentNode.Text == "Test Messages")
                {
                    return parentNode.PrevNode;
                }
              /*  else if (parentNode.Text == "Server Messages")
                {
                    return parentNode.PrevNode;
                } */
                // Üst düğüme git
                parentNode = parentNode.Parent;
            }

            // "Test Messages" düğümünü bulamazsak null döndürebiliriz
            return null;
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && treeView.SelectedNode != null)
            {
                TreeNode selectedNode = treeView.SelectedNode;

                // Seçilen düğümün hangi "Test Messages" düğümünün altında olduğunu bulun
                TreeNode testMessagesNode = FindTestMessagesNode(selectedNode);

                if (testMessagesNode != null)
                {
                    TreeNode aircraftNode = testMessagesNode;

                    if (aircraftNode != null)
                    {
                        string aircraftName = aircraftNode.Text;
                    }
                }

                // Düzenleme yapılan düğümü tut
                editedNode = selectedNode;
                editTextBox = new TextBox(); // TextBox oluştur
                editTextBox.Bounds = editedNode.Bounds; // TextBox boyutunu düğüme uygun ayarla
                editTextBox.Text = editedNode.Text; // TextBox içeriğini düğümün metniyle doldur
                editTextBox.KeyDown += EditTextBox_KeyDown; // TextBox'e KeyDown olayını ekle
                treeView.Controls.Add(editTextBox); // TextBox'i TreeView'e ekle
                editTextBox.Focus(); // TextBox'e odaklan

                // Bu olayın işlendiğini işaretle, böylece TreeView'e iki kez F2'ye basılmaz.
                e.Handled = true;
            }
        }

        private void EditTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Yeni metni al
                string newLabel = editTextBox.Text;
                string oldMessage = editedNode.Text;

                // TreeView'deki metni güncelle
                editedNode.Text = newLabel;

                // Uçağın adını düzenlenen düğümden al
                TreeNode testMessagesNode = FindTestMessagesNode(editedNode);

                if (testMessagesNode != null)
                {
                    string aircraftName = GetAircraftNameFromTreeNode(testMessagesNode); // TestMessages düğümünün altındaki Aircraft'ı al

                    if (!string.IsNullOrEmpty(aircraftName))
                    {
                        // Metin dosyasını güncelle
                        UpdateTextFile(aircraftName, oldMessage, newLabel);
                    }
                    else
                    {
                        MessageBox.Show("Aircraft name not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("TestMessages node not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Düzenleme kontrolünü kaldır
                treeView.Controls.Remove(editTextBox);
                editTextBox.Dispose();
            }
        }
     
        private void BtnReport_Click(object sender, EventArgs e)
        {
            HTMLReportGenerator reportGenerator = new HTMLReportGenerator();
            reportGenerator.CreateHTMLReport();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string stopCommand = "STOP_STREAMING";
            SendData(stopCommand);
        }
    }

    public class HTMLReportGenerator
    {
        public void CreateHTMLReport()
        {
            string folderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\ServerMessages"; // Klasör yolunu burada tanımlayın
            string templateFilePath = Path.Combine("C:\\Users\\cangu\\OneDrive\\Masaüstü\\Ershica\\BİTES STAJ PROJELER\\Avionics_Client\\denemeClient\\Test Messages Report", "RaporSablonu.html");


            //TestMessages connects Aircraft_Information*

            string aircraftfolderPath = @"C:\Users\cangu\OneDrive\Masaüstü\Ershica\BİTES STAJ PROJELER\VALUES";

            if (!File.Exists(templateFilePath))
            {
                MessageBox.Show("Rapor şablonu bulunamadı: " + templateFilePath, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string htmlTemplate = File.ReadAllText(templateFilePath);

            // Rapor verileri (klasördeki dosyalar)
            List<string> reportTables = new List<string>();
            string[] filePaths = Directory.GetFiles(folderPath, "Aircraft*_ServerMessages.txt");

            foreach (string filePath in filePaths)
            {
                string aircraftTestMessagesFileName = Path.GetFileNameWithoutExtension(filePath);

                // Dosya adından sayıyı al
                string aircraftNumber = Regex.Match(aircraftTestMessagesFileName, @"\d+").Value;

                // İlgili Aircraft_Information dosyasını bulun
                string aircraftInformationFileName = $"Aircraft_Information{aircraftNumber}.txt";
                string aircraftInformationFilePath = Path.Combine(aircraftfolderPath, aircraftInformationFileName);

                if (!File.Exists(aircraftInformationFilePath))
                {
                    MessageBox.Show($"Aircraft_Information dosyası bulunamadı: {aircraftInformationFileName}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                string aircraftTestMessages = File.ReadAllText(filePath);
                string aircraftInformation = File.ReadAllText(aircraftInformationFilePath);

                // Dosyayı satır satır okuyun ve gereksiz boşlukları kaldırarak işleyin
                string[] lines = aircraftInformation.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> cleanedLines = new List<string>();

                foreach (string line in lines)
                {
                    string cleanedLine = line.Trim(); // Satırın başındaki ve sonundaki boşlukları kaldırın
                    cleanedLines.Add(cleanedLine);
                }

                string dataItems = string.Join("<br>", cleanedLines); // Temizlenmiş satırları birleştirin

                // Dosyayı satır satır okuyun
                string[] linesMessages = aircraftTestMessages.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                List<string> selectedItems = new List<string>();

                foreach (string line in linesMessages)
                {
                    string color = "red"; // Varsayılan renk

                    if (line.Contains("Y"))
                    {
                        color = "green"; // Yes seçildiyse yeşil renk
                    }
                    else if (line.Contains("N"))
                    {
                        color = "red"; // No seçildiyse kırmızı renk
                    }

                    string testMessageHeader = $"<span style='color: blue;'>Test Messages:</span>";
                    string tableRow = $"<tr><td>{testMessageHeader} {line}</td><td style='color:{color}'>{line}</td></tr>";
                    selectedItems.Add(tableRow);
                }


                // Her dosya için ayrı bir tablo oluşturun ve Aircraft_Information dosyasının içeriğini ekleyin
                string tableRows = string.Join("", selectedItems);
                string reportTable = $"<h2>{aircraftTestMessagesFileName}</h2><table><tr><th>Test Message</th><th>Succession</th><th>Data</th></tr><tr><td></td><td></td><td>{dataItems}</td></tr>{tableRows}</table>";

                reportTables.Add(reportTable);
            }

            // Rapor şablonundaki veri yer tutucusunu değiştirin
            string tables = string.Join("", reportTables);
            htmlTemplate = htmlTemplate.Replace("<!-- Rapor verileri burada yer alacak -->", tables);

            // HTML raporunu bir dosyaya kaydedin
            File.WriteAllText("RaporSablonu.html", htmlTemplate);

            // Kullanıcıya rapor dosyasını gösterin veya açmasını sağlayın
            MessageBox.Show("HTML raporu başarıyla oluşturuldu. Rapor dosyası: RaporSablonu.html", "Rapor Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


    public class InputBoxForm : Form
    {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;

        public string UserInput => textBox.Text;

        public string EnteredText { get; private set; } // Renamed property

        public InputBoxForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox = new TextBox();
            this.okButton = new Button();
            this.cancelButton = new Button();

            // TextBox ayarları
            this.textBox.Location = new Point(20, 20);
            this.textBox.Size = new Size(200, 20);

            // OK düğmesi ayarları
            this.okButton.Text = "OK";
            this.okButton.Location = new Point(20, 50);
            this.okButton.Click += OkButton_Click; // OK düğmesine tıklandığında ne olacağını belirten olay işleyici

            // Cancel düğmesi ayarları
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Location = new Point(100, 50);
            this.cancelButton.Click += CancelButton_Click; // Cancel düğmesine tıklandığında ne olacağını belirten olay işleyici

            // Form ayarları
            this.Text = "Metin Girişi";
            this.ClientSize = new Size(240, 100);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği metni al
            EnteredText = textBox.Text;

            // DialogResult'ı OK olarak ayarla
            this.DialogResult = DialogResult.OK;

            // İletişim kutusunu kapat
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // İletişim kutusunu kapat
            this.Close();
        }
    }


    class UdpClient
    {
        private readonly Socket clientSocket;

        public UdpClient()
        {
            clientSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);
        }

        public void SendToServer(IPAddress serverIpAddress, int serverPortNum, byte[] dataBytes)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(serverIpAddress, serverPortNum);
            clientSocket.SendTo(dataBytes, serverEndPoint);
        }

        public void Close()
        {
            clientSocket.Close();
        }
    }


    public class DataProcessor
    {
        public string DataName { get; }
        public CheckBox CheckBox { get; }
        public string ControlName { get; }

        public DataProcessor(string dataName, CheckBox checkBox, string controlName)
        {
            DataName = dataName;
            CheckBox = checkBox;
            ControlName = controlName;
        }
    }

}