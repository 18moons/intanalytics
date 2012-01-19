using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MibClient2.Web.Mvc;
using DXAnalytics.Models.ReportingViewData;
using System.Data;
using DXAnalytics.Models;
using DXAnalytics.Base;

namespace DXAnalytics.Controllers
{
    public class ReportingController : BaseController
    {
        //
        // GET: /Reporting/

        /// <summary>
        /// ActionResult para exibir as Estatísticas Painel de Controle
        /// </summary>
        /// <returns></returns>
        public ActionResult ControlPanel()
        {
            //ViewData["ControlPanelStatistics"] = ReportingData.ControlPanelStatistics();
            return View();
        }

        /// <summary>
        /// ActionResult para exibir as Preferências do Perfil do Usuário
        /// </summary>
        /// <returns></returns>
        public ActionResult Preferences()
        {
            return View();
        }

        public ActionResult VisitorsOverview()
        {
            return View();
        }

        public ActionResult UsersActivations()
        {
            return View();
        }

        public ActionResult UsersOverview()
        {
            return View();
        }

        public ActionResult MediaPerformance()
        {
            return View(); 
        }
        public ActionResult PlaylistPerformance()
        {
            return View();
        }

        public ActionResult PlaylistPositionPerformance()
        {
            return View();
        }

        public ActionResult UseProfiles()
        {
            return View();
        }


        public ActionResult UserRecurrence()
        {
            return View();
        }

        public ActionResult UserBehaviour()
        {
            ViewData["ElegibleUsers"] = ReportingData.UserBehaviourUsers();
            return View();
        }

        public ActionResult MediaEngagement()
        {
            return View();
        }
    }
}
