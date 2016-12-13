namespace GasCalc
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MapTrip = new GMap.NET.WindowsForms.GMapControl();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LblHelpTextEndingPoint = new System.Windows.Forms.Label();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ListViewEmployeeTrip = new System.Windows.Forms.ListView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.LblFromText = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.LblToText = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.LblPrognosisDistance = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.LblPrognosisFuelConsumption = new System.Windows.Forms.Label();
            this.ButtonPostTrip = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gasCalcDataSet = new GasCalc.GasCalcDataSet();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxVehicle = new System.Windows.Forms.ComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gasCalcDataSetVehicle = new GasCalc.GasCalcDataSetVehicle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBoxReason = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.updateButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.employeeTableAdapter = new GasCalc.GasCalcDataSetTableAdapters.EmployeeTableAdapter();
            this.vehicleTableAdapter = new GasCalc.GasCalcDataSetVehicleTableAdapters.VehicleTableAdapter();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.UpdateEmployees = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel12.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSet)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSetVehicle)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapTrip
            // 
            this.MapTrip.Bearing = 0F;
            this.MapTrip.CanDragMap = true;
            this.MapTrip.EmptyTileColor = System.Drawing.Color.Navy;
            this.MapTrip.GrayScaleMode = false;
            this.MapTrip.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapTrip.LevelsKeepInMemmory = 5;
            this.MapTrip.Location = new System.Drawing.Point(228, 22);
            this.MapTrip.MarkersEnabled = true;
            this.MapTrip.MaxZoom = 16;
            this.MapTrip.MinZoom = 6;
            this.MapTrip.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapTrip.Name = "MapTrip";
            this.MapTrip.NegativeMode = false;
            this.MapTrip.PolygonsEnabled = true;
            this.MapTrip.RetryLoadTile = 0;
            this.MapTrip.RoutesEnabled = true;
            this.MapTrip.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapTrip.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapTrip.ShowTileGridLines = false;
            this.MapTrip.Size = new System.Drawing.Size(1106, 484);
            this.MapTrip.TabIndex = 0;
            this.MapTrip.Zoom = 6D;
            this.MapTrip.OnPositionChanged += new GMap.NET.PositionChanged(this.MapTrip_OnPositionChanged);
            this.MapTrip.OnMapDrag += new GMap.NET.MapDrag(this.MapTrip_OnMapDrag);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1350, 729);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblHelpTextEndingPoint);
            this.tabPage1.Controls.Add(this.flowLayoutPanel12);
            this.tabPage1.Controls.Add(this.flowLayoutPanel8);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.MapTrip);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1342, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Plan a Trip";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblHelpTextEndingPoint
            // 
            this.LblHelpTextEndingPoint.AutoSize = true;
            this.LblHelpTextEndingPoint.Location = new System.Drawing.Point(520, 6);
            this.LblHelpTextEndingPoint.Name = "LblHelpTextEndingPoint";
            this.LblHelpTextEndingPoint.Size = new System.Drawing.Size(270, 13);
            this.LblHelpTextEndingPoint.TabIndex = 8;
            this.LblHelpTextEndingPoint.Text = "Now double click the map again to set the ending point.";
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.Controls.Add(this.groupBox6);
            this.flowLayoutPanel12.Controls.Add(this.groupBox7);
            this.flowLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel12.Location = new System.Drawing.Point(3, 512);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(1336, 188);
            this.flowLayoutPanel12.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ListViewEmployeeTrip);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 180);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Selected employee";
            // 
            // ListViewEmployeeTrip
            // 
            this.ListViewEmployeeTrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewEmployeeTrip.Location = new System.Drawing.Point(3, 16);
            this.ListViewEmployeeTrip.Name = "ListViewEmployeeTrip";
            this.ListViewEmployeeTrip.Size = new System.Drawing.Size(336, 161);
            this.ListViewEmployeeTrip.TabIndex = 0;
            this.ListViewEmployeeTrip.UseCompatibleStateImageBehavior = false;
            this.ListViewEmployeeTrip.View = System.Windows.Forms.View.SmallIcon;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(351, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(284, 180);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Selected vehicle";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.groupBox2);
            this.flowLayoutPanel8.Controls.Add(this.button3);
            this.flowLayoutPanel8.Controls.Add(this.ButtonPostTrip);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 246);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(219, 258);
            this.flowLayoutPanel8.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trip details (prognosis)";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(194, 148);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.LblFromText);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(91, 13);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "From:";
            // 
            // LblFromText
            // 
            this.LblFromText.AutoSize = true;
            this.LblFromText.Location = new System.Drawing.Point(42, 0);
            this.LblFromText.Name = "LblFromText";
            this.LblFromText.Size = new System.Drawing.Size(46, 13);
            this.LblFromText.TabIndex = 1;
            this.LblFromText.Text = "             ";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Controls.Add(this.LblToText);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(90, 13);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "To:";
            // 
            // LblToText
            // 
            this.LblToText.AutoSize = true;
            this.LblToText.Location = new System.Drawing.Point(32, 0);
            this.LblToText.Name = "LblToText";
            this.LblToText.Size = new System.Drawing.Size(55, 13);
            this.LblToText.TabIndex = 1;
            this.LblToText.Text = "                ";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.Controls.Add(this.label7);
            this.flowLayoutPanel6.Controls.Add(this.LblPrognosisDistance);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 41);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(154, 13);
            this.flowLayoutPanel6.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Distance (km):";
            // 
            // LblPrognosisDistance
            // 
            this.LblPrognosisDistance.AutoSize = true;
            this.LblPrognosisDistance.Location = new System.Drawing.Point(84, 0);
            this.LblPrognosisDistance.Name = "LblPrognosisDistance";
            this.LblPrognosisDistance.Size = new System.Drawing.Size(67, 13);
            this.LblPrognosisDistance.TabIndex = 1;
            this.LblPrognosisDistance.Text = "                    ";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.Controls.Add(this.label9);
            this.flowLayoutPanel7.Controls.Add(this.LblPrognosisFuelConsumption);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 60);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(145, 26);
            this.flowLayoutPanel7.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Estimated fuel consumption:";
            // 
            // LblPrognosisFuelConsumption
            // 
            this.LblPrognosisFuelConsumption.AutoSize = true;
            this.LblPrognosisFuelConsumption.Location = new System.Drawing.Point(3, 13);
            this.LblPrognosisFuelConsumption.Name = "LblPrognosisFuelConsumption";
            this.LblPrognosisFuelConsumption.Size = new System.Drawing.Size(52, 13);
            this.LblPrognosisFuelConsumption.TabIndex = 5;
            this.LblPrognosisFuelConsumption.Text = "               ";
            // 
            // ButtonPostTrip
            // 
            this.ButtonPostTrip.Location = new System.Drawing.Point(3, 205);
            this.ButtonPostTrip.Name = "ButtonPostTrip";
            this.ButtonPostTrip.Size = new System.Drawing.Size(199, 36);
            this.ButtonPostTrip.TabIndex = 4;
            this.ButtonPostTrip.Text = "Post";
            this.ButtonPostTrip.UseVisualStyleBackColor = true;
            this.ButtonPostTrip.Click += new System.EventHandler(this.ButtonPostTrip_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(228, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(285, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Double click on the map to set the start point of your travel.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(219, 237);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.ComboBoxEmployee);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(194, 45);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee:";
            // 
            // ComboBoxEmployee
            // 
            this.ComboBoxEmployee.DataSource = this.employeeBindingSource;
            this.ComboBoxEmployee.DisplayMember = "Firstname";
            this.ComboBoxEmployee.FormattingEnabled = true;
            this.ComboBoxEmployee.Location = new System.Drawing.Point(3, 16);
            this.ComboBoxEmployee.Name = "ComboBoxEmployee";
            this.ComboBoxEmployee.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxEmployee.TabIndex = 1;
            this.ComboBoxEmployee.ValueMember = "EmployeeNo";
            this.ComboBoxEmployee.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEmployee_SelectedIndexChanged);
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.gasCalcDataSet;
            // 
            // gasCalcDataSet
            // 
            this.gasCalcDataSet.DataSetName = "GasCalcDataSet";
            this.gasCalcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel9);
            this.groupBox4.Location = new System.Drawing.Point(3, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 64);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vehicle";
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.label2);
            this.flowLayoutPanel9.Controls.Add(this.ComboBoxVehicle);
            this.flowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(196, 45);
            this.flowLayoutPanel9.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vehicle used:";
            // 
            // ComboBoxVehicle
            // 
            this.ComboBoxVehicle.DataSource = this.vehicleBindingSource;
            this.ComboBoxVehicle.DisplayMember = "Model";
            this.ComboBoxVehicle.FormattingEnabled = true;
            this.ComboBoxVehicle.Location = new System.Drawing.Point(3, 16);
            this.ComboBoxVehicle.Name = "ComboBoxVehicle";
            this.ComboBoxVehicle.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxVehicle.TabIndex = 3;
            this.ComboBoxVehicle.ValueMember = "VehicleNo";
            this.ComboBoxVehicle.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVehicle_SelectedIndexChanged);
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataMember = "Vehicle";
            this.vehicleBindingSource.DataSource = this.gasCalcDataSetVehicle;
            // 
            // gasCalcDataSetVehicle
            // 
            this.gasCalcDataSetVehicle.DataSetName = "GasCalcDataSetVehicle";
            this.gasCalcDataSetVehicle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.flowLayoutPanel10);
            this.groupBox5.Location = new System.Drawing.Point(3, 143);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(202, 94);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trip details";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(196, 75);
            this.flowLayoutPanel10.TabIndex = 0;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.AutoSize = true;
            this.flowLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel11.Controls.Add(this.label10);
            this.flowLayoutPanel11.Controls.Add(this.TxtBoxReason);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(193, 72);
            this.flowLayoutPanel11.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Reason and premises of the trip:";
            // 
            // TxtBoxReason
            // 
            this.TxtBoxReason.Location = new System.Drawing.Point(3, 16);
            this.TxtBoxReason.MaxLength = 100;
            this.TxtBoxReason.Multiline = true;
            this.TxtBoxReason.Name = "TxtBoxReason";
            this.TxtBoxReason.Size = new System.Drawing.Size(187, 53);
            this.TxtBoxReason.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.updateButton);
            this.tabPage2.Controls.Add(this.reloadButton);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1342, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quick view";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(302, 317);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "button4";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(220, 317);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(75, 23);
            this.reloadButton.TabIndex = 1;
            this.reloadButton.Text = "relaod";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(369, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "4.png");
            this.imageList1.Images.SetKeyName(1, "9.png");
            this.imageList1.Images.SetKeyName(2, "10.png");
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // vehicleTableAdapter
            // 
            this.vehicleTableAdapter.ClearBeforeFill = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.UpdateEmployees);
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1342, 703);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Employees";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1336, 697);
            this.listView1.TabIndex = 4;
            this.listView1.TileSize = new System.Drawing.Size(250, 250);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // UpdateEmployees
            // 
            this.UpdateEmployees.Location = new System.Drawing.Point(31, 479);
            this.UpdateEmployees.Name = "UpdateEmployees";
            this.UpdateEmployees.Size = new System.Drawing.Size(75, 23);
            this.UpdateEmployees.TabIndex = 5;
            this.UpdateEmployees.Text = "Update employees";
            this.UpdateEmployees.UseVisualStyleBackColor = true;
            this.UpdateEmployees.Click += new System.EventHandler(this.UpdateEmployees_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1342, 703);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "History/journal";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1320, 577);
            this.Name = "Form1";
            this.Text = "GasCalc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.flowLayoutPanel8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSet)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSetVehicle)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapTrip;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxVehicle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblFromText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblToText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblPrognosisDistance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblPrognosisFuelConsumption;
        private System.Windows.Forms.Label label8;
        private GasCalcDataSet gasCalcDataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private GasCalcDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private GasCalcDataSetVehicle gasCalcDataSetVehicle;
        private System.Windows.Forms.BindingSource vehicleBindingSource;
        private GasCalcDataSetVehicleTableAdapters.VehicleTableAdapter vehicleTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Button ButtonPostTrip;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.TextBox TxtBoxReason;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView ListViewEmployeeTrip;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label LblHelpTextEndingPoint;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button UpdateEmployees;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

