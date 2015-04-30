using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtAop.Context;

namespace Complex
{
    class Class1
    {
        public decimal aa()
        {
            decimal aaa;
           // aaa = Convert.ToDecimal(11111);

            InvokeContext context = new InvokeContext();
            context.Result = 1111111.1111M;

            aaa =Convert.ToDecimal(context.Result);

            return aaa;
        }
    }
}
