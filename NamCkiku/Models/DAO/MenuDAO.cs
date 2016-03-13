using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MenuDAO
    {
        /// <summary>
        /// Hàm Hiển Thị List Menu Theo Nhóm Menu
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public List<Menu> ViewMenuByGroupID(int GroupID)
        {
            using (ThucLop db = new ThucLop())
            {
                //Hàm Hiển Thị List Menu Theo Nhóm Menu,điều kiện TypeID= GroupID
                return db.Menus.Where(x => x.TypeID == GroupID).ToList();
            }
        }
    }
}
