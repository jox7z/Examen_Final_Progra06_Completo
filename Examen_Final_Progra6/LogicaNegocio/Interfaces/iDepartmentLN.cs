using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface iDepartmentLN
    {
        List<Department> obtenerDepartamentos();
        Department obtenerDepartamentoXID(int pIdDepartment);
        bool insDepartamento(Department pDepartment);
        bool modDepartamento(Department pDepartment);
        bool delDepartamento(Department pDepartment);

    }
}
