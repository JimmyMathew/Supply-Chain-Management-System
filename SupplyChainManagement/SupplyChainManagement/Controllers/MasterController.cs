using SupplyChainManagement.DAL;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyChainManagement.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        MasterDAL masterDal = new MasterDAL();
        [LoginCheckAttribute]
        public ActionResult Index()
        {
            return View();
        }

        #region User
        [LoginCheckAttribute]
        public ActionResult User()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllUsers()
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            userDetails = masterDal.ReadUserDetails().OrderByDescending(x => x.id).ToList();
            return Json(userDetails, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveUsers(string id, string name, string username, string password, string role)
        {
            if (id == "" || id == null)
                id = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            UserDetails item = new UserDetails();
            item.name = name;
            item.username = username;
            item.password = password;
            item.role = role;
            item.id = idFlag;
            if (idFlag == 0)
                res = masterDal.SaveUserDetails(item);
            else
                res = masterDal.UpdateUserDetails(item);
            resultList.Add(res);
            resultList.Add(GetAllUsers());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUsers(string id)
        {
            Response res = new Response();
            List<object> resultList = new List<object>();
            res = masterDal.DeleteUserDetails(Int32.Parse(id));
            resultList.Add(res);
            resultList.Add(GetAllUsers());
            return Json(resultList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Products
        [LoginCheckAttribute]
        public ActionResult Products()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllProducts()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>();
            productDetails = masterDal.ReadProductDetails().OrderByDescending(x => x.id).ToList();
            return Json(productDetails, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveProducts(string id, string name, string description, string model, string sku,string upc,string price,string quantity)
        {
            if (id == "" || id == null)
                id = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            ProductDetails item = new ProductDetails();
            item.name = name;
            item.id = idFlag;
            item.description = description;
            item.model = model;
            item.sku = sku;
            item.upc = upc;
            item.price = Double.Parse(price);
            item.quantity = int.Parse(quantity);
            if (idFlag == 0)
                res = masterDal.SaveProductDetails(item);
            else
                res = masterDal.UpdateProductDetails(item);
            resultList.Add(res);
            resultList.Add(GetAllProducts());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteProducts(string id)
        {
            Response res = new Response();
            List<object> resultList = new List<object>();
            res = masterDal.DeleteProductDetails(Int32.Parse(id));
            resultList.Add(res);
            resultList.Add(GetAllProducts());
            return Json(resultList, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region StakeHolders
        [LoginCheckAttribute]
        public ActionResult Holders()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllHolders()
        {
            List<HolderDetails> holderDetails = new List<HolderDetails>();
            holderDetails = masterDal.ReadHolderDetails().OrderByDescending(x => x.id).ToList();
            return Json(holderDetails, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveHolders(string id, string name, string location, string type)
        {
            if (id == "" || id == null)
                id = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            HolderDetails item = new HolderDetails();
            item.name = name;
            item.id = idFlag;
            item.type = type;
            item.location = location; 
            if (idFlag == 0)
                res = masterDal.SaveHolderDetails(item);
            else
                res = masterDal.UpdateHolderDetails(item);
            resultList.Add(res);
            resultList.Add(GetAllHolders());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteHolders(string id)
        {
            Response res = new Response();
            List<object> resultList = new List<object>();
            res = masterDal.DeleteHolderDetails(Int32.Parse(id));
            resultList.Add(res);
            resultList.Add(GetAllHolders());
            return Json(resultList, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}