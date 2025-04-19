using Examen_Final_Progra06_Interfaz.Models;

namespace Examen_Final_Progra06_Interfaz.Servicios.ProductReviews
{
    public interface IsrvPReviews
    {
        Task<List<mProductReview>> obtenerPReviews();
        Task<mProductReview> obtenerPReviewXID(int pIdPReview);
        Task<bool> agregaPReview(mProductReview pPReview);
        Task<bool> modificaPReview(mProductReview pProductreview);
        Task<bool> eliminaPReview(int pIdPReview);

        Task<string> Autenticar(Usuario pLogin);
    }
}
