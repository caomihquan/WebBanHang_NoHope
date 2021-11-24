using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedbackDao
    {
        WebBanHangDbContext db = null;
        public FeedbackDao()
        {
            db = new WebBanHangDbContext();
        }

        public IEnumerable<Feedback> ListAllPaging(int page, int pageSize)
        {
            return db.Feedbacks.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }



        public long Insert(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Delete(int id)
        {
            try
            {
                var fb = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(fb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
