using UnityEngine;

namespace Modules.Core.ServiceLocator
{
    public class BaseService<T> : MonoBehaviour, IGameService where T : IGameService
    {
        public void Awake()
        {
            // Destroy this service, if one already exists
            if (Game.Services.ServiceExists<T>())
            {
                Destroy(this.gameObject);
                return;
            }
            
            DontDestroyOnLoad(this);
        }
    
        public void OnEnable()
        {
            if(Game.Services.RegisterService<T>(this))
            {
                Debug.LogError("There already is a scene service registered!");
            }
        }

        public void OnDisable()
        {
            Game.Services.UnregisterService<T>(this);
        }
    }
}