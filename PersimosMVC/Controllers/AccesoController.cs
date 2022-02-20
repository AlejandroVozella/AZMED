using NLog;
using PersimosMVC.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Controllers
{
    public class AccesoController : Controller
    {
        //private static Logger logger = LogManager.GetLogger("myAppLoggersRules");
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            MyLogger.GetInstance().Info("Entrando al Login Controller.Motodo Login");
            try
            {
                using (Models.AzMedEntities db= new Models.AzMedEntities())
                {
                    var oUser = (from d in db.usuario
                                 where d.email == User.Trim() && d.password == Pass.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        MyLogger.GetInstance().Info("Login Failure");
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["User"] = oUser;
                            
                }

                MyLogger.GetInstance().Info("Login Satisfactorio");

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                MyLogger.GetInstance().Info("Login Failure");
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}