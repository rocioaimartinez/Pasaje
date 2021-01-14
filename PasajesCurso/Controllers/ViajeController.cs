using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasajesCurso.Models;

namespace PasajesCurso.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> listaViajes = null;
            using (var bd =new BDPasajeEntities())
            {
                listaViajes = (from viaje in bd.Viaje
                               join lugar in bd.Lugar
                               on viaje.IIDLUGARORIGEN equals lugar.IIDLUGAR
                               join lugarDestino in bd.Lugar
                               on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                               join bus in bd.Bus
                               on viaje.IIDBUS equals bus.IIDBUS
                               select new ViajeCLS
                               {
                                   iidViaje = viaje.IIDVIAJE,
                                   nombreOrigen = lugar.NOMBRE,
                                   nombreDestino = lugar.NOMBRE,
                                   nombreBus = bus.PLACA
                               }).ToList();
            }
            return View(listaViajes);
        }
    }
}