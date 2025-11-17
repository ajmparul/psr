using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSR
{
    public static class GlobalCommon
    {
        //////----------------Stagging-----------------------/////
        /// <summary>
        /// Added new link URL for the stagging server for the redirection on the local machine by AQ on 13-12-23
        /// </summary>
        //public static string ProjectInitial = "/dsap"; // For Localhost
        public static string APIUrl = "http://172.22.33.22/PSR/";

        public static string SsoUrl = "https://ssotest.rajasthan.gov.in:4443/SSOREST/GetUserDetailJSON";
        public static string SsoTokenUrl = "https://ssotest.rajasthan.gov.in:4443/SSOREST/GetTokenDetailJSON";
        public static string SSOSignoutUrl = "https://ssotest.rajasthan.gov.in/signout";
        public static string BackToSSOUrl = "https://ssotest.rajasthan.gov.in/sso";
        public static string SsoPass = "IDENTIFIEDBLOCK.TEST";
        public static string UserName = "@IDENTIFIEDBLOCK@test#123";
    }
}