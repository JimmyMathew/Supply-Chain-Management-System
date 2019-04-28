using SupplyChainManagement.DAL;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyChainManagement.Controllers
{
    public class ManufacturerController : Controller
    {
        MasterDAL masterDal = new MasterDAL();
        // GET: Manufacturer
        #region ManufacturerUnit
        [LoginCheckAttribute]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllManufacturerDetails()
        {
            List<object> resultList = new List<object>();
            List<ManufacturerUnitDetails> muDetails = new List<ManufacturerUnitDetails>();
            muDetails = masterDal.ReadManufacturerDetails().OrderByDescending(x => x.id).ToList();
            resultList.Add(muDetails);
            resultList.Add(masterDal.ReadProductDetails());
            resultList.Add(masterDal.ReadHolderDetails().ToList().Where(x => x.type == "Distributor").ToList());
            resultList.Add(masterDal.ReadHolderDetails().ToList().Where(x => x.type == "Manufacturer").ToList());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveManufacturers(string id, string name, string productname, string productid, string quantity)
        {
            if (id == "" || id == null)
                id = "0";
            if (productid == "" || productid == null)
                productid = "0";
            if (quantity == "" || quantity == null)
                quantity = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            ManufacturerUnitDetails item = new ManufacturerUnitDetails();
            item.name = name;
            item.productid = Int32.Parse(productid);
            item.productname = productname;
            item.quantity = Int32.Parse(quantity);
            item.id = idFlag;
            if (idFlag == 0)
                res = masterDal.SaveManufacturerDetails(item);
            else
                res = masterDal.UpdateManufacturerDetails(item);
            resultList.Add(res);
            resultList.Add(GetAllManufacturerDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteManufacturers(string id)
        {
            Response res = new Response();
            List<object> resultList = new List<object>();
            res = masterDal.DeleteManufacturerDetails(Int32.Parse(id));
            resultList.Add(res);
            resultList.Add(GetAllManufacturerDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult OrderManufacturers(string id, string name, string productname, string productid, string quantity,string actualQuantity,string distributorName,string distributorId)
        {
            if (id == "" || id == null)
                id = "0";
            if (productid == "" || productid == null)
                productid = "0";
            if (quantity == "" || quantity == null)
                quantity = "0";
            if (distributorId == "" || distributorId == null)
                distributorId = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            ManufacturerUnitDetails item = new ManufacturerUnitDetails();
            item.name = name;
            item.productid = Int32.Parse(productid);
            item.productname = productname;
            item.quantity = Int32.Parse(actualQuantity);
            item.id = idFlag;
            DistributorUnitDetails distItem = new DistributorUnitDetails();
            distItem.id = Int32.Parse(distributorId);
            distItem.name = distributorName;
            distItem.productid = Int32.Parse(productid);
            distItem.productname = productname;
            distItem.distributorId = Int32.Parse(distributorId);
            distItem.quantity = Int32.Parse(quantity);
            masterDal.UpdateManufacturerDetails(item);
            res = masterDal.SaveDisctributorDetails(distItem);
            resultList.Add(res);
            resultList.Add(GetAllManufacturerDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region DistributorUnit
        [LoginCheckAttribute]
        public ActionResult Distributor()
        {
            return View();
        }
        public ActionResult GetAllDistributorDetails()
        {
            List<object> resultList = new List<object>();
            List<DistributorUnitDetails> diDetails = new List<DistributorUnitDetails>();
            diDetails = masterDal.ReadDistributorDetails().OrderByDescending(x => x.id).ToList();
            resultList.Add(diDetails);
            resultList.Add(masterDal.ReadHolderDetails().ToList().Where(x => x.type == "Customer").ToList());
            resultList.Add(masterDal.ReadProductDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);
      }
        public ActionResult TransferManufacturers(string id, string name, string productname, string productid, string quantity, string distributorName, string distributorId)
        {
            if (id == "" || id == null)
                id = "0";
            if (productid == "" || productid == null)
                productid = "0";
            if (quantity == "" || quantity == null)
                quantity = "0";
            if (distributorId == "" || distributorId == null)
                distributorId = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            DeliveryUnitDetails distItem = new DeliveryUnitDetails();
            distItem.id = Int32.Parse(distributorId);
            distItem.name = name;
            distItem.productid = Int32.Parse(productid);
            distItem.productname = productname;
            distItem.distributorid = Int32.Parse(distributorId);
            distItem.distributorname = distributorName;
            distItem.quantity = Int32.Parse(quantity);
            masterDal.DeleteDistributorDetails(Int32.Parse(id));
            res = masterDal.SaveDeliveryDetails(distItem);
            resultList.Add(res);
            resultList.Add(GetAllDistributorDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region DeliveryUnit
        [LoginCheckAttribute]
        public ActionResult Delivery()
        {
            return View();
        }
        public ActionResult GetAllDeliveryDetails()
        {
            List<object> resultList = new List<object>();
            List<DeliveryUnitDetails> diDetails = new List<DeliveryUnitDetails>();
            diDetails = masterDal.ReadDeliveryDetails().Where(x=>x.isactive == true).OrderByDescending(x => x.id).ToList();
            resultList.Add(diDetails);
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeliverOrder(string id, string name, string productname, string productid, string quantity, string distributorname, string distributorid)
        {
            if (id == "" || id == null)
                id = "0";
            if (productid == "" || productid == null)
                productid = "0";
            if (quantity == "" || quantity == null)
                quantity = "0";
            if (distributorid == "" || distributorid == null)
                distributorid = "0";
            Response res = new Response();
            List<object> resultList = new List<object>();
            var idFlag = Int32.Parse(id);
            DeliveryUnitDetails distItem = new DeliveryUnitDetails();
            distItem.id = idFlag;
            distItem.name = name;
            distItem.productid = Int32.Parse(productid);
            distItem.productname = productname;
            distItem.distributorid = Int32.Parse(distributorid);
            distItem.distributorname = distributorname;
            distItem.quantity = Int32.Parse(quantity);
            res = masterDal.UpdateDeliveryDetails(distItem);
            resultList.Add(res);
            resultList.Add(GetAllDeliveryDetails());
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}