using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DXAnalytics.Models;
using System.Web.Mvc;
using MibClient2.Web;
using System.Collections;

namespace DXAnalytics.Base
{
    /// <summary>
    /// Classe de autenticação  
    /// </summary>
    public class Authenticator
    {
        /// <summary>
        /// Propriedade do usuário atual
        /// </summary>
        public static Authenticator Current
        {
            get 
            {
                var instance = (Authenticator)HttpContext.Current.Session["AUTH"];
                if(instance == null)
                {
                    instance = new Authenticator();
                    HttpContext.Current.Session["AUTH"] = instance;
                }
                return instance;
            }
        }

        /// <summary>
        /// Retorna a Model do usuário administrador
        /// </summary>
        public AdmUser CurrentUser;

        /// <summary>
        /// Valida os dados de acesso do usuário
        /// </summary>
        /// <param name="username">nome do usuario</param>
        /// <param name="password">senha do usuario</param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            this.CurrentUser = AdmUser.UserLogin(username, password);
            SaveCookie();
            return (CurrentUser.ID != 0);
        }

        /// <summary>
        /// Verifica se usuário está logado
        /// </summary>
        public bool IsLogged
        {
            get
            {
                if (CurrentUser != null) return (CurrentUser.ID != 0);
                    return false;
            }
        }

        /// <summary>
        /// Efetua o Logout do usuário
        /// </summary>
        public void Loggof()
        {
            this.CurrentUser = null;
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }

        /// <summary>
        /// Salva o cookie com as informações padrões para pesquisa
        /// </summary>
        private void SaveCookie()
        {
            var cookie = new HttpCookie("userData");
            cookie["filter"] = "0";
            cookie["start"] = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
            cookie["finish"] = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            cookie.Path = "/DxAnalytics";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }

    /// <summary>
    /// Executa filtro de Autenticação
    /// </summary>
    public class AuthenticationRequiredAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Authenticator.Current.IsLogged)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("~/Account/Login");
            }
        }
    }
}