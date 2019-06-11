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
    [RoutePrefix("Api/DisplayProduct")]
    [ApiAuthenticationFilter()]
    public class DisplayProductController : ApiController
    {
        private DaoDisplayProduct _daoDisplayProduct;
        public DisplayProductController()
        {
            _daoDisplayProduct = new DaoDisplayProduct();
        }
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                List<DisplayProductViewModel> productsViewModel = new List<DisplayProductViewModel>();

                var result = _daoDisplayProduct.GetAll();
                result.ToList().ForEach(x => {
                    productsViewModel.Add(new DisplayProductViewModel() { Image = x.Image, id = x.Id, Name = x.Name });
                });

                return request.CreateResponse(HttpStatusCode.OK, productsViewModel);
            }
            catch(Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }
            

        }
        [HttpGet]
        [Route("GetById")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            try
            {
                var result = _daoDisplayProduct.GetById(id);
                DisplayProductViewModel DisplayProductViewModel = new DisplayProductViewModel();
                DisplayProductViewModel.Image = result.Image;
                DisplayProductViewModel.id = result.Id;
                DisplayProductViewModel.Name = result.Name;

                return request.CreateResponse(HttpStatusCode.OK, DisplayProductViewModel);
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
        public HttpResponseMessage Update(HttpRequestMessage request, DisplayProductViewModel sanPham)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    if (sanPham.id != 0)
                    {
                        var result = _daoDisplayProduct.UpdateProduct(new SanPhamTrungBay() { Name = sanPham.Name, Id = sanPham.id, Image = sanPham.Image });
                        return request.CreateResponse(HttpStatusCode.OK, result);
                    }
                    else
                    {
                        var result = _daoDisplayProduct.Add(new SanPhamTrungBay() { Name = sanPham.Name, Image = sanPham.Image });
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
                if (_daoDisplayProduct.DeleteById(id))
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