using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class FooterDao
    {
        WebBanHangDbContext db = null;
        public FooterDao()
        {
            db = new WebBanHangDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
