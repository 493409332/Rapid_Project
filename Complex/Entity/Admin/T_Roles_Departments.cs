﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity.Admin.BaseModel;

namespace Complex.Entity.Admin
{
    public class T_Roles_Departments : AdminBase
    {
        public int RoleID { get; set; }
        public int DepID { get; set; }
    }
}