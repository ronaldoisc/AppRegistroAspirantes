using AppRegistroAspirantes.Filters;
using AppRegistroAspirantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRegistroAspirantes.Controllers
{
    public class BancoController : Controller
    {
        /// <summary>
        /// Vista para Mostrar todos los Bancos
        /// </summary>
        List<BancoModel> listaBancos = null;
        [Autorizacion(accion: "VER_BANCOS")]
        public ActionResult Index()
        {
            using (var bd = new RegistroAspirantesEntities())
            {
                listaBancos = (from banco in bd.Bancos
                               select new BancoModel
                               {
                                   Id = banco.Id,
                                   Nombre = banco.Nombre

                               }).ToList();
            }

            return View(listaBancos);
         
        }

        /// <summary>
        /// Vista para mostrar el Formulario de
        /// registro de un nuevo banco
        /// </summary>
        /// <returns></returns>

        [Autorizacion(accion: "CREAR_BANCOS")]
        public ActionResult Crear()
        {
            return View();
        }

        [Autorizacion(accion: ("CREAR_BANCOS"))]
        [HttpPost]
        public ActionResult Crear(BancoModel BancoModel)
        {
            if (!ModelState.IsValid)
            {
                return View(BancoModel);
            }
            else
            {
                using (var bd = new RegistroAspirantesEntities())
                {
                    Bancos oBancos = new Bancos();
                    oBancos.Nombre = BancoModel.Nombre;


                    bd.Bancos.Add(oBancos);
                    bd.SaveChanges();

                }
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Vista para Mostrar un Formulario
        /// para editar un Banco
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [Autorizacion(accion: "ACTUALIZAR_BANCOS")]
        public ActionResult Editar(int Id)
        {
            BancoModel bancoModel = new BancoModel();
            using (RegistroAspirantesEntities db = new RegistroAspirantesEntities())
            {
                var oTabla = db.Bancos.Find(Id);

                bancoModel.Nombre = oTabla.Nombre;

            }
            return View(bancoModel);
        }


        [Autorizacion(accion: "ACTUALIZAR_BANCOS")]
        [HttpPost]
        public ActionResult Editar(BancoModel BancoModel)
        {

            int IdBanco = BancoModel.Id;

            if (ModelState.IsValid)

                using (var bd = new RegistroAspirantesEntities())
                {
                    Bancos oBancos = bd.Bancos.Where(p => p.Id.Equals(IdBanco)).First();

                    oBancos.Nombre = BancoModel.Nombre;
                    bd.SaveChanges();

                }

            return RedirectToAction("Index");


        }
    }
}