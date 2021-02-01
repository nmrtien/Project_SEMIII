using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class PlanDBModel
    {
        private E_ProjectDbContext context = null;

        public PlanDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_PLAN> getListPlan()
        {

            var result = context.Database.SqlQuery<TB_PLAN>("Usp_GetAllPlan").ToList();

            return result;
        }

        public List<TB_PLAN> getListPlanTop3()
        {

            var result = context.Database.SqlQuery<TB_PLAN>("Usp_GetAllPlanTop3").ToList();

            return result;
        }

        public object updateStatusPlan(int n_id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusPlan @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public TB_PLAN getPlanById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_PLAN result = context.Database.SqlQuery<TB_PLAN>("Usp_GetPlanById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object updatePlanById(TB_PLAN model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DETAIL", model.S_DETAIL),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updatePlanById @N_ID,@S_NAME,@S_TYPE,@S_DETAIL,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createPlan(TB_PLAN model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DETAIL", model.S_DETAIL),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertPlan @S_NAME,@S_TYPE,@S_DETAIL,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
