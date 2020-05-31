using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solution.Models;

namespace Solution.Controllers
{
    public class HomeController : Controller
    {
        DataContext dbContext;
        public HomeController(DataContext context){ dbContext = context; }

        public IActionResult Index()
        {
            return View(dbContext);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Superuser superuser)
        {
            bool hasLoged = false;
            foreach(var item in dbContext.Superusers)
            {
                if(superuser.Name == item.Name && superuser.Password == item.Password)
                {
                    hasLoged = true;
                    break;
                }
            }
            if(hasLoged)
                return Redirect("~/Home/Administration");
            else
                return View();
        }
        public IActionResult ProductList()
        {
            return View(dbContext);
        }

        public IActionResult Category()
        {
            return View(dbContext);
        }

        [HttpPost]
        public IActionResult Category(Category category)
        {
            if(category != null)
            {
                dbContext.Categorys.Add(category);
                dbContext.SaveChanges();
            }
            return View(dbContext);
        }

        public IActionResult Administration()
        {
            return View(dbContext);
        }
        [HttpPost]
        public IActionResult Administration(Product product, int categoryId)
        {
            if(product != null)
            {
                var selectedCategory = dbContext.Categorys.Find(categoryId);
                product.ProductCategory = selectedCategory;
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            return View(dbContext);
        }
        public IActionResult EditProduct()
        {
            return View(dbContext);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product, int categoryId)
        {
            if(product != null)
            {
                var selectedCategory = dbContext.Categorys.Find(categoryId);
                var productEdited = dbContext.Products.Find(product.Id);
                productEdited.Name = product.Name;
                productEdited.Description = product.Description;
                productEdited.ProductCategory = selectedCategory;
                productEdited.Cost = product.Cost;
                dbContext.SaveChanges();
            }
            return View(dbContext);
        }
        [HttpPost]
        public IActionResult RemoveProduct(int? Id, string Name)
        {
            var productDeleted = dbContext.Products.Find(Id);
            dbContext.Products.Remove(productDeleted);
            dbContext.SaveChanges();
            return View(dbContext.Products.ToList());
        }
        public IActionResult RemoveProduct()
        {
            return View(dbContext.Products.ToList());
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
