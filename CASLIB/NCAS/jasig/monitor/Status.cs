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
//package org.jasig.cas.monitor;

/**
 * Describes a generic status condition.
 *
 * @author Marvin S. Addison
 * @since 3.5.0
 */
namespace NCAS.jasig.monitor
{
    public class Status
    {

        /** Generic UNKNOWN status. */
        public static Status UNKNOWN = new Status(StatusCode.UNKNOWN);

        /** Generic OK status. */
        public static Status OK = new Status(StatusCode.OK);

        /** Generic INFO status. */
        public static Status INFO = new Status(StatusCode.INFO);

        /** Generic WARN status. */
        public static Status WARN = new Status(StatusCode.WARN);

        /** Generic ERROR status. */
        public static Status ERROR = new Status(StatusCode.ERROR);

        /** Status code. */
        private StatusCode code;

        /** Human-readable status description. */
        private string description;


        /**
     * Creates a new status object with the given code.
     *
     * @param code Status code.
     *
     * @see #getCode()
     */
        public Status(StatusCode code)
            : this(code, null)
        {
            ;
        }


        /**
     * Creates a new status object with the given code.
     *
     * @param code Status code.
     * @param desc Human-readable status description.
     *
     * @see #getCode()
     */
        public Status(StatusCode code, string desc)
        {
            this.code = code;
            this.description = desc;
        }

        /**
     * Gets the status code.
     *
     * @return Status code.
     */
        public StatusCode getCode()
        {
            return this.code;
        }


        /**
     * @return Human-readable description of status.
     */
        public string getDescription()
        {
            return this.description;
        }
    }
}