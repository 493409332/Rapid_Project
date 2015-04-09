using Complex.Common.Utility;
using Complex.Entity;
using Complex.Logical.AopAttribute;
using Complex.Logical.ILogical;
using Complex.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.Realization
{
    [Description("Login")]
    public class Login : EFRepositoryBase<test2>, ILogin
    {
        public Login() {
            ChangeDatabase("OraString");
        }
        int ii = 1;
        //[Start]
        //[Ex]
        //public bool IsLogin(test2 model)
        //{ 
        //    ii = 2; 
        //    Insert(model);  
        //    return false;
        //}

        #region ILogin 成员


         [Start1]
        [Ex]
        public bool IsLogin(test2 model, int aa, decimal bb, object cc, float aaa)
     //   public bool IsLogin(test2 model, int aa)
        {
            Insert(model);

            throw new ArgumentOutOfRangeException("不存在的月份"); 
            var quer = EF.test2.AsNoTracking().ToList();
            //Update(model);
            ii = aa;
           // Insert(model);
            return false;
        }

        #endregion
    }
}
