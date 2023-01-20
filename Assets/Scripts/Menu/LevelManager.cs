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

    public TriggerMenu tM = null;
    public ShootBall sB = null;
    public SingleBallShot sBS = null;
    //public ActionBasedContinuousTurnProvider lSturn;
    //public ActionBasedContinuousMoveProvider lSmove;

    public Goal goalCheck = null;
    public Save saveCheck = null;

    public GameObject stText;
    public GameObject gkText;

    public GameObject shootingTutorial;
    public GameObject goalkeepingTutorial;

    void Start()
    {
        //Checking if which scene is active right now
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

        if (sceneName == "Euroborg - GK")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
        }

        gkText.SetActive(false);
        stText.SetActive(false);
    }

    void Update()
    {
        pbuttonRight.action.started += pButtonpressed;

        //Sets the tutorial screen up for a goalkeeping level
        if (isGoalkeepingLevel == true)
        {
            goalkeepingTutorial.SetActive(true);
            StartCoroutine(gkFlashText(3));
        }

        if (isGoalkeepingLevel == true && tutorialRead == true && gkText.activeInHierarchy == true)
        {
            goalkeepingTutorial.SetActive(false);
        }

        //Sets the tutorial screen up for a shooting level
        if (isShootingLevel == true)
        {
            shootingTutorial.SetActive(true);
            StartCoroutine(stFlashText(3));
        }
        
        if (isShootingLevel == true && tutorialRead == true && stText.activeInHierarchy == true)
        {
            shootingTutorial.SetActive(false);
        }

        //Disables the controls of the player while the tutorial screen is up
        if (goalkeepingTutorial.activeInHierarchy == true || shootingTutorial.activeInHierarchy == true)
        {
            tM.buttonEffected = false;
            if(shootingTutorial.activeInHierarchy == true && isShootingLevel == true)
            {
                sB.enabled = false;
            }
        }
        else if (goalkeepingTutorial.activeInHierarchy == false || shootingTutorial.activeInHierarchy == false)
        {
            if(shootingTutorial.activeInHierarchy == false && isShootingLevel == true)
            {
                sB.enabled = true;
            }
        }

        if (shootingTutorial.activeInHierarchy == false && isShootingLevel == true)
        {
            if (sB.isPressed == false && sB.powerMultiplier > 1f)
            {
                StartCoroutine(levelResult(3));
            }
        }

        if (goalkeepingTutorial.activeInHierarchy == false && isGoalkeepingLevel == true)
        {
            if (sBS.ballShot  == true)
            {
                StartCoroutine(levelResult(2));
            }
        }
    }

    //Making the flashing light show up after a few seconds
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

    //Shows the result
    IEnumerator levelResult(int secs)
    {
        yield return new WaitForSeconds(secs);
        if (isShootingLevel == true && goalCheck.goalScored == true)
        {
            Debug.Log("Scored");
        }
        
        if (isShootingLevel == true && goalCheck.goalScored == false)
        {
            Debug.Log("Missed chance");
        }
        
        if (isGoalkeepingLevel == true && Save.ballSaved == true)
        {
            Debug.Log("Saved");
        }
        
        if (isGoalkeepingLevel == true &&  goalCheck.goalScored == true)
        {
            Debug.Log("Scored against you");
        }

        if (isGoalkeepingLevel == true && Save.ballSaved == false && goalCheck.goalScored == false)
        {
            Debug.Log("Missed shot");
        }
        
    }

    //Part of the input system
    void pButtonpressed(InputAction.CallbackContext context)
    {
        if (gkText.activeInHierarchy == true || stText.activeInHierarchy == true)
        tutorialRead = true;
    }
}