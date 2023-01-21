using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StartingMenuRules : MonoBehaviour
{
    public ContinuousMoveProviderBase cB = null;
    public bool isStartingScene;
    
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "StartingScene")
        {
            isStartingScene = true;
        }
        else if (sceneName != "StartingScene")
        {
            isStartingScene = false;
        }
    }

    void Update()
    {
        if (isStartingScene == true)
        {
            cB.enabled = true;
            Time.timeScale = 1f;
        }
    }
}
