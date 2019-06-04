using Pittmark.Dao;
using PittmarkProject.Areas.Admin.Models;
using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PittmarkProject.Areas.Admin.Api
{
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiController
    {
        private DaoProduct _daoProduct;
        public ProductController()
        {
            _daoProduct = new DaoProduct();
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            List<ProductViewModel> productsViewModel = new List<ProductViewModel>();
            
            var result = _daoProduct.GetAll();
            result.ToList().ForEach(x => {
                productsViewModel.Add(new ProductViewModel() { Descript=x.Descript,id=x.Id,Name=x.Name,Price=x.Price });
            });
          
            return  request.CreateResponse(HttpStatusCode.OK, productsViewModel);
           
        }
        [HttpGet]
        [Route("GetById")]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            var result = _daoProduct.GetById(id);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Descript = result.Descript;
            productViewModel.id = result.Id;
            productViewModel.Name = result.Name;
            productViewModel.Price = result.Price;
            return request.CreateResponse(HttpStatusCode.OK, productViewModel);

        }
        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel sanPham)
        {
            if(sanPham.id!=0)
            {
                var result = _daoProduct.UpdateProduct(new SanPham() { Price = sanPham.Price, Name = sanPham.Name, Id = sanPham.id, Descript = sanPham.Descript });
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                var result = _daoProduct.Add(new SanPham() { Price = sanPham.Price, Name = sanPham.Name, Descript = sanPham.Descript });
                return request.CreateResponse(HttpStatusCode.OK, result);
            }

        }
        [HttpDelete]
        [Route("DeleteById")]
        public HttpResponseMessage DeleteById(HttpRequestMessage request, int id)
        {
            int count = 0;
            try
            {
                if (_daoProduct.DeleteById(id))
                {
                    count++;
                }
                var result = request.CreateResponse(HttpStatusCode.OK, count);
                return result;
            }
            catch
            {
                return null;
            }

        }
    }
}