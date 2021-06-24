using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class LocalidadModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
        public int IdPais { get; set; }
    }
}