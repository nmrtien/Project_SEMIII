using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class StoreDBModel
    {
        private E_ProjectDbContext context = null;

        public StoreDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_STORE> getListStore()
        {

            var accountResult = context.Database.SqlQuery<TB_STORE>("Usp_GetAllStore").ToList();

            return accountResult;
        }

        public object updateStatusStore(int n_id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusStore @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public TB_STORE getStoreById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_STORE storeResult = context.Database.SqlQuery<TB_STORE>("Usp_GetStoreById @N_ID", sqlParams).SingleOrDefault();

            return storeResult;
        }

        public object updateStoreById(TB_STORE store)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", store.N_ID),
                new SqlParameter("@S_NAME", store.S_NAME),
                new SqlParameter("@S_ADDRESS", store.S_ADDRESS),
                new SqlParameter("@S_CONTACT", store.S_CONTACT)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateStoreById @N_ID,@S_NAME,@S_ADDRESS,@S_CONTACT", sqlParams).SingleOrDefault();

            return result;
        }

        public object createStore(TB_STORE store)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_NAME", store.S_NAME),
                new SqlParameter("@S_ADDRESS", store.S_ADDRESS),
                new SqlParameter("@S_CONTACT", store.S_CONTACT)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertStore @S_NAME,@S_ADDRESS,@S_CONTACT", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
