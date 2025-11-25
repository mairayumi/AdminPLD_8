using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using wsPLD_8.Models.Shared;
using wsPLD_8.Models.Catalogos;
using wsPLD_8.Extesion;

namespace wsPLD_8.Controllers
{
    public class OficiosController : Controller
    {
        private Aplicacion<int> _aplicacion;
        private readonly SignInManager<Usuarios> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public OficiosController(SignInManager<Usuarios> signInManager
                   , ILogger<HomeController> logger
                   , Aplicacion<int> aplicacion)
        {
            _signInManager = signInManager;
            _logger = logger;
            _aplicacion = aplicacion;
        }

        // GET: OficiosController
        public ActionResult Index(int Id, int Año, int Tipo, int PagAct)
        {
            _aplicacion.Menu = string.Concat("Oficios cargados al dia ", Id);
            _aplicacion.Titulo = string.Concat("Listado de año ", Año);

            if (PagAct.Equals(0) && _aplicacion.PagAct.Equals(0))
                PagAct++;
            else if (PagAct.Equals(0))
                PagAct = _aplicacion.PagAct;

            Respuesta respuesta = new Respuesta();
            EncOficio encOficio = new EncOficio();

            respuesta = encOficio.Read(string.Concat("?Id=", Id, "&Año=", Año, "&Tipo=", Tipo, "&PagAct=", PagAct));
            if (respuesta.Exito == 1 && respuesta.Data.ToString().Length > 0)
            {
                encOficio = encOficio.Deserializar(respuesta.Data.ToString());
                return View(encOficio);
            }
            return View(encOficio);
        }

        // GET: OficiosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OficiosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OficiosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OficiosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OficiosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OficiosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OficiosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
