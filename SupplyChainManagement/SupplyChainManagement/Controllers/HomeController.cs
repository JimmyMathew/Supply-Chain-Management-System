using SupplyChainManagement.DAL;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyChainManagement.Controllers
{
    public class HomeController : Controller
    {
        MasterDAL masterDal = new MasterDAL();  
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginCheck()
        {
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();

            var obj = masterDal.ReadUserDetails().Where(a => a.username.Equals(username) && a.password.Equals(password)).FirstOrDefault();
            if (obj != null)
            {
                Session["employeeName"] = obj.name.ToString();
                Session["role"] = obj.role.ToString();
                Session["username"] = obj.username.ToString();
                //return View(new { redirecturl = "/Home/Index" }, JsonRequestBehavior.AllowGet);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home", new { result = "failure" });
            
        }
        public ActionResult Logout()
        {
            Session["role"] = null;
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }
        [LoginCheckAttribute]
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult GetDashboardDetails()
        {
            List<object> resultList = new List<object>();
            List<DeliveryUnitDetails> muDetails = new List<DeliveryUnitDetails>();
            muDetails = masterDal.ReadDeliveryDetails().Take(10).OrderByDescending(x => x.id).ToList();
            var totalManufacturers = masterDal.ReadManufacturerDetails().Count();
            var totalDistributions = masterDal.ReadDistributorDetails().Count();
            var totalDeliveries = masterDal.ReadDeliveryDetails().Where(x => x.isactive == false).ToList().Count();
            var totalCustomers = masterDal.ReadHolderDetails().Where(x => x.type == "Customer").ToList().Count();
            resultList.Add(totalManufacturers);
            resultList.Add(totalDistributions);
            resultList.Add(totalDeliveries);
            resultList.Add(totalCustomers);
            resultList.Add(muDetails);
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }


    }
}