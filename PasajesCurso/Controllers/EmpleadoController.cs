using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasajesCurso.Models;

namespace PasajesCurso.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleados = null;
            using (var bd= new BDPasajeEntities())
            {
                listaEmpleados = (from empleado in bd.Empleado
                                  where empleado.BHABILITADO==1
                                  join tipoUsuario in bd.TipoUsuario
                                  on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                  join tipoContrato in bd.TipoContrato
                                  on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                  select new EmpleadoCLS
                                  {
                                      iidEmpleado = empleado.IIDEMPLEADO,
                                      nombre = empleado.NOMBRE,
                                      apPaterno = empleado.APPATERNO,
                                      nombreTipoUsuario = tipoUsuario.NOMBRE,
                                      nombreTipoContrato = tipoContrato.NOMBRE
                                  }).ToList();
            }
            return View(listaEmpleados);
        }
        public ActionResult AddEmpleado()
        {
            listarCombos();
            return View();
        }
        public void listarCombos()
        {
            listarTipoUsuario();
            listarTipoContrato();
            listarSexo();
        }
        public void listarSexo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value="" });
                ViewBag.listaSexo = lista;
            }
        }
        public void listarTipoContrato()
        {
            List<SelectListItem> contratos;
            using(var bd= new BDPasajeEntities())
            {
                contratos = (from contrato in bd.TipoContrato
                              where contrato.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Text = contrato.NOMBRE,
                                  Value = contrato.IIDTIPOCONTRATO.ToString()
                              }).ToList();
                contratos.Insert(0, new SelectListItem { Text = "--Seleccione Tipo contrato", Value = "" });
                ViewBag.listaContratos = contratos;
            }
        }
        public void listarTipoUsuario()
        {
            List<SelectListItem> usuarios;
            using(var bd = new BDPasajeEntities())
            {
                usuarios = (from usuario in bd.TipoUsuario
                            where usuario.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Text = usuario.NOMBRE,
                                Value = usuario.IIDTIPOUSUARIO.ToString()
                            }).ToList();
                usuarios.Insert(0, new SelectListItem { Text = "--Seleccione Tipo Usuario--", Value = "" });
                ViewBag.listaUsuarios = usuarios;
            }
        }
        [HttpPost]
        public ActionResult AddEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oEmpleadoCLS);
            }
            using(var bd= new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                oEmpleado.APPATERNO = oEmpleadoCLS.apPaterno;
                oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidTipoUsuario;
                oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidTipoContrato;
                oEmpleado.IIDSEXO = oEmpleadoCLS.iidSexo;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}