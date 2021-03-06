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
//package org.jasig.cas.services;

//import java.util.*;
//import java.util.concurrent.ConcurrentHashMap;

//import com.github.inspektr.audit.annotation.Audit;
//import org.jasig.cas.authentication.principal.Service;
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import org.springframework.transaction.annotation.Transactional;

//import javax.validation.constraints.NotNull;

/**
 * Default implementation of the {@link ServicesManager} interface. If there are
 * no services registered with the server, it considers the ServicecsManager
 * disabled and will not prevent any service from using CAS.
 * 
 * @author Scott Battaglia
 * @version $Revision$ $Date$
 * @since 3.1
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NCAS.jasig.authentication.principal;

namespace NCAS.jasig.services
{
    public class DefaultServicesManagerImpl : ReloadableServicesManager
    {

        //private  Logger log = LoggerFactory.getLogger(getClass());

        /** Instance of ServiceRegistryDao. */
        ////@NotNull
        private ServiceRegistryDao serviceRegistryDao;

        /** Map to store all services. */
        private ConcurrentDictionary<long, RegisteredService> services = new ConcurrentDictionary<long, RegisteredService>();

        /** Default service to return if none have been registered. */
        private RegisteredService disabledRegisteredService;

        public DefaultServicesManagerImpl(
            ServiceRegistryDao serviceRegistryDao)
            : this(serviceRegistryDao, new List<string>())
        {
            ;
        }

        /**
     * Constructs an instance of the {@link DefaultServicesManagerImpl} where the default RegisteredService
     * can include a set of default attributes to use if no services are defined in the registry.
     * 
     * @param serviceRegistryDao the Service Registry Dao.
     * @param defaultAttributes the list of default attributes to use.
     */
        public DefaultServicesManagerImpl(ServiceRegistryDao serviceRegistryDao, List<string> defaultAttributes)
        {
            this.serviceRegistryDao = serviceRegistryDao;
            this.disabledRegisteredService = this.constructDefaultRegisteredService(defaultAttributes);

            this.load();
        }

        //@Transactional(readOnly = false)
        //@Audit(action = "DELETE_SERVICE", actionResolverName = "DELETE_SERVICE_ACTION_RESOLVER", resourceResolverName = "DELETE_SERVICE_RESOURCE_RESOLVER")
        public RegisteredService delete(long id)
        {
            RegisteredService r = this.findServiceBy(id);
            if (r == null)
            {
                return null;
            }

            this.serviceRegistryDao.delete(r);
            RegisteredService value;
            this.services.TryRemove(id, out value);

            return r;
        }

        /**
     * Note, if the repository is empty, this implementation will return a default service to grant all access.
     * <p>
     * This preserves default CAS behavior.
     */
        public RegisteredService findServiceBy(Service service)
        {
            List<RegisteredService> c = this.convertToTreeSet();

            if (c.Count == 0)
            {
                return this.disabledRegisteredService;
            }

            foreach (RegisteredService r in c)
            {
                if (r.matches(service))
                {
                    return r;
                }
            }

            return null;
        }

        public RegisteredService findServiceBy(long id)
        {
            RegisteredService r;

            var isgeted = this.services.TryGetValue(id, out r);



            try
            {
                return r == null ? null : (RegisteredService)r.Clone();
            }
            catch (System.NotSupportedException e)
            {
                return r;
            }
        }

        protected List<RegisteredService> convertToTreeSet()
        {
            return this.services.Values.OrderBy(x => x.getId()).ToList();
        }

        public Collection<RegisteredService> getAllServices()
        {
            return new Collection<RegisteredService>(this.convertToTreeSet());
        }

        public bool matchesExistingService(Service service)
        {
            return this.findServiceBy(service) != null;
        }

        //@Transactional(readOnly = false)
        //@Audit(action = "SAVE_SERVICE", actionResolverName = "SAVE_SERVICE_ACTION_RESOLVER", resourceResolverName = "SAVE_SERVICE_RESOURCE_RESOLVER")
        public RegisteredService save(RegisteredService registeredService)
        {
            RegisteredService r = this.serviceRegistryDao.save(registeredService);
            this.services.TryAdd(r.getId(), r);
            return r;
        }

        public void reload()
        {
            //log.info("Reloading registered services.");
            this.load();
        }

        private void load()
        {
            ConcurrentDictionary<long, RegisteredService> localServices = new ConcurrentDictionary<long, RegisteredService>();

            foreach (RegisteredService r in this.serviceRegistryDao.load())
            {
                //log.debug("Adding registered service " + r.getServiceId());
                localServices.TryAdd(r.getId(), r);
            }

            this.services = localServices;
            //log.info(string.format("Loaded %s services.", this.services.size()));
        }

        private RegisteredService constructDefaultRegisteredService(List<string> attributes)
        {
            RegisteredServiceImpl r = new RegisteredServiceImpl();
            r.setAllowedToProxy(true);
            r.setAnonymousAccess(false);
            r.setEnabled(true);
            r.setSsoEnabled(true);
            r.setAllowedAttributes(attributes);

            if (attributes == null || attributes.Count == 0)
            {
                r.setIgnoreAttributes(true);
            }

            return r;
        }
    }
}
