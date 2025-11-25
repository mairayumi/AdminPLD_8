using wsPLD_8.Extesion;
using static System.Net.Mime.MediaTypeNames;

namespace wsPLD_8.Models.Shared
{
    public class Aplicacion<TKey> where TKey : IEquatable<TKey>
    {   private IHttpContextAccessor _HttpContextAccessor;
        public Aplicacion(IHttpContextAccessor HttpContextAccessor)
        {
            _HttpContextAccessor= HttpContextAccessor;
            menusApp = new List<MenuApp>();
            LoadMenu();
            LoadCatalogo(1);
        }
        public int Id { get; set; }
        public TKey UsrId { get; set; }
        public string UsrImg { get; set; }
        public string UsrName { get; set; }
        public string NormalizedUsrName { get; set; }
        public int cTKA_Id { get; set; }
        public string UsrPassword { get; set; }
        public string UsrMessage { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string PostName { get; set; }
        public string FondoLogin { get; set; }
        public string Logo { get; set; }
        public string mainheader { get; set; }
        public string mainfooter { get; set; }
        public IList<MenuApp> menuAppsSuperior { get; set; }
        public IList<MenuApp> menusApp { get; set; }
        public Catalogo catalogo { get; set; }
        public string? Filtro { get; set; }
        public string? Periodo { get; set; }
        public int PagAct { get; set; }
        public string? Menu { get; set; }

        public string? Titulo { get; set; }
        void LoadMenu()
        {
            if (Id == 0) //ViewData["aplicacion"] == null)
            {
                Id = 1;
                Name = "Admin";
                Version = "1.2.2";
                PostName = "PLD";
                FondoLogin = "medico.png";
                PagAct = 1;
                //objAplicacion = aplicacion.Serializar();

                menuAppsSuperior = new List<MenuApp>() {
                new MenuApp {titulo= "PLD Listado",icon = "fa-chart-pie" ,hRef="/Home/Listado/1"}
                ,new MenuApp {titulo= "PLD Busqueda",icon = "fa-chart-pie" ,hRef="/Home/Details1"}
                ,new MenuApp {titulo= "PLD Calendar",icon = "fa-chart-pie" ,hRef="/Calendar/Index"}
                ,new MenuApp {titulo= "PLD Salud",icon = "fa-tree" ,hRef="https://adsarmpolonia01.rpa.gpv.mx/#/login", target="_blank"}
                ,new MenuApp {titulo= "PLD Seguros",icon = "fa-edit" ,hRef="https://adswarpolonia.rpa.gpv.mx/#/login", target="_blank"}
                ,new MenuApp {titulo= "PLD Patria",icon = "fa-table" ,hRef="https://adsarmpolonia02.gse.gpv.mx/#/login", target="_blank"}};
            }
        }
        void LoadCatalogo(int TipCatalogo)
        {
            catalogo = new Catalogo();
            Respuesta respuestaIn = catalogo.Read(TipCatalogo.ToString());
            if (respuestaIn.Exito == 1)
            {
                catalogo = catalogo.Deserializar(respuestaIn.Data.ToString());
            }
        }

        public void ValidaUser(Boolean LogIn)
        {
            
            if (LogIn)
            {
                //ViewData["body"] = "sidebar-mini";
                if (menusApp.Count == 0)
                {
                    menusApp.Add(new MenuApp
                    {
                        hRef = string.Concat("/Home/Usuario/" ,Id),
                        icon = "fa-solid fa-users",
                        titulo = "Matriz de Mando",
                        tab = "Usuario"
                    });

                    menusApp.Add(new MenuApp
                    {
                        hRef = "#",
                        icon = "fa-tachometer-alt",
                        titulo = "PLD Produccion",
                        Items = new List<MenuApp>()
                                                        { new MenuApp(){
                                                            hRef = "https://adsarmpolonia01.rpa.gpv.mx/#/login"
                                                            ,icon = "fa-circle"
                                                            ,titulo = "Salud"
                                                            ,span = "2"
                                                            ,target ="_blank"},
                                                          new MenuApp(){
                                                            hRef = "https://adswarpolonia.rpa.gpv.mx/#/login"
                                                            ,icon = "fa-circle"
                                                            ,titulo = "Seguros"},
                                                          new MenuApp(){
                                                            hRef = "https://adsarmpolonia02.gse.gpv.mx/#/login"
                                                            ,icon = "fa-circle"
                                                            ,titulo = "Patria"}
                                                         }
                    });
                    menusApp.Add(new MenuApp
                    {
                        hRef = "/Busqueda/Index",
                        icon = "fa-list",
                        titulo = "PLD Busqueda(s)",
                        tab = "Negocio"
                    });
                }
            }
        }
        public Aplicacion<int> ValidaUser(Aplicacion<int> _aplicacion)
        {
            string sAplicacion = _HttpContextAccessor.HttpContext.Session.GetString("Aplicacion");
            if (sAplicacion != null)
            {
                return _aplicacion.Deserializar(sAplicacion);
            }
            else
            {
                return _aplicacion;
            }
        }

    }
}