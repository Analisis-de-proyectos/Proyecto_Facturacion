using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Analisi.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,String password)
        {
            try
            {

                using (ventasEntities db = new ventasEntities() )
                {

                    var vUser = (from d in db.usuarios
                                 where d.email == username.Trim() && d.password == password.Trim()
                                 select d).FirstOrDefault();
                    if (vUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }
                    Session["User"] = vUser;
                
                }
                    return RedirectToAction("Index", "Home");

            }
            catch (Exception e)

            {

                ViewBag.Error = e.Message;
                return View();

            }



        }
    }
}