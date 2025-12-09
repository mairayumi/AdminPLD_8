using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using wsPLD_8.Extesion;
using wsPLD_8.Models;
using wsPLD_8.Models.Catalogos;
using wsPLD_8.Models.Shared;

namespace wsPLD_8.Controllers
{
    public class HomeController : Controller
    {
        private Aplicacion<int> _aplicacion;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SignInManager<Usuarios> signInManager
            , ILogger<HomeController> logger
            , Aplicacion<int> aplicacion)
        {
            _signInManager = signInManager;
            _logger = logger;
            _aplicacion = aplicacion;
            _aplicacion = _aplicacion.ValidaUser(_aplicacion);
        }

        public IActionResult Index()
        {
            _aplicacion.Menu = "Dashboard";
            _aplicacion.Titulo = "ticket de Usuario";
            if (_aplicacion.UsrId == 0) {
               _aplicacion.UsrId = _aplicacion.Id;
            }
            Graficas grafica = new Graficas();
            grafica.Totales = new List<GraficaTotales>();
            grafica.Totales.Add(new GraficaTotales() { Atrazado = 10, Cancelado = 1, EnProceso = 1, EnRevision = 3, Liverados = 1, Total = 1 });
            grafica.Graph1 = new Grafica();
            Respuesta respuesta = grafica.Read("?cTLS_Id="+_aplicacion.UsrId);

            if (respuesta.Exito == 1)
                return View(grafica.Deserializar(respuesta.Data.ToString()));
            else
                return View(grafica);
        }
        public IActionResult Listado(int cTLS_Id, int PagAct, string Filtro, string Periodo)
        {
            _aplicacion.Menu = "Catalogo de Ticket Armor";
            _aplicacion.Titulo = "Listado de Ticket";
            _aplicacion.UsrId = cTLS_Id;
            _aplicacion.Filtro = Filtro;
            _aplicacion.PagAct = PagAct;
            _aplicacion.Periodo = Periodo;
            if (PagAct == 0)
                PagAct++;
            TipoLista tipoLista = new TipoLista();
            Respuesta respuesta;

            string _filtro = "?cTLS_Id=" + cTLS_Id + "&PagAct=" + PagAct;
            if (Filtro != null && Filtro.Length > 0)
                _filtro += "&Filtro=" + Filtro;

            IList<TicketARMOR> ticketARMORs = new List<TicketARMOR>();
            respuesta = tipoLista.Read(_filtro);
            if (respuesta.Exito == 1)
            {
                tipoLista = tipoLista.Deserializar(respuesta.Data.ToString());
            }
            return View(tipoLista.ticketARMOR);
        }
        //
        [HttpPost]
        public async Task<IActionResult> Actividad(string tipo, string ValorIn)
        {
            TKAxActividad Valor = new TKAxActividad();
            Valor = Valor.Deserializar(ValorIn);

            _aplicacion.UsrId = Valor.cTLS_Id;
            _aplicacion.cTKA_Id = Valor.cTKA_Id;
            HttpContext.Session.SetString("Aplicacion", _aplicacion.Serializar());

            Respuesta respuesta = new Respuesta();
            TKAxActividad tKAxActividad = new TKAxActividad();
            tKAxActividad.cTLS_Id = Valor.cTLS_Id;
            tKAxActividad.cTKA_Id = Valor.cTKA_Id;
            tKAxActividad.rTKA_Id = Valor.rTKA_Id;
            tKAxActividad.rTKA_Actividad = Valor.rTKA_Actividad;
            tKAxActividad.rTKA_FechaSeguimiento = Valor.rTKA_FechaSeguimiento;
            tKAxActividad.cTAC_Id = Valor.cTAC_Id;
            tKAxActividad.cEAC_Id = Valor.cEAC_Id;
            tKAxActividad.UsrId = Valor.UsrId;
            if (tipo.Equals("Update"))
            {
                respuesta = tKAxActividad.Update();
            }
            else if (tipo.Equals("Delete"))
            {
                respuesta = tKAxActividad.Delete("?cTLS_Id=" + Valor.cTLS_Id + "&cTKA_Id=" + Valor.cTKA_Id + "&rTKA_Id=" + Valor.rTKA_Id);
            }
            else if (tipo.Equals("Create"))
            {
                respuesta = tKAxActividad.Create();
            }
            tKAxActividad = tKAxActividad.Deserializar(respuesta.Data.ToString());
            string mensaje = _aplicacion.Serializar();//"La actividad No. ";
            //return Ok(new { aplicacion = _aplicacion });
            return Ok(new { aplicacion = Json(new { aplicacion = ViewData["Aplicacion"] }) });
        }

        public IActionResult Create(int cTLS_Id,int PagAct, string Filtro)
        {
            _aplicacion.Menu = "Catalogo de Ticket Armor";
            _aplicacion.Titulo = "Creacion de Ticket";
            _aplicacion.UsrId = cTLS_Id;
            _aplicacion.PagAct = PagAct;
            _aplicacion.Filtro = Filtro;


            TicketARMOR ticketARMOR = new TicketARMOR();
            ticketARMOR.cTLS_Id = _aplicacion.UsrId;
            ticketARMOR.categoria = _aplicacion.catalogo.catalogosTicketARMOR[0].categoria;
            ticketARMOR.prioridad = _aplicacion.catalogo.catalogosTicketARMOR[0].prioridad;
            ticketARMOR.tipoSolicitud = _aplicacion.catalogo.catalogosTicketARMOR[0].tipoSolicitud;
            ticketARMOR.estadoSolicitud = _aplicacion.catalogo.catalogosTicketARMOR[0].estadoSolicitud;
            return View("Edit", ticketARMOR);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReturn(int PagAct, string Filtro, TicketARMOR collection)
        {
            //TicketARMOR collection = new TicketARMOR();
            Respuesta respuesta;
            _aplicacion.UsrId = collection.cTLS_Id;
            _aplicacion.cTKA_Id = collection.cTKA_Id;
            _aplicacion.PagAct = PagAct;
            _aplicacion.Filtro = Filtro;
            int Id = _aplicacion.UsrId * 1000 + collection.cTKA_Id;

            if (!ModelState.IsValid)
            {
                if (collection.cCAT_Id == 0)
                {
                    respuesta = collection.Delete(Id.ToString());
                    if (respuesta.Exito == 1)
                    {
                        collection = collection.Deserializar(respuesta.Data.ToString());
                        _aplicacion.catalogo.mensaje = "Se Elimino el ticket: " + collection.cTKA_Id;
                    }
                    //return View("Listado");
                    return RedirectToAction(nameof(Listado), new { cTLS_Id = collection.cTLS_Id, Pagact = PagAct, filtro = Filtro });
                }
                else
                {
                    _aplicacion.Menu = "Catalogo de Ticket Armor";

                    if (collection.cTKA_Id.Equals(0))
                    {
                        _aplicacion.Titulo = "Creacion de Ticket";
                    }
                    else
                    {
                        _aplicacion.Titulo = "Actualizacion de Ticket";
                    }
                    return View("Edit", collection);
                }
                //return RedirectToAction(nameof(Index));
            }

            collection.cTKA_FechaCreado = DateTime.Parse(collection.cTKA_FechaCreado).ToString("yyyy-MM-dd HH:mm:ss");
            if (collection.cTKA_FechaSolucion != null)
                collection.cTKA_FechaSolucion = DateOnly.Parse(collection.cTKA_FechaSolucion).ToString("yyyy-MM-dd");
            if (collection.cTKA_FechaSolucionReal != null)
                collection.cTKA_FechaSolucionReal = DateOnly.Parse(collection.cTKA_FechaSolucionReal).ToString("yyyy-MM-dd");
            if (collection.cTKA_FechaPruebas != null)
                collection.cTKA_FechaPruebas = DateOnly.Parse(collection.cTKA_FechaPruebas).ToString("yyyy-MM-dd");
            if (collection.cTKA_FechaDespliegue != null)
                collection.cTKA_FechaDespliegue = DateOnly.Parse(collection.cTKA_FechaDespliegue).ToString("yyyy-MM-dd");
            if (collection.cTKA_FechaPruebasProd != null)
                collection.cTKA_FechaPruebasProd = DateOnly.Parse(collection.cTKA_FechaPruebasProd).ToString("yyyy-MM-dd");
            if (collection.cTKA_FechaSeguimiento != null)
                collection.cTKA_FechaSeguimiento = DateOnly.Parse(collection.cTKA_FechaSeguimiento).ToString("yyyy-MM-dd");

            if (collection.cTKA_Id == 0)
            {
                collection.cTLS_Id = _aplicacion.UsrId;
                respuesta = collection.Create();
                if (respuesta.Exito == 1)
                {
                    collection = collection.Deserializar(respuesta.Data.ToString());
                    _aplicacion.catalogo.mensaje = "Se dio de alta el ticket: " + collection.cTKA_Id;
                }
            }
            else
            {
                respuesta = collection.Update();
                if (respuesta.Exito == 1)
                {
                    collection = collection.Deserializar(respuesta.Data.ToString());
                    _aplicacion.catalogo.mensaje = "Se actualizo el ticket: " + collection.cTKA_Id;
                }
                else
                {
                    _aplicacion.catalogo.mensaje = respuesta.Mensaje;
                }
            }
            //string mesage = MetodoGeneral.Upload(_aplicacion.UsrId, file).Result.ToString();
            //return View("Listado");
            return RedirectToAction(nameof(Listado), new { cTLS_Id = collection.cTLS_Id, Pagact = PagAct, filtro = Filtro });
        }

        public IActionResult Delete(int cTLS_Id,int id, int Pagact, string filtro)
        {
            _aplicacion.Menu = "Catalogo de Ticket Armor";
            _aplicacion.Titulo = "Eliminacion de Ticket";
            _aplicacion.UsrId = cTLS_Id;
            _aplicacion.PagAct = Pagact;
            _aplicacion.Filtro = filtro;

            TicketARMOR ticketARMOR = new TicketARMOR();
            id = _aplicacion.UsrId * 1000 + id;
            Respuesta respuesta = ticketARMOR.Read(id.ToString());
            if (respuesta.Exito == 1)
            {
                IList<TicketARMOR> ticketARMORs = ticketARMOR.DeserializarList(respuesta.Data.ToString());
                ticketARMORs[0].Accion = "disabled";
                return View("Edit", ticketARMORs[0]);
            }
            return View("Edit", ticketARMOR);
        }

        public IActionResult Details(int cTLS_Id, int id, int Pagact, string filtro)
        {
            _aplicacion.Menu = "Catalogo de Ticket Armor";
            _aplicacion.Titulo = "Detalle de Ticket";
            _aplicacion.UsrId = cTLS_Id;
            _aplicacion.PagAct = Pagact;
            _aplicacion.Filtro = filtro;

            TicketARMOR ticketARMOR = new TicketARMOR();
            id = _aplicacion.UsrId * 1000 + id;
            Respuesta respuesta = ticketARMOR.Read(id.ToString());
            if (respuesta.Exito == 1)
            {
                IList<TicketARMOR> ticketARMORs = ticketARMOR.DeserializarList(respuesta.Data.ToString());
                ticketARMORs[0].Accion = "disabled";
                return View("Edit", ticketARMORs[0]);
            }
            return View("Edit", ticketARMOR);
        }

        public IActionResult Edit(int cTLS_Id, int id, int Pagact, string filtro)
        {

            _aplicacion.Menu = "Catalogo de Ticket Armor";
            _aplicacion.Titulo = "Actualizacion de Ticket";
            _aplicacion.UsrId = cTLS_Id;
            _aplicacion.PagAct = Pagact;
            _aplicacion.Filtro = filtro;

            TicketARMOR ticketARMOR = new TicketARMOR();
            id = _aplicacion.UsrId * 1000 + id;
            Respuesta respuesta = ticketARMOR.Read(id.ToString());
            if (respuesta.Exito == 1)
            {
                IList<TicketARMOR> ticketARMORs = ticketARMOR.DeserializarList(respuesta.Data.ToString());
                return View("Edit", ticketARMORs[0]);
            }
            return View("Edit", ticketARMOR);
        }


        public IActionResult Cancel(int cTLS_Id,int Pagact, string filtro)
        {
            return RedirectToAction(nameof(Listado), new { cTLS_Id = cTLS_Id, Pagact = Pagact, filtro = filtro });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Usuario(int Id)
        {
            _aplicacion.UsrId = Id;
            _aplicacion.UsrImg = "usr-" + Id + "-128x128.jpg";
            
            _aplicacion.Menu = "Matriz de Mando";
            _aplicacion.Titulo = "Index Usuarios";

            HttpContext.Session.SetString("Aplicacion", _aplicacion.Serializar());

            Usuarios usuarios = new Usuarios();
            Respuesta respuestas = usuarios.Read("-" + Id.ToString());
            TipoLista tipoLista = new TipoLista();
            if (respuestas.Exito == 1)
            {
                tipoLista = tipoLista.Deserializar(respuestas.Data.ToString());
            }
            return View(tipoLista.ticketARMOR);
        }
        public ActionResult GetDetalles(int id, string name)
        {
            string sAplicacion = HttpContext.Session.GetString("Aplicacion");
            if (sAplicacion != null)
            {
                _aplicacion = _aplicacion.Deserializar(sAplicacion);
            }

            _aplicacion.UsrId = id;
            _aplicacion.UsrImg = "usr-" + id + "-128x128.jpg";
            _aplicacion.NormalizedUsrName = name;

            sAplicacion = _aplicacion.Serializar();
            HttpContext.Session.SetString("Aplicacion", sAplicacion);
            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index", "Home");
        }

    }
}
