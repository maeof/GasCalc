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
            this.MapTrip = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.MapTrip.Location = new System.Drawing.Point(34, 12);
            this.MapTrip.MarkersEnabled = true;
            this.MapTrip.MaxZoom = 18;
            this.MapTrip.MinZoom = 1;
            this.MapTrip.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapTrip.Name = "MapTrip";
            this.MapTrip.NegativeMode = false;
            this.MapTrip.PolygonsEnabled = true;
            this.MapTrip.RetryLoadTile = 0;
            this.MapTrip.RoutesEnabled = true;
            this.MapTrip.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapTrip.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapTrip.ShowTileGridLines = false;
            this.MapTrip.Size = new System.Drawing.Size(899, 329);
            this.MapTrip.TabIndex = 0;
            this.MapTrip.Zoom = 2D;
            this.MapTrip.OnPositionChanged += new GMap.NET.PositionChanged(this.MapTrip_OnPositionChanged);
            this.MapTrip.OnMapDrag += new GMap.NET.MapDrag(this.MapTrip_OnMapDrag);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(497, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 384);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MapTrip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapTrip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

