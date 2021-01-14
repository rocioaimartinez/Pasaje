using PasajesCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasajesCurso.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal = null;
            using (var bd= new BDPasajeEntities())
            {
                listaSucursal = (from suc in bd.Sucursal
                                 where suc.BHABILITADO==1
                                 select new SucursalCLS
                                 {
                                     iidSucursal = suc.IIDSUCURSAL,
                                     nombre = suc.NOMBRE,
                                     direccion = suc.DIRECCION,
                                     telefono = suc.TELEFONO,
                                     email = suc.EMAIL
                                 }).ToList();
            }
            return View(listaSucursal);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursalCLS);//Mantiene los valores ingresados
            }
            else
            {
                using (var bd=new BDPasajeEntities())
                {
                    Sucursal oSucursal = new Sucursal();
                    oSucursal.NOMBRE = oSucursalCLS.nombre;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaApertura;
                    oSucursal.BHABILITADO = 1;
                    bd.Sucursal.Add(oSucursal);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Editar(int id)
        {
            SucursalCLS oSucursalCLS = new SucursalCLS();
            using (var bd = new BDPasajeEntities())
            {
                Sucursal oSucursal = bd.Sucursal.Where(p => p.IIDSUCURSAL.Equals(id)).First();
                oSucursalCLS.iidSucursal = oSucursal.IIDSUCURSAL;
                oSucursalCLS.nombre = oSucursal.NOMBRE;
                oSucursalCLS.direccion = oSucursal.DIRECCION;
                oSucursalCLS.telefono= oSucursal.TELEFONO;
                oSucursalCLS.email= oSucursal.EMAIL;
                oSucursalCLS.fechaApertura= (DateTime)oSucursal.FECHAAPERTURA;

            }
            return View(oSucursalCLS);
        }
    }
}