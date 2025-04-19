using AccesoDatos.Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgra06ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly iDepartmentLN gObjDepartamentoLN_ENT = new DepartmentLN();
        public DepartmentController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;
        }

        [Route("[action]")]
        [HttpGet] 
        public List<Department> obtenerDepartamentos()
        {
            List<Department>lObjRespuesta = new List<Department>();
            try
            {
                lObjRespuesta = gObjDepartamentoLN_ENT.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdDepartment}")]
        [HttpGet]
        public Department obtenerDepartamentosXID(int pIdDepartment)
        {
            Department lObjRespuesta = new Department();
            try
            {
                lObjRespuesta = gObjDepartamentoLN_ENT.obtenerDepartamentoXID(pIdDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insDepartamento([FromBody] Department pDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjDepartamentoLN_ENT.insDepartamento(pDepartment);
                    return Ok(pDepartment);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult modDepartamento(Department pDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjDepartamentoLN_ENT.modDepartamento(pDepartment);
                    return Ok(pDepartment);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        [Route("[action]/{pIdDepartment}")]
        [HttpDelete]
        [HttpPost]
        public IActionResult delDepartamento(int pIdDepartment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjDepartamentoLN_ENT.obtenerDepartamentoXID(pIdDepartment);
                    if (regExiste != null)
                    {
                        gObjDepartamentoLN_ENT.delDepartamento(regExiste);
                        return Ok(regExiste);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }



    }
}
