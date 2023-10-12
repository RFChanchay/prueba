using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_IIP.Model;
using Prueba_IIP.Model.ViewModel;

namespace Prueba_IIP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new db_prueba_IIPEntities())
            {
                var list = from u in db.tbl_usuarios
                           where u.usuario == model.usuario
                           && u.clave == model.clave
                           && u.estado == 1
                           select u;
                if (list.Count() > 0)
                {
                    Session["Usuario"] = list.First();
                }
            }
            return Redirect(Url.Content("~/Home/"));
        }
    }
}