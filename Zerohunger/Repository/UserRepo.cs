using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zerohunger.Models;
using Zerohunger.EF;

namespace Zerohunger.Repository
{
    public class UserRepo
    {

        public List<TypeModel> GetType()
        {
            using (var context = new ZerohungerEntities())
            {
                var result = context.Type.Select(x => new TypeModel { Id = x.Id, Name = x.Name }).ToList();
                return result;
            }
        }
        public int AddUser(UserModel model)
        {
            using (var context = new ZerohungerEntities())
            {
                Users user = new Users()
                {
                    Email = model.Email,
                    Password = model.Password,
                    TypeId = model.TypeId
                };

                var result = context.Users.Add(user);
                context.SaveChanges();
                return user.User_id;
            }

        }
        public int LoginUser(UserModel model)
        {
            using (var context = new ZerohungerEntities())
            {
                var result = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (result != null)
                {
                    return (int)result.TypeId;
                }
            }
            return 0;
        }
    }
}