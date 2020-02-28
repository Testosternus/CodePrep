using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodePrep.Services
{
    public static class ApiClientFactory
    {
        public static Func<HttpClient> ValueFactory = () =>
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://services.runescape.com/m=itemdb_rs/bestiary");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            return client;
        };

        private static Lazy<HttpClient> client = new Lazy<HttpClient>(ValueFactory); //lazy Singleton, 1 httpclient per application launch

        public static HttpClient HttpClient
        {
            get { return client.Value; }
        }
    }
}
