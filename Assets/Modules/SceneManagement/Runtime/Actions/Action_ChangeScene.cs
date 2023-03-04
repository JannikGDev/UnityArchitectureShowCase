using Assets.Modules.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Modules.SceneManagement
{
    [RequireComponent(typeof(ScenePicker))]
    public class Action_ChangeScene : BaseAction
    {
        public override void X_PerformAction()
        {
            var sceneService = Game.Services.GetService<ISceneService>();
            var path = this.GetComponent<ScenePicker>().scenePath;
       
            sceneService.ChangeSceneTo(path); 
        }
    }
}


