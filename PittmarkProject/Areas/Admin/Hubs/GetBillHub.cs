using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Pittmark.Dao;
using PittmarkProject.Models;

namespace PittmarkProject.Areas.Admin.Hubs
{
    public class GetBillHub : Hub
    {
        public Task JoinGroup()
        {
            return Groups.Add(Context.ConnectionId, Pittmark.Common.Constraints.Admin);
        }
        public override Task OnConnected()
        {
            Groups.Add(Context.ConnectionId, Pittmark.Common.Constraints.Admin);
            return base.OnConnected();
        }
        public Task SendBillToAdmin(int idBill)
        {
            DaoManageBill daoBill = new DaoManageBill();
            BillViewModel model = new BillViewModel();
            var donHang = daoBill.GetById(idBill);
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


            return Clients.Group(Pittmark.Common.Constraints.Admin).getBill(billViewModel);


        }
    }
}