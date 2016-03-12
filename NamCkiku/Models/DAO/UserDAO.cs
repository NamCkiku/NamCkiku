using Models.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
        /// <summary>
        /// Hiển Thị Danh Sách Người Dùng
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> ViewUser()
        {
            using(ThucLop db=new ThucLop())
            {
                //trả về list người dùng
               return db.Users.ToList();
            }
        }
        /// <summary>
        /// Thêm Người Dùng
        /// </summary>
        /// <param name="user">Danh Sách Người Dùng</param>
        /// <returns></returns>
        public int Insert(User user)
        {
            using (ThucLop db = new ThucLop())
            {
                db.Users.Add(user);//Thêm Người Dùng
                db.SaveChanges();
                return user.ID;
            }
        }
        /// <summary>
        /// Sửa Người Dùng
        /// </summary>
        /// <param name="user">Người Dùng</param>
        /// <returns></returns>
        public bool Update(User user)
        {
            using (ThucLop db = new ThucLop())
            {
                var model= db.Users.Find(user.ID);
                if(model!=null)
                {
                    model.Name = user.Name;
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        model.Password = user.Password;
                    }
                    model.Address = user.Address;
                    model.Email = user.Email;
                    model.ModifiedBy = user.ModifiedBy;
                    model.ModifiedDate = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                else
                { return false; }
              
            }
        }
        /// <summary>
        /// Đăng Nhập Vào Trang Quản Trị
        /// </summary>
        /// <param name="userName">Tên Tài Khoản</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public int Login(string userName, string password)
        {
            using (ThucLop db = new ThucLop())
            {
                var result = db.Users.SingleOrDefault(x => x.UserName == userName);//lấy giá trị của User Name
                if (result == null)//Nếu bằng null
                {
                    return 0;//Nhập Tài Khoản Và Mật Khẩu
                }
                else    //Khác Null
                {
                    if (result.Status == false)//Trạng Thaí = False
                    {
                        return -1;  //Tài Khoản Đang Bị Khóa
                    }
                    else  //Trạng Thái == true
                    {
                        if (result.Password == password)  //Nếu Password đúng
                            return 1; //Đăng Nhập Thành Công
                        else
                            return -2; //Sai tài khoản và mật khẩu
                    }
                }
            }
        }
        /// <summary>
        /// Lấy Gía Trị Của UserName
        /// </summary>
        /// <param name="UserName">Tên Tài Khoản</param>
        /// <returns></returns>
        public User GetByID(string UserName)
        {
            using (ThucLop db = new ThucLop())
            {
                return db.Users.SingleOrDefault(x => x.UserName == UserName);  //Lấy Gía Trị Của UserName
            }
        }
        public User ViewDetail(int ID)
        {
            using (ThucLop db = new ThucLop())
            {
                return db.Users.Find(ID);
            }
        }
        public bool Delete(int ID)
        {
            using (ThucLop db = new ThucLop())
            {
                var user= db.Users.Find(ID);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
        }
        public bool Signup(User user)
        {
            using (ThucLop db = new ThucLop())
            {
                if (user != null)
                {
                    var User = db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
