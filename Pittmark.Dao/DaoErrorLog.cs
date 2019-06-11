using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoErrorLog
    {
        private PittmarkStoreEntities daoError;
        public DaoErrorLog()
        {
            daoError = new PittmarkStoreEntities();
        }
        public ErrorLog Add(string method, string note, string message)
        {
            var error= daoError.ErrorLogs.Add(new ErrorLog() { Method = method, Message = message, Note = note });
            daoError.SaveChanges();
            return error;
        }
    }
}
