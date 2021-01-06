using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasajesCurso.Models
{
    public class ClienteCLS
    {
        [Display(Name ="ID Cliente")]
        public int iidCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede superara los 100 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(100, ErrorMessage = "El apellido paterno no puede superara los 100 caracteres")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(100, ErrorMessage = "El apellido materno no puede superara los 100 caracteres")]
        public string apMaterno { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress(ErrorMessage ="Ingrese un formato valido")]
        public string email { get; set; }

        [Display(Name = "Direccion")]
        [Required]
        [StringLength(100, ErrorMessage ="La direccion no puede superara los 100 caracteres")]
        public string direccion { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidSexo { get; set; }

        [Display(Name = "Celular")]
        [Required]
        [StringLength(10, ErrorMessage = "El Telefono Celular no puede superara los 100 caracteres")]
        public string telefonoCelular { get; set; }

        [Display(Name = "Telefono Fijo")]
        [StringLength(10, ErrorMessage = "El telefono fijo no puede superara los 100 caracteres")]
        public string telefonoFijo { get; set; }

        

        public int bHabilitado { get; set; }
    }
}