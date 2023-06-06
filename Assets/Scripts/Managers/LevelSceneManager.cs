using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public void SceneLoader(string p_sceneNew)    
    {
        SceneManager.LoadScene(p_sceneNew);
    }
}
