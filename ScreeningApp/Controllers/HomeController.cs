using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreeningApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int originalNumber = 1;

            object boxedObject = originalNumber;
            boxedObject = 123;
            
            
            //unbox this variable;
            //originalNumber = (int) boxedObject;
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ShowCSharpPage()
        {
            int something = 1;
            return View("CSharpMain");
        }

        public ActionResult ShowJavaScriptPage()
        {
            int something = 1;
            return View("JavaScriptMain");
        }

        public ActionResult ShowRazorPage()
        {
            int something = 1;
            return View("RazorMain");
        }

        public ActionResult ShowMVCPage()
        {
            int something = 1;
            return View("MVCMain");
        }

        public ActionResult ShowEasterEggPage()
        {
            int something = 1;
            if (something == 1)
            {
                throw new Exception();
            }
            return View("EasterEggMain");
        }
    }
}