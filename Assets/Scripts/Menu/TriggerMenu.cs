using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TriggerMenu : MonoBehaviour
{
    public InputActionReference triggerMenuOpen = null;
    public InputActionReference triggerMenuClosed = null;
    public GameObject playerMenu;
    public bool buttonEffected;
    bool menuClose;

    string sceneName;

    void Start()
    {
        playerMenu.SetActive(false);
        buttonEffected = true;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        triggerMenuOpen.action.started += MBOpen;
        triggerMenuClosed.action.started += MBClose;
        if (buttonEffected == false && sceneName != "StartingScene")
        {
            playerMenu.SetActive(true);
        }
        else if (buttonEffected == true && sceneName != "StartingScene")
        {
            playerMenu.SetActive(false);
        }
    }

    void MBOpen(InputAction.CallbackContext context)
    {
        buttonEffected = false;
    }

    void MBClose(InputAction.CallbackContext context)
    {
        buttonEffected = true;
    }
}
