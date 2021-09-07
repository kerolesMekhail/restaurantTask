using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Abstract.IEmployee
{
    public interface IEmployee
    {
        List<cardVM> Orders(string search);
        cardVM Details(int Id);
        int Confirmed(int id);
    }
}
