namespace Assets.Modules.SceneManagement
{
    public interface ISceneService : IGameService
    {
        public void ChangeSceneTo(string scenePath);
    }
    
    public class DummySceneService : ISceneService
    {
        public void ChangeSceneTo(string scenePath)
        {
            
        }
    }
}