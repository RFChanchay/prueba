using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_IIP.Model.TableViewModel
{
    public class EstudiantesTableViewModel
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> IdDeGrupo { get; set; }
        public string nombGrupo { get; set; }
    }
}