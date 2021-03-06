/*
 * Licensed to Jasig under one or more contributor license
 * agreements. See the NOTICE file distributed with this work
 * for additional information regarding copyright ownership.
 * Jasig licenses this file to you under the Apache License,
 * Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License.  You may obtain a
 * copy of the License at the following location:
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
//package org.jasig.cas.web;

//import javax.servlet.http.HttpRequest;
//import javax.servlet.http.HttpResponse;
//import javax.validation.constraints.NotNull;

//import org.jasig.cas.CentralAuthenticationService;
//import org.jasig.cas.authentication.principal.SimpleWebApplicationServiceImpl;
//import org.jasig.cas.services.RegisteredService;
//import org.jasig.cas.services.ServicesManager;
//import org.jasig.cas.web.support.CookieRetrievingCookieGenerator;
//import org.springframework.web.servlet.ModelAndView;
//import org.springframework.web.servlet.mvc.AbstractController;
//import org.springframework.web.servlet.view.RedirectView;

/**
 * Controller to delete ticket granting ticket cookie in order to log out of
 * single sign on. This controller : the idea of the ESUP Portail's
 * Logout patch to allow for redirecting to a url on logout. It also exposes a
 * log out link to the view via the WebConstants.LOGOUT constant.
 * 
 * @author Scott Battaglia
 * @version $Revision$ $Date$
 * @since 3.0
 */

using System.Web;
using NCAS.jasig.authentication.principal;
using NCAS.jasig.services;
using NCAS.jasig.web.MOCK2JAVA;
using NCAS.jasig.web.support;

namespace NCAS.jasig.web
{
    public class LogoutController : AbstractController
    {

        /** The CORE to which we delegate for all CAS functionality. */
        ////@NotNull
        private CentralAuthenticationService centralAuthenticationService;

        /** CookieGenerator for TGT Cookie */
        ////@NotNull
        private CookieRetrievingCookieGenerator ticketGrantingTicketCookieGenerator;

        /** CookieGenerator for Warn Cookie */
        ////@NotNull
        private CookieRetrievingCookieGenerator warnCookieGenerator;

        /** Logout view name. */
        ////@NotNull
        private string logoutView;

        ////@NotNull
        private ServicesManager servicesManager;

        /**
     * bool to determine if we will redirect to any url provided in the
     * service request parameter.
     */
        private bool followServiceRedirects;

        public LogoutController()
        {
            this.setCacheSeconds(0);
        }

        protected ModelAndView handleRequestInternal(
            HttpRequest request, HttpResponse response)
        {
            string ticketGrantingTicketId = this.ticketGrantingTicketCookieGenerator.retrieveCookieValue(request);
            string service = request.QueryString[("service")];

            if (ticketGrantingTicketId != null)
            {
                this.centralAuthenticationService
                    .destroyTicketGrantingTicket(ticketGrantingTicketId);

                this.ticketGrantingTicketCookieGenerator.removeCookie(response);
                this.warnCookieGenerator.removeCookie(response);
            }

            if (this.followServiceRedirects && service != null)
            {
                RegisteredService rService = this.servicesManager.findServiceBy(new SimpleWebApplicationServiceImpl(service));

                if (rService != null && rService.isEnabled())
                {
                    return new ModelAndView(new RedirectView(service));
                }
            }

            return new ModelAndView(this.logoutView);
        }

        public void setTicketGrantingTicketCookieGenerator(
            CookieRetrievingCookieGenerator ticketGrantingTicketCookieGenerator)
        {
            this.ticketGrantingTicketCookieGenerator = ticketGrantingTicketCookieGenerator;
        }

        public void setWarnCookieGenerator(CookieRetrievingCookieGenerator warnCookieGenerator)
        {
            this.warnCookieGenerator = warnCookieGenerator;
        }

        /**
     * @param centralAuthenticationService The centralAuthenticationService to
     * set.
     */
        public void setCentralAuthenticationService(
            CentralAuthenticationService centralAuthenticationService)
        {
            this.centralAuthenticationService = centralAuthenticationService;
        }

        public void setFollowServiceRedirects(bool followServiceRedirects)
        {
            this.followServiceRedirects = followServiceRedirects;
        }

        public void setLogoutView(string logoutView)
        {
            this.logoutView = logoutView;
        }

        public void setServicesManager(ServicesManager servicesManager)
        {
            this.servicesManager = servicesManager;
        }
    }
}
