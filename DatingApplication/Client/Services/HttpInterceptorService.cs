using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Toolbelt.Blazor;

namespace DatingApplication.Client.Services
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor interceptor;
        private readonly NavigationManager navManager;
        
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            this.interceptor = interceptor;
            this.navManager = navManager;
        }
        public void MonitorEvent() => interceptor.AfterSend += InterceptorResponse;

        private void InterceptorResponse(object? sender, HttpClientInterceptorEventArgs e)
        {
            //throw new NotImplementedException();
            string message = string.Empty;
            if (!e.Response.IsSuccessStatusCode) 
            {
                var responseCode = e.Response.StatusCode;
                switch(responseCode)
                {
                    case HttpStatusCode.NotFound:
                        navManager.NavigateTo("/404");
                        message = "The requested resource was not found ";
                        break;
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        navManager.NavigateTo("/unauthorized");
                        message = "You are not authorized to access this resource. ";
                        break;
                    default:
                        navManager.NavigateTo("/500");
                        message = "Something went wrong. please contact Administrator";
                        break;
                }
            }
        }
        public void DisposeEvent() => interceptor.AfterSend -= InterceptorResponse;
    }
}
