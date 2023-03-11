using Assets.Modules.SceneManagement;
using Modules.AudioSystem.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Core.ServiceLocator
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initiailze()
        {
            // Initialize default service locator.
            ServiceLocator.Initialize();

            Game.Services.RegisterDummyService<IAudioService>(new DummyAudioService());
            Game.Services.RegisterDummyService<IDialogService>(new DummyDialogService());
            Game.Services.RegisterDummyService<ISceneService>(new DummySceneService());
            Game.Services.RegisterDummyService<IGlobalTimerService>(new DummyGlobalTimerService());
        }
    }
}