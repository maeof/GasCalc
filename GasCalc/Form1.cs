using System;
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

        private void button3_Click(object sender, EventArgs e)
        {
          
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
                //UpdateAppliesToLabels(GetSelectedTripFrom(ListViewAppliesToEntry));
            }
            catch
            {

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
                cmd.CommandText = "SELECT TripID, VehicleNo, FromText, ToText, Distance, FuelConsumption " +
                    "FROM dbo.Trip " +
                    "WHERE EmployeeNo='" + Employee.EmployeeNo + "'";

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
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString;
            cn.Open();

            Trip thisTrip = new Trip();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TripID, VehicleNo, EmployeeNo FROM dbo.Trip " +
                "WHERE TripID=" + int.Parse(ListView.SelectedItems[0].Text) + "";

            SqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    thisTrip.VehicleNo = (int)DataReader["VehicleNo"];
                    thisTrip.EmployeeNo = (int)DataReader["EmployeeNo"];
                    thisTrip.TripID = (int)DataReader["TripID"];
                }
            }
            return thisTrip;
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
            }
            catch
            {
                MessageBox.Show("Something went wrong while posting the actual trip.");
            }
        }

        private void ComboBoxEmployeeDeviation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee thisEmployee = GetSelectedEmployeeFrom(ComboBoxEmployeeDeviation);



            Trip thisTrip = null;
            using (var ctx = new GasCalcEntities())
            {
                try
                {
                    thisTrip = ctx.Trips.Find(1);
                }
                catch { MessageBox.Show("mate what"); }
            }
            MessageBox.Show(thisTrip.FromLongitude + "");

        }
    }
}
