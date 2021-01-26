using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class ProductDBModel
    {
        private E_ProjectDbContext context = null;

        public ProductDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_PRODUCT> getListProduct()
        {

            var result = context.Database.SqlQuery<TB_PRODUCT>("Usp_GetAllProduct").ToList();

            return result;
        }

        public object updateStatusProduct(int n_id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", n_id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusProduct @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public TB_PRODUCT getProductById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_PRODUCT result = context.Database.SqlQuery<TB_PRODUCT>("Usp_GetProductById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        public object updateProductById(TB_PRODUCT model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@N_PRICE", model.N_PRICE),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateProductById @N_ID,@S_NAME,@N_PRICE,@S_TYPE,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createProduct(TB_PRODUCT model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@N_PRICE", model.N_PRICE),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DETAIL", model.S_DETAIL),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertProduct @S_NAME,@N_PRICE,@S_TYPE,@S_DETAIL,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
