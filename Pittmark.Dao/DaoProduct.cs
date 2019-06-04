using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pittmark.Dao
{
    public class DaoProduct
    {
        private PittmarkStoreEntities _daoProduct;
        public DaoProduct()
        {
            _daoProduct = new PittmarkStoreEntities();
        }
        public IEnumerable<SanPham> GetAll()
        {
            List<SanPham> lstSanPham = _daoProduct.SanPhams.Where(X=>X.Delete_YMD==null).ToList();
            return lstSanPham;
        }
        public SanPham GetById(int id)
        {
            return _daoProduct.SanPhams.Where(x => x.Id == id).Single();
        }
        public bool AddProduct(SanPham sanPham)
        {
             var result = _daoProduct.SanPhams.Add(sanPham);
             return  _daoProduct.SaveChanges()==1;
            
        }
        public bool UpdateProduct(SanPham sanPham)
        {
            var result = _daoProduct.SanPhams.Where(sp=>sp.Id==sanPham.Id).Single();
            result.Descript = sanPham.Descript;
            result.Name = sanPham.Name;
            result.Price = sanPham.Price;
           
            return _daoProduct.SaveChanges() == 1;
        }
        public bool DeleteById(int id)
        {
            try
            {

                var result = GetById(id);

                result.Delete_YMD = DateTime.Now;

                _daoProduct.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SanPham Add(SanPham sanPham)
        {
            var result =  _daoProduct.SanPhams.Add(sanPham);
            _daoProduct.SaveChanges();
            return result;
          
        }
    }
}
