using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SupplyChainManagement.DAL
{
    public class MasterDAL
    {
        scmEntities entities = new scmEntities();
        #region User Details
        public List<UserDetails> ReadUserDetails()
        {
            return entities.users.Select(x => new UserDetails

            {
                id = x.id,
                name = x.name,
                username = x.username,
                password = x.password,
                role = x.role
            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveUserDetails(UserDetails obj)
        {
            var IsExist = entities.users.Where(x => x.username == obj.username).ToList();
            if (IsExist.Count == 0)
            {
                user itemObj = new user();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.username = obj.username;
                itemObj.password = obj.password;
                itemObj.role = obj.role;
                itemObj.createdBy = "Admin";
                itemObj.createdOn = DateTime.Now;
                itemObj.updatedBy = "Admin";
                itemObj.updatedOn = DateTime.Now;
                entities.users.Add(itemObj);

                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "User details added successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "User already exists" };

        }
        public Response UpdateUserDetails(UserDetails obj)
        {
            var IsExist = entities.users.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.users.Where(x => x.id == obj.id).FirstOrDefault();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.username = obj.username;
                itemObj.password = obj.password;
                itemObj.role = obj.role;
                itemObj.createdBy = "Admin";
                itemObj.createdOn = DateTime.Now;
                itemObj.updatedBy = "Admin";
                itemObj.updatedOn = DateTime.Now;
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "User details updated successfully " };
            }
            else
                return new Response { IsSuccess = false, Message = "User already exists" };

        }
        public Response DeleteUserDetails(int id)
        {
            var itemObj = entities.users.Where(x => x.id == id).FirstOrDefault();
            if (itemObj != null)
            {
                entities.users.Remove(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = false, Message = "User details deleted successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Data deletion error. Contact Administrator" };
        }
        #endregion
        #region ProductDetails
        public List<ProductDetails> ReadProductDetails()
        {
            return entities.products.Select(x => new ProductDetails

            {
                id = x.id,
                name = x.name,
                description = x.description,
                model = x.model,
                sku = x.sku,
                upc = x.upc,
                price = x.price,
                quantity = x.quantity
            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveProductDetails(ProductDetails obj)
        {
            var IsExist = entities.products.Where(x => x.name == obj.name).ToList();
            if (IsExist.Count == 0)
            {
                product itemObj = new product();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.description = obj.description;
                itemObj.model = obj.model;
                itemObj.sku = obj.sku;
                itemObj.upc = obj.upc;
                itemObj.price = obj.price;
                itemObj.quantity = obj.quantity;
                itemObj.createdBy = "Admin";
                itemObj.createdOn = DateTime.Now;
                itemObj.updatedBy = "Admin";
                itemObj.updatedOn = DateTime.Now;
                entities.products.Add(itemObj);

                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Product details added successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Product already exists" };

        }
        public Response UpdateProductDetails(ProductDetails obj)
        {
            var IsExist = entities.products.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.products.Where(x => x.id == obj.id).FirstOrDefault();
                product itemObj1 = new product();
                itemObj1.id = obj.id;
                itemObj1.name = obj.name;
                itemObj1.description = obj.description;
                itemObj1.model = obj.model;
                itemObj1.sku = obj.sku;
                itemObj1.upc = obj.upc;
                itemObj1.price = obj.price;
                itemObj.quantity = obj.quantity;
                itemObj1.createdBy = "Admin";
                itemObj1.createdOn = DateTime.Now;
                itemObj1.updatedBy = "Admin";
                itemObj1.updatedOn = DateTime.Now;
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Product details updated successfully " };
            }
            else
                return new Response { IsSuccess = false, Message = "Product already exists" };

        }
        public Response DeleteProductDetails(int id)
        {
            var itemObj = entities.products.Where(x => x.id == id).FirstOrDefault();
            if (itemObj != null)
            {
                entities.products.Remove(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = false, Message = "Product details deleted successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Data deletion error. Contact Administrator" };
        }
        #endregion
        #region StakeHolderDetails
        public List<HolderDetails> ReadHolderDetails()
        {
            return entities.stakeholders.Select(x => new HolderDetails

            {
                id = x.id,
                name = x.name,
                location= x.location,
                type = x.type
            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveHolderDetails(HolderDetails obj)
        {
            var IsExist = entities.stakeholders.Where(x => x.name == obj.name && x.type == obj.type).ToList();
            if (IsExist.Count == 0)
            {
                stakeholder itemObj = new stakeholder();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.location = obj.location;
                itemObj.type = obj.type;
                itemObj.createdBy = "Admin";
                itemObj.createOn = DateTime.Now;
                itemObj.updateBy = "Admin";
                itemObj.updateOn = DateTime.Now;
                entities.stakeholders.Add(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Stake Holder details added successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Stakeholder already exists" };

        }
        public Response UpdateHolderDetails(HolderDetails obj)
        {
            var IsExist = entities.stakeholders.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.stakeholders.Where(x => x.id == obj.id).FirstOrDefault();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.location = obj.location;
                itemObj.type = obj.type;
                itemObj.createdBy = "Admin";
                itemObj.createOn = DateTime.Now;
                itemObj.updateBy = "Admin";
                itemObj.updateOn = DateTime.Now;
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Stake Holder details updated successfully " };
            }
            else
                return new Response { IsSuccess = false, Message = "Stake Holder already exists" };

        }
        public Response DeleteHolderDetails(int id)
        {
            var itemObj = entities.stakeholders.Where(x => x.id == id).FirstOrDefault();
            if (itemObj != null)
            {
                entities.stakeholders.Remove(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = false, Message = "User details deleted successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Data deletion error. Contact Administrator" };
        }
        #endregion
        #region ManufacturerUnit
        public List<ManufacturerUnitDetails> ReadManufacturerDetails()
        {
            return entities.manufacturerunits.Select(x => new ManufacturerUnitDetails

            {
                id = x.id,
                name = x.name,
                productid = x.productid,
                productname = x.productname,
                quantity = x.quantity,
                createdOn = x.createdOn.ToString(),

            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveManufacturerDetails(ManufacturerUnitDetails obj)
        {
                manufacturerunit itemObj = new manufacturerunit();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.productid = obj.productid;
                itemObj.productname = obj.productname;
                itemObj.quantity = obj.quantity;
                itemObj.createdOn = DateTime.Now;
                entities.manufacturerunits.Add(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Manufacturer details added successfully" };
        }
        public Response UpdateManufacturerDetails(ManufacturerUnitDetails obj)
        {
            var IsExist = entities.manufacturerunits.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.manufacturerunits.Where(x => x.id == obj.id).FirstOrDefault();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.productid = obj.productid;
                itemObj.productname = obj.productname;
                itemObj.quantity = obj.quantity;
                itemObj.createdOn = DateTime.Now;
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Manufacturer details updated successfully " };
            }
            else
                return new Response { IsSuccess = false, Message = "Manufacturer already exists" };

        }
        public Response DeleteManufacturerDetails(int id)
        {
            var itemObj = entities.manufacturerunits.Where(x => x.id == id).FirstOrDefault();
            if (itemObj != null)
            {
                entities.manufacturerunits.Remove(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = false, Message = "Manufacturer details deleted successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Data deletion error. Contact Administrator" };
        }
        #endregion

        #region DistributorUnit
        public List<DistributorUnitDetails> ReadDistributorDetails()
        {
            return entities.distributorunits.Select(x => new DistributorUnitDetails

            {
                id = x.id,
                name = x.name,
                distributorId= x.distributorId,
                productid = x.productid,
                productname = x.productname,
                quantity = x.quantity,
                createdOn = x.createdOn.ToString(),

            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveDisctributorDetails(DistributorUnitDetails obj)
        {
            distributorunit itemObj = new distributorunit();
            itemObj.id = obj.id;
            itemObj.name = obj.name;
            itemObj.distributorId = obj.distributorId;
            itemObj.productid = obj.productid;
            itemObj.productname = obj.productname;
            itemObj.quantity = obj.quantity;
            itemObj.createdOn = DateTime.Now;
            entities.distributorunits.Add(itemObj);
            entities.SaveChanges();
            return new Response { IsSuccess = true, Message = "Order forwarded to distribution unit: " + obj.name};
        }
        public Response DeleteDistributorDetails(int id)
        {
            var itemObj = entities.distributorunits.Where(x => x.id == id).FirstOrDefault();
            if (itemObj != null)
            {
                entities.distributorunits.Remove(itemObj);
                entities.SaveChanges();
                return new Response { IsSuccess = false, Message = "Distributor details deleted successfully" };
            }
            else
                return new Response { IsSuccess = false, Message = "Data deletion error. Contact Administrator" };
        }
        #endregion
        #region DeliveryUnit
        public List<DeliveryUnitDetails> ReadDeliveryDetails()
        {
            return entities.deliveryunits.Select(x => new DeliveryUnitDetails

            {
                id = x.id,
                name = x.name,
                distributorid = x.distributorid,
                distributorname = x.distributorname,
                productid = x.productid,
                productname = x.productname,
                quantity = x.quantity,
                createdOn = x.createdOn.ToString(),
                isactive = x.isactive

            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveDeliveryDetails(DeliveryUnitDetails obj)
        {
            deliveryunit itemObj = new deliveryunit();
            itemObj.id = obj.id;
            itemObj.name = obj.name;
            itemObj.distributorid = obj.distributorid;
            itemObj.distributorname = obj.distributorname;
            itemObj.productid = obj.productid;
            itemObj.productname = obj.productname;
            itemObj.quantity = obj.quantity;
            itemObj.createdOn = DateTime.Now;
            itemObj.isactive = true;
            entities.deliveryunits.Add(itemObj);
            entities.SaveChanges();
            return new Response { IsSuccess = true, Message = "Order Transferred to delivery unit: " + obj.name };
        }
        public Response UpdateDeliveryDetails(DeliveryUnitDetails obj)
        {
            var IsExist = entities.deliveryunits.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.deliveryunits.Where(x => x.id == obj.id).FirstOrDefault();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.distributorname = obj.distributorname;
                itemObj.distributorid = obj.distributorid;
                itemObj.productid = obj.productid;
                itemObj.productname = obj.productname;
                itemObj.quantity = obj.quantity;
                itemObj.createdOn = DateTime.Now;
                itemObj.isactive = false;
                entities.SaveChanges();
                return new Response { IsSuccess = true, Message = "Order Delivered successfully to:  "+ obj.name  };
            }
            else
                return new Response { IsSuccess = false, Message = "Manufacturer already exists" };

        }
        #endregion

    }
}