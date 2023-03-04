using System;
using System.Collections.Generic;
using Modules.Core.ServiceLocator;
using UnityEngine;

public static class Game
{
    /// <summary>
    /// Singleton static reference to the service locator, use this to retrieve any kind of service
    /// </summary>
    public static IServiceLocator Services;
}