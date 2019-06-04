using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoCustomer
    {
        private PittmarkStoreEntities _daoCustomer;
        public DaoCustomer()
        {
            _daoCustomer = new PittmarkStoreEntities();
        }
       
    }
}
