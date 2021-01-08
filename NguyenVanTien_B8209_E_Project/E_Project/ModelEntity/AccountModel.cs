using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class AccountModel
    {
        private E_ProjectDbContext context = null;

        public AccountModel()
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
            var result = context.Database.SqlQuery<int>("PROC_Login @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return result;
        }

        public TB_ACCOUNT getAccount(string account, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ACCOUNT", account),
                new SqlParameter("@S_PASSWORD", password)
            };
            TB_ACCOUNT accountResult = context.Database.SqlQuery<TB_ACCOUNT>("PROC_GetAccount @S_ACCOUNT,@S_PASSWORD", sqlParams).SingleOrDefault();

            return accountResult;
        }

        public List<TB_ACCOUNT> getListEmployee()
        {
       
            var accountResult = context.Database.SqlQuery<TB_ACCOUNT>("PROC_GetListEmployee").ToList();

            return accountResult;
        }

        public object deleteAccount(string s_id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ID", s_id)
            };
            var result = context.Database.SqlQuery<object>("PROC_DeleteAccount @S_ID", sqlParams).SingleOrDefault();
            return result;
        }

        public object inActiveAccount(string s_id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ID", s_id)
            };
            var result = context.Database.SqlQuery<object>("PROC_InActiveAccount @S_ID", sqlParams).SingleOrDefault();
            return result;
        }
    }
}
