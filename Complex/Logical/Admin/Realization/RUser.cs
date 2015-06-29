using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity.Admin;
using Complex.ICO_AOP;
using Complex.ICO_AOP.Attribute;
using Complex.Repository;

namespace Complex.Logical.Admin.Realization
{
    [ICOConfig("RUser")]
    public class RUser : RBase<T_User>, IUser
    {
        public RUser()
            : base("MySQLServerContext")
        { 
        }

        //public List<T_Button> GetPage(string predicate, int page, int page_size, string order, string asc)
        //{
        //  //  return GetAllNoCache().OrderBy(p=>p.ID).Skip(( page - 1 ) * page_size).Take(page_size).ToList();
           
        //    return SearchSqLFor_Page<T_Button>("ID>1",2,5,"ID","asc"); 
        //}
 
 
    
       
    }
}
