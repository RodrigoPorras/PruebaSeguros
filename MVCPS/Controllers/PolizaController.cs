using MVCPS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            IEnumerable<MvcPolizaModel> polizaList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Polizas").Result;
            polizaList = response.Content.ReadAsAsync<IEnumerable<MvcPolizaModel>>().Result;
            return View(polizaList);
        }


        public ActionResult AddOrEdit(int id = 0)
        {

            HttpResponseMessage responseTC = GlobalVariables.webApiClient.GetAsync("TipoDeCubrimientos").Result;
            HttpResponseMessage responseTR = GlobalVariables.webApiClient.GetAsync("TipoDeRiesgos").Result;
            MvcPolizaModel tmpPolizaModel;

            if (id == 0)
            {
                tmpPolizaModel = new MvcPolizaModel
                {
                    TipoDeCubrimientoCollection = responseTC.Content.ReadAsAsync<IEnumerable<MvcTipoDeCubrimientoModel>>().Result.ToList(),
                    TipoDeRiesgoCollection = responseTR.Content.ReadAsAsync<IEnumerable<MvcTipoDeRiesgoModel>>().Result.ToList()
                };

                return View(tmpPolizaModel);
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Polizas/" + id.ToString()).Result;
                tmpPolizaModel = response.Content.ReadAsAsync<MvcPolizaModel>().Result;

                tmpPolizaModel.TipoDeCubrimientoCollection = responseTC.Content.ReadAsAsync<IEnumerable<MvcTipoDeCubrimientoModel>>().Result.ToList();
                tmpPolizaModel.TipoDeRiesgoCollection = responseTR.Content.ReadAsAsync<IEnumerable<MvcTipoDeRiesgoModel>>().Result.ToList();

                return View(tmpPolizaModel);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcPolizaModel poliza)
        {

            if (ModelState.IsValid)
            {
                if (poliza.IDPoliza == 0)
                {
                    HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Polizas", poliza).Result;
                    TempData["SuccessMessage"] = "Poliza Guardada Exitosamente";
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Polizas/" + poliza.IDPoliza, poliza).Result;
                    TempData["SuccessMessage"] = "Poliza Actualizada Exitosamente";
                }
                return RedirectToAction("Index");
            }else {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                TempData["ErrorMessage"] = "Error no se pudo Guardar/Actualizar";
                return RedirectToAction("Index");
               
            }
            
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Polizas/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Poliza Eliminada Exitosamente";
            return RedirectToAction("Index");
        }
    }


}