using Dapper;
using DataReadingPerformace.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace.Northwind.Services
{
    public class DapperOrderService
    {
        private string connectionString { get; set; } = ConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString;
        public OrderModel GetOrder(int orderId)
        {
            using (var db = new SqlConnection(connectionString))
            {
                return db.Query<OrderModel>(@"Select * From Orders WHERE OrderID = @orderId", new { orderId }).SingleOrDefault();
            }

        }
    }
}
