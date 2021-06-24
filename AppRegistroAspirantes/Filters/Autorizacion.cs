using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Filters
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autorizacion : AuthorizeAttribute
    {
        private AdministradorModel admin;
        private RegistroAspirantesEntities bd = new RegistroAspirantesEntities();
        private string accion;

        public Autorizacion(string accion)
        {
            this.accion = accion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                admin = (AdministradorModel)HttpContext.Current.Session["ADMINISTRADOR"];

                if (admin != null)
                {
                    var listaAcciones = from item in bd.AccionesAdministradores
                                        join accion in bd.Acciones on item.IdAccion equals accion.Id
                                        where item.IdAdministrador == admin.IdRol && accion.Descripcion == this.accion
                                        select item;
                    if (listaAcciones.ToList().Count < 1)
                    {
                        filterContext.Result = new RedirectResult("~/Error/AccesoNoAutorizado");
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Admin/Login");
                }
                //base.OnAuthorization(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Error/AccesoNoAutorizado");
            }
        }
    }

}