using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CartDAO
    {
        // Chứa các mặt hàng đã chọn
        public List<Product> Items = new List<Product>();
        public void Update(int id, int newQuantity)
        {
            var item = Items.Single(i => i.ID == id);
            item.Quantity = newQuantity;
        }
    }
}
