using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductCategoryDAO
    {
        /// <summary>
        /// Hàm Lấy ProductCategory theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCategory ViewDetailProductCategory(int id)
        {
            using (ThucLop db = new ThucLop())
            {
                //Hàm Lấy ProductCategory theo ID
                return db.ProductCategories.Find(id);
            }
        }
        /// <summary>
        /// Lấy Ra List Danh Sách Loại Sản Phẩm
        /// </summary>
        /// <param name="top">số product muốn lấy</param>
        /// <returns></returns>
        public List<ProductCategory> ListProductCategory()
        {
            using (ThucLop db = new ThucLop())
            {
                //Lấy Ra danh sách product,Sắp Xếp theo ngày mới nhất
                return db.ProductCategories.Where(x => x.Status == true).ToList();
            }
        }
    }
}
