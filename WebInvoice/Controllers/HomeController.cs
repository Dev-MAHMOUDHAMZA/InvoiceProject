using Domain.Models;
using Infarstructuer.Data;
using Infarstructuer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebInvoice.Models;

namespace WebInvoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Invoice()
        {
            //User
            return View(new BayInvoiceViewModel
            {
                CategoryList = _context.Categories.Where(x => x.CurrentState > 0 && x.BaranchId == 2).ToList(),
                SupplierList = _context.Suppliers.Where(x => x.CurrentState > 0 && x.BaranchId == 2).ToList(),
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Invoice(BayInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var x = _context.BuyInovices.Where(x => x.BaranchId == 2).Max(x => x.BuyInvoice +1);

                var result = _context.InvoiceTemps.Where(x=>x.BaranchId.Equals(2)).ToList();
                foreach (var item in result)
                {
                    model.NewBuyInovice.BuyInvoiceItemList.Add(new BuyInvoiceItem()
                    {
                        CategoryId = item.CategoryId,
                        ProductId = item.ProductId,
                        Price = item.Price,
                        Quntity = item.Quntity,
                        Total = item.Total
                    });
                    _context.InvoiceTemps.Remove(item);
                    _context.SaveChanges();
                }//
                model.NewBuyInovice.BaranchId = 2;
                _context.BuyInovices.Add(model.NewBuyInovice);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");   
            }
            return View(model.NewBuyInovice);
        }
        public IActionResult GetProduct(int? Id)
        {
            return Json(_context.Products.Where(x => x.CurrentState > 0 && x.BaranchId == 2 && x.CategoryId.Equals(Id)).ToList());
        }
        public IActionResult GetPriceProduct(int? Id)
        {
            return Json(_context.Products.FirstOrDefault(x => x.CurrentState > 0 && x.BaranchId == 2 && x.productId.Equals(Id)));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}