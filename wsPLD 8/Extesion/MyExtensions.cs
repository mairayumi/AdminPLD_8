using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using wsPLD_8.Models.Shared;

namespace wsPLD_8.Extesion
{
    public static class MyExtensions
    {
        //public static Usuario User;
        public static Respuesta Execute<T>(this T source)
        {
            return source.Operacion("E").Result;
        }
        //public static Respuesta Create<T>(this T source)
        //{
        //    return source.Operacion("I").Result;
        //}
        public static Respuesta Create<T>(this T source, string Servicio="")
        {
            return source.Operacion("I", Servicio).Result;
        }

        //public static Respuesta Read<T>(this T source)
        //{
        //    return source.Operacion("S").Result;
        //}
        public static Respuesta Read<T>(this T source, string Servicio = "")
        {
            return source.Operacion("S", Servicio).Result;
        }

        public static Respuesta Update<T>(this T source, string Servicio = "")
        {
            return source.Operacion("U").Result;
        }
        public static Respuesta Delete<T>(this T source, string Servicio = "")
        {
            return source.Operacion("D", Servicio).Result;
        }

        internal static string Serializar<T>(this T source)
        {
            string sXML = JsonConvert.SerializeObject(source);
            return sXML;
        }

        internal static T Deserializar<T>(this T source, string sXML)
        {
            T result = JsonConvert.DeserializeObject<T>(sXML);
            return result;
        }

        internal static List<T> DeserializarList<T>(this T source, string sXML)
        {
            List<T> result;
            result = JsonConvert.DeserializeObject<List<T>>(sXML);
            return result;
        }

        internal static async System.Threading.Tasks.Task<Respuesta> Operacion(this object sourceIn, string Tipo, string Servicio = "")
        {
            Respuesta _respueta = new Respuesta();
            //Para web config
            //string _BaseUrl = ConfigurationManager.AppSettings("WebServices");
            var bulder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connectionString = bulder.GetSection("ConnectionStrings:WebServices").Value;
            string ServicioIn = "/api/" + sourceIn.GetType().Name;

            if (Servicio.Length > 0)
                ServicioIn += "/" + Servicio;

            Servicio = ServicioIn;

            try
            {
                using (HttpClient clients = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(sourceIn), Encoding.UTF8, "application/json");

                    clients.BaseAddress = new Uri(connectionString);
                    HttpResponseMessage response = null;

                    switch (Tipo)
                    {
                        case "S":
                            {
                                response = clients.GetAsync(Servicio).Result;
                                break;
                            }

                        case "I" or "E":
                            {
                                response = clients.PostAsync(Servicio, content).Result;
                                break;
                            }

                        case "U":
                            {
                                response = clients.PutAsync(Servicio, content).Result;
                                break;
                            }

                        case "D":
                            {
                                response = clients.DeleteAsync(Servicio).Result;
                                break;
                            }
                    }

                    var JSon = response.Content.ReadAsStringAsync().Result;
                    if (JSon.Length > 0)
                    {
                        _respueta = JsonConvert.DeserializeObject<Respuesta>(JSon);
                    }
                    else
                    {
                        _respueta.Exito = 0;
                        _respueta.Mensaje = (int)response.StatusCode + ' ' + response.RequestMessage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                _respueta.Exito = 0;
                _respueta.Mensaje = ex.Message;
            }

            return _respueta;
        }
        public static string GenerarContraseña(int longitud = 8)
        {
            // Definir los conjuntos de caracteres posibles
            string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string minusculas = "abcdefghijklmnopqrstuvwxyz";
            string numeros = "0123456789";
            string caracteresEspeciales = "!@$^*()-_={}|:,.?";

            // Combinamos todos los conjuntos de caracteres
            string todosCaracteres = mayusculas + minusculas + numeros + caracteresEspeciales;

            // Crear un generador aleatorio
            Random random = new Random();

            // Generamos la contraseña garantizando que haya al menos un carácter de cada tipo
            char[] contrasena = new char[longitud];

            contrasena[0] = mayusculas[random.Next(mayusculas.Length)]; // Mayúscula
            contrasena[1] = minusculas[random.Next(minusculas.Length)]; // Minúscula
            contrasena[2] = numeros[random.Next(numeros.Length)]; // Número
            contrasena[3] = caracteresEspeciales[random.Next(caracteresEspeciales.Length)]; // Carácter especial

            // Llenamos el resto de la contraseña con caracteres aleatorios
            for (int i = 4; i < longitud; i++)
            {
                contrasena[i] = todosCaracteres[random.Next(todosCaracteres.Length)];
            }

            // Mezclamos los caracteres de la contraseña para evitar patrones predecibles
            Random rng = new Random();
            contrasena = contrasena.OrderBy(c => rng.Next()).ToArray();

            // Convertir el arreglo de caracteres a una cadena
            return new string(contrasena);
        }

    }
}
