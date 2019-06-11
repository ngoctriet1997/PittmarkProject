using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoClientScreen
    {
        private PittmarkStoreEntities _daoProfile;
        private PittmarkStoreEntities _daoCustomer;
        public DaoClientScreen()
        {
            _daoProfile = new PittmarkStoreEntities();
            _daoCustomer = new PittmarkStoreEntities();
        }
        public IEnumerable<Address> GetAddresses()
        {
            return _daoProfile.Addresses.AsEnumerable();
        }
        public IEnumerable<Email> GetEmails()
        {
            return _daoProfile.Emails.AsEnumerable();
        }
        public IEnumerable<Facebook> GetFacebooks()
        {
            return _daoProfile.Facebooks.AsEnumerable();
        }
        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        {
            return _daoProfile.PhoneNumbers.AsEnumerable();
        }
        public IEnumerable<SanPham> GetProducts()
        {
            return _daoProfile.SanPhams.Where(x=>x.Delete_YMD==null).AsEnumerable();
        }
        public IEnumerable<SanPhamTrungBay> GetDisplayProducts()
        {
            var result = _daoProfile.SanPhamTrungBays.Where(x => x.Delete_YMD == null).AsEnumerable().ToList();
            return result;
        }
        public Profile GetProfiles()
        {
            return _daoProfile.Profiles.Single();
        }
        public Customer AddCustomer(Customer customer)
        {
            var result = _daoCustomer.Customers.Add(customer);
            _daoCustomer.SaveChanges();
            return result;
        }
        public DonHang AddBill(DonHang donHang)
        {
            var result = _daoCustomer.DonHangs.Add(donHang);
            _daoCustomer.SaveChanges();

            //PittamaskProject.DbMain.Backup.PittmarkStoreEntities pittmarkStoreEntities = new PittamaskProject.DbMain.Backup.PittmarkStoreEntities();
            //pittmarkStoreEntities.DonHangs.Add(new PittamaskProject.DbMain.Backup.DonHang() { })

            return result;
        }
        public SanPham GetProductById(int? id)
        {
            return _daoCustomer.SanPhams.Find(id);
        }
    }
}
