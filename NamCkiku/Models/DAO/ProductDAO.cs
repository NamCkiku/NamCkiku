using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        /// <summary>
        /// Lấy Ra List Danh Sách Sản Phẩm Mới
        /// </summary>
        /// <param name="top">số product muốn lấy</param>
        /// <returns></returns>
        public List<Product> ListNewProduct(int top)
        {
            using (ThucLop db = new ThucLop())
            {
                //Lấy Ra danh sách product,Sắp Xếp theo ngày mới nhất
                return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
            }
        }
        /// <summary>
        /// Hàm Lấy ra List Danh Sách Sản Phẩm Hot
        /// </summary>
        /// <param name="top">số product muốn lấy</param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct(int top)
        {
            using (ThucLop db = new ThucLop())
            {
                //Lấy ra List Danh Sách Sản Phẩm Hot,điều kiện Trường TopHot khác Null và TopHot có ngày lớn hơn ngày hiện tại
                return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
            }
        }
        /// <summary>
        /// Hàm Lấy ra List Danh Sách Sản Phẩm Hot
        /// </summary>
        /// <param name="top">số product muốn lấy</param>
        /// <returns></returns>
        //public List<Product> ListSaleoffProduct(int top)
        //{
        //    using (ThucLop db = new ThucLop())
        //    {
        //        //Lấy ra List Danh Sách Sản Phẩm Hot,điều kiện Trường TopHot khác Null và TopHot có ngày lớn hơn ngày hiện tại
        //        return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        //    }
        //}
        /// <summary>
        /// Hàm Lấy Ra ID prduct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product ViewDetailProduct(int id)
        {
            using (ThucLop db = new ThucLop())
            {
                return db.Products.Find(id);
            }
        }
        /// <summary>
        /// Hiển Thị Danh Sách Sản Phẩm
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> ViewProduct()
        {
            using (ThucLop db = new ThucLop())
            {
                //trả về list Sản Phẩm
                return db.Products.ToList();
            }
        }
        /// <summary>
        /// Thêm Sản Phẩm
        /// </summary>
        /// <param name="user">Danh Sách Sản Phẩm</param>
        /// <returns></returns>
        public int Insert(Product product)
        {
            using (ThucLop db = new ThucLop())
            {
                db.Products.Add(product);//Thêm Sản Phẩm
                db.SaveChanges();
                return product.ID;
            }
        }
        /// <summary>
        /// Sửa Người Dùng
        /// </summary>
        /// <param name="user">Người Dùng</param>
        /// <returns></returns>
        public bool Update(Product product)
        {
            using (ThucLop db = new ThucLop())
            {
                var model = db.Products.Find(product.ID);
                if (model != null)
                {
                    model.Name = product.Name;
                    model.Detail = product.Detail;
                    model.Price = product.Price;
                    model.ModifiedBy = product.ModifiedBy;
                    model.ModifiedDate = DateTime.Now;
                    model.PromotionPrice = product.PromotionPrice;
                    model.Image = product.Image;
                    model.MoreImages = product.MoreImages;
                    model.Quantity = product.Quantity;
                    model.Status = product.Status;
                    model.Code = product.Code;
                    model.Warranty = product.Warranty;
                    model.MetaTitle = product.MetaTitle;
                    model.ModifiedBy = product.ModifiedBy;
                    model.Description = model.Description;
                    model.MetaKeywords = product.MetaKeywords;
                    model.MetaDescriptions = product.MetaDescriptions;
                    model.CategoryID = product.CategoryID;
                    model.IncludedVAT = product.IncludedVAT;
                    model.TopHot = product.TopHot;
                    db.SaveChanges();
                    return true;
                }
                else
                { return false; }

            }
        }
        /// <summary>
        /// Lấy Gía Trị Của Sản Phẩm theo ID
        /// </summary>
        /// <param name="UserName">Tên Tài Khoản</param>
        /// <returns></returns>
        public Product GetByID(int ID)
        {
            using (ThucLop db = new ThucLop())
            {
                return db.Products.Find(ID);  //Lấy Gía Trị Của UserName
            }
        }
        public Product ViewDetail(int ID)
        {
            using (ThucLop db = new ThucLop())
            {
                return db.Products.Find(ID);
            }
        }
        public bool Delete(int ID)
        {
            using (ThucLop db = new ThucLop())
            {
                var product = db.Products.Find(ID);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
        }
    }
}
