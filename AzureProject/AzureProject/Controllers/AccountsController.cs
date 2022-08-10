using AzureProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureProject.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel lg)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var users = db.UserMasters.Where(x => x.UserName == lg.UserName && x.Password == lg.Password);
                if (users.Count() > 0)
                {
                    var user = users.FirstOrDefault();
                    TempData["msg"] = "1";

                    HttpContext.Session.SetInt32("userid", user.UserID);
                    HttpContext.Session.SetInt32("role", user.Role);
                    HttpContext.Session.SetString("name", user.UserName);
                    return RedirectToAction("MainUI", "Dashboard");
                 
                }
                else
                {
                    TempData["msg"] = "Incorrect userID or Password";
                }
            }
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserMaster st)
        {
            if (!ModelState.IsValid)
            {
                using (ProjectContext db = new ProjectContext())
                {
                    
                    st.Role = 2;
                    db.UserMasters.Add(st);
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
            return View();
        }
        public IActionResult Index()
        {
            using (ProjectContext db = new ProjectContext())
            {
                TempData["UserMasters"] = db.UserMasters.ToList();
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            UserMaster? ss = new UserMaster();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.UserMasters.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Edit(UserMaster s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var Result = db.UserMasters.Find(s.UserID);

                Result.FirstName = s.FirstName;
                Result.LastName = s.LastName;
                Result.DOB = s.DOB;
                Result.Gender = s.Gender;
                Result.Contact = s.Contact;
                Result.EmailID = s.EmailID;
                Result.UserName = s.UserName;
                Result.Password = s.Password;
                Result.Role = s.Role;
                Result.Q1 = s.Q1;
                Result.Q2 = s.Q2;
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
            return RedirectToAction("Index", "Accounts");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            UserMaster ss = new UserMaster();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.UserMasters.Where(x => x.UserID == id).FirstOrDefault();
                db.UserMasters.Remove(ss);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    TempData["DeleteMsg"] = "1";
                    ModelState.Clear();
                }

            }
            return RedirectToAction("Index", "Accounts");
        }

        
        public IActionResult ForgetPassword2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword2(FPModel fp)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var users = db.UserMasters.Where(x => x.UserName == fp.UserName && x.Q1 == fp.Q1 && x.Q2==fp.Q2);
                if (users.Count() > 0)
                {
                    var user = users.FirstOrDefault();
                    TempData["msg"] = "1";
                    int n = user.UserID;
                    HttpContext.Session.SetInt32("userID", user.UserID);
                   
                    return RedirectToAction("Reset", "Accounts", new  {id = n });

                }
                else
                {
                    ModelState.Clear();
                    TempData["msg"] = "Incorrect userID or Recovery Question answer";
                }
            }
            return View();
        }

        public IActionResult Reset(int id)
        {
            UserMaster? ss = new UserMaster();
            using (ProjectContext db = new ProjectContext())
            {
                ss = db.UserMasters.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(ss);
        }

        [HttpPost]
        public IActionResult Reset(UserMaster s)
        {
            using (ProjectContext db = new ProjectContext())
            {
                var Result = db.UserMasters.Find(s.UserID);

                Result.Password = s.Password;
                Result.Q1 = s.Q1;
                Result.Q2 = s.Q2;
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
            return RedirectToAction("Login", "Accounts");
        }

        public IActionResult Help()
        {
            return View();
        }


    }
}
