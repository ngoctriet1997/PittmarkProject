using Pittmark.Dao;
using PittmarkProject.Areas.Admin.Authentication;
using PittmarkProject.Areas.Infrastructure;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace PittmarkProject.Areas.Admin.Api
{
    [RoutePrefix("Api/Bill")]
    [ApiAuthSaler()]
    public class BillController : ApiController
    {
        DaoManageBill _daoManageBill;
        public BillController()
        {
            _daoManageBill = new DaoManageBill();
        }   
        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page = 1, int pageSize = 5, int maxPage = 4)
        {
            try
            {
                string username = Thread.CurrentPrincipal.Identity.Name;
                List<BillViewModel> lstBill = new List<BillViewModel>();
                int totalRow;
                var lstResult = _daoManageBill.GetAll(page, pageSize, out totalRow);
                lstResult.ToList().ForEach(x =>
                {
                    BillViewModel bill = new BillViewModel();

                    var itemBill = x.GetType().GetProperty("b_customer").GetValue(x, null);

                    bill.Address = itemBill.GetType().GetProperty("Address").GetValue(itemBill, null);
                    bill.CustomerName = itemBill.GetType().GetProperty("Name").GetValue(itemBill, null);
                    bill.NumberPhone = itemBill.GetType().GetProperty("Number").GetValue(itemBill, null);
                    bill.OrderDate = itemBill.GetType().GetProperty("Insert_YMD").GetValue(itemBill, null);
                    bill.Price = (double)itemBill.GetType().GetProperty("Price").GetValue(itemBill, null);
                    bill.Status = itemBill.GetType().GetProperty("Status").GetValue(itemBill, null);
                    bill.Id = itemBill.GetType().GetProperty("Id").GetValue(itemBill, null);

                    bill.ProductName = x.GetType().GetProperty("Name").GetValue(x, null);


                    lstBill.Add(bill);
                });
                int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
                var paginationSet = new PaginationSet<BillViewModel>()
                {
                    Items = lstBill,
                    MaxPage = maxPage,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = totalPage
                };
                return request.CreateResponse(HttpStatusCode.OK, paginationSet);
            }
            catch(Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name,e.Message);
                return null;
            }
          
        }

        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            try
            {
                var donHang = _daoManageBill.GetById(id);
                BillViewModel billViewModel = new BillViewModel();
                billViewModel.CustomerName = donHang.Customer.Name;
                billViewModel.Status = donHang.Status;
                billViewModel.ProductName = donHang.SanPham.Name;
                billViewModel.Descript = donHang.Note;
                billViewModel.Price = (double)donHang.Price;
                billViewModel.OrderDate = donHang.Insert_YMD;
                billViewModel.Address = donHang.Customer.Address;
                billViewModel.NumberPhone = donHang.Customer.Number;
                billViewModel.Id = donHang.Id;
                billViewModel.IdProduct = donHang.Id_product;
                var result = request.CreateResponse(HttpStatusCode.OK, billViewModel);
                return result;
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
        public HttpResponseMessage UpdateBill(HttpRequestMessage request, BillViewModel bill)
        {

            try
            {
                _daoManageBill.UpdateBill(new DbMain.DonHang() { Id = bill.Id, Status = bill.Status });
                var result = request.CreateResponse(HttpStatusCode.OK);
                return result;
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage DeleteByIds(HttpRequestMessage request, int id)
        {
            int count = 0;
            try
            {
                if (_daoManageBill.DeleteById(id))
                {
                    count++;
                }
                var result = request.CreateResponse(HttpStatusCode.OK, count);
                return result;
            }
            catch(Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, GetType().Name, e.Message);
                return null;
            }
        }

    }
}