using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prueba_IIP.Model.ViewModel
{
    public class GrupoViewModel
    {
        
        //public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese el nombre del grupo")]
        [StringLength(200)]
        public string NombreGrupo { get; set; }
    }

    public class EditarGrupoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombre del Grupo")]
        [StringLength(200)]
        public string NombreGrupo { get; set; }
    }

    public class EliminarGrupoViewModel
    {
        public int Id { get; set; }
    }
}