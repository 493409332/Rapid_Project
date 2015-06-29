using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity.Admin;

namespace Complex.Logical
{
    public interface IBase<T>
    {
        int Add(T model);



        int Remove(int ID);



        int Edit(T model);

        List<T> GetPage(string predicate, int page, int page_size, string order, string asc, out int total);

        List<T> GetPageList(T model, int page, int rows, string sort, string order, out int total, string[] where);

        IEnumerable<T> GetPageEnumerable(T model, int page, int rows, string sort, string order, out int total, string[] where);

        List<T> GetAllList();

        IEnumerable<T> GetAllEnumerable();

       
    }
}
