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
using System.Windows.Forms.DataVisualization.Charting;

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
            GetData("SELECT VehicleNo, LicensePlate, Model, FuelConsumptionPer100 FROM Vehicle", ref bindingSource1, ref dataAdapter);

            MapTrip.MapProvider = BingMapProvider.Instance;                                              
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            MapTrip.SetPositionByKeywords("Lithuania");

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
                MapControls.PaintMarkerOnMap(MapTrip, start, "Start", GMarkerGoogleType.green_big_go);

                LblHelpTextEndingPoint.Visible = true;
                first = false;
            }
            else
            {
                end = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);
                MapControls.PaintMarkerOnMap(MapTrip, end, "End", GMarkerGoogleType.red_big_stop);
                MapRoute thisRoute = MapControls.PaintRouteOnMap(MapTrip, start, end);
                Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxVehicle);
                
                SetPrognosisLabels(thisRoute, thisVehicle);

                LblHelpTextEndingPoint.Visible = false;
                first = true;
            }
        }
        
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

        private Trip GetTripById(int ID)
        {
            Trip Trip = null;
            using (var ctx = new GasCalcEntities())
            {
                try
                {
                    Trip = ctx.Trips.Find(ID);
                }
                catch { }
            }
            return Trip;
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
                LblPrognosisFuelConsumption.Text = GasCalcFlow.CalcFuelConsumption((decimal)Route.Distance, Vehicle.FuelConsumptionPer100).ToString();
        }


        private void MapTrip_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void MapTrip_OnMapDrag()
        {
            
        }

        private void MapTrip_OnPositionChanged(PointLatLng point)
        {

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

        public T SqlExecute<T>(string Query, Func<SqlDataReader, T> projection)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand(Query, cn))
                {
                    //cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {
                        return projection(reader);
                    }
                    
                }
            }
        
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
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
            ImageList EmployeeImagesList = new ImageList();
            int EmployeeImageIndex = 0;
            
           // SqlExecute("SELECT EmployeeNo, Firstname, Lastname FROM Employee", out ReadEmployees);

            var employees = SqlExecute("SELECT EmployeeNo, Firstname, Lastname FROM Employee", r =>
            {
                List<Employee> result = new List<Employee>();
                while (r.Read())
                {
                    result.Add(new Employee {
                        EmployeeNo = (int)r["EmployeeNo"],
                        Firstname = (string)r["Firstname"],
                        Lastname = (string)r["Lastname"]
                    });
                }
                
                return result;
            });

            EmployeeImagesList.ImageSize = new Size(150, 150);
            listView1.SmallImageList = EmployeeImagesList;
            listView1.LargeImageList = EmployeeImagesList;

            var EmployeeImages = SqlExecute("SELECT Image, EmployeeNo FROM EmployeeImage", r =>
            {                
                List<EmployeeImage> result = new List<EmployeeImage>();
                while (r.Read())
                {
                    result.Add(new EmployeeImage {
                        Image = (byte[])r["Image"],
                        EmployeeNo = (int)r["EmployeeNo"]
                    });
                }
                return result;                          
            });

            EmployeeImageIndex = 0;
            foreach (var Image in EmployeeImages)
            {
                EmployeeImagesList.Images.Add(EmployeeImageIndex.ToString(), ByteArrayToImage(Image.Image));
                EmployeeImageIndex++;
            }

            EmployeeImageIndex = 0;
            foreach (var Employee in employees)
            {
                ListViewItem tile = new ListViewItem(
                    Employee.Firstname + " " + Employee.Lastname, EmployeeImageIndex.ToString());

                listView1.Items.Add(tile);
                EmployeeImageIndex++;
            }
            
        }

        private void ComboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxVehicle);
            MapRoute thisMapRoute = MapControls.GetActiveRoute(MapTrip);
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
                MapRoute thisMapRoute = MapControls.GetActiveRoute(MapTrip);

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
                cmd.Parameters.AddWithValue("@FuelConsumption", GasCalcFlow.CalcFuelConsumption((decimal)thisMapRoute.Distance, thisVehicle.FuelConsumptionPer100));
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

        private void ListViewAppliesToEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateAppliesToLabels(GetSelectedTripFrom(ListViewAppliesToEntry));
            }
            catch
            {

            }            
        }

        private void UpdateAppliesToLabels(Trip trip)
        {
            if (trip != null)
            {
                LblPlannedDistance.Text = trip.Distance.ToString();
                LblPlannedFuelConsumption.Text = trip.FuelConsumption.ToString();
            }            
            else
            {
                LblPlannedDistance.Text = "";
                LblPlannedFuelConsumption.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAppliesToEntryList(ListViewAppliesToEntry, GetSelectedEmployeeFrom(ComboBoxEmployeeAppliesTo));            
        }

        private void FillAppliesToEntryList(ListView ListView, Employee Employee)
        {
            ListView.Items.Clear();

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;                
                cmd.CommandText = "SELECT TripID, VehicleNo, FromText, ToText, Distance, FuelConsumption FROM dbo.Trip AS A " +
                                  "WHERE A.EmployeeNo = "+ Employee.EmployeeNo + " AND " +
                                         "(SELECT COUNT(*) FROM dbo.ActualTrip AS B " +
                                         "WHERE B.EmployeeNo = "+ Employee.EmployeeNo + " AND " +
                                         "A.TripID = B.ExternalTripID) = 0;";

                SqlDataReader DataReader = cmd.ExecuteReader();

                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        ListViewItem row = new ListViewItem(DataReader["TripID"].ToString());
                        ListView.Items.Add(row);
                        row.SubItems.Add(DataReader["FromText"] + " - " + DataReader["ToText"]);                        
                    }
                }
                DataReader.Close();
                cn.Close();
            }
            catch
            {
                
            }            
        }

        public Trip GetSelectedTripFrom(ListView ListView)
        {
            Trip Trip = null;
            using (var ctx = new GasCalcEntities())
            {
                try
                {
                    Trip = ctx.Trips.Find(int.Parse(ListView.SelectedItems[0].Text));
                }
                catch { }
            }
            return Trip;
        }

        private void ButtonPostActualTrip_Click(object sender, EventArgs e)
        {
            try
            {
                Trip thisTrip = GetSelectedTripFrom(ListViewAppliesToEntry);

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO dbo.ActualTrip(ExternalTripID, VehicleNo, EmployeeNo," +
                                  "Distance, FuelConsumption, PostingDate)" +
                                  "VALUES (@ExternalTripID, @VehicleNo, @EmployeeNo," +
                                  "@Distance, @FuelConsumption, @PostingDate)";
                
                cmd.Parameters.AddWithValue("@VehicleNo", thisTrip.VehicleNo);
                cmd.Parameters.AddWithValue("@EmployeeNo", thisTrip.EmployeeNo);
                cmd.Parameters.AddWithValue("@ExternalTripID", thisTrip.TripID);

                cmd.Parameters.AddWithValue("@Distance", decimal.Parse(LblActualDistance.Text));
                cmd.Parameters.AddWithValue("@FuelConsumption", decimal.Parse(LblActualFuelConsumption.Text));
                cmd.Parameters.AddWithValue("@PostingDate", DateTime.Today);                
                
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("You have successfully posted the actual trip.");
                FillAppliesToEntryList(ListViewAppliesToEntry, GetSelectedEmployeeFrom(ComboBoxEmployeeAppliesTo));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something went wrong while posting the actual trip: " + ex.Message);
            }
        }

        private void ComboBoxEmployeeDeviation_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlowDeviationCharts.Controls.Clear();

            Employee thisEmployee = GetSelectedEmployeeFrom(ComboBoxEmployeeDeviation);

            using (var ctx = new GasCalcEntities())
            {
                var ActualTripsFiltered = ctx.ActualTrips
                    .Include("Trip")
                    .Where(x => x.EmployeeNo == thisEmployee.EmployeeNo);

                foreach (ActualTrip ActualTrip in ActualTripsFiltered)                
                {
                    var x = ActualTrip.Trip;
                    Trip Trip = GetTripById(ActualTrip.ExternalTripID);
                    FillDeviationTo(FlowDeviationCharts, Trip, ActualTrip);                
                }
            }
        }

        private void FillDeviationTo(FlowLayoutPanel FlowLayout, Trip Trip, ActualTrip ActualTrip)
        {
            FlowLayout.SuspendLayout();
            
            Chart DeviationChart = new Chart();
            ChartArea ChartArea = new ChartArea("ChartArea");

            DeviationChart.Name = Trip.TripID.ToString();
            DeviationChart.Size = new Size { Height = 300, Width = 300 };
            DeviationChart.ChartAreas.Add(ChartArea);

            var series1 = new Series
            {
                Name = "PlannedDistance",
                Color = Color.Green,
                Label = Trip.Distance.ToString(),
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            var series2 = new Series
            {
                Name = "ActualDistance",
                Color = Color.Blue,
                Label = ActualTrip.Distance.ToString(),
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            var series3 = new Series
            {
                Name = "Deviation",
                Color = Color.Red,
                Label = "Deviation",
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            // method
            if (Trip.Distance - ActualTrip.Distance < 0)
                series3.Color = Color.Red;
            else if (Trip.Distance - ActualTrip.Distance > 0)
                series3.Color = Color.Green;
            else
                series3.Color = Color.Gray;

            DeviationChart.Series.Add(series1);
            DeviationChart.Series.Add(series2);
            DeviationChart.Series.Add(series3);

            series1.Points.AddXY(Trip.FromText + " - " + Trip.ToText, Trip.Distance);
            series2.Points.AddXY("Testing", ActualTrip.Distance);
            series3.Points.AddXY(0, Trip.Distance - ActualTrip.Distance);

            //Label LblAbout = new Label();
            //LblAbout.Text = Trip.PostingDate.ToString();

            //FlowLayout.Controls.Add(LblAbout);
            FlowLayout.Controls.Add(DeviationChart);
            FlowLayout.ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Vehicle thisVehicle = GetSelectedVehicleFrom(ComboBoxUpdateVehicle);

                SqlConnection cn = new SqlConnection(ConnectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Vehicle SET FuelConsumptionPer100 = '" + decimal.Parse(TextBoxNewFuelConsumption.Text) + "' " +
                    "WHERE VehicleNo = " + thisVehicle.VehicleNo;

                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Vehicle model " + thisVehicle.Model + " has been updated successfuly.");
            }
            catch { }
        }
    }
}
