﻿using Complex.Entity;
 
using Complex.Logical.ILogical;
using Complex.Repository.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Dependency("Login")]
        public ITest2 Login { get; set; }

        [Dependency("Login1")]
        public ITest2 Login1 { get; set; }
  //      public ILogin Login2 = DependencyUnityContainer.Current.Resolve<ILogin>("Login1");

      //  DependencyUnityContainer
        public ActionResult Index()
        {
            object aa = HttpContext.Items["123"];
          //  decimal aaa11 = Login.IsLogin(new test2() { ID = 1, Name = "aaaaaaa", Num = 1, test3 = new test3() { Name1 = "aaaaaaaaaa", Num1 = 1 } }, 11, 1.11m, 111, 1.1123f);
          //  bool aa = Login.IsLogin(new test2() { ID = 1, Name = "12", Num = 1, test3 = new test3() { Name1 = "123", Num1 = 1 } }, 212);
       //     bool aa1 = Login1.IsLogin(new test2());

          //  bool aa1 = Login2.IsLogin(new T_Department());
            //using (EntitytoData dbcontext = EntitytoData.Init("MyContext"))
            //{
                

            //   // dbcontext.TestCase.Add(new TestCase { Field1 = 1, Field3 = "a", Field2 = 1.2F, Field4 = "a", Field5 = DateTime.Now });
            //     dbcontext.TestCase.Add(new TestCase { Field1 = 1, Field3 = "啊的的的的", Field2 = 1.2F, Field4 = "才是是是是是", Field5 = DateTime.Now });
               
            //   //dbcontext.test2.Add(new test2 { ID = 12, Name = "adas2d", Num = 3212 });
            //     int ii = dbcontext.SaveChanges(); 
            //    TestCase model = dbcontext.TestCase.Find(7);
            //}

            return View();
        }

    }
}
