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

        public object updateStatusOrder(int id, string s_status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id),
                new SqlParameter("@S_STATUS", s_status)
            };
            var result = context.Database.SqlQuery<object>("Usp_UpdateStatusOrder @N_ID,@S_STATUS", sqlParams).SingleOrDefault();
            return result;
        }

        public object activeOrderByCustomerId(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_CUSTOMER_ID", id)
            };
            var result = context.Database.SqlQuery<object>("Usp_ActiveOrderByCustomerId @N_CUSTOMER_ID", sqlParams).SingleOrDefault();
            return result;
        }

        public object deleteOrderById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", id)
            };
            var result = context.Database.SqlQuery<object>("Usp_DeleteOrderById @N_ID", sqlParams).SingleOrDefault();
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

        public List<TB_ORDER> getOrdersByCustomerId(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_CUSTOMER_ID", id)
            };
            List<TB_ORDER> result = context.Database.SqlQuery<TB_ORDER>("Usp_GetOrdersByCustomerId @N_CUSTOMER_ID", sqlParams).ToList();

            return result;
        }

        public object updateOrderById(TB_ORDER model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_ID", model.N_ID),
                new SqlParameter("@S_CUSTOMER_NAME", model.S_CUSTOMER_NAME),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@S_DESCRIPTION", model.S_DESCRIPTION)
            };
            var result = context.Database.SqlQuery<object>("Usp_updateOrderById @N_ID,@S_CUSTOMER_NAME,@S_PHONE,@S_ADDRESS,@S_DESCRIPTION", sqlParams).SingleOrDefault();

            return result;
        }

        public object createOrder(TB_ORDER model, int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@N_AMOUNT", model.N_AMOUNT),
                new SqlParameter("@N_TOTAL", model.N_TOTAL),
                new SqlParameter("@S_TYPE", model.S_TYPE),
                new SqlParameter("@S_CUSTOMER_NAME", model.S_CUSTOMER_NAME),
                new SqlParameter("@S_PHONE", model.S_PHONE),
                new SqlParameter("@S_ADDRESS", model.S_ADDRESS),
                new SqlParameter("@N_ID", id),
                new SqlParameter("@N_CUSTOMER_ID", model.N_CUSTOMER_ID)
            };
            var result = context.Database.SqlQuery<object>("Usp_InsertOrder @N_AMOUNT,@N_TOTAL,@S_TYPE,@S_CUSTOMER_NAME,@S_PHONE,@S_ADDRESS,@N_ID,@N_CUSTOMER_ID", sqlParams).SingleOrDefault();

            return result;
        }
    }
}
