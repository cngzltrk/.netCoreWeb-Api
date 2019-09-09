using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
namespace appMvc
{
    public static class GlobalVeriables
    {
        public static HttpClient wepApiClient = new HttpClient();
        static GlobalVeriables()
        {
            wepApiClient.BaseAddress = new Uri("https://localhost:44379/api/");
            wepApiClient.DefaultRequestHeaders.Clear();
            wepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
