using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MibClient2.Config;

namespace DXAnalytics
{
    public class Config<T> : MibConfig where T : class
    {
        static T _instance;
        public static T Current
        {
            get { return _instance ?? (_instance = Activator.CreateInstance(typeof(T), true) as T); }
        }
        protected Config(string filename, string section) : base(filename, section) { }
        protected Config(string section) : base("GeneralConfig.xml", section) { }
    }

    public class GeneralConfig : Config<GeneralConfig> 
    {
        private GeneralConfig() : base("default") { }
        public string GeneralMD5Key { get { return this.GetString("generalMD5Key"); } }
    }
}