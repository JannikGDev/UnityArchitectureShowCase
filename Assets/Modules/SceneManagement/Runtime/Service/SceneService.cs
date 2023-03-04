using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.Core.ServiceLocator;
using UnityEngine;

namespace Assets.Modules.SceneManagement
{
    public class SceneService : BaseService<ISceneService>, ISceneService
    {
        [SerializeField]
        private SceneBaseServiceConfig config;

        public void ChangeSceneTo(string scenePath)
        {
            var Loader = GameObject.Instantiate(config.loaderPrefab, new Vector3(0, 0, 100), Quaternion.identity);
            Loader.StartLoading(scenePath, config.testMode);
        }
    }
}
