using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoManageBill
    {
        private PittmarkStoreEntities _daoManageBill;
        public DaoManageBill()
        {
            _daoManageBill = new PittmarkStoreEntities();
        }

        public IEnumerable<dynamic> GetAll(int page, int pageSize, out int totalRow)
        {
            var bill_customer = _daoManageBill.DonHangs.Join(_daoManageBill.Customers,
                                                       donhang => donhang.Id_customer,
                                                       customer => customer.Id,
                                                       (donhang, customer) => new {donhang.Status,donhang.Id_product,customer.Address,customer.Name,
                                                       donhang.Insert_YMD,customer.Number,donhang.Price,donhang.Id,donhang.Delete_YMD}).Where(x=>x.Delete_YMD==null);
            var bill_customer_sanpham = bill_customer.Join(_daoManageBill.SanPhams,
                                                            b_customer => b_customer.Id_product,
                                                            sanpham => sanpham.Id,
                                                            (b_customer, sanpham) =>new { b_customer ,sanpham.Name  });
            totalRow = bill_customer_sanpham.Count();
            return bill_customer_sanpham.OrderByDescending(x=>x.b_customer.Insert_YMD).Skip((page-1)*pageSize).Take(pageSize);
        }
        public DonHang GetById(int id)
        {
            return _daoManageBill.DonHangs.Where(x => x.Id == id).Single();
        }
        public DonHang UpdateBill(DonHang donHang)
        {
            try
            {
                var result = GetById(donHang.Id);
                result.Status = donHang.Status;
                result.Update_YMD = DateTime.Now;
            
                _daoManageBill.SaveChanges();
                return result;
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteById(int id)
        {
            try
            {

                var result = GetById(id);
              
                result.Delete_YMD = DateTime.Now;

                _daoManageBill.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
