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
            if(id == 0)
             return View(new mvcPolizaModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Polizas/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPolizaModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcPolizaModel poliza)
        {
            if(poliza.IDPoliza == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Polizas", poliza).Result;
                TempData["SuccessMessage"] = "Poliza Guardada Exitosamente";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Polizas/"+poliza.IDPoliza,poliza).Result;
                TempData["SuccessMessage"] = "Poliza Actualizada Exitosamente";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Polizas/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Poliza Eliminada Exitosamente";
            return RedirectToAction("Index");
        }
    }


}