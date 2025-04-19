using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class ProductReviewLN : iProductReviewLN
    {
        public static AWContext lObjAWcnn = new AWContext();

        private readonly iProductReviewAD gObjProductReviewAD = new ProductReviewAD(lObjAWcnn);

        public List<ProductReview> obtenerProductReviews()
        {
            List<ProductReview> lObjRespuesta = new List<ProductReview>();

            try
            {
                lObjRespuesta = gObjProductReviewAD.obtenerProductReviews();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public ProductReview obtenerProductReviewXID(int pIdReview)
        {
            ProductReview lObjRespuesta = new ProductReview();

            try
            {
                lObjRespuesta = gObjProductReviewAD.obtenerProductReviewXID(pIdReview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool insProductReview(ProductReview pReview)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjProductReviewAD.insProductReview(pReview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool modProductReview(ProductReview pReview)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjProductReviewAD.modProductReview(pReview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool delProductReview(ProductReview pReview)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjProductReviewAD.delProductReview(pReview);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}
