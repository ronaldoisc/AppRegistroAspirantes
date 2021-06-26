using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class BancoModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Banco")]
        public string Nombre { get; set; }
    }
}