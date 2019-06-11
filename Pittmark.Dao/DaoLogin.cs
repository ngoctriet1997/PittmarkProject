using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoLogin
    {
        private PittmarkStoreEntities DaoAdmin;
        public DaoLogin()
        {
            DaoAdmin = new PittmarkStoreEntities();
        }
        public bool CheckLogin(string userName,string passWord)
        {
            try
            {
                var mk = DaoAdmin.Admins.Where(x => x.Username == userName).Single().Passwords.Where(x => x.Status == "1").Single();
                if (DaoAdmin.Admins.Count(x => x.Username == userName) > 0 && mk.Password1 == passWord)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public int? GetRole(string userName,string password)
        {
            var mk = DaoAdmin.Admins.Where(x => x.Username == userName).Single().Passwords.Where(x => x.Status == "1").Single();
            if (DaoAdmin.Admins.Count(x => x.Username == userName) > 0 && mk.Password1 == password)
            {
                return mk.Admin.Role;
            }
            return -1;
        }
    }
}
