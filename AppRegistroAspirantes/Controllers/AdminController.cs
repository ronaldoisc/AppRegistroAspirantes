using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppRegistroAspirantes.Filters;
using AppRegistroAspirantes.Models;
namespace AppRegistroAspirantes.Controllers
{
    public class AdminController : Controller
    {
        [Autenticacion]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
         {
             AdministradorModel administrador = (AdministradorModel)HttpContext.Session["ADMINISTRADOR"];
             if (administrador != null)
             {
                 return RedirectToAction("Index");
             }
             return View();
         }

         [HttpPost]
         public ActionResult Login(string correo, string contrasenia)
         {
             if (!ModelState.IsValid)
             {
                 return View();
             }
             else
             {
                 using (var bd = new RegistroAspirantesEntities())
                 {
                     Administradores admin = bd.Administradores.FirstOrDefault(a => a.Correo == correo && a.Contrasenia == contrasenia);

                     if (admin != null)
                     {
                         AdministradorModel administrador = new AdministradorModel
                         {
                             Nombre = admin.Nombre,
                             ApellidoPaterno = admin.ApellidoPaterno,
                             ApellidoMaterno = admin.ApellidoMaterno,
                             Correo = admin.Correo,
                             Contrasenia = admin.Contrasenia,
                             TelefonoCelular = admin.TelefonoCelular,
                             TelefonoFijo = admin.TelefonoFijo,
                             IdCampus = admin.IdCampus != null ? (int)admin.IdCampus : 0,
                             IdRol = admin.IdRol
                         };
                         Session["ADMINISTRADOR"] = administrador;
                         return RedirectToAction("Index");
                     }
                     else
                     {
                         return View();
                     }
                 }
             }
         }

         [Autenticacion]
         public ActionResult CerrarSesion()
         {
             Session.Remove("ADMINISTRADOR");
            //return RedirectToAction("Login");
            return Redirect(Url.Content("~/Admin/Login"));
        }
     }
    

}

