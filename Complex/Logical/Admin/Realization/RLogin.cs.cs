using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity.Admin;
using Complex.ICO_AOP.Attribute;
using Complex.Repository;

namespace Complex.Logical.Admin.Realization
{ 
    [ICOConfig("RLogin")]
    public class RLogin : EFRepositoryBase<T_User>, ILogin
    {
        #region ILogin 成员

        public bool SearchForName(string username)
        {
            return GetAllNoCache().Where(p => p.UserName == username).Count() > 0;

        }
        public T_User SearchForNameorPwd(string username, string userpwd)
        {
            return GetAllNoCache().Where(p => p.UserName == username && p.Password == userpwd).FirstOrDefault();
        }


        #endregion

        #region IBase<T_User> 成员

        public int Add(T_User model)
        {
            throw new NotImplementedException();
        }

        public int Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public int Edit(T_User model)
        {
            throw new NotImplementedException();
        }

        public List<T_User> GetPageList(T_User model, int page, int rows, string sort, string order, out int total, string[] where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_User> GetPageEnumerable(T_User model, int page, int rows, string sort, string order, out int total, string[] where)
        {
            throw new NotImplementedException();
        }

        public List<T_User> GetAllList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_User> GetAllEnumerable()
        {
            throw new NotImplementedException();
        }

        #endregion

 

        #region IBase<T_User> 成员


        public List<T_User> GetPage(string predicate, int page, int page_size, string order, string asc, out int total)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
