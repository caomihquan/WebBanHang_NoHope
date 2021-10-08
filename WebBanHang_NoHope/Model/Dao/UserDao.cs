using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
   public class UserDao
    {
        WebBanHangDbContext db = null;
        public UserDao()
        {
            db = new WebBanHangDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string userName, string passWord)
        {
            var res = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
