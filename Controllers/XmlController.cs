using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXAnalytics.Models;
using System.Data;
using DXAnalytics.Base;

namespace DXAnalytics.Controllers
{
    public class XmlController : BaseController
    {
        //
        // GET: /DxAnalytics/Xml/

        #region Control Panel
        /// <summary>
        /// Retorna o resultado de estatísticas para o painel de controle
        /// </summary>
        /// <returns></returns>
        public ActionResult ControlPanelStatistics()
        {
            return View(ReportingData.ControlPanelStatistics());
        }

        /// <summary>
        /// Retorna o resultado total de visitas para o painel de controle
        /// </summary>
        /// <returns></returns>
        public ActionResult ControlPanelVisits()
        {
            return View(ReportingData.ControlPanelVisits());
        }
        #endregion Control Panel

        #region Preferences
        /// <summary>
        /// Retorna o resultado das preferencias (audio / legenda / qualidade) para exibição
        /// </summary>
        /// <returns></returns>
        public ActionResult AudioPreferences()
        {
            return View(ReportingData.Preferences(EReportingPreferences.Audio));
        }

        public ActionResult SubtitlePreferences()
        {
            return View(ReportingData.Preferences(EReportingPreferences.Subtitle));
        }

        public ActionResult QualityPreferences()
        {
            return View(ReportingData.Preferences(EReportingPreferences.Quality));
        }
        #endregion Preferences

        public ActionResult UsersSubscriptions()
        {
            DataSet dsUserSubs = ReportingData.UsersSubscriptions();
            return View(dsUserSubs);
        }

        public ActionResult UserAudience()
        {
            return View(ReportingData.UserAudience());

        }

        public ActionResult SessionTimming()
        {
            return View(ReportingData.SessionTimming());
        }

        public ActionResult LastLogin(string orientation)
        {
            ViewData["orientation"] = orientation;
            return View(ReportingData.LastLogin());
        }




        public ActionResult ProfilesPerUser()
        {
            DataSet dsProPerUser = ReportingData.ProfilesPerUser();
            return View(dsProPerUser);
        }

        public ActionResult ActivatedKeys()
        {
            DataSet dsActKeys = ReportingData.ActivatedKeys();
            return View(dsActKeys);
        }

        public ActionResult MediaPerformance()
        {
            return View(ReportingData.MediaPerformance());
        }


        public ActionResult MediaPerformanceAnalytic()
        {
            return View(ReportingData.MediaPerformanceAnalytic());
        }

        public ActionResult PlaylistPerformanceAnalytic()
        {
            return View(ReportingData.PlaylistPerformanceAnalytic());

        }


        public ActionResult PlaylistPositionPerformanceAnalytic()
        {
            return View(ReportingData.PlaylistPositionPerformanceAnalytic());

        }


        public ActionResult ProfilesAge()
        {
            return View(ReportingData.ProfilesAge());
        }


        public ActionResult ProfilesGender()
        {
            return View(ReportingData.ProfilesGender());
        }

        public ActionResult ProfilesActivity()
        {
            return View(ReportingData.ProfilesActivity());
        }


        public ActionResult LogoutInterval()
        {
            return View(ReportingData.LogoutInterval());
        }
        public ActionResult UserBehaviour(int id)
        {
            return View(ReportingData.UserBehaviour(id));
        }



    }
}
