using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zerohunger.Models
{
    public class UserModel
    {
        public int User_id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> TypeId { get; set; }

        public virtual Type Type { get; set; }
    }
}