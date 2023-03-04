using System.Collections;
using Assets.Modules.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        private AsyncOperation loadOperation;
        private AsyncOperation unloadOperation;
        
        [SerializeField]
        private float exitWait;

        [SerializeField]
        private float entryWait;
        
        [SerializeField]
        private float loadingWait;

        [SerializeField] 
        private LoadProgressUpdater progressUpdater;
        
        [SerializeField]
        UnityEvent<float> onLoadEntry;

        [SerializeField]
        UnityEvent<float> onLoadExit;

        private bool testMode = false;
        
        public void StartLoading(string scenePath, bool testMode = false)
        {
            this.testMode = testMode;
            
            if (string.IsNullOrEmpty(scenePath))
            {
                throw new System.Exception("Scene Path was not set!");
            }
            
            DontDestroyOnLoad(this);
         
            Time.timeScale = 0;

            StartCoroutine(LoaderUpdate(scenePath));
        }

        private IEnumerator LoaderUpdate(string scenePath)
        {
            LoadEntry();
            
            if(entryWait > 0)
                yield return new WaitForSecondsRealtime(entryWait);

            if (testMode)
                loadOperation = EditorSceneManager.LoadSceneAsyncInPlayMode(scenePath, new LoadSceneParameters(LoadSceneMode.Single));
            else
                loadOperation = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
            
            loadOperation.allowSceneActivation = false;
            
            if(progressUpdater != null)
                progressUpdater.ShowLoadProgress(loadOperation);

            if(loadingWait > 0)
                yield return new WaitForSecondsRealtime(entryWait);
            
            while (loadOperation.progress < 0.9f)
            {
                yield return null;
            }
        
            loadOperation.allowSceneActivation = true;

            while (!loadOperation.isDone)
            {
                yield return null;
            }

            var newScene = SceneManager.GetSceneByPath(scenePath);
            SceneManager.SetActiveScene(newScene);
        
            Time.timeScale = 1;

            LoadExit();
            
            if (exitWait > 0)
                yield return new WaitForSecondsRealtime(exitWait);
        
            Destroy(this.gameObject);
        }

       

        protected virtual void LoadEntry() 
        {
            onLoadEntry?.Invoke(entryWait);
        }
        protected virtual void LoadExit() 
        {
            onLoadExit?.Invoke(exitWait);
        }
    }

