// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.Framework.DependencyInjection.ServiceLookup
{
    internal class Service : IService
    {
        private readonly IServiceDescriptor _descriptor;

        public Service(IServiceDescriptor descriptor)
        {
            _descriptor = descriptor;
        }

        public IService Next { get; set; }

        public LifecycleKind Lifecycle
        {
            get { return _descriptor.Lifecycle; }
        }

        public object Create(ServiceProvider provider)
        {
            if (_descriptor.ImplementationInstance != null)
            {
                return _descriptor.ImplementationInstance;
            }
            else
            {
                var serviceFactory =
                    ActivatorUtilities.CreateFactory(_descriptor.ImplementationType);
                return serviceFactory(provider);
            }
        }
    }
}
