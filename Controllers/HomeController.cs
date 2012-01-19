using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXAnalytics.Base;
using MibClient2.Crypto;
using System.IO;
using System.Security.Cryptography;
using MibClient2.Web.Tools;
using DXAnalytics.Models;
using DXAnalytics.Models.ReportingViewData;

namespace DXAnalytics.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["ReportTitle"] = "Control Panel";
            ViewData["ReportAction"] = "ControlPanel";
            return View("Index");
        }

        public ActionResult UsersPreferences()
        {
            ViewData["ReportTitle"] = "Users - Preferences";
            ViewData["ReportAction"] = "Preferences";
            return View("Index");
        }

        public ActionResult UsersOverview()
        {
            ViewData["ReportTitle"] = "Users - Overview";
            ViewData["ReportAction"] = "UsersOverview";
            return View("Index");
        }

        public ActionResult UsersActivations()
        {
            ViewData["ReportTitle"] = "Users - Subscriptions vs Activations";
            ViewData["ReportAction"] = "UsersActivations";
            return View("Index");
        }

        public ActionResult MediaPerformance()
        {
            ViewData["ReportTitle"] = "Media Performance";
            ViewData["ReportAction"] = "MediaPerformance";
            return View("Index");
        }

        public ActionResult PlaylistPerformance()
        {
            ViewData["ReportTitle"] = "Playlist Performance";
            ViewData["ReportAction"] = "PlaylistPerformance";
            return View("Index");
        }

        public ActionResult PlaylistPositionPerformance()
        {
            ViewData["ReportTitle"] = "Position Performance";
            ViewData["ReportAction"] = "PlaylistPositionPerformance";
            return View("Index");

        }

        public ActionResult UseProfiles()
        {
            ViewData["ReportTitle"] = "Use Profile";
            ViewData["ReportAction"] = "UseProfiles";
            return View("Index");
        }
        public ActionResult UserBehaviour()
        {
            ViewData["ReportTitle"] = "User Behaviour";
            ViewData["ReportAction"] = "UserBehaviour";
            return View("Index");
        }

        public ActionResult UserRecurrence()
        {
            ViewData["ReportTitle"] = "Access Recurrence";
            ViewData["ReportAction"] = "UserRecurrence";
            return View("Index");
        }

        public ActionResult MediaEngagement()
        {
            ViewData["ReportTitle"] = "Media Engagement";
            ViewData["ReportAction"] = "MediaEngagement";
            return View("Index");
        }

    }
}
