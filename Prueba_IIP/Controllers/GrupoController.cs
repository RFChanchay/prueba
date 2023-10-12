using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_IIP.Model;
using Prueba_IIP.Model.TableViewModel;
using Prueba_IIP.Model.ViewModel;
namespace Prueba_IIP.Controllers
{
    public class GrupoController : Controller
    {
        // GET: Grupo
        public ActionResult Index()
        {
            List<GrupoTableViewModel> list = null;
            using (db_prueba_IIPEntities db = new db_prueba_IIPEntities())
            {
                list = (from d in db.Grupo
                        select new GrupoTableViewModel
                        {
                            idGrupo=d.idGrupo,
                            nombreGrupo=d.nombreGrupo

                        }
                       ).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Nuevo()
        {

            return View();
        }
        public ActionResult Nuevo(GrupoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (db_prueba_IIPEntities db = new db_prueba_IIPEntities())
            {
                Grupo oMarca = new Grupo();
                //oMarca.idGrupo = model.Id;
                oMarca.nombreGrupo = model.NombreGrupo;
                db.Grupo.Add(oMarca);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Grupo/"));
        }
        public ActionResult Eliminar(int id)
        {
            EliminarGrupoViewModel model = new EliminarGrupoViewModel();

            using (var db = new db_prueba_IIPEntities())
            {
                var oMarca = db.Grupo.Find(id);
                db.Grupo.Remove(oMarca);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Grupo/"));
        }
        public ActionResult Editar(int id)
        {
            EditarGrupoViewModel model = new EditarGrupoViewModel();

            using (var db = new db_prueba_IIPEntities())
            {
                var oMarca = db.Grupo.Find(id);
                model.Id = oMarca.idGrupo;
                model.NombreGrupo = oMarca.nombreGrupo;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarGrupoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (db_prueba_IIPEntities db = new db_prueba_IIPEntities())
            {
                var oMarca = db.Grupo.Find(model.Id);
                oMarca.nombreGrupo = model.NombreGrupo;

                db.Entry(oMarca).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Grupo/"));
        }
    }
}