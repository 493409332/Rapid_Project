using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity.Admin.BaseModel;

namespace Complex.Entity.Admin
{
    public class T_RoleNavBtns : AdminBase
    {
        public int RoleID { get; set; }
        public int NavID { get; set; }
        public int BtnID { get; set; }
    }
}
