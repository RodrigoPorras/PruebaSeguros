using MVCPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCPS.Controllers
{
    public class PolizaController : Controller
    {
        // GET: Poliza
        public ActionResult Index()
        {
            IEnumerable<mvcPolizaModel> polizaList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Polizas").Result;
            polizaList = response.Content.ReadAsAsync<IEnumerable<mvcPolizaModel>>().Result;
            return View(polizaList);
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new mvcPolizaModel());
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcPolizaModel poliza)
        {
            Console.WriteLine("entra el metrood");
            HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Polizas", poliza).Result;

            return RedirectToAction("Index");
        }
    }


}