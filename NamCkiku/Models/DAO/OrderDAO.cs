using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDAO
    {
        public int Insert(Order order)
        {
            using(ThucLop db = new ThucLop())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order.ID;
            }
        }
    }
}
