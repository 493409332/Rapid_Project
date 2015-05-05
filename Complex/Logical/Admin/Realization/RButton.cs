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
    [ICOConfig("RButton")]
    public class RButton : EFRepositoryBase<T_Button>, IButton
    {
        public RButton()
        {
            ChangeDatabase("MySQLContext");
        }
        #region IBase<T_Button> 成员
        public IEnumerable<T_Button> GetPageEnumerable(T_Button model, int page, int rows, string sort, string order, out int total, object where)
        {
            var quer = new List<T_Button>();
            quer.Add(new T_Button());
            total = 10;
            return quer;
        }
        public List<T_Button> GetPageList(T_Button model, int page, int rows, string sort, string order, out int total, object where)
        {
            throw new NotImplementedException();
        }

       
        [AOPTransaction]
        public int Add(T_Button model)
        {
            return Insert(model);
        }

        public bool AddRteboll(T_Button model)
        {
            throw new NotImplementedException();
        }

        public int Remove(T_Button model)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRteboll(T_Button model)
        {
            throw new NotImplementedException();
        }

        public int Edit(T_Button model)
        {
            throw new NotImplementedException();
        }

        public bool EditRteboll(T_Button model)
        {
            throw new NotImplementedException();
        }

      

        public List<T_Button> GetAllList(T_Button model, int page, int rows, string sort, string order, out int total)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T_Button> GetAllEnumerable(T_Button model, int page, int rows, string sort, string order, out int total)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
