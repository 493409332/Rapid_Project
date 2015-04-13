using Complex.Common.Utility;
using Complex.Entity;
using Complex.Logical.AopAttribute;
using Complex.Logical.ILogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
using Complex.ICO_AOP; 

namespace Complex.Logical.Realization
{
    //[ICOConfigAttrbute("Login1", typeof(Login1))]
    [ICOConfig("Login1")]
    public class Login1 : ILogin
    {
        int ii = 1;
        Login test = new Login();
    
        //[Start]
        //public bool IsLogin(test2 model)
        //{
        //    ii = 2;
          
        //    return false;
        //}

        #region ILogin 成员

          [Start1]
        public bool IsLogin(test2 model, int aa, decimal bb, object cc, float aaa)
      //  public bool IsLogin(test2 model, int aa)
            {
            ii = 2;

          
            test.OpenTransaction();
            try
            {
                test.IsLogin(model, aa, bb, cc, aaa);

            }
            catch ( Exception )
            {
                test.Rollback();
                throw;
            }
            test.Commit();


            return false;
        }

        #endregion
    }
}
