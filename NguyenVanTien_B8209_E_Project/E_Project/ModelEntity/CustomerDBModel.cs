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

        public int Login(string account, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", account),
                new SqlParameter("@S_PASSWORD", password)
            };
            var result = context.Database.SqlQuery<int>("Usp_CustomerLogin @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return result;
        }

        public TB_CUSTOMER getCustomer(string account, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", account),
                new SqlParameter("@S_PASSWORD", password)
            };
            TB_CUSTOMER accountResult = context.Database.SqlQuery<TB_CUSTOMER>("Usp_GetCustomerLogin @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return accountResult;
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
            TB_CUSTOMER result = context.Database.SqlQuery<TB_CUSTOMER>("Usp_GetCustomerById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object updateCustomerById(TB_CUSTOMER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_CUSTOMER_NAME", model.S_ADDRESS),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateCustomerById @N_ID,@S_CUSTOMER_NAME,@S_PHONE,@S_ADDRESS,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object updateCodeById(TB_CUSTOMER model)
        {
            object[] sqlParams =
            {
                 new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_CODE", model.S_CODE)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateCodeCustomer @N_ID,@S_CODE", sqlParams).SingleOrDefault();

            return result;
        }


        public object registerCustomer(TB_CUSTOMER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", model.S_ACCOUNT),
                new SqlParameter("@S_PASSWORD", model.S_PASSWORD),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_RegisterCustomer @S_ACCOUNT,@S_PASSWORD,@S_NAME,@S_PHONE,@S_ADDRESS,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createPlanDetail(TB_PLAN_DETAIL model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@D_EXPRIRE", model.D_EXPRIRE),                         
                new SqlParameter("@N_AMOUNT", model.N_AMOUNT),
                new SqlParameter("@S_DETAIL", model.S_DESCRIPTION),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION),
                new SqlParameter("@N_PLAN_ID", model.N_PLAN_ID),
                new SqlParameter("@N_CUSTOMER_ID", model.N_CUSTOMER_ID)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertPlanDetail @D_EXPRIRE,@N_AMOUNT,@S_DETAIL,@S_DESCRIPTION,@N_PLAN_ID,@N_CUSTOMER_ID", sqlParams).SingleOrDefault();

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
