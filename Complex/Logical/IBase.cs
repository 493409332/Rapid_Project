using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical
{
    public interface IBase<T>
    {
        int Add(T model);
        bool AddRteboll(T model);

        int Remove(T model);
        bool RemoveRteboll(T model);

        int Edit(T model);
        bool EditRteboll(T model);

        List<T> GetPageList(T model, int page, int rows, string sort, string order, out int total,object where);
        IEnumerable<T> GetPageEnumerable(T model, int page, int rows, string sort, string order, out int total, object where);

        List<T> GetAllList(T model, int page, int rows, string sort, string order, out int total);
        IEnumerable<T> GetAllEnumerable(T model, int page, int rows, string sort, string order, out int total);
       
    }
}
