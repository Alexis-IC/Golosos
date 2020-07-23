using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LosGolosos.Models;

namespace LosGolosos.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {   
            List<EmployeesCLS> list = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                list = (from em in bd.Empleados
                        join person in bd.Personas
                        on em.idPersona equals person.idPersona
                        select new EmployeesCLS
                        {
                            idEmpleado = em.idEmpleado,
                            nombre = person.nombre,
                            apellido = person.apellido,
                            dir = person.dir,
                            tel = person.tel,
                            correo = person.correo,
                            cargo = em.idCargo == 1 ? "Administrador" : "Vendedor",
                            sexo = em.sexo == "M" ? "Masculino" : "Femenino",
                            dui = em.dui,
                            estado = em.idEstado == 1 ? "Activo" : "Inactivo"
                        }).ToList();
            }

            ViewBag.ListaRol = ComboRol();
            ViewBag.ListaSexo = ComboSexo();

            return View(list);
        }

        public ActionResult Productos()
        {
            List<ProductoCLS> list = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                list = (from product in bd.Productos
                        join cat in bd.Categorias
                        on product.idCategoria equals cat.idCategoria
                        select new ProductoCLS
                        {
                            idProducto = (int)product.idProducto,
                            idCategoria = (int)product.idCategoria,
                            nombre = product.nombre,
                            imagen = product.imagen,
                            categoria = cat.nombre,
                            detalle = product.detalle,
                            stock = (int)product.stock,
                            precio = (decimal)product.precio
                        }).ToList();
            }

            ViewBag.ListaCat = ComboCat();
            return View(list);
        }


        public ActionResult FiltroProductos(string nombre)
        {
            List<ProductoCLS> list = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                if (nombre == null)
                {
                    list = (from product in bd.Productos
                            join cat in bd.Categorias
                            on product.idCategoria equals cat.idCategoria
                            select new ProductoCLS
                            {
                                idProducto = (int)product.idProducto,
                                idCategoria = (int)product.idCategoria,
                                nombre = product.nombre,
                                imagen = product.imagen,
                                categoria = cat.nombre,
                                detalle = product.detalle,
                                stock = (int)product.stock,
                                precio = (decimal)product.precio
                            }).ToList();
                }
                else
                {
                    list = (from product in bd.Productos
                            join cat in bd.Categorias
                            on product.idCategoria equals cat.idCategoria
                            where product.nombre.Contains(nombre)
                            select new ProductoCLS
                            {
                                idProducto = (int)product.idProducto,
                                idCategoria = (int)product.idCategoria,
                                nombre = product.nombre,
                                imagen = product.imagen,
                                categoria = cat.nombre,
                                detalle = product.detalle,
                                stock = (int)product.stock,
                                precio = (decimal)product.precio
                            }).ToList();
                }
            }

            ViewBag.ListaCat = ComboCat();

            return PartialView("_TableProducts", list);
        }


        public ActionResult Filtro(string nombre)
        {
            List<EmployeesCLS> list = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                if(nombre == null)
                {
                    list = (from em in bd.Empleados
                            join person in bd.Personas
                            on em.idPersona equals person.idPersona
                            select new EmployeesCLS
                            {
                                idEmpleado = em.idEmpleado,
                                nombre = person.nombre,
                                apellido = person.apellido,
                                dir = person.dir,
                                tel = person.tel,
                                correo = person.correo,
                                cargo = em.idCargo == 1 ? "Administrador" : "Vendedor",
                                sexo = em.sexo == "M" ? "Masculino" : "Femenino",
                                dui = em.dui,
                                estado = em.idEstado == 1 ? "Activo" : "Inactivo"
                            }).ToList();
                }
                else
                {
                    list = (from em in bd.Empleados
                            join person in bd.Personas
                            on em.idPersona equals person.idPersona
                            where person.nombre.Contains(nombre) || person.apellido.Contains(nombre)
                            select new EmployeesCLS
                            {
                                idEmpleado = em.idEmpleado,
                                nombre = person.nombre,
                                apellido = person.apellido,
                                dir = person.dir,
                                tel = person.tel,
                                correo = person.correo,
                                cargo = em.idCargo == 1 ? "Administrador" : "Vendedor",
                                sexo = em.sexo == "M" ? "Masculino" : "Femenino",
                                dui = em.dui,
                                estado = em.idEstado == 1 ? "Activo" : "Inactivo"
                            }).ToList();
                }
            }

            ViewBag.ListaRol = ComboRol();
            ViewBag.ListaSexo = ComboSexo();

            return PartialView("_TableEmployees",list);
        }

        public List<SelectListItem> ComboCat()
        {
            List<SelectListItem> sourceList = new List<SelectListItem>();

            sourceList.Add(new SelectListItem { Text = "Postres", Value = "1" });
            sourceList.Add(new SelectListItem { Text = "Bebidas", Value = "2" });
            sourceList.Add(new SelectListItem { Text = "Combos", Value = "3" });

            return sourceList;
        }

        public List<SelectListItem> ComboRol()
        {
            List<SelectListItem> sourceList = new List<SelectListItem>();

            sourceList.Add(new SelectListItem { Text = "Administrador", Value = "1"});
            sourceList.Add(new SelectListItem { Text = "Vendedor", Value = "2" });

            return sourceList;
        }

        public List<SelectListItem>ComboSexo()
        {
            List<SelectListItem> sourceList = new List<SelectListItem>();

            sourceList.Add(new SelectListItem { Text = "Masculino", Value = "M" });
            sourceList.Add(new SelectListItem { Text = "Femenino", Value = "F" });

            return sourceList;
        }

        public string AgregarProducto(ProductoCLS oProductoCLS, string titulo)
        {
            string resp = "0";

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                if (titulo.Equals("1"))
                {

                    string nombreImagen = Path.GetFileNameWithoutExtension(oProductoCLS.archivo.FileName);
                    string extension = Path.GetExtension(oProductoCLS.archivo.FileName);

                    nombreImagen += DateTime.Now.ToString("dMMyyyy-ff") + extension;
                    oProductoCLS.imagen = "~/theme/productos/" + nombreImagen;

                    string rutaGuardar = Path.Combine(Server.MapPath("~/theme/productos/"), nombreImagen);

                    oProductoCLS.archivo.SaveAs(rutaGuardar);

                    Productos oProducto = new Productos();
                    oProducto.idCategoria = oProductoCLS.idCategoria;
                    oProducto.nombre = oProductoCLS.nombre;
                    oProducto.imagen = oProductoCLS.imagen;
                    oProducto.detalle = oProductoCLS.detalle;
                    oProducto.stock = oProductoCLS.stock;
                    oProducto.precio = oProductoCLS.precio;

                    bd.Productos.Add(oProducto);
                    resp = bd.SaveChanges().ToString();
                }
            }

            return resp;
        }

        public ActionResult Ordenar()
        {
            List<ProductoCLS> list = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                list = (from product in bd.Productos
                        join cat in bd.Categorias
                        on product.idCategoria equals cat.idCategoria
                        select new ProductoCLS
                        {
                            idProducto = (int)product.idProducto,
                            idCategoria = (int)product.idCategoria,
                            nombre = product.nombre,
                            imagen = product.imagen,
                            categoria = cat.nombre,
                            detalle = product.detalle,
                            stock = (int)product.stock,
                            precio = (decimal)product.precio
                        }).ToList();
            }

            ViewBag.ListaCat = ComboCat();
            return View(list);
        }

        public ActionResult AgregarCarrito(int idProducto)
        {
            if(Session["Carrito"] != null)
            {
                List<ProductoCLS> sesion = (List<ProductoCLS>)Session["Carrito"];

                if (sesion.Find(p => p.idProducto.Equals(idProducto)) != null)
                {
                    sesion.Where(p => p.idProducto == idProducto).ToList().ForEach(s => s.pedidos++);
                    Session["Carrito"] = sesion;
                    return PartialView("_TableCart", sesion);
                }

            }

            ProductoCLS producto = null;

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                producto = (from product in bd.Productos
                            join cat in bd.Categorias
                            on product.idCategoria equals cat.idCategoria
                            where product.idProducto == idProducto
                            select new ProductoCLS
                            {
                                idProducto = (int)product.idProducto,
                                idCategoria = (int)product.idCategoria,
                                pedidos = 1,
                                nombre = product.nombre,
                                imagen = product.imagen,
                                categoria = cat.nombre,
                                detalle = product.detalle,
                                stock = (int)product.stock,
                                precio = (decimal)product.precio
                            }).First();
            }

            List<ProductoCLS> list = new List<ProductoCLS>();

            list.Add(producto);

            if (Session["Carrito"] != null)
            {
                list.AddRange((List<ProductoCLS>)Session["Carrito"]);
            }

            Session["Carrito"] = list;

            return PartialView("_TableCart",list);
        }

        public string Registrar(EmployeesCLS oEmployeesCLS, string titulo)
        {
            string resp = "0";

            using (BDGolososEntities bd = new BDGolososEntities())
            {
                if(titulo.Equals("1"))
                {
                    Personas oPersona = new Personas();
                    oPersona.nombre = oEmployeesCLS.nombre;
                    oPersona.apellido = oEmployeesCLS.apellido;
                    oPersona.dir = oEmployeesCLS.dir;
                    oPersona.tel = oEmployeesCLS.tel;
                    oPersona.correo = oEmployeesCLS.correo;

                    bd.Personas.Add(oPersona);
                    bd.SaveChanges();

                    Empleados oEmpleado = new Empleados();
                    
                    oEmpleado.dui = oEmployeesCLS.dui;
                    
                    int idPersona = bd.Personas.Where(p => p.correo.Equals(oEmployeesCLS.correo)).First().idPersona;

                    oEmpleado.idPersona = idPersona;
                    oEmpleado.idCargo = oEmployeesCLS.idCargo;
                    oEmpleado.sexo = oEmployeesCLS.sexo;
                    oEmpleado.idEstado = 1;
                    
                    bd.Empleados.Add(oEmpleado);
                    bd.SaveChanges();

                    Usuarios oUsuarios = new Usuarios();

                    oUsuarios.idPersona = idPersona;
                    oUsuarios.usuario = oEmployeesCLS.user;
                    oUsuarios.clave = oEmployeesCLS.pass;

                    bd.Usuarios.Add(oUsuarios);
                    resp = bd.SaveChanges().ToString();
                }
            }

            return resp;
        }
    }
}