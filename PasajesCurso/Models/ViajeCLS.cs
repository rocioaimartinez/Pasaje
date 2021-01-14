using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PasajesCurso.Models
{
    public class ViajeCLS
    {
        [Display(Name ="Id Viaje")]
        public int iidViaje { get; set; }
        [Display(Name = "Lugar de Origen")]
        [Required]
        public int iidLugarDeOrigen { get; set; }
        [Display(Name = "Lugar de Destino")]
        [Required]
        public int iidLugarDeDestino { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public double precio { get; set; }
        [Display(Name = "Fecha Viaje")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaViaje { get; set; }
        [Display(Name = "Bus")]
        [Required]
        public int iidBus { get; set; }
        [Display(Name = "Asientos Disponibles")]
        [Required]
        public int numeroDeAsientosDisponibles { get; set; }
        //
        [Display(Name = "Origen")]
        public string nombreOrigen { get; set; }
        [Display(Name = "Destino")]
        public string nombreDestino { get; set; }
        [Display(Name = "Bus")]
        public string nombreBus { get; set; }
    }
}