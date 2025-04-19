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
    public class DepartmentAD : iDepartmentAD
    {
        private AWContext gObjCnnAW;

        public DepartmentAD(AWContext lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;

        }

        public List<Department> obtenerDepartamentos()
        {
            List <Department> lObjRespuesta = new List<Department> ();

            try
            {
                lObjRespuesta = gObjCnnAW.Departments.ToList();
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
                lObjRespuesta = gObjCnnAW.Departments.ToList().Find(d => d.DepartmentId == pIdDepartment);
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
                var lRegExiste = gObjCnnAW.Departments.Find(pDepartment.DepartmentId);
                if(lRegExiste == null)
                {
                    gObjCnnAW.Departments.Add(pDepartment);
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

        public bool modDepartamento(Department pDepartment)
        {
            bool lObjRespuesta = false;
            try
            {
                var lRegExiste = gObjCnnAW.Departments.Find(pDepartment.DepartmentId);
                if (lRegExiste != null)
                {
                    gObjCnnAW.Entry(lRegExiste).CurrentValues.SetValues(pDepartment);
                    gObjCnnAW.Entry(lRegExiste).State = EntityState.Modified;
                    gObjCnnAW.SaveChanges() ;
                    lObjRespuesta = true;
                }
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
                var lRegExiste = gObjCnnAW.Departments.Find(pDepartment.DepartmentId);
                if (lRegExiste != null)
                {
                    gObjCnnAW.Entry(lRegExiste).CurrentValues.SetValues(pDepartment);
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
