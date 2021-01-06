using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasajesCurso.Models
{
    public class SucursalCLS
    {
        [Display(Name ="Id Sucursal")]
        public int iidSucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Maximo de caracteres: 100")]
        public string nombre { get; set; }
        [Display(Name = "Direccion")]
        [Required]
        [StringLength(100, ErrorMessage = "Maximo de caracteres: 200")]
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Maximo de caracteres: 10")]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Maximo de caracteres: 100")]
        [EmailAddress(ErrorMessage ="Ingrese un Email Valido")]
        public string email { get; set; }
        [Display(Name = "Fecha Apertura")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime fechaApertura { get; set; }
        public int bHabilitado { get; set; }
    }
}