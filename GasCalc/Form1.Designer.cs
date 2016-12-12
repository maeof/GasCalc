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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gasCalcDataSet = new GasCalc.GasCalcDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxVehicle = new System.Windows.Forms.ComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gasCalcDataSetVehicle = new GasCalc.GasCalcDataSetVehicle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.LblPrognosisDistance = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.LblPrognosisFuelConsumption = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UpdateEmployees = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.updateButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.employeeTableAdapter = new GasCalc.GasCalcDataSetTableAdapters.EmployeeTableAdapter();
            this.vehicleTableAdapter = new GasCalc.GasCalcDataSetVehicleTableAdapters.VehicleTableAdapter();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPostTrip = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSetVehicle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
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
            this.MapTrip.Size = new System.Drawing.Size(1062, 484);
            this.MapTrip.TabIndex = 0;
            this.MapTrip.Zoom = 6D;
            this.MapTrip.OnPositionChanged += new GMap.NET.PositionChanged(this.MapTrip_OnPositionChanged);
            this.MapTrip.OnMapDrag += new GMap.NET.MapDrag(this.MapTrip_OnMapDrag);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 135);
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1304, 538);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel8);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.MapTrip);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1296, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Plan a Business Trip";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(228, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(346, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Double click on the map to set the start and ending points of your travel.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
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
            this.groupBox1.Size = new System.Drawing.Size(197, 106);
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(191, 87);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 126);
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
            this.flowLayoutPanel3.Size = new System.Drawing.Size(194, 107);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(80, 13);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(70, 13);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
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
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(3, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(91, 32);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trip details (fact)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UpdateEmployees);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.updateButton);
            this.tabPage2.Controls.Add(this.reloadButton);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1296, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UpdateEmployees
            // 
            this.UpdateEmployees.Location = new System.Drawing.Point(622, 317);
            this.UpdateEmployees.Name = "UpdateEmployees";
            this.UpdateEmployees.Size = new System.Drawing.Size(75, 23);
            this.UpdateEmployees.TabIndex = 4;
            this.UpdateEmployees.Text = "button4";
            this.UpdateEmployees.UseVisualStyleBackColor = true;
            this.UpdateEmployees.Click += new System.EventHandler(this.UpdateEmployees_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(384, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(422, 277);
            this.listView1.TabIndex = 3;
            this.listView1.TileSize = new System.Drawing.Size(250, 250);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
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
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.groupBox2);
            this.flowLayoutPanel8.Controls.Add(this.groupBox3);
            this.flowLayoutPanel8.Controls.Add(this.button3);
            this.flowLayoutPanel8.Controls.Add(this.button2);
            this.flowLayoutPanel8.Controls.Add(this.button1);
            this.flowLayoutPanel8.Controls.Add(this.ButtonPostTrip);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 246);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(219, 258);
            this.flowLayoutPanel8.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel9);
            this.groupBox4.Location = new System.Drawing.Point(3, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 106);
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
            this.flowLayoutPanel9.Size = new System.Drawing.Size(196, 87);
            this.flowLayoutPanel9.TabIndex = 0;
            // 
            // ButtonPostTrip
            // 
            this.ButtonPostTrip.Location = new System.Drawing.Point(3, 202);
            this.ButtonPostTrip.Name = "ButtonPostTrip";
            this.ButtonPostTrip.Size = new System.Drawing.Size(75, 23);
            this.ButtonPostTrip.TabIndex = 4;
            this.ButtonPostTrip.Text = "Post";
            this.ButtonPostTrip.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 538);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "GasCalc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gasCalcDataSetVehicle)).EndInit();
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
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapTrip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button UpdateEmployees;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxVehicle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
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
    }
}

