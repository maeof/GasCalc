﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace GasCalc
{
    public partial class Form1 : Form
    {
        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");

        bool first = true;
        PointLatLng start;
        PointLatLng end;
        
        //--
        BindingSource bindingSource1 = new BindingSource();            
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GasCalc;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {            
            vehicleTableAdapter.Fill(this.gasCalcDataSetVehicle.Vehicle);            
            employeeTableAdapter.Fill(this.gasCalcDataSet.Employee);

            dataGridView1.DataSource = bindingSource1;
            GetData("select VehicleNo, LicensePlate, Model, FuelConsumptionPer100 from Vehicle", ref bindingSource1, ref dataAdapter);

            MapTrip.MapProvider = BingMapProvider.Instance;                                              
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            MapTrip.SetPositionByKeywords("Lithuania");

            //MapTrip.OnMapDrag += MapTrip_OnMapDrag;
            MapTrip.DoubleClick += MapTrip_DoubleClick;
            MapTrip.MouseDoubleClick += MapTrip_MouseDoubleClick;

            MapTrip.Overlays.Add(routes);
            MapTrip.Overlays.Add(polygons);
            MapTrip.Overlays.Add(objects);
            MapTrip.Overlays.Add(top);

            LblHelpTextEndingPoint.Visible = false;                                                        
        }

        private void MapTrip_MouseDoubleClick(object sender, MouseEventArgs e)
        {                        
            if (first)
            {
                MapTrip.Overlays.Clear();

                start = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);
                PaintMarkerOnMap(MapTrip, start, "Start", GMarkerGoogleType.green_big_go);

                LblHelpTextEndingPoint.Visible = true;
                first = false;
            }
            else
            {
                end = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);
                PaintMarkerOnMap(MapTrip, end, "End", GMarkerGoogleType.red_big_stop);
                MapRoute thisRoute = PaintRouteOnMap(MapTrip, start, end);
                Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxVehicle);
                
                SetPrognosisLabels(thisRoute, thisVehicle);

                LblHelpTextEndingPoint.Visible = false;
                first = true;
            }
        }

        // move this method
        public Vehicle GetSelectedVehicleFrom(ComboBox thisComboBox)
        {
            Vehicle Vehicle = null;
            using (var ctx = new GasCalcEntities())
            {
                try
                {
                    Vehicle = ctx.Vehicles.Find((int)thisComboBox.SelectedValue);
                }
                catch { }
            }
            return Vehicle;
        }

        private Employee GetSelectedEmployeeFrom(ComboBox thisComboBox)
        {
            Employee Employee = null;
            using (var ctx = new GasCalcEntities())
            {
                try
                {
                    Employee = ctx.Employees.Find((int)thisComboBox.SelectedValue);
                }
                catch { }
            }
            return Employee;
        }

        private void SetPrognosisLabels(MapRoute Route, Vehicle Vehicle)
        {
            if (Route != null)
            {
                UpdateDistanceLabel(Route);
                UpdateFromToTextLabels(Route);
            }

            if (Route != null & Vehicle != null)
                UpdateFuelConsumptionLabel(Route, Vehicle);                                              
        }

        private void UpdateFromToTextLabels(MapRoute Route)
        {            
            XElement From = GoogleApi.GetResponseFromGeocoding(Route.From.Value);
            XElement To = GoogleApi.GetResponseFromGeocoding(Route.To.Value);

            LblFromText.Text = GoogleApi.ExtractAddressFromResponse(From);
            LblToText.Text = GoogleApi.ExtractAddressFromResponse(To);
        }

        private void UpdateDistanceLabel(MapRoute Route)
        {
            if (Route != null)
                LblPrognosisDistance.Text = Math.Round(Route.Distance, 2).ToString();
        }

        private void UpdateFuelConsumptionLabel(MapRoute Route, Vehicle Vehicle)
        {
            if (Route != null && Vehicle != null)
                LblPrognosisFuelConsumption.Text = CalcFuelConsumption((decimal)Route.Distance, Vehicle.FuelConsumptionPer100).ToString();
        }

        //deprecated
        private void UpdateLabel (Label thisLabel, string thisText)
        {
            if (thisLabel != null)
                thisLabel.Text = thisText;
        }

        // move this method
        public decimal CalcFuelConsumption(decimal Distance, decimal FuelConsumption)
        {
            return Math.Round((FuelConsumption * Distance) / 100, 2);
        }

        // move
        private void PaintMarkerOnMap(GMapControl Map, PointLatLng Point, string TooltipText, GMarkerGoogleType MarkerType)
        {
            GMapOverlay MapObjects = new GMapOverlay("mapobjects");
            Map.Overlays.Add(MapObjects);

            GMapMarker m = new GMarkerGoogle(Point, MarkerType);
            m.ToolTipText = TooltipText;
            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            MapObjects.Markers.Add(m);
        }

        private void MapTrip_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
        }

        private void MapTrip_OnMapDrag()
        {
            //MessageBox.Show("test");
        }

        private void MapTrip_OnPositionChanged(PointLatLng point)
        {
            //Point test = new Point();
            //MessageBox.Show(point.ToString());
        }
        
        //move this
        private MapRoute PaintRouteOnMap(GMapControl Map, PointLatLng Start, PointLatLng End)
        {                        
            GMapOverlay MapRoutes = new GMapOverlay("maproutes");
            //MapTrip.Overlays.Add(MapRoutes);
            Map.Overlays.Add(MapRoutes);

            RoutingProvider rp = Map.MapProvider as RoutingProvider;

            MapRoute route = rp.GetRoute(Start, End, false, false, (int)Map.Zoom);
            if (route != null)
            {                
                GMapRoute r = new GMapRoute(route.Points, route.Name);
                r.IsHitTestVisible = true;
                MapRoutes.Routes.Add(r);
                                
                Map.ZoomAndCenterRoute(r);
            }
            return route;
        }

        //move this
        private MapRoute GetActiveRoute(GMapControl Map)
        {
            foreach (GMapOverlay thisOverlay in Map.Overlays)
            {
                foreach (GMapRoute thisRoute in thisOverlay.Routes)
                {
                    return thisRoute;
                }
            }
            return null;
        }

        private void SqlExecute(string Query, out SqlDataReader DataReader)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GasCalc;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Query;

            DataReader = cmd.ExecuteReader();
        }

        //temp
        private void button3_Click(object sender, EventArgs e)
        {
            MapRoute test = GetActiveRoute(MapTrip);            
            MessageBox.Show("test.Points.Count = " + test.Points.Count);            
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText, ref bindingSource1, ref dataAdapter);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {            
            dataAdapter.Update((DataTable)bindingSource1.DataSource);

            UpdateComboBoxEmployee();
            UpdateComboBoxVehicle();
        }
        
        private void UpdateComboBoxVehicle()
        {
            vehicleTableAdapter.Fill(gasCalcDataSetVehicle.Vehicle);
            ComboBoxVehicle.DataSource = vehicleBindingSource;
        }

        private void UpdateComboBoxEmployee()
        {
            employeeTableAdapter.Fill(gasCalcDataSet.Employee);
            ComboBoxEmployee.DataSource = employeeBindingSource;
        }

        private void GetData(string Query, ref BindingSource BindingSource, ref SqlDataAdapter DataAdapter)
        {                      
            try                
            {                             
                DataAdapter = new SqlDataAdapter(Query, ConnectionString);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(DataAdapter);                
                DataTable table = new DataTable();               
                                
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter.Fill(table);
                BindingSource.DataSource = table;                              
            }
            catch (SqlException)
            {
                MessageBox.Show("Could not retrieve from DB.");
            }
        }      

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void UpdateEmployees_Click(object sender, EventArgs e)
        {
            SqlDataReader ReadEmployees;            
            ImageList EmployeeImages = new ImageList();
            int EmployeeImageIndex = 0;
            
            SqlExecute("SELECT EmployeeNo, Firstname, Lastname FROM Employee", out ReadEmployees);

            EmployeeImages.ImageSize = new Size(150, 150);
            listView1.SmallImageList = EmployeeImages;
            listView1.LargeImageList = EmployeeImages;

            // method:
            if (ReadEmployees.HasRows)
            {
                while (ReadEmployees.Read())
                {                    
                    using (SqlConnection cn = new SqlConnection(ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT Image FROM EmployeeImage WHERE EmployeeNo=" +
                            ReadEmployees["EmployeeNo"];
                        cn.Open();

                        object ExpectedImage = cmd.ExecuteScalar();
                        if (ExpectedImage != null)
                        {
                            Image EmployeeImage = ByteArrayToImage((byte[])ExpectedImage);
                            EmployeeImages.Images.Add(EmployeeImageIndex.ToString(), EmployeeImage);                        
                        }

                        cn.Close();
                    }

                    ListViewItem tile = new ListViewItem(
                        ReadEmployees["Firstname"] + " " + ReadEmployees["Lastname"],
                        EmployeeImageIndex.ToString());
                    
                    EmployeeImageIndex++;
                    listView1.Items.Add(tile);
                }
            }
            ReadEmployees.Close();
            //SqlExecute -? cn.Close();
        }

        private void ComboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxVehicle);
            MapRoute thisMapRoute = GetActiveRoute(MapTrip);
            SetPrognosisLabels(thisMapRoute, thisVehicle);
        }

        public Image GetEmployeeImage(Employee Employee)
        {                            
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Image FROM EmployeeImage WHERE EmployeeNo=" + Employee.EmployeeNo;
                    cn.Open();

                    object ExpectedImage = cmd.ExecuteScalar();
                    Image EmployeeImageConverted = null;
                    if (ExpectedImage != null)
                    {
                        EmployeeImageConverted = ByteArrayToImage((byte[])ExpectedImage);
                    }

                    cn.Close();
                    return EmployeeImageConverted;
                }
                catch
                {                    
                    return null;
                }
            }                                                
        }

        public void FillEmployeeViewTo(ListView ListView, Employee thisEmployee)
        {
            try
            {
                Image EmployeeImageDb = GetEmployeeImage(thisEmployee);
                ImageList EmployeeImages = new ImageList();

                int EmployeeImageIndex = 0;

                if (EmployeeImageDb != null)
                    EmployeeImages.Images.Add(EmployeeImageIndex.ToString(), EmployeeImageDb);

                EmployeeImages.ImageSize = new Size(150, 150);
                ListView.SmallImageList = EmployeeImages;
                ListView.LargeImageList = EmployeeImages;

                ListViewItem tile = new ListViewItem(
                    thisEmployee.Position + " " + thisEmployee.Firstname + " " + thisEmployee.Lastname,
                    EmployeeImageIndex.ToString());

                EmployeeImageIndex++;
                ListView.Items.Add(tile);
            }
            catch { }
        }

        private void ButtonPostTrip_Click(object sender, EventArgs e)
        {
            try
            {
                Employee thisEmployee = GetSelectedEmployeeFrom(ComboBoxEmployee);
                Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxVehicle);
                MapRoute thisMapRoute = GetActiveRoute(MapTrip);                                

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO dbo.Trip(VehicleNo, EmployeeNo," +
                                  "FromText, ToText, FromLatitude, FromLongitude," +
                                  "ToLatitude, ToLongitude, Distance, FuelConsumption," +
                                  "PostingDate, Reason)" +
                                  "VALUES (@VehicleNo, @EmployeeNo, @FromText, @ToText," +
                                  "@FromLatitude, @FromLongitude, @ToLatitude, @ToLongitude," +
                                  "@Distance, @FuelConsumption, @PostingDate, @Reason)";

                cmd.Parameters.AddWithValue("@VehicleNo", thisVehicle.VehicleNo);
                cmd.Parameters.AddWithValue("@EmployeeNo", thisEmployee.EmployeeNo);                
                cmd.Parameters.AddWithValue("@FromText", LblFromText.Text);                
                cmd.Parameters.AddWithValue("@ToText", LblToText.Text);
                cmd.Parameters.AddWithValue("@FromLatitude", thisMapRoute.Points.First().Lat);
                cmd.Parameters.AddWithValue("@FromLongitude", thisMapRoute.Points.First().Lng);
                cmd.Parameters.AddWithValue("@ToLatitude", thisMapRoute.Points.Last().Lat);
                cmd.Parameters.AddWithValue("@ToLongitude", thisMapRoute.Points.Last().Lng);
                cmd.Parameters.AddWithValue("@Distance", thisMapRoute.Distance);
                cmd.Parameters.AddWithValue("@FuelConsumption", CalcFuelConsumption((decimal)thisMapRoute.Distance, thisVehicle.FuelConsumptionPer100));
                cmd.Parameters.AddWithValue("@PostingDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@Reason", TxtBoxReason.Text);

                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("The trip has been successfully registered.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Not all needed parameters are set: " + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong with the SQL: " + ex.Message);
            }
        }

        private void ComboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewEmployeeTrip.Items.Clear();
            FillEmployeeViewTo(ListViewEmployeeTrip, GetSelectedEmployeeFrom(ComboBoxEmployee));
        }
    }
}
