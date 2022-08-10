using AzureProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index_Products()
        {
            //    using (ProjectContext db = new ProjectContext())
            //    {
            //        TempData["Products"] = db.Products.ToList();
            //    }
            //    return View();
            //
            ProjectContext db = new ProjectContext();
            IEnumerable<Products> objProductsList = db.Products;
            return View(objProductsList);
        }

        public IActionResult UserIndex()
        {
            using (ProjectContext db = new ProjectContext())
            {
                TempData["Products"] = db.Products.ToList();
            }
            return View();
        }

        public IActionResult CartIndex()
        {
            using (ProjectContext db = new ProjectContext())
            {
                TempData["Carts"] = db.Carts.ToList();
            }

            

            return View();
        }
        public IActionResult AddProducts()
        {
            using (ProjectContext db = new ProjectContext())
            {
                TempData["Categories"] = db.Categories.ToList();
            }

            return View();
        }


        [HttpPost]
        public IActionResult AddProducts(Products st)
        {
            if (!ModelState.IsValid)
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Products.Add(st);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            //  return RedirectToAction("Index_Products", "Dashboard");
            return View();
        }


        public IActionResult UI()
        {
            return View();
        }

        public IActionResult MainUI()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            Products? ss = new Products();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(Products s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var Result = db.Products.Find(s.ProductId);

                Result.Name = s.Name;
                Result.Category = s.Category;
                Result.Price = s.Price;
                Result.Image = s.Image;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("Index_Products", "Dashboard");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Products ss = new Products();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
                db.Products.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index_Products", "Dashboard");
        }


        public IActionResult AddToCart(int id)
        {
            Products? ss = new Products();
            int n = (int)HttpContext.Session.GetInt32("userid");
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            }
            Cart? s = new Cart();
            s.UserID = n;
            s.ProductId = ss.ProductId;
            s.ProductName = ss.Name;
            s.Price = ss.Price;

            return View(s);
        }


        [HttpPost]
        public IActionResult AddToCart(Cart s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                // var Result = db.Products.Find(s.ProductId);
                if (!ModelState.IsValid)
                {
                    db.Carts.Add(s);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return RedirectToAction("CartIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteFromCart(int id)
        {
            Cart ss = new Cart();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Carts.Where(x => x.CartId == id).FirstOrDefault();
                db.Carts.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("CartIndex", "Dashboard");
        }


        public IActionResult PerformOrder(int id)
        {
            Cart? ss = new Cart();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Carts.Where(x => x.CartId == id).FirstOrDefault();
            }
            Orders? s = new Orders();
            s.UserID = ss.UserID;
            s.ProductId = ss.ProductId;
            s.ProductName = ss.ProductName;
            s.Price = ss.Price;
            s.status = "Order to be Placed";

            return View(s);
        }

        [HttpPost]
        public IActionResult PerformOrder(Orders s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                // var Result = db.Products.Find(s.ProductId);
                if (!ModelState.IsValid)
                {
                    db.Orders.Add(s);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return RedirectToAction("OrderIndex", "Dashboard");
        }

        public IActionResult OrderIndex()
        {
            using (ProjectContext db = new ProjectContext())
            {
                TempData["Orders"] = db.Orders.ToList();
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            Orders ss = new Orders();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
                db.Orders.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("OrderIndex", "Dashboard");
        }

        public IActionResult UpdateOrder(int id)
        {
            Orders? ss = new Orders();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Orders s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var Result = db.Orders.Find(s.OrderId);

                Result.ProductName = s.ProductName;
                Result.status = s.status;
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["EditMsg"] = "1";
                    ModelState.Clear();
                }
                else
                {
                    TempData["EditMsg"] = "0";
                }

            }
            return RedirectToAction("OrderIndex", "Dashboard");
        }

        public IActionResult Categories()
        {
            using (ProjectContext db = new ProjectContext())
            {

                TempData["Categories"] = db.Categories.ToList();
            }
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddCategory(Categories st)
        {
            if (!ModelState.IsValid)
            {
                using (ProjectContext db = new ProjectContext())
                {
                    db.Categories.Add(st);
                    int count = db.SaveChanges();
                    if (count > 0)
                    {
                        TempData["AddMsg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AddMsg"] = "0";
                    }
                }
            }
            return RedirectToAction("Categories", "Dashboard");
            //return View();
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Categories ss = new Categories();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                db.Categories.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Categories", "Dashboard");
        }

        public IActionResult Explore(string c)
        {
            List<Products> products = new List<Products>();
            using (ProjectContext db = new ProjectContext())
            {
                products = db.Products.Where(x => x.Category == c).ToList();
            }

            //Categories ss = new Categories();
            //using (ProjectContext db = new ProjectContext())
            //{
            //    ss = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            //}
            // Products s = new Products(); 



            return View(products);
        }

        public IActionResult Demo()
        {
            List<Products> products = new List<Products>();
            using (ProjectContext db = new ProjectContext())
            {
                products = db.Products.ToList();
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Demo(string Productsearch)
        {
            //for search 

            ViewData["Getproductdetails"] = Productsearch;

            ProjectContext db = new ProjectContext();
            var prodquery = from x in db.Products select x;
            if (!String.IsNullOrEmpty(Productsearch))
            {
                prodquery = prodquery.Where(model => model.Name.Contains(Productsearch) || model.Category.Contains(Productsearch));

            }
            return View(prodquery.AsQueryable().ToList());
        }

        [HttpGet]
        public IActionResult Index_Products(string Productsearch)
        {
            //for search 

            ViewData["Getproductdtails"] = Productsearch;

            ProjectContext db = new ProjectContext();
            var prodquery = from x in db.Products select x;
            if (!String.IsNullOrEmpty(Productsearch))
            {
                prodquery = prodquery.Where(model => model.Name.Contains(Productsearch) || model.Category.Contains(Productsearch));

            }
            return View(prodquery.AsQueryable().ToList());
        }
    }
}
