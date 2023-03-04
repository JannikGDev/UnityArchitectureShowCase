namespace Assets.Modules.SceneManagement
{
    public interface ISceneService : IGameService
    {
        public void ChangeSceneTo(string scenePath);
    }
}