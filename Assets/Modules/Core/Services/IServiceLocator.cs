public interface IServiceLocator
{
    /// <summary>
    /// Retrieves an implementation of service T.
    /// If no implementation is found, it should return a dummy service only containing stubs that do nothing
    /// The existence of a dummy service is not yet enforced
    /// </summary>
    /// <typeparam name="T">The Service Type</typeparam>
    /// <returns>An implementation of the given service</returns>
    public T GetService<T>() where T : IGameService;

    /// <summary>
    /// Registers the given service for the given service type.
    /// </summary>
    /// <param name="service">The service to register</param>
    /// <param name="overwrite">if true, it will remove already registered services of the same kind</param>
    /// <typeparam name="T">The service interface type</typeparam>
    /// <returns>Returns true if there was already a service registered</returns>
    public bool RegisterService<T>(IGameService service, bool overwrite = true) where T : IGameService;

    /// <summary>
    /// Registers a dummy service for the given service type
    /// </summary>
    /// <param name="service">The dummy service to register</param>
    /// <typeparam name="T">The service interface type</typeparam>
    /// <returns></returns>
    public bool RegisterDummyService<T>(IGameService service) where T : IGameService;
    
    /// <summary>
    /// Removes the given service from the service registry
    /// </summary>
    /// <typeparam name="T">The service interface type</typeparam>
    /// <param name="service">The service to unregister</param>
    /// <returns>true if the service was found and unregistered, false if no fitting service of Type T was found</returns>
    public bool UnregisterService<T>(IGameService service) where T : IGameService;

    /// <summary>
    /// Returns if a service of the given type exists
    /// </summary>
    /// <typeparam name="T">The service interface type</typeparam>
    /// <returns>true if service of type T exists</returns>
    public bool ServiceExists<T>();
}