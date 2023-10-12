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
    public class EstudiantesController : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            List<EstudiantesTableViewModel> lstestudiante = null;
            using(var db= new db_prueba_IIPEntities())
            {
                lstestudiante = (from v in db.Estudiantes
                                 join m in db.Grupo on v.idGrupo equals m.idGrupo
                                 select new EstudiantesTableViewModel
                                 {
                                     IdEstudiante = v.idEstudiante,
                                     Nombre=v.Nombre,
                                     Apellido=v.Apellido,
                                     nombGrupo=m.nombreGrupo
                                 }).ToList();
            }
            return View(lstestudiante);
            
        }
        public void CargarCboxMarcas()
        {
            List<SelectListItem> list = null;
            using (var db = new db_prueba_IIPEntities())
            {
                list = (from m in db.Grupo
                        select new SelectListItem
                        {
                            Value = m.idGrupo.ToString(),
                            Text = m.nombreGrupo.ToString()
                        }).ToList();
                ViewBag.marcas = list;
            }
        }
        public ActionResult Nuevo()
        {
            CargarCboxMarcas();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EstudianteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCboxMarcas();
                return View(model);
            }

            using (db_prueba_IIPEntities db = new db_prueba_IIPEntities())
            {
                Estudiantes oVehiculo = new Estudiantes();
                oVehiculo.Nombre = model.Nombre;
                oVehiculo.Apellido = model.Apellido;
                oVehiculo.idGrupo = model.idGrupo;
                db.Estudiantes.Add(oVehiculo);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Estudiantes/"));
        }

        public ActionResult Edit(int id)
        {
            CargarCboxMarcas();
            EditarEstudianteViewModel model = new EditarEstudianteViewModel();

            using (var db = new db_prueba_IIPEntities())
            {
                var oMarca = db.Estudiantes.Find(id);
                model.Id = oMarca.idEstudiante;
                model.nombre = oMarca.Nombre;
                model.apellido = oMarca.Apellido;
                model.idGrupo = oMarca.idGrupo;

            }
            return View(model);
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditarEstudianteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCboxMarcas();
                return View(model);
            }

            using (db_prueba_IIPEntities db = new db_prueba_IIPEntities())
            {
                var oVehiculo = db.Estudiantes.Find(model.Id);
                oVehiculo.Nombre = model.nombre;
                oVehiculo.Apellido = model.apellido;
                oVehiculo.idGrupo = model.idGrupo;
                //oVehiculo.Grupo = db.Grupo.Find(model.idGrupo);

                db.Entry(oVehiculo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Estudiantes/"));

        }

        public ActionResult Eliminar(int id)
        {
            EliminarEstudianteViewModel model = new EliminarEstudianteViewModel();

            using (var db = new db_prueba_IIPEntities())
            {
                var oVehiculo = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(oVehiculo);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Estudiantes/"));
        }


    }
}