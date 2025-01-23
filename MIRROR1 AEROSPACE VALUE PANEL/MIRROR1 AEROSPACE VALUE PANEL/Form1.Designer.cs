namespace MIRROR1_AEROSPACE_VALUE_PANEL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTemperature = new System.Windows.Forms.Label();
            this.txtBoxTemperature = new System.Windows.Forms.TextBox();
            this.labelAltitude = new System.Windows.Forms.Label();
            this.labelFuelLevel = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelHeading = new System.Windows.Forms.Label();
            this.labelWindInformation = new System.Windows.Forms.Label();
            this.labelWeather = new System.Windows.Forms.Label();
            this.labelFlightRoute = new System.Windows.Forms.Label();
            this.labelNumberPassengers = new System.Windows.Forms.Label();
            this.labelCabinStatus = new System.Windows.Forms.Label();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.txtFlightRoute = new System.Windows.Forms.TextBox();
            this.txtBoxWindInfo = new System.Windows.Forms.TextBox();
            this.txtBoxHeading = new System.Windows.Forms.TextBox();
            this.txtBoxSpeed = new System.Windows.Forms.TextBox();
            this.txtBoxFuelLevel = new System.Windows.Forms.TextBox();
            this.txtBoxAltitude = new System.Windows.Forms.TextBox();
            this.txtNumberPassengers = new System.Windows.Forms.TextBox();
            this.labelAircraftType = new System.Windows.Forms.Label();
            this.labelAircraftModel = new System.Windows.Forms.Label();
            this.comboBoxWeather = new System.Windows.Forms.ComboBox();
            this.comboBoxCabinStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxAircraftType = new System.Windows.Forms.ComboBox();
            this.comboBoxAircraftModel = new System.Windows.Forms.ComboBox();
            this.btnIncreaseTemp = new System.Windows.Forms.Button();
            this.btnDecreaseTemp = new System.Windows.Forms.Button();
            this.buttonIncreaseAltitude = new System.Windows.Forms.Button();
            this.btnIncreaseFuelLevel = new System.Windows.Forms.Button();
            this.btnIncreaseSpeed = new System.Windows.Forms.Button();
            this.btnIncreaseNumberPassengers = new System.Windows.Forms.Button();
            this.btnDecreaseAltitude = new System.Windows.Forms.Button();
            this.btnDecreaseFuelLevel = new System.Windows.Forms.Button();
            this.btnDecreaseSpeed = new System.Windows.Forms.Button();
            this.btnDecreaseNumberPassengers = new System.Windows.Forms.Button();
            this.btnIncreaseHeading = new System.Windows.Forms.Button();
            this.btnDecreaseHeading = new System.Windows.Forms.Button();
            this.txtBoxSpeedValueRange = new System.Windows.Forms.TextBox();
            this.txtBoxFuelLevelValueRange = new System.Windows.Forms.TextBox();
            this.txtBoxTempValueRange = new System.Windows.Forms.TextBox();
            this.txtBoxAltitudeValueRange = new System.Windows.Forms.TextBox();
            this.txtBoxNumberPassengersValueRange = new System.Windows.Forms.TextBox();
            this.txtBoxHeadingExp = new System.Windows.Forms.TextBox();
            this.txtBoxWindExp = new System.Windows.Forms.TextBox();
            this.txtBoxFlightRouteExp = new System.Windows.Forms.TextBox();
            this.txtBoxPitch = new System.Windows.Forms.TextBox();
            this.txtBoxRoll = new System.Windows.Forms.TextBox();
            this.txtBoxSlipSkidValue = new System.Windows.Forms.TextBox();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelRoll = new System.Windows.Forms.Label();
            this.labelSlipSkid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTemperature
            // 
            this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(18, 9);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(67, 13);
            this.labelTemperature.TabIndex = 0;
            this.labelTemperature.Text = "Temperature";
            // 
            // txtBoxTemperature
            // 
            this.txtBoxTemperature.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTemperature.Location = new System.Drawing.Point(21, 25);
            this.txtBoxTemperature.Name = "txtBoxTemperature";
            this.txtBoxTemperature.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTemperature.TabIndex = 1;
            this.txtBoxTemperature.TextChanged += new System.EventHandler(this.txtBoxTemperature_TextChanged);
            // 
            // labelAltitude
            // 
            this.labelAltitude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAltitude.AutoSize = true;
            this.labelAltitude.Location = new System.Drawing.Point(165, 9);
            this.labelAltitude.Name = "labelAltitude";
            this.labelAltitude.Size = new System.Drawing.Size(42, 13);
            this.labelAltitude.TabIndex = 2;
            this.labelAltitude.Text = "Altitude";
            // 
            // labelFuelLevel
            // 
            this.labelFuelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFuelLevel.AutoSize = true;
            this.labelFuelLevel.Location = new System.Drawing.Point(312, 9);
            this.labelFuelLevel.Name = "labelFuelLevel";
            this.labelFuelLevel.Size = new System.Drawing.Size(56, 13);
            this.labelFuelLevel.TabIndex = 3;
            this.labelFuelLevel.Text = "Fuel Level";
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(459, 9);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "Speed";
            // 
            // labelHeading
            // 
            this.labelHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeading.AutoSize = true;
            this.labelHeading.Location = new System.Drawing.Point(18, 126);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(47, 13);
            this.labelHeading.TabIndex = 5;
            this.labelHeading.Text = "Heading";
            // 
            // labelWindInformation
            // 
            this.labelWindInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWindInformation.AutoSize = true;
            this.labelWindInformation.Location = new System.Drawing.Point(165, 126);
            this.labelWindInformation.Name = "labelWindInformation";
            this.labelWindInformation.Size = new System.Drawing.Size(87, 13);
            this.labelWindInformation.TabIndex = 6;
            this.labelWindInformation.Text = "Wind Information";
            // 
            // labelWeather
            // 
            this.labelWeather.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWeather.AutoSize = true;
            this.labelWeather.Location = new System.Drawing.Point(312, 126);
            this.labelWeather.Name = "labelWeather";
            this.labelWeather.Size = new System.Drawing.Size(48, 13);
            this.labelWeather.TabIndex = 7;
            this.labelWeather.Text = "Weather";
            // 
            // labelFlightRoute
            // 
            this.labelFlightRoute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFlightRoute.AutoSize = true;
            this.labelFlightRoute.Location = new System.Drawing.Point(459, 126);
            this.labelFlightRoute.Name = "labelFlightRoute";
            this.labelFlightRoute.Size = new System.Drawing.Size(64, 13);
            this.labelFlightRoute.TabIndex = 8;
            this.labelFlightRoute.Text = "Flight Route";
            // 
            // labelNumberPassengers
            // 
            this.labelNumberPassengers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumberPassengers.AutoSize = true;
            this.labelNumberPassengers.Location = new System.Drawing.Point(12, 237);
            this.labelNumberPassengers.Name = "labelNumberPassengers";
            this.labelNumberPassengers.Size = new System.Drawing.Size(114, 13);
            this.labelNumberPassengers.TabIndex = 9;
            this.labelNumberPassengers.Text = "Number of Passengers";
            // 
            // labelCabinStatus
            // 
            this.labelCabinStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCabinStatus.AutoSize = true;
            this.labelCabinStatus.Location = new System.Drawing.Point(165, 237);
            this.labelCabinStatus.Name = "labelCabinStatus";
            this.labelCabinStatus.Size = new System.Drawing.Size(67, 13);
            this.labelCabinStatus.TabIndex = 10;
            this.labelCabinStatus.Text = "Cabin Status";
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInfo.Location = new System.Drawing.Point(494, 404);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(100, 52);
            this.btnSaveInfo.TabIndex = 11;
            this.btnSaveInfo.Text = "Save Informations";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // txtFlightRoute
            // 
            this.txtFlightRoute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFlightRoute.Location = new System.Drawing.Point(462, 142);
            this.txtFlightRoute.Name = "txtFlightRoute";
            this.txtFlightRoute.Size = new System.Drawing.Size(100, 20);
            this.txtFlightRoute.TabIndex = 12;
            this.txtFlightRoute.TextChanged += new System.EventHandler(this.txtFlightRoute_TextChanged);
            // 
            // txtBoxWindInfo
            // 
            this.txtBoxWindInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxWindInfo.Location = new System.Drawing.Point(168, 142);
            this.txtBoxWindInfo.Name = "txtBoxWindInfo";
            this.txtBoxWindInfo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWindInfo.TabIndex = 14;
            this.txtBoxWindInfo.TextChanged += new System.EventHandler(this.txtBoxWindInfo_TextChanged);
            // 
            // txtBoxHeading
            // 
            this.txtBoxHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxHeading.Location = new System.Drawing.Point(21, 142);
            this.txtBoxHeading.Name = "txtBoxHeading";
            this.txtBoxHeading.Size = new System.Drawing.Size(100, 20);
            this.txtBoxHeading.TabIndex = 15;
            this.txtBoxHeading.TextChanged += new System.EventHandler(this.txtBoxHeading_TextChanged);
            // 
            // txtBoxSpeed
            // 
            this.txtBoxSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSpeed.Location = new System.Drawing.Point(462, 25);
            this.txtBoxSpeed.Name = "txtBoxSpeed";
            this.txtBoxSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSpeed.TabIndex = 16;
            this.txtBoxSpeed.TextChanged += new System.EventHandler(this.txtBoxSpeed_TextChanged);
            // 
            // txtBoxFuelLevel
            // 
            this.txtBoxFuelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxFuelLevel.Location = new System.Drawing.Point(315, 25);
            this.txtBoxFuelLevel.Name = "txtBoxFuelLevel";
            this.txtBoxFuelLevel.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFuelLevel.TabIndex = 17;
            this.txtBoxFuelLevel.TextChanged += new System.EventHandler(this.txtBoxFuelLevel_TextChanged);
            // 
            // txtBoxAltitude
            // 
            this.txtBoxAltitude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxAltitude.Location = new System.Drawing.Point(168, 25);
            this.txtBoxAltitude.Name = "txtBoxAltitude";
            this.txtBoxAltitude.Size = new System.Drawing.Size(100, 20);
            this.txtBoxAltitude.TabIndex = 18;
            this.txtBoxAltitude.TextChanged += new System.EventHandler(this.txtBoxAltitude_TextChanged);
            // 
            // txtNumberPassengers
            // 
            this.txtNumberPassengers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumberPassengers.Location = new System.Drawing.Point(21, 253);
            this.txtNumberPassengers.Name = "txtNumberPassengers";
            this.txtNumberPassengers.Size = new System.Drawing.Size(100, 20);
            this.txtNumberPassengers.TabIndex = 19;
            this.txtNumberPassengers.TextChanged += new System.EventHandler(this.txtNumberPassengers_TextChanged);
            // 
            // labelAircraftType
            // 
            this.labelAircraftType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftType.AutoSize = true;
            this.labelAircraftType.Location = new System.Drawing.Point(312, 236);
            this.labelAircraftType.Name = "labelAircraftType";
            this.labelAircraftType.Size = new System.Drawing.Size(67, 13);
            this.labelAircraftType.TabIndex = 21;
            this.labelAircraftType.Text = "Aircraft Type";
            // 
            // labelAircraftModel
            // 
            this.labelAircraftModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftModel.AutoSize = true;
            this.labelAircraftModel.Location = new System.Drawing.Point(459, 236);
            this.labelAircraftModel.Name = "labelAircraftModel";
            this.labelAircraftModel.Size = new System.Drawing.Size(72, 13);
            this.labelAircraftModel.TabIndex = 22;
            this.labelAircraftModel.Text = "Aircraft Model";
            // 
            // comboBoxWeather
            // 
            this.comboBoxWeather.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeather.FormattingEnabled = true;
            this.comboBoxWeather.Location = new System.Drawing.Point(315, 142);
            this.comboBoxWeather.Name = "comboBoxWeather";
            this.comboBoxWeather.Size = new System.Drawing.Size(100, 21);
            this.comboBoxWeather.TabIndex = 25;
            this.comboBoxWeather.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeather_SelectedIndexChanged);
            // 
            // comboBoxCabinStatus
            // 
            this.comboBoxCabinStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCabinStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCabinStatus.FormattingEnabled = true;
            this.comboBoxCabinStatus.Location = new System.Drawing.Point(168, 252);
            this.comboBoxCabinStatus.Name = "comboBoxCabinStatus";
            this.comboBoxCabinStatus.Size = new System.Drawing.Size(100, 21);
            this.comboBoxCabinStatus.TabIndex = 26;
            this.comboBoxCabinStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxCabinStatus_SelectedIndexChanged);
            // 
            // comboBoxAircraftType
            // 
            this.comboBoxAircraftType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxAircraftType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAircraftType.FormattingEnabled = true;
            this.comboBoxAircraftType.Location = new System.Drawing.Point(315, 252);
            this.comboBoxAircraftType.Name = "comboBoxAircraftType";
            this.comboBoxAircraftType.Size = new System.Drawing.Size(135, 21);
            this.comboBoxAircraftType.TabIndex = 27;
            this.comboBoxAircraftType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAircraftType_SelectedIndexChanged);
            // 
            // comboBoxAircraftModel
            // 
            this.comboBoxAircraftModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxAircraftModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAircraftModel.FormattingEnabled = true;
            this.comboBoxAircraftModel.Location = new System.Drawing.Point(456, 252);
            this.comboBoxAircraftModel.Name = "comboBoxAircraftModel";
            this.comboBoxAircraftModel.Size = new System.Drawing.Size(100, 21);
            this.comboBoxAircraftModel.TabIndex = 28;
            // 
            // btnIncreaseTemp
            // 
            this.btnIncreaseTemp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncreaseTemp.Location = new System.Drawing.Point(127, 12);
            this.btnIncreaseTemp.Name = "btnIncreaseTemp";
            this.btnIncreaseTemp.Size = new System.Drawing.Size(20, 22);
            this.btnIncreaseTemp.TabIndex = 29;
            this.btnIncreaseTemp.Text = "+";
            this.btnIncreaseTemp.UseVisualStyleBackColor = true;
            this.btnIncreaseTemp.Click += new System.EventHandler(this.btnIncreaseTemp_Click);
            // 
            // btnDecreaseTemp
            // 
            this.btnDecreaseTemp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseTemp.Location = new System.Drawing.Point(127, 40);
            this.btnDecreaseTemp.Name = "btnDecreaseTemp";
            this.btnDecreaseTemp.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseTemp.TabIndex = 30;
            this.btnDecreaseTemp.Text = "-";
            this.btnDecreaseTemp.UseVisualStyleBackColor = true;
            this.btnDecreaseTemp.Click += new System.EventHandler(this.btnDecreaseTemp_Click);
            // 
            // buttonIncreaseAltitude
            // 
            this.buttonIncreaseAltitude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonIncreaseAltitude.Location = new System.Drawing.Point(274, 12);
            this.buttonIncreaseAltitude.Name = "buttonIncreaseAltitude";
            this.buttonIncreaseAltitude.Size = new System.Drawing.Size(20, 22);
            this.buttonIncreaseAltitude.TabIndex = 31;
            this.buttonIncreaseAltitude.Text = "+";
            this.buttonIncreaseAltitude.UseVisualStyleBackColor = true;
            this.buttonIncreaseAltitude.Click += new System.EventHandler(this.buttonIncreaseAltitude_Click);
            // 
            // btnIncreaseFuelLevel
            // 
            this.btnIncreaseFuelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncreaseFuelLevel.Location = new System.Drawing.Point(421, 12);
            this.btnIncreaseFuelLevel.Name = "btnIncreaseFuelLevel";
            this.btnIncreaseFuelLevel.Size = new System.Drawing.Size(20, 22);
            this.btnIncreaseFuelLevel.TabIndex = 32;
            this.btnIncreaseFuelLevel.Text = "+";
            this.btnIncreaseFuelLevel.UseVisualStyleBackColor = true;
            this.btnIncreaseFuelLevel.Click += new System.EventHandler(this.btnIncreaseFuelLevel_Click);
            // 
            // btnIncreaseSpeed
            // 
            this.btnIncreaseSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncreaseSpeed.Location = new System.Drawing.Point(568, 12);
            this.btnIncreaseSpeed.Name = "btnIncreaseSpeed";
            this.btnIncreaseSpeed.Size = new System.Drawing.Size(20, 22);
            this.btnIncreaseSpeed.TabIndex = 33;
            this.btnIncreaseSpeed.Text = "+";
            this.btnIncreaseSpeed.UseVisualStyleBackColor = true;
            this.btnIncreaseSpeed.Click += new System.EventHandler(this.btnIncreaseSpeed_Click);
            // 
            // btnIncreaseNumberPassengers
            // 
            this.btnIncreaseNumberPassengers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncreaseNumberPassengers.Location = new System.Drawing.Point(127, 237);
            this.btnIncreaseNumberPassengers.Name = "btnIncreaseNumberPassengers";
            this.btnIncreaseNumberPassengers.Size = new System.Drawing.Size(20, 22);
            this.btnIncreaseNumberPassengers.TabIndex = 34;
            this.btnIncreaseNumberPassengers.Text = "+";
            this.btnIncreaseNumberPassengers.UseVisualStyleBackColor = true;
            this.btnIncreaseNumberPassengers.Click += new System.EventHandler(this.btnIncreaseNumberPassengers_Click);
            // 
            // btnDecreaseAltitude
            // 
            this.btnDecreaseAltitude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseAltitude.Location = new System.Drawing.Point(274, 40);
            this.btnDecreaseAltitude.Name = "btnDecreaseAltitude";
            this.btnDecreaseAltitude.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseAltitude.TabIndex = 35;
            this.btnDecreaseAltitude.Text = "-";
            this.btnDecreaseAltitude.UseVisualStyleBackColor = true;
            this.btnDecreaseAltitude.Click += new System.EventHandler(this.btnDecreaseAltitude_Click);
            // 
            // btnDecreaseFuelLevel
            // 
            this.btnDecreaseFuelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseFuelLevel.Location = new System.Drawing.Point(421, 40);
            this.btnDecreaseFuelLevel.Name = "btnDecreaseFuelLevel";
            this.btnDecreaseFuelLevel.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseFuelLevel.TabIndex = 36;
            this.btnDecreaseFuelLevel.Text = "-";
            this.btnDecreaseFuelLevel.UseVisualStyleBackColor = true;
            this.btnDecreaseFuelLevel.Click += new System.EventHandler(this.btnDecreaseFuelLevel_Click);
            // 
            // btnDecreaseSpeed
            // 
            this.btnDecreaseSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseSpeed.Location = new System.Drawing.Point(568, 40);
            this.btnDecreaseSpeed.Name = "btnDecreaseSpeed";
            this.btnDecreaseSpeed.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseSpeed.TabIndex = 37;
            this.btnDecreaseSpeed.Text = "-";
            this.btnDecreaseSpeed.UseVisualStyleBackColor = true;
            this.btnDecreaseSpeed.Click += new System.EventHandler(this.btnDecreaseSpeed_Click);
            // 
            // btnDecreaseNumberPassengers
            // 
            this.btnDecreaseNumberPassengers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseNumberPassengers.Location = new System.Drawing.Point(127, 263);
            this.btnDecreaseNumberPassengers.Name = "btnDecreaseNumberPassengers";
            this.btnDecreaseNumberPassengers.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseNumberPassengers.TabIndex = 38;
            this.btnDecreaseNumberPassengers.Text = "-";
            this.btnDecreaseNumberPassengers.UseVisualStyleBackColor = true;
            this.btnDecreaseNumberPassengers.Click += new System.EventHandler(this.btnDecreaseNumberPassengers_Click);
            // 
            // btnIncreaseHeading
            // 
            this.btnIncreaseHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIncreaseHeading.Location = new System.Drawing.Point(127, 126);
            this.btnIncreaseHeading.Name = "btnIncreaseHeading";
            this.btnIncreaseHeading.Size = new System.Drawing.Size(20, 22);
            this.btnIncreaseHeading.TabIndex = 39;
            this.btnIncreaseHeading.Text = "+";
            this.btnIncreaseHeading.UseVisualStyleBackColor = true;
            this.btnIncreaseHeading.Click += new System.EventHandler(this.btnIncreaseHeading_Click);
            // 
            // btnDecreaseHeading
            // 
            this.btnDecreaseHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDecreaseHeading.Location = new System.Drawing.Point(127, 154);
            this.btnDecreaseHeading.Name = "btnDecreaseHeading";
            this.btnDecreaseHeading.Size = new System.Drawing.Size(20, 22);
            this.btnDecreaseHeading.TabIndex = 40;
            this.btnDecreaseHeading.Text = "-";
            this.btnDecreaseHeading.UseVisualStyleBackColor = true;
            this.btnDecreaseHeading.Click += new System.EventHandler(this.btnDecreaseHeading_Click);
            // 
            // txtBoxSpeedValueRange
            // 
            this.txtBoxSpeedValueRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSpeedValueRange.Location = new System.Drawing.Point(462, 49);
            this.txtBoxSpeedValueRange.Multiline = true;
            this.txtBoxSpeedValueRange.Name = "txtBoxSpeedValueRange";
            this.txtBoxSpeedValueRange.ReadOnly = true;
            this.txtBoxSpeedValueRange.Size = new System.Drawing.Size(100, 46);
            this.txtBoxSpeedValueRange.TabIndex = 41;
            this.txtBoxSpeedValueRange.TextChanged += new System.EventHandler(this.txtBoxSpeedValueRange_TextChanged);
            // 
            // txtBoxFuelLevelValueRange
            // 
            this.txtBoxFuelLevelValueRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxFuelLevelValueRange.Location = new System.Drawing.Point(315, 49);
            this.txtBoxFuelLevelValueRange.Multiline = true;
            this.txtBoxFuelLevelValueRange.Name = "txtBoxFuelLevelValueRange";
            this.txtBoxFuelLevelValueRange.ReadOnly = true;
            this.txtBoxFuelLevelValueRange.Size = new System.Drawing.Size(100, 46);
            this.txtBoxFuelLevelValueRange.TabIndex = 42;
            this.txtBoxFuelLevelValueRange.TextChanged += new System.EventHandler(this.txtBoxFuelLevelValueRange_TextChanged);
            // 
            // txtBoxTempValueRange
            // 
            this.txtBoxTempValueRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTempValueRange.Location = new System.Drawing.Point(21, 51);
            this.txtBoxTempValueRange.Multiline = true;
            this.txtBoxTempValueRange.Name = "txtBoxTempValueRange";
            this.txtBoxTempValueRange.ReadOnly = true;
            this.txtBoxTempValueRange.Size = new System.Drawing.Size(100, 44);
            this.txtBoxTempValueRange.TabIndex = 44;
            this.txtBoxTempValueRange.TextChanged += new System.EventHandler(this.txtBoxTempValueRange_TextChanged);
            // 
            // txtBoxAltitudeValueRange
            // 
            this.txtBoxAltitudeValueRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxAltitudeValueRange.Location = new System.Drawing.Point(168, 51);
            this.txtBoxAltitudeValueRange.Multiline = true;
            this.txtBoxAltitudeValueRange.Name = "txtBoxAltitudeValueRange";
            this.txtBoxAltitudeValueRange.ReadOnly = true;
            this.txtBoxAltitudeValueRange.Size = new System.Drawing.Size(100, 46);
            this.txtBoxAltitudeValueRange.TabIndex = 45;
            this.txtBoxAltitudeValueRange.TextChanged += new System.EventHandler(this.txtBoxAltitudeValueRange_TextChanged);
            // 
            // txtBoxNumberPassengersValueRange
            // 
            this.txtBoxNumberPassengersValueRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxNumberPassengersValueRange.Location = new System.Drawing.Point(21, 279);
            this.txtBoxNumberPassengersValueRange.Multiline = true;
            this.txtBoxNumberPassengersValueRange.Name = "txtBoxNumberPassengersValueRange";
            this.txtBoxNumberPassengersValueRange.ReadOnly = true;
            this.txtBoxNumberPassengersValueRange.Size = new System.Drawing.Size(100, 46);
            this.txtBoxNumberPassengersValueRange.TabIndex = 46;
            this.txtBoxNumberPassengersValueRange.TextChanged += new System.EventHandler(this.txtBoxNumberPassengersValueRange_TextChanged);
            // 
            // txtBoxHeadingExp
            // 
            this.txtBoxHeadingExp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxHeadingExp.Location = new System.Drawing.Point(21, 168);
            this.txtBoxHeadingExp.Multiline = true;
            this.txtBoxHeadingExp.Name = "txtBoxHeadingExp";
            this.txtBoxHeadingExp.ReadOnly = true;
            this.txtBoxHeadingExp.Size = new System.Drawing.Size(100, 46);
            this.txtBoxHeadingExp.TabIndex = 47;
            // 
            // txtBoxWindExp
            // 
            this.txtBoxWindExp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxWindExp.Location = new System.Drawing.Point(168, 168);
            this.txtBoxWindExp.Multiline = true;
            this.txtBoxWindExp.Name = "txtBoxWindExp";
            this.txtBoxWindExp.ReadOnly = true;
            this.txtBoxWindExp.Size = new System.Drawing.Size(100, 46);
            this.txtBoxWindExp.TabIndex = 48;
            // 
            // txtBoxFlightRouteExp
            // 
            this.txtBoxFlightRouteExp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxFlightRouteExp.Location = new System.Drawing.Point(462, 168);
            this.txtBoxFlightRouteExp.Multiline = true;
            this.txtBoxFlightRouteExp.Name = "txtBoxFlightRouteExp";
            this.txtBoxFlightRouteExp.ReadOnly = true;
            this.txtBoxFlightRouteExp.Size = new System.Drawing.Size(100, 46);
            this.txtBoxFlightRouteExp.TabIndex = 49;
            // 
            // txtBoxPitch
            // 
            this.txtBoxPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxPitch.Location = new System.Drawing.Point(21, 361);
            this.txtBoxPitch.Name = "txtBoxPitch";
            this.txtBoxPitch.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPitch.TabIndex = 50;
            this.txtBoxPitch.TextChanged += new System.EventHandler(this.txtBoxPitch_TextChanged);
            // 
            // txtBoxRoll
            // 
            this.txtBoxRoll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxRoll.Location = new System.Drawing.Point(168, 361);
            this.txtBoxRoll.Name = "txtBoxRoll";
            this.txtBoxRoll.Size = new System.Drawing.Size(100, 20);
            this.txtBoxRoll.TabIndex = 51;
            this.txtBoxRoll.TextChanged += new System.EventHandler(this.txtBoxRoll_TextChanged);
            // 
            // txtBoxSlipSkidValue
            // 
            this.txtBoxSlipSkidValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSlipSkidValue.Location = new System.Drawing.Point(315, 361);
            this.txtBoxSlipSkidValue.Name = "txtBoxSlipSkidValue";
            this.txtBoxSlipSkidValue.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSlipSkidValue.TabIndex = 52;
            this.txtBoxSlipSkidValue.TextChanged += new System.EventHandler(this.txtBoxSlipSkidValue_TextChanged);
            // 
            // labelPitch
            // 
            this.labelPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(18, 345);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(61, 13);
            this.labelPitch.TabIndex = 53;
            this.labelPitch.Text = "Pitch Value";
            // 
            // labelRoll
            // 
            this.labelRoll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRoll.AutoSize = true;
            this.labelRoll.Location = new System.Drawing.Point(169, 345);
            this.labelRoll.Name = "labelRoll";
            this.labelRoll.Size = new System.Drawing.Size(55, 13);
            this.labelRoll.TabIndex = 54;
            this.labelRoll.Text = "Roll Value";
            // 
            // labelSlipSkid
            // 
            this.labelSlipSkid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSlipSkid.AutoSize = true;
            this.labelSlipSkid.Location = new System.Drawing.Point(312, 345);
            this.labelSlipSkid.Name = "labelSlipSkid";
            this.labelSlipSkid.Size = new System.Drawing.Size(45, 13);
            this.labelSlipSkid.TabIndex = 55;
            this.labelSlipSkid.Text = "SlipSkid";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 468);
            this.Controls.Add(this.labelSlipSkid);
            this.Controls.Add(this.labelRoll);
            this.Controls.Add(this.labelPitch);
            this.Controls.Add(this.txtBoxSlipSkidValue);
            this.Controls.Add(this.txtBoxRoll);
            this.Controls.Add(this.txtBoxPitch);
            this.Controls.Add(this.txtBoxFlightRouteExp);
            this.Controls.Add(this.txtBoxWindExp);
            this.Controls.Add(this.txtBoxHeadingExp);
            this.Controls.Add(this.txtBoxNumberPassengersValueRange);
            this.Controls.Add(this.txtBoxAltitudeValueRange);
            this.Controls.Add(this.txtBoxTempValueRange);
            this.Controls.Add(this.txtBoxFuelLevelValueRange);
            this.Controls.Add(this.txtBoxSpeedValueRange);
            this.Controls.Add(this.btnDecreaseHeading);
            this.Controls.Add(this.btnIncreaseHeading);
            this.Controls.Add(this.btnDecreaseNumberPassengers);
            this.Controls.Add(this.btnDecreaseSpeed);
            this.Controls.Add(this.btnDecreaseFuelLevel);
            this.Controls.Add(this.btnDecreaseAltitude);
            this.Controls.Add(this.btnIncreaseNumberPassengers);
            this.Controls.Add(this.btnIncreaseSpeed);
            this.Controls.Add(this.btnIncreaseFuelLevel);
            this.Controls.Add(this.buttonIncreaseAltitude);
            this.Controls.Add(this.btnDecreaseTemp);
            this.Controls.Add(this.btnIncreaseTemp);
            this.Controls.Add(this.comboBoxAircraftModel);
            this.Controls.Add(this.comboBoxAircraftType);
            this.Controls.Add(this.comboBoxCabinStatus);
            this.Controls.Add(this.comboBoxWeather);
            this.Controls.Add(this.labelAircraftModel);
            this.Controls.Add(this.labelAircraftType);
            this.Controls.Add(this.txtNumberPassengers);
            this.Controls.Add(this.txtBoxAltitude);
            this.Controls.Add(this.txtBoxFuelLevel);
            this.Controls.Add(this.txtBoxSpeed);
            this.Controls.Add(this.txtBoxHeading);
            this.Controls.Add(this.txtBoxWindInfo);
            this.Controls.Add(this.txtFlightRoute);
            this.Controls.Add(this.btnSaveInfo);
            this.Controls.Add(this.labelCabinStatus);
            this.Controls.Add(this.labelNumberPassengers);
            this.Controls.Add(this.labelFlightRoute);
            this.Controls.Add(this.labelWeather);
            this.Controls.Add(this.labelWindInformation);
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelFuelLevel);
            this.Controls.Add(this.labelAltitude);
            this.Controls.Add(this.txtBoxTemperature);
            this.Controls.Add(this.labelTemperature);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.TextBox txtBoxTemperature;
        private System.Windows.Forms.Label labelAltitude;
        private System.Windows.Forms.Label labelFuelLevel;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Label labelWindInformation;
        private System.Windows.Forms.Label labelWeather;
        private System.Windows.Forms.Label labelFlightRoute;
        private System.Windows.Forms.Label labelNumberPassengers;
        private System.Windows.Forms.Label labelCabinStatus;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.TextBox txtFlightRoute;
        private System.Windows.Forms.TextBox txtBoxWindInfo;
        private System.Windows.Forms.TextBox txtBoxHeading;
        private System.Windows.Forms.TextBox txtBoxSpeed;
        private System.Windows.Forms.TextBox txtBoxFuelLevel;
        private System.Windows.Forms.TextBox txtBoxAltitude;
        private System.Windows.Forms.TextBox txtNumberPassengers;
        private System.Windows.Forms.Label labelAircraftType;
        private System.Windows.Forms.Label labelAircraftModel;
        private System.Windows.Forms.ComboBox comboBoxWeather;
        private System.Windows.Forms.ComboBox comboBoxCabinStatus;
        private System.Windows.Forms.ComboBox comboBoxAircraftType;
        private System.Windows.Forms.ComboBox comboBoxAircraftModel;
        private System.Windows.Forms.Button btnIncreaseTemp;
        private System.Windows.Forms.Button btnDecreaseTemp;
        private System.Windows.Forms.Button buttonIncreaseAltitude;
        private System.Windows.Forms.Button btnIncreaseFuelLevel;
        private System.Windows.Forms.Button btnIncreaseSpeed;
        private System.Windows.Forms.Button btnIncreaseNumberPassengers;
        private System.Windows.Forms.Button btnDecreaseAltitude;
        private System.Windows.Forms.Button btnDecreaseFuelLevel;
        private System.Windows.Forms.Button btnDecreaseSpeed;
        private System.Windows.Forms.Button btnDecreaseNumberPassengers;
        private System.Windows.Forms.Button btnIncreaseHeading;
        private System.Windows.Forms.Button btnDecreaseHeading;
        private System.Windows.Forms.TextBox txtBoxSpeedValueRange;
        private System.Windows.Forms.TextBox txtBoxFuelLevelValueRange;
        private System.Windows.Forms.TextBox txtBoxTempValueRange;
        private System.Windows.Forms.TextBox txtBoxAltitudeValueRange;
        private System.Windows.Forms.TextBox txtBoxNumberPassengersValueRange;
        private System.Windows.Forms.TextBox txtBoxHeadingExp;
        private System.Windows.Forms.TextBox txtBoxWindExp;
        private System.Windows.Forms.TextBox txtBoxFlightRouteExp;
        private System.Windows.Forms.TextBox txtBoxPitch;
        private System.Windows.Forms.TextBox txtBoxRoll;
        private System.Windows.Forms.TextBox txtBoxSlipSkidValue;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelRoll;
        private System.Windows.Forms.Label labelSlipSkid;
    }
}

