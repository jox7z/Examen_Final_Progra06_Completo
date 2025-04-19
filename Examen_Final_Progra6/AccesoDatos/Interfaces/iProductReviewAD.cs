using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace AccesoDatos.Interfaces
{
    public interface iProductReviewAD
    {
        List<ProductReview> obtenerProductReviews();
        ProductReview obtenerProductReviewXID(int pIdReview);
        bool insProductReview(ProductReview pReview);
        bool modProductReview(ProductReview pReview);
        bool delProductReview(ProductReview pReview);

    }
}
