using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace GasCalc
{
    public static class MapControls
    {
        public static MapRoute GetActiveRoute(GMapControl Map)
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

        public static MapRoute PaintRouteOnMap(GMapControl Map, PointLatLng Start, PointLatLng End)
        {
            GMapOverlay MapRoutes = new GMapOverlay("maproutes");            
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

        public static void PaintMarkerOnMap(GMapControl Map, PointLatLng Point, string TooltipText, GMarkerGoogleType MarkerType)
        {
            GMapOverlay MapObjects = new GMapOverlay("mapobjects");
            Map.Overlays.Add(MapObjects);

            GMapMarker m = new GMarkerGoogle(Point, MarkerType);
            m.ToolTipText = TooltipText;
            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            MapObjects.Markers.Add(m);
        }
    }
}
