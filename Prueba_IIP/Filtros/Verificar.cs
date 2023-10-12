using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_IIP.Model;
using Prueba_IIP.Controllers;


namespace Prueba_IIP.Filtros
{
    public class Verificar:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var oUsuario = (tbl_usuarios)HttpContext.Current.Session["Usuario"];
            if (oUsuario == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/");
                }
            }
            base.OnActionExecuted(filterContext);
        }

    }
}