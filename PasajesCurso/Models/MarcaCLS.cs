using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasajesCurso.Models
{
    public class MarcaCLS
    {
        [Display(Name ="Id Marca")]
        public int iidMarca { get; set; }
        [Display(Name = "Nombre Marca")]
        [Required]
        [StringLength(100, ErrorMessage ="Maximo de caracteres: 100")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion Marca")]
        [Required]
        [StringLength(100, ErrorMessage = "Maximo de caracteres: 200")]
        public string descripcion { get; set; }
        public int bHabilitado { get; set; }
    }
}