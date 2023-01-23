using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StartingMenuRules : MonoBehaviour
{
    public ContinuousMoveProviderBase cB = null;
    public GameObject pS = null;
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
            //SOUNNNNNNNNNNNNNND//
          //  FindObjectOfType<AudioManager>().Play("Anthem");
            //SOUNDDDDDDDDDDDDDDD//

            cB.moveSpeed = 5f;
            Time.timeScale = 1f;
            pS.SetActive(false);
        }
    }
}
