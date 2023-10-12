using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prueba_IIP.Model.ViewModel
{
    public class EstudianteViewModel
    {
        [Required]
        public int idEstudiante { get; set; }
        [Required]
        [Display(Name = "Ingrese el nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese el apellido")]
        public string Apellido { get; set; }
        [Required]
        public Nullable<int> idGrupo { get; set; }

        [Display(Name = "Ingrese el nombre")]
        public string nombGrupo { get; set; }


    }
    public class EliminarEstudianteViewModel
    {
        public int Id { get; set; }
    }
    public class EditarEstudianteViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese el nombre")]
        [StringLength(10)]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el Apellido")]
        public string apellido { get; set; }

        [Required]
        public Nullable<int> idGrupo { get; set; }
        [Display(Name = "Ingrese el nombre de grupo")]
        public string nombGrupo { get; set; }
    }
}