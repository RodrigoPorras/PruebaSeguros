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
    }
}