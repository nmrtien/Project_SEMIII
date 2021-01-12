using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class AccountDBModel
    {
        private E_ProjectDbContext context = null;

        public AccountDBModel()
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
            var result = context.Database.SqlQuery<int>("Usp_Login @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return result;
        }

        public TB_ACCOUNT getAccount(string account, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", account),
                new SqlParameter("@S_PASSWORD", password)
            };
            TB_ACCOUNT accountResult = context.Database.SqlQuery<TB_ACCOUNT>("Usp_GetAccountLogin @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return accountResult;
        }

        public List<TB_ACCOUNT> getListEmployee()
        {
       
            var accountResult = context.Database.SqlQuery<TB_ACCOUNT>("Usp_GetListEmployee").ToList();

            return accountResult;
        }

        public List<TB_ACCOUNT> getListManager()
        {

            var accountResult = context.Database.SqlQuery<TB_ACCOUNT>("Usp_GetListManager").ToList();

            return accountResult;
        }

        public List<TB_STORE> getAllStore()
        {

            var result = context.Database.SqlQuery<TB_STORE>("Usp_GetAllStore").ToList();

            return result;
        }

        public List<TB_DEPARTMENT> getAllDepartment()
        {

            var result = context.Database.SqlQuery<TB_DEPARTMENT>("Usp_GetAllDepartment").ToList();

            return result;
        }

        public object deleteAccount(int n_id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id)
            };
            var result = context.Database.SqlQuery<object>("Usp_DeleteAccount @N_ID", sqlParams).SingleOrDefault();
            return result;
        }

        public object updateStatusAccount(int n_id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusAccount @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public object createAccount(TB_ACCOUNT account)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", account.S_ACCOUNT),
                new SqlParameter("@S_PASSWORD", account.S_PASSWORD),
                new SqlParameter("@S_TYPE", account.S_TYPE),
                new SqlParameter("@S_FULLNAME", account.S_FULLNAME),
                new SqlParameter("@S_PHONE", account.S_PHONE),
                new SqlParameter("@S_ADDRESS", account.S_ADDRESS),
                new SqlParameter("@S_TECHNICAL", account.S_TECHNICAL),
                new SqlParameter("@D_BIRTHDAY", account.D_BIRTHDAY),
                new SqlParameter("@N_STORE_ID", account.N_STORE_ID),
                new SqlParameter("@N_DEPARTMENT_ID", account.N_DEPARTMENT_ID)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertAccount @S_ACCOUNT,@S_PASSWORD,@S_TYPE,@S_FULLNAME,@S_PHONE,@S_ADDRESS,@S_TECHNICAL,@D_BIRTHDAY,@N_STORE_ID,@N_DEPARTMENT_ID", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
