using Pittmark.Dao;
using PittmarkProject.Areas.Admin.Authentication;
using PittmarkProject.Areas.Admin.Models;
using PittmarkProject.DbMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace PittmarkProject.Areas.Admin.Api
{
    [RoutePrefix("Api/Product")]
    [ApiAuthenticationFilter()]
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
            try
            {
                List<ProductViewModel> productsViewModel = new List<ProductViewModel>();

                var result = _daoProduct.GetAll();
                result.ToList().ForEach(x =>
                {
                    productsViewModel.Add(new ProductViewModel() { Descript = x.Descript, id = x.Id, Name = x.Name, Price = x.Price });
                });

                return request.CreateResponse(HttpStatusCode.OK, productsViewModel);
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }
        }
        [HttpGet]
        [Route("GetById")]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            try
            {
                var result = _daoProduct.GetById(id);
                ProductViewModel productViewModel = new ProductViewModel();
                productViewModel.Descript = result.Descript;
                productViewModel.id = result.Id;
                productViewModel.Name = result.Name;
                productViewModel.Price = result.Price;
                return request.CreateResponse(HttpStatusCode.OK, productViewModel);
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }
        }
        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (sanPham.id != 0)
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
                else
                {
                    return request.CreateResponse(HttpStatusCode.LengthRequired);
                }
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
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
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }

        }
    }
}