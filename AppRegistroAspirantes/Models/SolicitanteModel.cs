using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroAspirantes.Models
{
    public class SolicitanteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string IdGenero { get; set; }
        public string Genero { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public byte[] Foto { get; set; }
        public int IdPais { get; set; }
        [Display(Name = "País")]
        public string Pais { get; set; }
        public int IdLocalidad { get; set; }
        public string Localidad { get; set; }

        [Display(Name = "CP")]
        [DataType(DataType.PostalCode)]
        public int CodigoPostal { get; set; }
        public string Correo { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public byte IdGradoEstudios { get; set; }
        [Display(Name = "Último Grado de Estudios")]
        public string GradoEstudios { get; set; }
        public string EscuelaProcedencia { get; set; }
        public int IdCampus { get; set; }
        [Display(Name = "Campus Asignado")]
        public string CampusAsignado { get; set; }
        public int IdCarrera { get; set; }
        public string Carrera { get; set; }
        public Nullable<bool> EstatusPago { get; set; }
        [Display(Name = "Fotografía")]
        [Required]
        public HttpPostedFileBase Imagen { get; set; }
        public virtual Campus Campus { get; set; }
        public virtual Carreras Carreras { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual GradosEstudio GradosEstudio { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual Paises Paises { get; set; }


       



        [Display(Name = "Identificación")]
        [Required]
        public HttpPostedFileBase INE { get; set; }

        [Display(Name = "Certificado Bachillerato")]
        [Required]
        public HttpPostedFileBase Certificado { get; set; }

        public byte[] Identificacion { get; set; }
        public byte[] CertificadoBachillerato { get; set; }


        public List<CarrerasModel> carreras { get; set; }
    }
}