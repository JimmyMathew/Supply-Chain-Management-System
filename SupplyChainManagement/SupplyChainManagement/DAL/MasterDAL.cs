using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
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
                entities.products.Add(itemObj);
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
    }
}