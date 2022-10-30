using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21437221_HW06.Models;
using PagedList;

namespace u21437221_HW06.Controllers
{
    public class OrderController : Controller
    {
        dataService data = new dataService();
        // GET: Order
        public ActionResult Orders(/*DateTime date*/)
        {
            int PageNumbers = 10;
            int CurrentPage = 1;
            //List<Order> orders = data.getOrderByDate(date);
            List<Order> orders = data.getOrder();
            return View(orders.ToPagedList(CurrentPage,PageNumbers));
        }
    }
}