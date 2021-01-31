using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModelEntity
{
    public class CustomerDBModel
    {
        private E_ProjectDbContext context = null;

        public CustomerDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_CUSTOMER> getListCustomer()
        {

            var result = context.Database.SqlQuery<TB_CUSTOMER>("Usp_GetAllCustomer").ToList();

            return result;
        }

        public object updateStatusCustomer(int id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusCustomer @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public object getDetailCustomer(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id),
            };
            var result = context.Database.SqlQuery<TB_CUSTOMER>("Usp_GetDetailCustomer @N_ID", sqlParams).ToList();
            return result;
        }

        public TB_CUSTOMER getCustomerById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_CUSTOMER result = context.Database.SqlQuery<TB_CUSTOMER>("Usp_GetOrderById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object updateOrderById(TB_CUSTOMER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_CUSTOMER_NAME", model.S_ADDRESS),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateOrderById @N_ID,@S_CUSTOMER_NAME,@S_PHONE,@S_ADDRESS,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createCustomer(TB_CUSTOMER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_CODE", model.S_CODE),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION),
                new SqlParameter("@N_ACCOUNT_ID", model.N_ACCOUNT_ID)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertCustomer @S_CODE,@S_NAME,@S_PHONE,@S_ADDRESS,@S_DESCRIPTION,@N_ACCOUNT_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object createPlanDetail(TB_PLAN_DETAIL model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_AMOUNT", model.N_AMOUNT),                         
                new SqlParameter("@S_DETAIL", model.S_DETAIL),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION),
                new SqlParameter("@D_EXPRIRE", model.D_EXPRIRE),
                new SqlParameter("@N_CUSTOMER_ID", model.N_CUSTOMER_ID),
                new SqlParameter("@N_PLAN_ID", model.N_PLAN_ID)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertPlanDetail @N_AMOUNT,@S_DETAIL,@S_DESCRIPTION,@D_EXPRIRE,@N_CUSTOMER_ID,@N_PLAN_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public List<TB_ACCOUNT> getListSale()
        {

            var accountResult = context.Database.SqlQuery<TB_ACCOUNT>("Usp_GetListSale").ToList();

            return accountResult;
        }

        public List<TB_PLAN> getListPlan()
        {

            var result = context.Database.SqlQuery<TB_PLAN>("Usp_GetAllPlan").ToList();

            return result;
        }
    }
}
