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

namespace GasCalc
{
    public partial class Form1 : Form
    {
        /*GMapOverlay markers;
        GMapOverlay routes;
        GMapOverlay objects;*/

        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");

        bool first = true;
        PointLatLng start;
        PointLatLng end;

        public Form1()
        {
            InitializeComponent();
            //objects = new GMapOverlay("objects");
            /*
            markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(48.8617774, 2.349272),
                GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            MapTrip.Overlays.Add(markers);

            routes = new GMapOverlay("routes");
            GMapRoute route = new GMapRoute("test");
            route.Points.Add(new PointLatLng(48.8617774, 2.349272));
            route.Points.Add(new PointLatLng(54.6961334816182, 25.2985095977783));
            MessageBox.Show(route.Distance.ToString());
            routes.Routes.Add(route);
            MapTrip.Overlays.Add(routes);*/
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //MapTrip.MapProvider = LithuaniaMapProvider.Instance;
            //GoogleMapProvider.Instance.ApiKey = "AIzaSyBbH9eC9C14-3CDRFJeagiVuhqkk7eSDi8";
            //GoogleMapProvider.Instance.
            MapTrip.MapProvider = BingMapProvider.Instance;
                      
            
            //MapTrip.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            //MapTrip.SetPositionByKeywords("Lithuania");
            MapTrip.SetPositionByKeywords("Lithuania");           

            //MapTrip.OnMapDrag += MapTrip_OnMapDrag;
            MapTrip.DoubleClick += MapTrip_DoubleClick;
            MapTrip.MouseDoubleClick += MapTrip_MouseDoubleClick;


            MapTrip.Overlays.Add(routes);
            MapTrip.Overlays.Add(polygons);
            MapTrip.Overlays.Add(objects);
            MapTrip.Overlays.Add(top);

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            //..
            cn.Close();
        }

        private void MapTrip_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            MessageBox.Show(MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y).ToString());
            if (first)
            {
                start = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);
                first = false;
            }
            else
            {
                end = MapTrip.FromLocalToLatLng(e.Location.X, e.Location.Y);
                first = true;
            }
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
            RoutingProvider rp = MapTrip.MapProvider as RoutingProvider;
            if (rp == null)
            {
                rp = GMapProviders.OpenStreetMap; // use OpenStreetMap if provider does not implement routing
            }

            MapRoute route = rp.GetRoute(start, end, false, false, (int)MapTrip.Zoom);
            if (route != null)
            {
                // add route
                GMapRoute r = new GMapRoute(route.Points, route.Name);
                r.IsHitTestVisible = true;
                routes.Routes.Add(r);

                // add route start/end marks
                GMapMarker m1 = new GMarkerGoogle(start, GMarkerGoogleType.green_big_go);
                m1.ToolTipText = "Start: " + route.Name;
                m1.ToolTipMode = MarkerTooltipMode.Always;

                GMapMarker m2 = new GMarkerGoogle(end, GMarkerGoogleType.red_big_stop);
                m2.ToolTipText = "End: fetch from Google";
                m2.ToolTipMode = MarkerTooltipMode.Always;

                objects.Markers.Add(m1);
                objects.Markers.Add(m2);

                MapTrip.ZoomAndCenterRoute(r);
            }
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
    }
}
