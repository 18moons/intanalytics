using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using DXAnalytics.Base;
using MibClient2.Web.Mvc;
using DXAnalytics.Models.ReportingViewData;

namespace DXAnalytics.Views.Shared
{
    public partial class Site : ViewMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var load = new DefaultLoads();
            load.LoadCss(this.MibCssCompressor.CssCompressor).AddUrl("/DxAnalytics/Content/Styles/master.css", true);
            load.LoadJavascript(this.MibJsCompressor);
        }
    }
}