using Examen_Final_Progra06_Interfaz.Models;

namespace Examen_Final_Progra06_Interfaz.Servicios.Departments
{
    public interface IsrvDepartments
    {
        
        Task<List<mDepartments>> obtenerDepartamentos();
        Task<mDepartments> obtenerDepartamentoXID(int pIdDepartments);
        Task<bool> agregaDepartamento(mDepartments pDepartamento);
        Task<bool> modificaDepartamento(mDepartments pDepartamento);
        Task<bool> eliminaDepartamento(int pIdDepartamento);
        Task<string> Autenticar(Usuario pLogin);

    }
}
