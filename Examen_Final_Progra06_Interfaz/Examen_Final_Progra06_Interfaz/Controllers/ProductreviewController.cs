using Microsoft.AspNetCore.Mvc;
using Examen_Final_Progra06_Interfaz.Models;
using Examen_Final_Progra06_Interfaz.Servicios.ProductReviews;

namespace Examen_Final_Progra06_Interfaz.Controllers
{
    public class ProductreviewController : Controller
    {
        private readonly IsrvPReviews gApiProductreview;

        public ProductreviewController(IsrvPReviews lApiProductreview)
        {
            gApiProductreview = lApiProductreview;
        }

        [HttpGet]
        public async Task<ActionResult> obtenerProductreviews()
        {
            List<mProductReview> lObjRespuesta = new List<mProductReview>();
            try
            {
                lObjRespuesta = await gApiProductreview.obtenerPReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> agregaProductreview()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> modificaProductreview(int pIdProductreview)
        {
            mProductReview lObjRespuesta = new mProductReview();
            try
            {
                lObjRespuesta = await gApiProductreview.obtenerPReviewXID(pIdProductreview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> eliminaProductreview(int pIdProductreview)
        {
            mProductReview lObjRespuesta = new mProductReview();
            try
            {
                lObjRespuesta = await gApiProductreview.obtenerPReviewXID(pIdProductreview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpGet]
        public async Task<ActionResult> detalleProductreview(int pIdProductreview)
        {
            mProductReview lObjRespuesta = new mProductReview();
            try
            {
                lObjRespuesta = await gApiProductreview.obtenerPReviewXID(pIdProductreview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        [HttpPost]
        public async Task<ActionResult> insProductreview(mProductReview pProductreview)
        {
            List<mProductReview> lObjRespuesta = new List<mProductReview>();
            try
            {
                if (await gApiProductreview.agregaPReview(pProductreview))
                {
                    
                }
                else
                {
                   
                }
                lObjRespuesta = await gApiProductreview.obtenerPReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerProductreviews", lObjRespuesta);
        }

        [HttpPost]
        public async Task<ActionResult> modProductreview(mProductReview pProductreview)
        {
            List<mProductReview> lObjRespuesta = new List<mProductReview>();
            try
            {
                if (await gApiProductreview.modificaPReview(pProductreview))
                {
                   
                }
                else
                {
                    
                }
                lObjRespuesta = await gApiProductreview.obtenerPReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerProductreviews", lObjRespuesta);
        }

        [HttpPost]
        public async Task<ActionResult> delProductreview(mProductReview pProductreview)
        {
            List<mProductReview> lObjRespuesta = new List<mProductReview>();
            try
            {
                if (await gApiProductreview.eliminaPReview(pProductreview.ProductReviewId))
                {
                    
                }
                else
                {
                    
                }
                lObjRespuesta = await gApiProductreview.obtenerPReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return View("obtenerProductreviews", lObjRespuesta);
        }
    }
}
