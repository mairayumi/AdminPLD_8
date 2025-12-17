using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using waPLD.Models.Shared;

namespace waPLD.Extesion
{
    public static class MyExtensions
    {
        public static Respuesta Execute<T>(this T source)
        {
            return source.Operacion("E").Result;
        }
        public static Respuesta Create<T>(this T source)
        {
            return source.Operacion("I").Result;
        }
        public static Respuesta Read<T>(this T source)
        {
            return source.Operacion("S").Result;
        }
        public static Respuesta Update<T>(this T source)
        {
            return source.Operacion("U").Result;
        }
        public static Respuesta Delete<T>(this T source)
        {
            return source.Operacion("D").Result;
        }

        //------< Acceso Data Base Local Locales >-------------
        public static Respuesta ExecuteLocal<T>(this T source, string DataSource, string InitialCatalog)
        {
            return source.Operacion("E", DataSource, InitialCatalog).Result;
        }

        public static Respuesta CreateLocal<T>(this T source, string DataSource, string InitialCatalog)
        {
            return source.Operacion("I", DataSource, InitialCatalog).Result;
        }
        public static Respuesta ReadLocal<T>(this T source, string DataSource, string InitialCatalog)
        {
            return source.Operacion("S", DataSource, InitialCatalog).Result;
        }
        public static Respuesta UpdateLocal<T>(this T source, string DataSource, string InitialCatalog)
        {
            return source.Operacion("U", DataSource, InitialCatalog).Result;
        }
        public static Respuesta DeleteLocal<T>(this T source, string DataSource, string InitialCatalog)
        {
            return source.Operacion("D", DataSource, InitialCatalog).Result;
        }
        //------< Fin Acceso Data Base Local Locales >-------------
        internal static string Serializar<T>(this T source)
        {
            //XmlSerializer serializer =
            //    new XmlSerializer(typeof(T));

            //StringWriter stringWriter = new StringWriter();
            ////Declara la salida
            //String sXML;

            //using (XmlWriter writer = XmlWriter.Create(stringWriter))
            //{
            //    serializer.Serialize(writer, source);
            //    sXML = stringWriter.ToString().Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", "");
            //    sXML = sXML.Replace(@"\", "");
            //}
            string sXML = JsonConvert.SerializeObject(source);
            return sXML;
        }
        internal static T Deserializar<T>(this T source, string sXML)
        {
            //XmlSerializer serializer =
            //    new XmlSerializer(typeof(T));
            //StringReader reader = new StringReader(sXML);
            ////Declara la salida
            //T result;
            //using (XmlReader xmlReader = XmlReader.Create(reader))
            //{
            //    result = (T)serializer.Deserialize(xmlReader);
            //}
            T result = JsonConvert.DeserializeObject<T>(sXML);
            return result;
        }

        internal static List<T> DeserializarList<T>(this T source, string sXML)
        {
            //XmlSerializer serializer =
            //    new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Raiz"));
            //StringReader reader = new StringReader(sXML);
            ////Declara la salida
            List<T> result;
            //using (XmlReader xmlReader = XmlReader.Create(reader))
            //{
            //    result = (List<T>)serializer.Deserialize(xmlReader);
            //}
            result = JsonConvert.DeserializeObject<List<T>>(sXML);
            return result;
        }

        internal async static Task<Respuesta> Operacion<T>(this T value, string Tipo,string DataSource=null, string InitialCatalog = null)
        {
            Respuesta respuesta = new Respuesta();
            string valor = value.GetType().Name.Replace("Service", "");
            if (value.GetType().GenericTypeArguments.Count()>0)
            {
                valor = value.GetType().GenericTypeArguments[0].Name;
            }

            string sSQL = "sp" + Tipo + "_" + valor;
            //Solicitudes
            string connectString = @"Data Source = adsPeru05;Initial Catalog=pDBSirec2; Persist Security Info=True;User ID=adminPld;Password=Rpatria07;";
            //Base de datos local
            if (value.GetType().Namespace.Equals("waPLD.Models.Bitacora") ||
                value.GetType().Namespace.Equals("waPLD.Models.Catalogo") ||
                value.GetType().Namespace.Equals("waPLD.Models.Shared") ||
                value.GetType().Namespace.Equals("waPLD.Models.Catalogo.Usuario"))
            {
                //adsarmor02.rpa.gpv.mx[10.200.1.121]
                DataSource = "adsarmor02.rpa.gpv.mx";
                InitialCatalog = "Accesos";
            }

            if (DataSource != null) {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json")
                           .Build();

                connectString = configuration.GetConnectionString("DBTicketArmor");
                connectString = connectString
                                    .Replace("@DataSource", DataSource)
                                    .Replace("@InitialCatalog", InitialCatalog);
                connectString = connectString.Replace("Trust Server Certificate=True;", "");
            }

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectString);

            try
            {
                SqlCommand command = new SqlCommand(sSQL);
                string sXML = value.Serializar();
                command.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrEmpty(sXML))
                {
                    command.Parameters.AddWithValue("@JsonDocument", sXML);
                }

                //using (SqlConnection connection = new SqlConnection((User == null) ? builder.ConnectionString : connectString))
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    command.Connection = connection;
                    connection.Open();
                    var Valor = await command.ExecuteReaderAsync();
                    if (Valor.HasRows)
                    {
                        while (Valor.Read())
                        {
                            if (Valor.GetString(0).Equals("false"))
                            {
                                respuesta.exito = 0;
                                respuesta.mensaje = "Consulta sin resultados";
                            }
                            else
                            {
                                respuesta = respuesta.Deserializar(Valor.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                respuesta.mensaje = ex.Message;
                Console.Write(respuesta);
                throw;
            }
            return respuesta;
        }
        public static string GetSHA256<T>(this T source)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(source.ToString()));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}