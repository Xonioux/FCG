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

    public void PlayEuroborg2()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayEuroborg3()
    {
        SceneManager.LoadScene(6);
    }

    public void PlayInternational1()
    {
        SceneManager.LoadScene(7);
    }

    public void PlayInternational2()
    {
        SceneManager.LoadScene(8);
    }

    public void PlayInternational3()
    {
        SceneManager.LoadScene(9);
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
