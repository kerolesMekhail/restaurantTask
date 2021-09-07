using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Abstract.IUser
{
    public interface IUser
    {
        object CreateUser(userVM user);
        userVM Login(string userNameOrEmail, string password); 
    }
}
