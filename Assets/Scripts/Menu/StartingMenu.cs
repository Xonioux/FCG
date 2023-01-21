using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenu : MonoBehaviour
{
    public void PlayCup1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayCup2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayCup3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayEuroborg1()
    {
        SceneManager.LoadScene(4);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
