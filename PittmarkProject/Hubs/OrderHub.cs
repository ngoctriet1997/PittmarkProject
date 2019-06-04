using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Pittmark.Dao;
using PittmarkProject.DbMain;
using PittmarkProject.Models;

namespace PittmarkProject.Hubs
{
    public class OrderHub : Hub
    {
        private DaoClientScreen _daoClientScreen;

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public OrderHub()
        {
            _daoClientScreen = new DaoClientScreen();
        }
        public void Send()
        {

        }
        public int SendBillToAdmin(BillViewModel billViewModel)
        {
            DonHang donHang = new DonHang();
            try
            {
                Customer customer = new Customer();
                customer.Address = billViewModel.Address;
                customer.Name = billViewModel.CustomerName;
                customer.Number = billViewModel.NumberPhone;
                customer = _daoClientScreen.AddCustomer(customer);

                SanPham sanPham = _daoClientScreen.GetProductById(billViewModel.IdProduct);

               
                donHang.Id_product = billViewModel.IdProduct;
                donHang.Id_customer = customer.Id;
                donHang.Price = (decimal)sanPham.Price;
                donHang.Note = billViewModel.Descript;
                donHang.Insert_YMD = DateTime.Now;
                donHang.Update_YMD = DateTime.Now;
                donHang.Status = 0;




                _daoClientScreen.AddBill(donHang);

   


                Clients.Caller.SendStatus("true");
                return donHang.Id;

            }
            catch (Exception e)
            {
                Clients.Caller.SendStatus("false");
                return 0;
            }
           
        }
    }
}