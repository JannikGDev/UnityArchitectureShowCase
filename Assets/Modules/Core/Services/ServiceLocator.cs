using System;
using System.Collections.Generic;

namespace Modules.Core.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        public static void Initialize()
        {
            Game.Services = new ServiceLocator();
        }
        
        private readonly Dictionary<Type, IGameService> serviceRegistry = new Dictionary<Type, IGameService>();
        private readonly Dictionary<Type, IGameService> dummyServiceRegistry = new Dictionary<Type, IGameService>();

        
        
        public T GetService<T>() where T : IGameService
        {
            var key = typeof(T);
            if (!serviceRegistry.ContainsKey(key))
                return (T)dummyServiceRegistry[key];

            return (T)serviceRegistry[key];
        }

        public bool RegisterService<T>(IGameService service, bool overwrite = true) where T : IGameService
        {
            var key = typeof(T);
            var serviceAlreadyPresent = serviceRegistry.ContainsKey(key);

            if(overwrite || !serviceAlreadyPresent)
                serviceRegistry[key] = service;

            return serviceAlreadyPresent;
        }
        
        public bool RegisterDummyService<T>(IGameService service) where T : IGameService
        {
            var key = typeof(T);
            var serviceAlreadyPresent = dummyServiceRegistry.ContainsKey(key);

            if(!serviceAlreadyPresent)
                dummyServiceRegistry[key] = service;

            return serviceAlreadyPresent;
        }

        public bool UnregisterService<T>(IGameService service) where T : IGameService
        {
            var key = typeof(T);
            if (!serviceRegistry.ContainsKey(key))
                return false;

            if (!serviceRegistry[key].Equals(service))
                return false;

            return serviceRegistry.Remove(key);
        }

        public bool ServiceExists<T>()
        {
            var key = typeof(T);
            return serviceRegistry.ContainsKey(key);
        }
    }
}