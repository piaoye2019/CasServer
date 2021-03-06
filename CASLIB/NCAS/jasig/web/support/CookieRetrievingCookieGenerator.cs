using System;
using NCAS.jasig.web.MOCK2JAVA;
using System.Web;

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
//package org.jasig.cas.web.support;

//import javax.servlet.http.Cookie;
//import javax.servlet.http.HttpRequest;
//import javax.servlet.http.HttpResponse;

//import org.jasig.cas.authentication.principal.RememberMeCredentials;
//import org.springframework.util.StringUtils;
//import org.springframework.web.util.CookieGenerator;

/**
 * : CookieGenerator to allow you to retrieve a value from a request.
 * <p>
 * Also has support for RememberMe Services
 *  
 * @author Scott Battaglia
 * @version $Revision: 1.1 $ $Date: 2005/08/19 18:27:17 $
 * @since 3.1
 *
 */
namespace NCAS.jasig.web.support
{
    public class CookieRetrievingCookieGenerator : CookieGenerator
    {

        /** The maximum age the cookie should be remembered for.
     * The default is three months (7889231 in seconds, according to Google) */
        private int rememberMeMaxAge = 7889231;

        public void addCookie(HttpRequest request, HttpResponse response, string cookieValue)
        {

            //if (!StringUtils.hasText(request.getParameter(RememberMeCredentials.REQUEST_PARAMETER_REMEMBER_ME))) {
            //    super.addCookie(response, cookieValue);
            //} else {
            //     Cookie cookie = createCookie(cookieValue);
            //    cookie.setMaxAge(this.rememberMeMaxAge);
            //    if (isCookieSecure()) {
            //        cookie.setSecure(true);
            //    }
            //    response.addCookie(cookie);
            //}
        }

        public string retrieveCookieValue(HttpRequest request)
        {
            // Cookie cookie = org.springframework.web.util.WebUtils.getCookie(
            //    request, getCookieName());

            //return cookie == null ? null : cookie.getValue();

            return "";
        }

        public void setRememberMeMaxAge(int maxAge)
        {
            this.rememberMeMaxAge = maxAge;
        }

        internal void setCookiePath(string cookiePath)
        {
            throw new NotImplementedException();
        }
 
    }
}
