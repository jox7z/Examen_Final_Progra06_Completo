using Microsoft.AspNetCore.Mvc;
using Examen_Final_Progra06_Interfaz.Models;
using Examen_Final_Progra06_Interfaz.Servicios.Departments;

namespace Examen_Final_Progra06_Interfaz.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IsrvDepartments gApiDepartment;

        public DepartmentController(IsrvDepartments lApiDepartment)
        {
            gApiDepartment = lApiDepartment;
        }

        [HttpGet]
        public async Task<ActionResult> obtenerDepartamentos()
        {
            List<mDepartments> lObjRespuesta = new List<mDepartments>();
            try
            {
                lObjRespuesta = await gApiDepartment.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> agregaDepartamento()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> modificaDepartamento(int pIdDepartment)
        {
            mDepartments lObjRespuesta = new mDepartments();
            try
            {
                lObjRespuesta = await gApiDepartment.obtenerDepartamentoXID(pIdDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> eliminaDepartamento(int pIdDepartment)
        {
            mDepartments lObjRespuesta = new mDepartments();
            try
            {
                lObjRespuesta = await gApiDepartment.obtenerDepartamentoXID(pIdDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> detalleDepartamento(int pIdDepartment)
        {
            mDepartments lObjRespuesta = new mDepartments();
            try
            {
                lObjRespuesta = await gApiDepartment.obtenerDepartamentoXID(pIdDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }


        [HttpPost]
        public async Task<ActionResult> insDepartamento(mDepartments pDepartamento)
        {
            List<mDepartments> lObjRespuesta = new List<mDepartments>();
            try
            {
                if (await gApiDepartment.agregaDepartamento(pDepartamento))
                {
                    
                }
                else
                {
                    
                }
                lObjRespuesta = await gApiDepartment.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerDepartamentos", lObjRespuesta);
        }

        [HttpPost]
        public async Task<ActionResult> modDepartamento(mDepartments pDepartamento)
        {
            List<mDepartments> lObjRespuesta = new List<mDepartments>();
            try
            {
                if (await gApiDepartment.modificaDepartamento(pDepartamento))
                {
                    
                }
                else
                {
                    
                }
                lObjRespuesta = await gApiDepartment.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerDepartamentos", lObjRespuesta);
        }

        [HttpPost]
        public async Task<ActionResult> delDepartamento(mDepartments pDepartamento)
        {
            List<mDepartments> lObjRespuesta = new List<mDepartments>();
            try
            {
                if (await gApiDepartment.eliminaDepartamento(pDepartamento.DepartmentId))
                {
                    
                }
                else
                {
                   
                }
                lObjRespuesta = await gApiDepartment.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerDepartamentos", lObjRespuesta);
        }
    }
}
