using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public InputActionReference pbuttonRight = null;
    public bool isShootingLevel;
    public bool isGoalkeepingLevel;

    public bool tutorialRead;

    public GameObject stText;
    public GameObject gkText;

    public GameObject shootingTutorial;
    public GameObject goalkeepingTutorial;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Cup - GK")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
        }

        if (sceneName == "Cup - Shot1")
        {
            isShootingLevel = true;
            isGoalkeepingLevel = false;
        }

        if (sceneName == "Cup - Shot2")
        {
            isShootingLevel = true;
            isGoalkeepingLevel = false;
        }

        gkText.SetActive(false);
        stText.SetActive(false);
    }

    void Update()
    {
        pbuttonRight.action.started += pButtonpressed;
        if (isGoalkeepingLevel == true)
        {
            goalkeepingTutorial.SetActive(true);
            StartCoroutine(gkFlashText(3));
        }

        if (isGoalkeepingLevel == true && tutorialRead == true && gkText.activeInHierarchy == true)
        {
            goalkeepingTutorial.SetActive(false);
        }

        if (isShootingLevel == true)
        {
            shootingTutorial.SetActive(true);
            StartCoroutine(stFlashText(3));
        }
        else if (isShootingLevel == true && tutorialRead == true && stText.activeInHierarchy == true)
        {
            shootingTutorial.SetActive(false);
        }


    }


    IEnumerator gkFlashText(int secs)
    {
        yield return new WaitForSeconds(secs);
        gkText.SetActive(true);
    }

    IEnumerator stFlashText(int secs)
    {
        yield return new WaitForSeconds(secs);
        stText.SetActive(true);
    }

    void pButtonpressed(InputAction.CallbackContext context)
    {
        if (gkText.activeInHierarchy == true || stText.activeInHierarchy == true)
        tutorialRead = true;
    }
}
