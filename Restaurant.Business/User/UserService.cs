using Restaurant.Abstract.IUser;
using Restaurant.Data.Data;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.User
{
    public class UserService : IUser
    {
        RestaurantEntities1 _DB = new RestaurantEntities1();
        public object CreateUser(userVM userVm)
        {
            try
            {
                var res = _DB.users.Where(x => x.userName == userVm.userName || x.password == userVm.password || x.email == userVm.email).FirstOrDefault();
                if(res != null)
                {
                    return null;
                }
                userVm.cDate = DateTime.Now;
                userVm.isActive = true;
                userVm.typeOfUser = "customer";
                var model = user.Clone(userVm);
                _DB.users.Add(model);
                _DB.SaveChanges();
                return model;

            }
            catch(Exception ex)
            {
                return new userVM();
            }
        }

        public userVM Login(string userNameOrEmail , string password)
        {
            try
            {
                var Result =(from u in _DB.users
                             where((u.userName == userNameOrEmail && u.password == password) || (u.email == userNameOrEmail && u.password == password))
                             select new userVM()
                             {
                                 address= u.address,
                                 cDate= u.cDate,
                                 email= u.email,
                                 fullName= u.fullName,
                                 id= u.id,
                                 isActive= u.isActive,
                                 password= u.password,
                                 Phone= u.Phone,
                                 typeOfUser= u.typeOfUser,
                                 userName= u.userName
                             }).FirstOrDefault();
                if(Result !=null)
                {
                    return Result;
                }
                return new userVM();

            }
            catch
            {
                return new userVM();
            }
        }
    }
}
