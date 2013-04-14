using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FreeQ_WS.GeoCodeService;

namespace FreeQ_WS.Models
{
    public class PushPinModel
    {
        public string Title { get; set; }    public string Description { get; set; }    public double Longitude { get; set; }    public double Latitude { get; set; }

    }

    #region Services

    public interface IMapService
    {
        List<PushPinModel> GetAddressList();
        PushPinModel GetHQLocation();
    }

    public struct geoloc
    {
        public double lat;
        public double lon;
    }

    public class MapService : IMapService
    {

        public MapService()
        {
        }

        private geoloc GeocodeAddress(string address)
        {
            GeocodeRequest geocodeRequest = new GeocodeRequest();

            // Set the credentials using a valid Bing Maps key
            geocodeRequest.Credentials = new GeoCodeService.Credentials();
            geocodeRequest.Credentials.ApplicationId = "AiIo0eq8yDzQx40gwHidcSJzTIZjanj36I5v_xVhbNCuB-3GTeJ0tkTM2c7exntM";

            // Set the full address query
            geocodeRequest.Query = address;

            // Set the options to only return high confidence results 
            ConfidenceFilter[] filters = new ConfidenceFilter[1];
            filters[0] = new ConfidenceFilter();
            filters[0].MinimumConfidence = GeoCodeService.Confidence.High;

            // Add the filters to the options
            GeocodeOptions geocodeOptions = new GeocodeOptions();
            geocodeOptions.Filters = filters;
            geocodeRequest.Options = geocodeOptions;

            // Make the geocode request
            GeoCodeService.GeocodeServiceClient geocodeService = new GeoCodeService.GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
            GeocodeResponse geocodeResponse = geocodeService.Geocode(geocodeRequest);

            if (geocodeResponse.Results.Length > 0)
            {
                geoloc res = new geoloc();
                res.lat = geocodeResponse.Results[0].Locations[0].Latitude;
                res.lon = geocodeResponse.Results[0].Locations[0].Longitude;

                return res;
            }
            else
                throw new Exception("No Results Found");
        }

        public PushPinModel GetHQLocation()
        {
            geoloc l = this.GeocodeAddress("Alexander Platz, 10178 Berlin Germany"); // ("Neue Schönhauser Straße 18, 10178 Berlin Germany");

            return (new PushPinModel
            {
                Description = string.Empty,
                Latitude = l.lat,
                Longitude = l.lon,
                Title = ""
            });
        }

        public List<PushPinModel> GetAddressList()
        {
            FreeQ_DBEntities context = new FreeQ_DBEntities();

            FreeQ_WS.Classes.FreeQ_DataContext db = new Classes.FreeQ_DataContext();
            List<PushPinModel> ppl = new List<PushPinModel>();
            geoloc l;
            List<string> la = (from a in context.Queue.Where("1 == 1")
                    where a.Queue_Address.Length != 0
                    select a.Queue_Address).ToList<string>();

            foreach (string a in la)
            {
                l = this.GeocodeAddress(a);

                //add the pushpin info
                ppl.Add(new PushPinModel
                {
                    Description = a,
                    Latitude = l.lat,
                    Longitude = l.lon,
                    Title = ""
                });
            }

            db.Dispose();
            context.Dispose();

            return ppl;
        }

    }

    #endregion

}
