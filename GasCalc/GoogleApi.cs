using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GasCalc
{
    public static class GoogleApi
    {
        //private readonly string ApiKey = "AIzaSyBbH9eC9C14-3CDRFJeagiVuhqkk7eSDi8";

        public static XElement GetResponseFromGeocoding(PointLatLng ThePoint)
        {
            string ApiKey = "AIzaSyBbH9eC9C14-3CDRFJeagiVuhqkk7eSDi8";

            var RequestUrl = @"https://maps.googleapis.com/maps/api/geocode/xml?latlng="+
                ThePoint.Lat + "," + ThePoint.Lng + "&sensor=false&key=" + ApiKey;

            var Request = WebRequest.Create(RequestUrl);
            var Response = Request.GetResponse();
            var XDoc = XDocument.Load(Response.GetResponseStream());

            var Result = XDoc.Element("GeocodeResponse");
            var Status = Result.Element("status");

            if (Status.Value == "OK")
                return Result.Element("result");
            else
                return null;                                                
        }       

        public static string ExtractAddressFromResponse(XElement Response)
        {
            return Response.Element("formatted_address").Value;
        }        
    }
}
