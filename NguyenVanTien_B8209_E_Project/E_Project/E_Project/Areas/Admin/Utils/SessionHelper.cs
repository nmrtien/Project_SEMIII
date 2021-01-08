using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Project.Areas.Admin.Utils
{
    public class SessionHelper
    {
        public static void SetSession(InfoSession infoSession)
        {
            HttpContext.Current.Session["inforSession"] = infoSession;
        }

        public static void DestroySession()
        {
            HttpContext.Current.Session["inforSession"] = null;
        }

        public static InfoSession GetInfoSession()
        {
            var infoSession = HttpContext.Current.Session["inforSession"];
            if (infoSession == null)
            {
                return null;
            }
            else
            {
                return infoSession as InfoSession;
            }
        }
    }
}