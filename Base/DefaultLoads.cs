using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibCompressor;
using MibClient2.Web.Components;

namespace DXAnalytics.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultLoads
    {
        /// <summary>
        /// 
        /// </summary>
        public DefaultLoads()
        {
            this.LoadCssList();
        }

        /// <summary>
        /// 
        /// </summary>
        private List<string> CssToLoad = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        protected void LoadCssList()
        {
            this.CssToLoad.Add("/DxAnalytics/Content/Styles/commons.css");
            this.CssToLoad.Add("/DxAnalytics/Content/Styles/jquery-ui-1.8.9.custom.css");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cssCompressor"></param>
        public void LoadCss(MibClient2.Web.Components.MibCssCompressor cssCompressor)
        {
            foreach (string urlToAdd in this.CssToLoad)
            {
                cssCompressor.CssCompressor.AddUrl(urlToAdd,true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compressor"></param>
        /// <returns></returns>
        public CssCompressor LoadCss(CssCompressor compressor)
        {
            foreach (string urlToAdd in this.CssToLoad)
            {
                compressor.AddUrl(urlToAdd);
            }
            return compressor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsCompressor"></param>
        public void LoadJavascript(MibJsCompressor jsCompressor)
        {
            jsCompressor.JsCompressor.AddUrl("/DxAnalytics/Content/Scripts/jquery-1.4.4.min.js", true);
            jsCompressor.JsCompressor.AddUrl("/DxAnalytics/Content/Scripts/jquery-ui-1.8.9.custom.min.js", true);
            jsCompressor.JsCompressor.AddUrl("/DxAnalytics/Content/Scripts/swfobject.js", true);
            jsCompressor.JsCompressor.AddUrl("/DxAnalytics/Content/Scripts/commons.js", true);
        }
    }
}