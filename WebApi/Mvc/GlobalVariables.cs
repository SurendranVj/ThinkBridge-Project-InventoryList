using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient client=new HttpClient();

        static GlobalVariables()
        {
            client.BaseAddress=new Uri("http://localhost:15898/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}