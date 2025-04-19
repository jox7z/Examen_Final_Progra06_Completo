using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Implementacion
{
    public class ProductReviewAD : iProductReviewAD
    {
        private AWContext gObjCnnAW;

        public ProductReviewAD(AWContext lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;
        }

        public List<ProductReview> obtenerProductReviews()
        {
            List<ProductReview> lObjRespuesta = new List<ProductReview>();

            try
            {
                lObjRespuesta = gObjCnnAW.ProductReviews.ToList();
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
                lObjRespuesta = gObjCnnAW.ProductReviews.ToList().Find(p => p.ProductReviewId == pIdReview);
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
                var lRegExiste = gObjCnnAW.ProductReviews.Find(pReview.ProductReviewId);

                if (lRegExiste == null)
                {
                    gObjCnnAW.ProductReviews.Add(pReview);
                    gObjCnnAW.SaveChanges();
                    lObjRespuesta = true;
                }
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
                var lRegExiste = gObjCnnAW.ProductReviews.Find(pReview.ProductReviewId);

                if (lRegExiste != null)
                {
                    gObjCnnAW.Entry(lRegExiste).CurrentValues.SetValues(pReview);
                    gObjCnnAW.Entry(lRegExiste).State = EntityState.Modified;
                    gObjCnnAW.SaveChanges();
                    lObjRespuesta = true;
                }
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
                var lRegExiste = gObjCnnAW.ProductReviews.Find(pReview.ProductReviewId);

                if (lRegExiste != null)
                {
                    gObjCnnAW.Entry(lRegExiste).CurrentValues.SetValues(pReview);
                    gObjCnnAW.Entry(lRegExiste).State = EntityState.Deleted;
                    gObjCnnAW.SaveChanges();
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
