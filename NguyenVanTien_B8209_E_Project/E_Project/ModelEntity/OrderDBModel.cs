using ModelEntity.Frameworks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class OrderDBModel
    {
        private E_ProjectDbContext context = null;

        public OrderDBModel()
        {
            context = new E_ProjectDbContext();
        }

        public List<TB_ALL_ORDER> getListOrder()
        {

            var result = context.Database.SqlQuery<TB_ALL_ORDER>("Usp_GetAllOrder").ToList();

            return result;
        }

        public object updateStatusOrder(string name, DateTime orderDate, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_CUSTOMER_NAME", name),
                new SqlParameter("@D_CREATED", orderDate),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusOrder @S_CUSTOMER_NAME,@D_CREATED,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public object getDetailOrder(string name, DateTime orderDate)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_CUSTOMER_NAME", name),
                new SqlParameter("@D_CREATED", orderDate)
            };
            var result = context.Database.SqlQuery<TB_ORDER>("Usp_GetDetailOrder @S_CUSTOMER_NAME,@D_CREATED", sqlParams).ToList();
            return result;
        }

        public TB_ORDER getOrderById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            TB_ORDER result = context.Database.SqlQuery<TB_ORDER>("Usp_GetOrderById @N_ID", sqlParams).SingleOrDefault();

            return result;
        }

        /*public object updateOrderById(TB_ORDER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@N_PRICE", model.N_PRICE),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateOrderById @N_ID,@S_NAME,@N_PRICE,@S_TYPE,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createOrder(TB_ORDER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@S_NAME", model.S_NAME),
                new SqlParameter("@N_PRICE", model.N_PRICE),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_DETAIL", model.S_DETAIL),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertOrder @S_NAME,@N_PRICE,@S_TYPE,@S_DETAIL,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }*/
    }
}
