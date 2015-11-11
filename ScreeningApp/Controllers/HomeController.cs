using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using ScreeningApp.Models;

namespace ScreeningApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int originalNumber = 1;

            object boxedObject = originalNumber;
            boxedObject = 123;
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
            var selectList = from CurrencyType t in Enum.GetValues(typeof (CurrencyType)) 
                             select new {ID = t, Name = GetEnumDescription(t)};
            
            ViewData["currencyTypes"] = new SelectList(selectList, "ID", "Name");
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

        public ActionResult ConvertCurrency(double amount, CurrencyType convertFrom, CurrencyType convertTo)
        {
            double multiplier = GetMultiplier(convertFrom, convertTo);
            double convertedAmount = amount * multiplier;

            return Json(convertedAmount, JsonRequestBehavior.AllowGet);
        }

        private double GetMultiplier(CurrencyType fromType, CurrencyType toType)
        {
            double multiplier = 0;

            if (fromType == CurrencyType.USD)
            {
                multiplier = ConvertFromUS(toType);
            }
            else
            {
                Response.StatusCode = 520;
            }
            
            return multiplier;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        private double ConvertFromUS(CurrencyType toType)
        {
            switch (toType)
            {
                case CurrencyType.USD:
                    return 1;
                case CurrencyType.BYR:
                    return 17640;
                case CurrencyType.KES:
                    return 102.25;
                case CurrencyType.BRL:
                    return 3.77;
                case CurrencyType.CNY:
                    return 6.37;
                default:
                    return 1;
            }
        }
    }
}