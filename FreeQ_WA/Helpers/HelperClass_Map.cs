using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeQ_WA.GeoCodeService;

namespace FreeQ_WA.Helpers
{
    public struct geoloc
    {
        public double lat;
        public double lon;
    }

    public class HelperClass_Map
    {
        public geoloc GeocodeAddress(string address)
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
            filters[0].MinimumConfidence = GeoCodeService.Confidence.Low;

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
    }
}