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

        public TB_STORE getStoreById(string id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ID", id)
            };
            TB_STORE storeResult = context.Database.SqlQuery<TB_STORE>("PROC_GetStoreById @S_ID", sqlParams).SingleOrDefault();

            return storeResult;
        }

        public object updateStoreById(TB_STORE store)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_ID", store.S_ID),
                new SqlParameter("@S_NAME", store.S_NAME),
                new SqlParameter("@S_ADDRESS", store.S_ADDRESS),
                new SqlParameter("@S_CONTACT", store.S_CONTACT),
            };
            var result = context.Database.SqlQuery<object>("PROC_updateStoreById @S_ID,@S_NAME,@S_ADDRESS,@S_CONTACT", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
