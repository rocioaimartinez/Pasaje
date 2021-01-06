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
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string apMaterno { get; set; }

        [Display(Name = "Fecha Contrato")]
        public DateTime fechaContrato { get; set; }

        [Display(Name = "Sueldo")]
        public decimal sueldo { get; set; }
        public int iidTipoUsuario { get; set; }
        public int iidTipoContrato { get; set; }
        public int iidSexo { get; set; }
        public int bHabilitado { get; set; }
        public int bTieneUsuario { get; set; }
        public int tipoUsuario { get; set; }


    }
}