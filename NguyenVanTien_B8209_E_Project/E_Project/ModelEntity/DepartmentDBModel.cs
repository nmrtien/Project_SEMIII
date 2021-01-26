using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class DepartmentDBModel
    {
        private E_ProjectDbContext context = null;

        public DepartmentDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_DEPARTMENT> getListDepartment()
        {

            var result = context.Database.SqlQuery<TB_DEPARTMENT>("Usp_GetAllDepartment").ToList();

            return result;
        }

        public object updateStatusDepartment(int n_id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusDepartment @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public TB_DEPARTMENT getDepartmentById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_DEPARTMENT result = context.Database.SqlQuery<TB_DEPARTMENT>("Usp_GetDepartmentById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object updateDepartmentById(TB_DEPARTMENT model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_CONTACT", model.S_CONTACT)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateDepartmentById @N_ID,@S_NAME,@S_CONTACT", sqlParams).SingleOrDefault();

            return result;
        }

        public object createDepartment(TB_DEPARTMENT model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_CONTACT", model.S_CONTACT)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertDepartment @S_NAME,@S_CONTACT", sqlParams).SingleOrDefault();

            return result;
        }
    }
}

