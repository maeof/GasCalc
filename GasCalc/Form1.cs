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
            // TODO: This line of code loads data into the 'gasCalcDataSetVehicle.Vehicle' table. You can move, or remove it, as needed.
            this.vehicleTableAdapter.Fill(this.gasCalcDataSetVehicle.Vehicle);
            // TODO: This line of code loads data into the 'gasCalcDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.gasCalcDataSet.Employee);
            //MapTrip.MapProvider = LithuaniaMapProvider.Instance;          
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

            //--
            // Bind the DataGridView to the BindingSource 
            // and load the data from the database.    
                                         
            dataGridView1.DataSource = bindingSource1;
            GetData("select VehicleNo, LicensePlate, Model from Vehicle", ref bindingSource1, ref dataAdapter);
            //--            
            /*BindingSource BindingSourceEmployee = new BindingSource();            
            SqlDataAdapter DataAdapterEmployee = new SqlDataAdapter();

            ComboBoxEmployee.DataSource = BindingSourceEmployee;            
            GetData("SELECT Firstname FROM Employee", ref BindingSourceEmployee, ref DataAdapterEmployee);
              */  
        }

        private void MapTrip_MouseDoubleClick(object sender, MouseEventArgs e)
        {                        
            if (first)
            {
                MapTrip.Overlays.Clear();

                start = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);

                PaintMarkerOnMap(MapTrip, start, "Start", GMarkerGoogleType.green_big_go);

                first = false;
            }
            else
            {
                end = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);

                PaintMarkerOnMap(MapTrip, end, "End", GMarkerGoogleType.red_big_stop);
                MapRoute thisRoute = PaintRouteOnMap(MapTrip, start, end);

                SetPrognosisLabels(thisRoute);
                
                first = true;
            }
        }

        private void SetPrognosisLabels(MapRoute Route)
        {
            if (Route != null)
            {
                LblPrognosisDistance.Text = Math.Round(Route.Distance, 2).ToString();
                //LblPrognosisFuelConsumption.Text = CalcFuelConsumption(Route.Distance).ToString();
            }
            else
            {
                LblPrognosisDistance.Text = "";
                LblPrognosisFuelConsumption.Text = "";
            }
        }

        public decimal CalcFuelConsumption(MapRoute Route, int VehicleNo)
        {
            return 0;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            PaintRouteOnMap(MapTrip, start, end);
        }
        
        //move this
        private MapRoute PaintRouteOnMap(GMapControl Map, PointLatLng Start, PointLatLng End)
        {                        
            GMapOverlay MapRoutes = new GMapOverlay("maproutes");
            MapTrip.Overlays.Add(MapRoutes);

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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (GMapOverlay thisOverlay in MapTrip.Overlays)
            {
                foreach (GMapRoute thisRoute in thisOverlay.Routes)
                {
                    MessageBox.Show(thisRoute.Distance.ToString());
                }
            }
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
            /*
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GasCalc;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "INSERT INTO Employee (Firstname, Lastname, Position) "+
            //                                "VALUES ('Thomas', 'Smith', 'CEO')";

            cmd.CommandText = "INSERT INTO Vehicle (VIN, LicensePlate, FuelType, FuelConsumptionPer100) "+
                                            "VALUES ('a12', '123av', 'diesel', 4.5)";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //..
            cn.Close();*/            
            LookupVehicle LookupVehicle = new LookupVehicle();
            LookupVehicle.ShowDialog(this);

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText, ref bindingSource1, ref dataAdapter);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // Update the database with the user's changes.
            dataAdapter.Update((DataTable)bindingSource1.DataSource);

            // ListChanged += ...
            vehicleTableAdapter.Fill(gasCalcDataSetVehicle.Vehicle);
            ComboBoxVehicle.DataSource = vehicleBindingSource;
            //vehicleTableAdapter.Update((GasCalcDataSetVehicle)vehicleBindingSource.DataSource);
            //vehicleTableAdapter.Update()
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
                    // LINQ agregatine?
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
    }
}
