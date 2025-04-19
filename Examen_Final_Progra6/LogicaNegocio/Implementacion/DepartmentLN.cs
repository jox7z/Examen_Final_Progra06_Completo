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
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Implementacion
{
    public class DepartmentLN : iDepartmentLN
    {
        public static AWContext lObjAWcnn = new AWContext();

        private readonly iDepartmentAD gObjDepartmentAD = new DepartmentAD(lObjAWcnn);

        public List<Department> obtenerDepartamentos()
        {
            List<Department> lObjRespuesta = new List<Department>();

            try
            {
                lObjRespuesta = gObjDepartmentAD.obtenerDepartamentos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public Department obtenerDepartamentoXID(int pIdDepartment)
        {
            Department lObjRespuesta = new Department();

            try
            {
                lObjRespuesta = gObjDepartmentAD.obtenerDepartamentoXID(pIdDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool insDepartamento(Department pDepartment)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjDepartmentAD.insDepartamento(pDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool modDepartamento(Department pDepartment)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjDepartmentAD.modDepartamento(pDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool delDepartamento(Department pDepartment)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjDepartmentAD.delDepartamento(pDepartment);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}
