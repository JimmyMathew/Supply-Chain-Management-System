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
                usename = x.usename,
                password = x.password,
                role = x.role
            }).OrderByDescending(x => x.id).ToList();
        }
        public Response SaveUserDetails(UserDetails obj)
        {
            List<UserDetails> userList = new List<UserDetails>();
            var IsExist = entities.users.Where(x => x.usename == obj.usename).ToList();
            if (IsExist.Count == 0)
            {
                user itemObj = new user();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.name = obj.name;
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
            List<UserDetails> userList = new List<UserDetails>();
            var IsExist = entities.users.Where(x => x.id == obj.id).ToList();
            if (IsExist.Count != 0)
            {
                var itemObj = entities.users.Where(x => x.id == obj.id).FirstOrDefault();
                itemObj.id = obj.id;
                itemObj.name = obj.name;
                itemObj.usename = obj.usename;
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
    }
}