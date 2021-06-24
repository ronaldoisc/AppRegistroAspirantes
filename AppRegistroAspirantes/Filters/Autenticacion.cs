using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Filters
{
    public class Autenticacion : ActionFilterAttribute
    {
        private AdministradorModel administrador;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                administrador = (AdministradorModel)HttpContext.Current.Session["ADMINISTRADOR"];

                if (administrador == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Admin/Login");
                }

            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
            }
        }
    }
}