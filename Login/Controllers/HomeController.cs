using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Session["Usuario"].ToString()))
            {
                return View("Login");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Login()
        {
            Session["Usuario"] = "";

            string NuevaLista = "";
            Models.Home ho = new Models.Home();
            ho.Cadena = "a,b,c,d";
            foreach (DataRow item in ho.ListaContrasena().Rows)
            {
                NuevaLista += "<li><a href='#" + item["palabra"] + "'>" + item["palabra"] +"</a></li>";
            }
            ViewBag.Lista = NuevaLista;
            return View();
        }

        [HttpPost]
        public JsonResult CargaLista(Models.Home ho) {

            string NuevaLista = "";
            foreach (DataRow item in ho.ListaContrasena().Rows)
            {
                NuevaLista += "<li><a id='"+item["palabra"] +"' class='Tag' href=\"javascript:rescata('"+item["palabra"]+"')\"> " + item["palabra"] + "</a></li>";
            }

            return Json(new { Lista = NuevaLista });
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public JsonResult CreaUsuario(Models.Home home) {
            return Json(new {Ok = home.CreaUsuario() });
        }

        public JsonResult CargaCadenas(Models.Home hom) {
            bool estado = hom.CargaCadenas();
            if (estado)
            {
                Session["Usuario"] = hom.Cadena;
            }
            else
            {
                Session["Usuario"] = "";
            }
            return Json(new { ok = estado});
        }
    }
}