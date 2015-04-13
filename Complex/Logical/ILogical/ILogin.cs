using Complex.Common.Utility;
using Complex.Entity;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.ICO_AOP;
using Complex.ICO_AOP.Utility;
 

namespace Complex.Logical.ILogical
{
    [ICO_AOPEnable(true)]
    public interface ILogin : ITransientLifetimeManagerRegister
    {
        bool IsLogin(test2 model,int aa,decimal bb,object cc ,float aaa);
      //  bool IsLogin(test2 model, int aa); 
    }
}
