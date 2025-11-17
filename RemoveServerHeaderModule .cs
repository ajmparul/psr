using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSR
{
    public class RemoveServerHeaderModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(OnEndRequest);
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
        }

        public void Dispose() { }
    }
}