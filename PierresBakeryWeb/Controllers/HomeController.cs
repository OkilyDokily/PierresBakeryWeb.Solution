using Microsoft.AspNetCore.Mvc;
using PierresBakeryWeb.Models;
using System.Collections.Generic;
using System;

namespace PierresBakeryWeb.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      Dictionary<string,Dictionary<string,int[]>> menu = Order.CreateItemsMenu();
      return View(menu);
    }

    [HttpPost("/result")]
    public ActionResult Result(int brioche, int zwieback, int croissant, int cronut)
    {
  
      Order.ordersAmount = new Dictionary<string,int>();
      Order.AddToOrder("Brioche",brioche);
      Order.AddToOrder("Zwieback",zwieback);
      Order.AddToOrder("Croissant",croissant);
      Order.AddToOrder("Cronut",cronut);

      Dictionary<string, Dictionary<string,int[]>> totals = Order.GetTotalsForAllOrder();

      return View(totals);
    }

  }
}