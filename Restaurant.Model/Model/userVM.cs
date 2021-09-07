using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.Model
{
    public class userVM
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public string typeOfUser { get; set; }
        public System.DateTime? cDate { get; set; }
    }
}
