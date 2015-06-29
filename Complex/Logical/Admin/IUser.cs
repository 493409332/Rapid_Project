﻿using Complex.Entity.Admin;
using Complex.ICO_AOP.Attribute;
using Complex.ICO_AOP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.Admin
{
    [ICO_AOPEnable(true)]
    public interface IUser : ITransientLifetimeManagerRegister, IBase<T_User>
    {

    }
}