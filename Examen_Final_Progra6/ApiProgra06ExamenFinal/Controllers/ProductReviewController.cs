using AccesoDatos.Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgra06ExamenFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly iProductReviewLN gObjProductReviewLN_ENT = new ProductReviewLN();

        public ProductReviewController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;
        }

        [Route("[action]")]
        [HttpGet]
        public List<ProductReview> obtenerProductReviews()
        {
            List<ProductReview> lObjRespuesta = new List<ProductReview>();
            try
            {
                lObjRespuesta = gObjProductReviewLN_ENT.obtenerProductReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdProductReview}")]
        [HttpGet]
        public ProductReview obtenerProductReviewXID(int pIdProductReview)
        {
            ProductReview lObjRespuesta = new ProductReview();
            try
            {
                lObjRespuesta = gObjProductReviewLN_ENT.obtenerProductReviewXID(pIdProductReview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insProductReview([FromBody] ProductReview pProductReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjProductReviewLN_ENT.insProductReview(pProductReview);
                    return Ok(pProductReview);
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
        [HttpPut]
        public IActionResult modProductReview([FromBody] ProductReview pProductReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjProductReviewLN_ENT.modProductReview(pProductReview);
                    return Ok(pProductReview);
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

        [Route("[action]/{pIdProductReview}")]
        [HttpDelete]
        public IActionResult delProductReview(int pIdProductReview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjProductReviewLN_ENT.obtenerProductReviewXID(pIdProductReview);
                    if (regExiste != null)
                    {
                        gObjProductReviewLN_ENT.delProductReview(regExiste);
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
