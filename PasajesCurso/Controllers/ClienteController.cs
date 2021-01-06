using PasajesCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasajesCurso.Controllers
{
    public class ClienteController : Controller
    {
        List<SelectListItem> lista;
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> listaClientes = null;
            using(var bd= new BDPasajeEntities())
            {
                listaClientes = (from cli in bd.Cliente
                                 where cli.BHABILITADO == 1
                                 select new ClienteCLS
                                 {
                                     iidCliente = cli.IIDCLIENTE,
                                     nombre = cli.NOMBRE,
                                     apPaterno = cli.APPATERNO,
                                     apMaterno = cli.APMATERNO,
                                     telefonoFijo=cli.TELEFONOFIJO
                                 }).ToList();
            }
            return View(listaClientes);
        }
        public void LlenarSexo()
        {
            using (var bd= new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }

        public ActionResult Agregar()
        {
            LlenarSexo();
            ViewBag.lista = lista;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                LlenarSexo();
                ViewBag.lista = lista;
                return View(oClienteCLS);
            }
            else
            {
                using(var bd= new BDPasajeEntities())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.NOMBRE = oClienteCLS.nombre;
                    oCliente.APPATERNO = oClienteCLS.apPaterno;
                    oCliente.APMATERNO = oClienteCLS.apMaterno;
                    oCliente.EMAIL = oClienteCLS.email;
                    oCliente.DIRECCION = oClienteCLS.direccion;
                    oCliente.IIDSEXO = oClienteCLS.iidSexo;
                    oCliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                    oCliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;
                    oCliente.BHABILITADO = 1;
                    bd.Cliente.Add(oCliente);
                    bd.SaveChanges();

                }
                return RedirectToAction("Index");
            }
        }
    }
}