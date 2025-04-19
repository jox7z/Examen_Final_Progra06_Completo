using System.Text;
using System.Text.Json.Serialization;
using Examen_Final_Progra06_Interfaz.Models;
using Newtonsoft.Json;

namespace Examen_Final_Progra06_Interfaz.Servicios.Departments
{
    public class srvDepartments : IsrvDepartments
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvDepartments()
        {
            var appConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            gBaseUrl = appConfig.GetSection("ConfigApi:baseUrl").Value;
        }

        public async Task<string> Autenticar(Usuario pLogin)
        {
            bool lObjRespuesta = false;
            mDepartments lObjResultado = new mDepartments();

            try
            {
                
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);

                var credenciales = new Usuario { usuario = pLogin.usuario, contrasena = pLogin.contrasena };
                var contenido = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

                var ejecucion = await cliente.PostAsync("api/Autenticacion/validarUsuario", contenido);

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<resultadoToken>(respuesta);
                    gToken = resultado.token;
                }
                else {
                    gToken = "";
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return gToken; 
        }


        public async Task<List<mDepartments>> obtenerDepartamentos()
        {
            List<mDepartments> lObjRespuesta = new List<mDepartments>();

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);

                var ejecucion = await cliente.GetAsync("api/Department/obtenerDepartamentos");

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mDepartments>>(respuesta);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lObjRespuesta;
        }

        public async Task<mDepartments> obtenerDepartamentoXID(int pIdDepartments)
        {
            mDepartments lObjRespuesta = new mDepartments();

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"api/Department/obtenerDepartamentosXID/{pIdDepartments}");


                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mDepartments>(respuesta);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lObjRespuesta;
        }

        public async Task<bool> agregaDepartamento(mDepartments pDepartamento)
        {
            mDepartments lObjResultado = new mDepartments();
            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pDepartamento), System.Text.Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("api/Department/insDepartamento", contenido);


                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mDepartments>(respuesta);
                    if (lObjResultado.DepartmentId != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public async Task<bool> modificaDepartamento(mDepartments pDepartamento)
        {
            mDepartments lObjResultado = new mDepartments();
            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pDepartamento), System.Text.Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("api/Department/modDepartamento", contenido);

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mDepartments>(respuesta);
                    if (lObjResultado.DepartmentId != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public async Task<bool> eliminaDepartamento(int pIdDepartamento)
        {
            mDepartments lObjResultado = new mDepartments();
            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"api/Department/delDepartamento/{pIdDepartamento}");

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mDepartments>(respuesta);
                    if (lObjResultado.DepartmentId != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }




    }
}
