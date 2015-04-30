using MtAop.BaseAttribute;
using MtAop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Logical.test1.AopAttribute
{
    public class EndAttribute : BaseEndAttribute
    {
        public override InvokeContext Action(InvokeContext context)
        {
            Console.WriteLine("log start!");
            return context;
        }
    }
}
