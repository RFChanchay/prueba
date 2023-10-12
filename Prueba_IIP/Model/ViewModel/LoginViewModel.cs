using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prueba_IIP.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Ingrese el Usuario")]
        public string usuario { get; set; }
        [Required]
        [Display(Name = "Ingrese la clave")]
        public string clave { get; set; }


    }
}