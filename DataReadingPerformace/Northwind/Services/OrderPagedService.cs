using DataReadingPerformace.Models;
using DataReadingPerformace.Northwind.NorthwindDataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReadingPerformace.Northwind.Services
{
    public class OrderPagedService
    {
        public IPagedList<ShortOrderModel> GetOrdersFromDatbase()
        {
            using (var db = new NorthwindModels())
            {
                var res = db.Orders.OrderBy(x=>x.OrderID).Select(x => new ShortOrderModel() {
                    CustomerID = x.CustomerID,
                    OrderID = x.OrderID,
                    ShipAddress = x.ShipAddress,
                    ShipCountry = x.ShipCountry,
                    ShipName = x.ShipName
                }).ToPagedList(2, 20);

                return res;                
            }
        }
    }
}
