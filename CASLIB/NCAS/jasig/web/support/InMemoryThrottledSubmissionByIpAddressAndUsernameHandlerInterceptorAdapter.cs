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

//import javax.servlet.http.HttpRequest;

/**
 * Attempts to throttle by both IP Address and username.  Protects against instances where there is a NAT, such as
 * a local campus wireless network.
 *
 * @author Scott Battaglia
 * @version $Revision$ $Date$
 * @since 3.3.5
 */

using System;
using System.Web;
using NCAS.jasig.web.MOCK2JAVA;

namespace NCAS.jasig.web.support
{
    public class InMemoryThrottledSubmissionByIpAddressAndUsernameHandlerInterceptorAdapter : AbstractInMemoryThrottledSubmissionHandlerInterceptorAdapter
    {

        //@Override
        protected override string constructKey(HttpRequest request)
        {
            string username = request.getParameter(this.getUsernameParameter());

            if (username == null)
            {
                return request.getRemoteAddr();
            }

            return request.getRemoteAddr() + ";" + username.ToLower();
        }
    }
}
