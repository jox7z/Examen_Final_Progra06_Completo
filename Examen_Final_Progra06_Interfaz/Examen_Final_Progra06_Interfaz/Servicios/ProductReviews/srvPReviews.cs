using System.Text;
using System.Text.Json.Serialization;
using Examen_Final_Progra06_Interfaz.Models;
using Newtonsoft.Json;

namespace Examen_Final_Progra06_Interfaz.Servicios.ProductReviews
{
    public class srvPReviews : IsrvPReviews
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvPReviews()
        {
            var appConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            gBaseUrl = appConfig.GetSection("ConfigApi:baseUrl").Value;
        }

        public async Task<string> Autenticar(Usuario pLogin)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);

                var credenciales = new Usuario
                {
                    usuario = pLogin.usuario,
                    contrasena = pLogin.contrasena
                };

                var contenido = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

                var ejecucion = await cliente.PostAsync("api/Autenticacion/validarUsuario/", contenido);

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<resultadoToken>(respuesta);
                    gToken = resultado.token;
                }
                else
                {
                    gToken = "";
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return gToken;
        }


        public async Task<List<mProductReview>> obtenerPReviews()
        {
           
            List<mProductReview> lObjRespuesta = new List<mProductReview>();

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync("ProductReview/obtenerProductReviews/");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mProductReview>>(respuesta);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lObjRespuesta;
        }

        public async Task<mProductReview> obtenerPReviewXID(int pIdPReview)
        {
            

            mProductReview lObjRespuesta = new mProductReview();

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"ProductReview/obtenerProductReviewXID/{pIdPReview}");

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mProductReview>(respuesta);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lObjRespuesta;
        }

        public async Task<bool> agregaPReview(mProductReview pPReview)
        {
          

            mProductReview lObjResultado = new mProductReview();
            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pPReview), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("ProductReview/insProductReview/", contenido);

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mProductReview>(respuesta);
                    if (lObjResultado.ProductReviewId != 0)
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

        public async Task<bool> modificaPReview(mProductReview pProductreview)
        {
            

            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pProductreview), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PutAsync("ProductReview/modProductReview/", contenido);

                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    var lObjResultado = JsonConvert.DeserializeObject<mProductReview>(respuesta);
                    if (lObjResultado.ProductReviewId != 0)
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

        public async Task<bool> eliminaPReview(int pIdPReview)
        {
           

            bool lObjRespuesta = false;

            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"ProductReview/delProductreview/{pIdPReview}");

                if (ejecucion.IsSuccessStatusCode)
                {
                    lObjRespuesta = true;
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