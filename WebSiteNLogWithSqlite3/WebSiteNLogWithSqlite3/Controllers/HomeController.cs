using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteNLogWithSqlite3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                LogManager.GetLogger("Action Index").Info("好人一生平安");
                //以下故意將型別設成Null 再塞值，造成Exception
                List<object> testObject = new List<object>();
                testObject = null;
                testObject.Add(null);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("Action Index").ErrorException("Title:測試發生錯誤", ex);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}