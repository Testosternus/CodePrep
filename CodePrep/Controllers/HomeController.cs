using CodePrep.Models;
using CodePrep.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodePrep.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client;
        public HomeController()
        {
            client = ApiClientFactory.HttpClient ?? throw new ArgumentNullException();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> SlayerList(int id=112)
        {

            var response = await client.GetStringAsync($"{client.BaseAddress}/slayerBeasts.json?identifier={id}");

            var data = JsonConvert.DeserializeObject<IEnumerable<ResponseBasic>>(response);

            return View(new SlayerBeastVM
            {
                Beasts = data,
                CategoryID = id
            });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}