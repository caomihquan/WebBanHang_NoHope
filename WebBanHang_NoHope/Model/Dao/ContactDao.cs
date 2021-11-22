using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        WebBanHangDbContext db = null;
        public ContactDao()
        {
            db = new WebBanHangDbContext();
        }

        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);

            db.SaveChanges();
            return fb.ID;
        }

    }
}
