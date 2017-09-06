using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebSiteNLogWithSqlite3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SqliteDBInitinal();//當網站建立時會自動建立SqliteDB
        }

        /// <summary>
        /// 
        /// </summary>
        private void SqliteDBInitinal()
        {
            //建立DB
            try
            {
                //Sqlite3DB的建立路徑 - Nlog的路徑
                var nlogSqlitePath = HttpContext.Current.Server.MapPath("~/App_Data/NLog_Record.s3db");
                //
                SQLiteConnection.CreateFile(nlogSqlitePath);
            }
            catch (Exception ex)//當發生錯誤時
            {
                //使用Nlog內建的Error Exception紀錄
                LogManager.GetLogger("MyNlog").ErrorException("建立.s3db時發生例外", ex);
            }
        }

    }
}
