using System.Collections;
using System.Collections.Generic;
using Assets.Modules.SceneManagement;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Scenes/Config")]
public class SceneBaseServiceConfig : BaseServiceConfig<ISceneService>
{
    [SerializeField]
    public SceneLoader loaderPrefab;

    [SerializeField] 
    public bool testMode;
}


