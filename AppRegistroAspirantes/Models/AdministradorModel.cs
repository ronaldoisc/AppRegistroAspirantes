using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class AdministradorModel
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public int IdCampus { get; set; }
        public byte IdRol { get; set; }

        public bool EsCapazDe(string accion)
        {
            bool aux = false;

            using (var bd = new RegistroAspirantesEntities())
            {
                aux = (from item in bd.AccionesAdministradores
                       join ac in bd.Acciones on item.IdAccion equals ac.Id
                       where item.IdAdministrador == IdRol && ac.Descripcion == accion
                       select item).ToList().Count > 0 ? true : false;
            }

            return aux;
        }
    }
}