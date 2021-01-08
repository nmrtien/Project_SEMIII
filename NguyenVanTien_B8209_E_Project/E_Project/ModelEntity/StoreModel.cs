using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class StoreModel
    {
        private E_ProjectDbContext context = null;

        public StoreModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_STORE> getListStore()
        {

            var accountResult = context.Database.SqlQuery<TB_STORE>("PROC_GetAllStore").ToList();

            return accountResult;
        }

        public object inActiveStore(string s_id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ID", s_id)
            };
            var result = context.Database.SqlQuery<object>("PROC_InActiveStore @S_ID", sqlParams).SingleOrDefault();
            return result;
        }
    }
}
