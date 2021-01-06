﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasajesCurso.Models;

namespace PasajesCurso.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd =new BDPasajeEntities())
            {
                 listaMarca = (from marca in bd.Marca
                               where marca.BHABILITADO==1
                                             select new MarcaCLS
                                             {
                                                 iidMarca = marca.IIDMARCA,
                                                 nombre = marca.NOMBRE,
                                                 descripcion = marca.DESCRIPCION
                                             }).ToList();
            }
            return View(listaMarca);
        }
        public ActionResult Agregar()//genera la vista
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)//hace la accion
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaCLS);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            
        }
    }

}