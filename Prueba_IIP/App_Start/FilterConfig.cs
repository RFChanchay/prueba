using System.Web;
using System.Web.Mvc;

namespace Prueba_IIP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.Verificar());
        }
    }
}
