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
//package org.jasig.cas.authentication.handler.support;

//import org.jasig.cas.authentication.principal.UsernamePasswordCredentials;
//import org.springframework.util.StringUtils;

/**
 * Simple test implementation of a AuthenticationHandler that returns true if
 * the username and password match. This class should never be enabled in a
 * production environment and is only designed to facilitate unit testing and
 * load testing.
 * 
 * @author Scott Battaglia
 * @version $Revision$ $Date$
 * @since 3.0
 */

using NCAS.jasig.authentication.principal;
using NCAS.jasig.web.MOCK2JAVA;

namespace NCAS.jasig.authentication.handler.support
{
    public class SimpleTestUsernamePasswordAuthenticationHandler :
        AbstractUsernamePasswordAuthenticationHandler
    {

        public SimpleTestUsernamePasswordAuthenticationHandler()
        {
            //log
            //    .warn(this.getClass().getName()
            //        + " is only to be used in a testing environment.  NEVER enable this in a production environment.");
        }

        protected override bool authenticateUsernamePasswordInternal(UsernamePasswordCredentials credentials)
        {
            string username = credentials.getUsername();
            string password = credentials.getPassword();

            if (StringUtils.hasText(username) && StringUtils.hasText(password)
                && username.Equals(this.getPasswordEncoder().encode(password)))
            {
                //log
                //    .debug("User [" + username
                //        + "] was successfully authenticated.");
                return true;
            }

            //log.debug("User [" + username + "] failed authentication");

            return false;
        }
    }
}
