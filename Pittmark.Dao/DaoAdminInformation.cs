
using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoAdminInformation
    {

        private PittmarkStoreEntities DaoAdmin;
        public DaoAdminInformation()
        {
            DaoAdmin = new PittmarkStoreEntities();
        }
        public bool ChangePassword(string userName, string newPassword)
        {
            try
            {
                var ad = DaoAdmin.Admins.Where(x => x.Username == userName).Single();
                ad.Passwords.ToList().ForEach(x => { x.Status = "0"; });
                DaoAdmin.SaveChanges();

                var pw = new Password() { Id_admin = ad.Id, Insert_YMD = DateTime.Now, Password1 = newPassword, Status = "1" };
                var passwordAdmin = DaoAdmin.Passwords.Add(pw);
                DaoAdmin.SaveChanges();           
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
