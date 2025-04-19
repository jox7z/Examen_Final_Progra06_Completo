using Microsoft.AspNetCore.Mvc;
using Examen_Final_Progra06_Interfaz.Models;
using Examen_Final_Progra06_Interfaz.Servicios.Departments;
using Examen_Final_Progra06_Interfaz.Servicios.ProductReviews;

namespace Examen_Final_Progra06_Interfaz.Controllers
{
    public class LoginController : Controller
    {
        private readonly IsrvDepartments gApiDepartamentos;
        private readonly IsrvPReviews gApiProductoReview;

        public LoginController(IsrvDepartments lApiDepartamentos, IsrvPReviews lApiProductoReview)
        {
            gApiDepartamentos = lApiDepartamentos;
            gApiProductoReview = lApiProductoReview;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> accesoUsuario(Usuario pLogin)
        {
            string token = await gApiDepartamentos.Autenticar(pLogin);
            string token2 = await gApiProductoReview.Autenticar(pLogin);

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(token2))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("errorGeneral");
            }
        }

        [HttpGet]
        public IActionResult errorGeneral()
        {
            return View();
        }

        [HttpGet]
        public IActionResult retornarLogin()
        {
            return View("Login");
        }
    }
}
