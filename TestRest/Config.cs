using System;
using System.Collections.Generic;
using System.Text;

namespace TestRest
{
    public class Config
    {
        public static string host = "petstore.swagger.io/v2";

        public static Uri GetUri(string status)
        {
            Uri uri = new Uri($"http://{host}/pet/findByStatus?status={status}");
            return uri;
        }

        public static Uri Get(Uri uri)
        {

            return uri;
        }
    }


}


