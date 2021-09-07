using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Data
{
    public partial class user
    {
        public static user Clone(userVM userVM)
        {
            user x = new user();
            x.address = userVM.address;
            x.cDate = userVM.cDate;
            x.fullName = userVM.fullName;
            x.id = userVM.id;
            x.isActive = userVM.isActive;
            x.password = userVM.password;
            x.Phone = userVM.Phone;
            x.typeOfUser = userVM.typeOfUser;
            x.userName = userVM.userName;
            x.email = userVM.email;
            return x;
        }
    }
}
