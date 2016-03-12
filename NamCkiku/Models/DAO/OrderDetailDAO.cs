using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailDAO
    {
        public bool Insert(OderDetail detail)
        {
            using (ThucLop db = new ThucLop())
            {
                db.OderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
        }
    }
}
