using MtAop.BaseAttribute;
using MtAop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Entity;
namespace Complex.Logical.test1.AopAttribute
{
    public class StartAttribute : BaseStartAttribute
    {
        public override InvokeContext Action(InvokeContext context)
        {
            

            Console.WriteLine("log start!");
            context.IsRun = true;
            return context;
        }
    }
   
}
