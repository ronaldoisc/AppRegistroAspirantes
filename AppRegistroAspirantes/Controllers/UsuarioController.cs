using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppRegistroAspirantes.Models;
using AppRegistroAspirantes.Filters;

namespace AppRegistroAspirantes.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Autorizacion(accion: "VER_USUARIOS")]
        public ActionResult Index()
        {
            List<UsuarioModel> usuarios = null;

            using(var bd = new RegistroAspirantesEntities())
            {
                usuarios = (from usr in bd.Administradores
                            join campus in bd.Campus on usr.IdCampus equals campus.Id
                            select new UsuarioModel 
                            {
                                Id = usr.Id,
                                Nombre = usr.Nombre,
                                ApellidoPaterno = usr.ApellidoPaterno,
                                ApellidoMaterno = usr.ApellidoMaterno,
                                Correo = usr.Correo,
                                Contrasenia = usr.Contrasenia,
                                TelefonoFijo = usr.TelefonoFijo,
                                TelefonoCelular = usr.TelefonoCelular,
                                IdCampus = (int) usr.IdCampus,
                                IdRol = (byte) usr.IdCampus,
                                Campus = usr.Campus.Nombre
                            }).ToList();
            }

            ViewBag.usuarios = usuarios;

            return View();
        }

        [Autorizacion(accion: "CREAR_USUARIOS")]
        public ActionResult Crear()
        {
            return View();
        }

        [Autorizacion(accion: "CREAR_USUARIOS")]
        [HttpPost]
        public ActionResult Crear(UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioModel);
            } else
            {
                using(var bd = new RegistroAspirantesEntities())
                {
                    Administradores admin = new Administradores
                    {
                        Nombre = usuarioModel.Nombre,
                        ApellidoPaterno = usuarioModel.ApellidoPaterno,
                        ApellidoMaterno = usuarioModel.ApellidoMaterno,
                        Correo = usuarioModel.Correo,
                        Contrasenia = usuarioModel.Contrasenia,
                        TelefonoFijo = usuarioModel.TelefonoFijo,
                        TelefonoCelular = usuarioModel.TelefonoCelular,
                        IdCampus = usuarioModel.IdCampus,
                        IdRol = 2
                    };

                    bd.Administradores.Add(admin);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }

        [Autorizacion(accion: "ACTUALIZAR_USUARIOS")]
        public ActionResult Actualizar(int id)
        {
            UsuarioModel usuario = null;
            using (var bd = new RegistroAspirantesEntities())
            {
                Administradores admin = bd.Administradores.Find(id);
                usuario = new UsuarioModel
                {
                    Nombre = admin.Nombre,
                    ApellidoPaterno = admin.ApellidoPaterno,
                    ApellidoMaterno = admin.ApellidoMaterno,
                    Correo = admin.Correo,
                    Contrasenia = admin.Contrasenia,
                    TelefonoFijo = admin.TelefonoFijo,
                    TelefonoCelular = admin.TelefonoCelular,
                    IdCampus = (byte) admin.IdCampus,
                    IdRol = admin.IdRol
                };
            }
            return View(usuario);
        }

        [Autorizacion(accion: "ACTUALIZAR_USUARIOS")]
        [HttpPost]
        public ActionResult Actualizar(UsuarioModel usuarioModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(usuarioModel);
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    Administradores admin = bd.Administradores.Find(usuarioModel.Id);
                    admin.Nombre = usuarioModel.Nombre;
                    admin.ApellidoPaterno = usuarioModel.ApellidoPaterno;
                    admin.ApellidoMaterno = usuarioModel.ApellidoMaterno;
                    admin.Correo = usuarioModel.Correo;
                    admin.TelefonoFijo = usuarioModel.TelefonoFijo;
                    admin.TelefonoCelular = usuarioModel.TelefonoCelular;
                    admin.IdCampus = usuarioModel.IdCampus;
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }
    }
}