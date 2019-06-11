using Pittmark.Dao;
using PittmarkProject.DbMain;
using PittmarkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace PittmarkProject.Api
{
    [RoutePrefix("Api/Client")]
    public class ClientHomeController : ApiController
    {
        private DaoClientScreen _daoClientScreen;
        public ClientHomeController()
        {
            _daoClientScreen = new DaoClientScreen();
        }
        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, BillViewModel billViewModel)
        {
            try
            {
                Customer customer = new Customer();
                customer.Address = billViewModel.Address;
                customer.Name = billViewModel.CustomerName;
                customer.Number = billViewModel.NumberPhone;
                customer = _daoClientScreen.AddCustomer(customer);

                SanPham sanPham = _daoClientScreen.GetProductById(billViewModel.IdProduct);

                DonHang donHang = new DonHang();
                donHang.Id_product = billViewModel.IdProduct;
                donHang.Id_customer = customer.Id;
                donHang.Price = (decimal)sanPham.Price;
                donHang.Note = billViewModel.Descript;
                donHang.Insert_YMD = DateTime.Now;
                donHang.Update_YMD = DateTime.Now;
                donHang.Status = 0;

                _daoClientScreen.AddBill(donHang);

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                DaoErrorLog daoErrorLog = new DaoErrorLog();
                daoErrorLog.Add(MethodBase.GetCurrentMethod().Name, "", e.Message);
                return request.CreateResponse(HttpStatusCode.NotImplemented);
            }

        }
    }
}