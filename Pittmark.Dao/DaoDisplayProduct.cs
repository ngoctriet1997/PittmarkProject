using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoDisplayProduct
    {
        private PittmarkStoreEntities _daoDisplayProduct;
        public DaoDisplayProduct()
        {
            _daoDisplayProduct = new PittmarkStoreEntities();
        }
        public IEnumerable<SanPhamTrungBay> GetAll()
        {
            List<SanPhamTrungBay> lstSanPham = _daoDisplayProduct.SanPhamTrungBays.Where(X => X.Delete_YMD == null).ToList();
            return lstSanPham;
        }
        public SanPhamTrungBay GetById(int id)
        {
            return _daoDisplayProduct.SanPhamTrungBays.Where(x => x.Id == id).Single();
        }
        public bool AddProduct(SanPhamTrungBay SanPhamTrungBay)
        {
            var result = _daoDisplayProduct.SanPhamTrungBays.Add(SanPhamTrungBay);
            return _daoDisplayProduct.SaveChanges() == 1;

        }
        public bool UpdateProduct(SanPhamTrungBay SanPhamTrungBay)
        {
            var result = _daoDisplayProduct.SanPhamTrungBays.Where(sp => sp.Id == SanPhamTrungBay.Id).Single();
            result.Image = SanPhamTrungBay.Image;
            result.Name = SanPhamTrungBay.Name;
           

            return _daoDisplayProduct.SaveChanges() == 1;
        }
        public bool DeleteById(int id)
        {
            try
            {

                var result = GetById(id);

                result.Delete_YMD = DateTime.Now;

                _daoDisplayProduct.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SanPhamTrungBay Add(SanPhamTrungBay SanPhamTrungBay)
        {
            var result = _daoDisplayProduct.SanPhamTrungBays.Add(SanPhamTrungBay);
            _daoDisplayProduct.SaveChanges();
            return result;

        }
    }
}
