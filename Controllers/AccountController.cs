using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MibClient2.Web.Components;

namespace DXAnalytics.Base
{
    /// <summary>
    /// 
    /// </summary>
    [HandleError]
    public class AccountController : Controller
    {

        private Authenticator _authenticator;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (HttpContext.Session["AUTH"] != null)
                if (((Authenticator)HttpContext.Session["AUTH"]).IsLogged) HttpContext.Response.Redirect("~/Home/Index");
            return View();
        }

        public ActionResult Authenticator(string uname, string upass)
        {
            try
            {
                _authenticator = new Authenticator();
                if (_authenticator.Login(uname, upass))
                {
                    HttpContext.Session["AUTH"] = _authenticator;
                    HttpContext.Session["UID"] = _authenticator.CurrentUser.ID;
                    HttpContext.Session["UName"] = _authenticator.CurrentUser.Name;
                    return Json(new { Status = "OK", UserName = _authenticator.CurrentUser.Name }, "text/plain");
                }
                else
                    return Json(new { Status = "Error", Message = "Username and/or password invalid." }, "text/plain");
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Error", Message = ex.Message.ToString() }, "text/plain");
            }

        }

        public void Loggof()
        {
            if (HttpContext.Session["AUTH"] != null) ((Authenticator)HttpContext.Session["AUTH"]).Loggof();
        }
    }
}