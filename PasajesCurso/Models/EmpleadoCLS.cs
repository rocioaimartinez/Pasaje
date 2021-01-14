using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasajesCurso.Models
{
    public class EmpleadoCLS
    {
        [Display(Name="Id Empleado")]
        public int iidEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage ="Longitud Maxima 100")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 200")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud Maxima 200")]
        public string apMaterno { get; set; }

        [Display(Name = "Fecha Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaContrato { get; set; }
        [Display(Name = "Sueldo")]
        [Required]
        [Range(0,100000, ErrorMessage ="Fuera de Rango")]
        public decimal sueldo { get; set; }

        //[Display(Name = "Sueldo")]
        //public decimal sueldo { get; set; }
        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iidTipoUsuario { get; set; }
        [Display(Name = "Tipo Contrato")]
        [Required]
        public int iidTipoContrato { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int iidSexo { get; set; }
        public int bHabilitado { get; set; }
        //public int bTieneUsuario { get; set; }
        //public int tipoUsuario { get; set; }
        [Display(Name = "Tipo Contrato")]
        public string nombreTipoContrato { get; set; }
        [Display(Name = "Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }
    }
}