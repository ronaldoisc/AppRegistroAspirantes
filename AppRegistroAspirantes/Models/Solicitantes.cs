//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppRegistroAspirantes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solicitantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string IdGenero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public byte[] Foto { get; set; }
        public int IdPais { get; set; }
        public int IdLocalidad { get; set; }
        public string Correo { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public byte IdGradoEstudios { get; set; }
        public string EscuelaProcedencia { get; set; }
        public int IdCampus { get; set; }
        public int IdCarrera { get; set; }
        public byte[] Identificacion { get; set; }
        public byte[] CertificadoBachillerato { get; set; }
        public Nullable<bool> EstatusPago { get; set; }
    
        public virtual Campus Campus { get; set; }
        public virtual Carreras Carreras { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual GradosEstudio GradosEstudio { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual Paises Paises { get; set; }
    }
}
