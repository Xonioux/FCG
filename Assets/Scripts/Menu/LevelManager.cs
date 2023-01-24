using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class LevelManager : MonoBehaviour
{
    public InputActionReference pbuttonRight = null;
    public bool isShootingLevel;
    public bool isGoalkeepingLevel;
    public bool tutorialRead;

    public VideoPlayer knvbVP;
    public VideoPlayer euroborgVP;
    public VideoPlayer internationalVP;

    public VideoClip knvb1;
    public VideoClip knvb2;
    public VideoClip knvb3;

    public VideoClip euroborg1;
    public VideoClip euroborg2;
    public VideoClip euroborg3;

    public VideoClip international1;
    public VideoClip international2;
    public VideoClip international3;
    
    public TriggerMenu tM = null;
    public ShootBall sB = null;
    public SingleBallShot sBS = null;
    public ContinuousMoveProviderBase cB = null;
    public Goal goalCheck = null;
    public Save saveCheck = null;
    public CountdownTimer timer;

    public GameObject pS = null;
    public GameObject stText;
    public GameObject gkText;


    public GameObject shootingTutorial;
    public GameObject goalkeepingTutorial;

    public GameObject GKSave;
    public GameObject GKFail;
    public GameObject STScore;
    public GameObject STMiss;

    string sceneName;

    void Start()
    {
        //Checking if which scene is active right now
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Cup - GK")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
            knvbVP.enabled = true;
            euroborgVP.enabled = false;
            internationalVP.enabled = false;
            knvbVP.clip = knvb1;
            knvbVP.isLooping = true;
        }

        if (sceneName == "Cup - Shot1")
        {
            isShootingLevel = true;
            isGoalkeepingLevel = false;
            knvbVP.enabled = true;
            euroborgVP.enabled = false;
            internationalVP.enabled = false;
            knvbVP.clip = knvb2;
            knvbVP.isLooping = true;
        }

        if (sceneName == "Cup - Shot2")
        {
            isShootingLevel = true;
            isGoalkeepingLevel = false;
            knvbVP.enabled = true;
            euroborgVP.enabled = false;
            internationalVP.enabled = false;
            knvbVP.clip = knvb3;
            knvbVP.isLooping = true;
        }

        if (sceneName == "Euroborg - GK1")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
            knvbVP.enabled = false;
            euroborgVP.enabled = true;
            internationalVP.enabled = false;
            euroborgVP.clip = euroborg1;
            euroborgVP.isLooping = true;
        }

        if (sceneName == "Euroborg - Shot")
        {
            isGoalkeepingLevel = false;
            isShootingLevel = true;
            knvbVP.enabled = false;
            euroborgVP.enabled = true;
            internationalVP.enabled = false;
            euroborgVP.clip = euroborg2;
            euroborgVP.isLooping = true;
        }

        if (sceneName == "Euroborg - GK2")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
            knvbVP.enabled = false;
            euroborgVP.enabled = true;
            internationalVP.enabled = false;
            euroborgVP.clip = euroborg3;
            euroborgVP.isLooping = true;
        }

        if (sceneName == "International - GK")
        {
            isGoalkeepingLevel = true;
            isShootingLevel = false;
            knvbVP.enabled = false;
            euroborgVP.enabled = false;
            internationalVP.enabled = true;
            internationalVP.clip = international1;
            internationalVP.isLooping = true;
        }

        if (sceneName == "International - Shot")
        {
            isGoalkeepingLevel = false;
            isShootingLevel = true;
            knvbVP.enabled = false;
            euroborgVP.enabled = false;
            internationalVP.enabled = true;
            internationalVP.clip = international2;
            internationalVP.isLooping = true;
        }

        if (sceneName == "International - Penalty")
        {
            isGoalkeepingLevel = false;
            isShootingLevel = true;
            knvbVP.enabled = false;
            euroborgVP.enabled = false;
            internationalVP.enabled = true;
            internationalVP.clip = international3;
            internationalVP.isLooping = true;
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
            pS.SetActive(false);
        }

        if (isGoalkeepingLevel == true && tutorialRead == true && gkText.activeInHierarchy == true)
        {
            goalkeepingTutorial.SetActive(false);
            pS.SetActive(false);
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
            pS.SetActive(true);
        }

        //Disables the controls of the player while the tutorial screen is up
        if (tutorialRead == false)
        {
            cB.moveSpeed = 0f;
            tM.buttonEffected = false;
            if(shootingTutorial.activeInHierarchy == true && isShootingLevel == true)
            {
                sB.enabled = false;
            }

        }
        else if (tutorialRead == true)
        {
            this.GetComponent<CountdownTimer>().enabled = true;
            if (timer.countdowntimerDone == true)
            {

            //SOUNDDDDDDDDDDDDDDDDDDDDDDDS//    
           // FindObjectOfType<AudioManager>().Play("Cheering");
            //SOUNNNNNNNNNNNNNNNNNNNNNNNNNNNDDDDDDDDDDDDS//
                
                cB.moveSpeed = 5f;
                if(shootingTutorial.activeInHierarchy == false && isShootingLevel == true)
                {
                    sB.enabled = true;
                }
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
            STScore.SetActive(true);
            if (sceneName == "Cup - GK" || sceneName == "Cup - Shot1" || sceneName == "Cup - Shot2")
            {
                knvbVP.Play();
            }
            else if (sceneName == "Euroborg - GK1" || sceneName == "Euroborg - GK2" || sceneName == "Euroborg - Shot")
            {
                euroborgVP.Play();
            }
            else if (sceneName == "International - GK" || sceneName == "International - Shot" || sceneName == "International - Penalty")
            {
                internationalVP.Play();
            }
        }
        
        if (isShootingLevel == true && goalCheck.goalScored == false)
        {
            Debug.Log("Missed chance");
            STMiss.SetActive(true);
            if (sceneName == "Cup - GK" || sceneName == "Cup - Shot1" || sceneName == "Cup - Shot2")
            {
                knvbVP.Play();
            }
            else if (sceneName == "Euroborg - GK1" || sceneName == "Euroborg - GK2" || sceneName == "Euroborg - Shot")
            {
                euroborgVP.Play();
            }
            else if (sceneName == "International - GK" || sceneName == "International - Shot" || sceneName == "International - Penalty")
            {
                internationalVP.Play();
            }
        }
        
        if (isGoalkeepingLevel == true && Save.ballSaved == true && goalCheck.goalScored == false)
        {
            Debug.Log("Saved");
            GKSave.SetActive(true);
            if (sceneName == "Cup - GK" || sceneName == "Cup - Shot1" || sceneName == "Cup - Shot2")
            {
                knvbVP.Play();
            }
            else if (sceneName == "Euroborg - GK1" || sceneName == "Euroborg - GK2" || sceneName == "Euroborg - Shot")
            {
                euroborgVP.Play();
            }
            else if (sceneName == "International - GK" || sceneName == "International - Shot" || sceneName == "International - Penalty")
            {
                internationalVP.Play();
            }
        }
        
        if (isGoalkeepingLevel == true &&  goalCheck.goalScored == true)
        {
            Debug.Log("Scored against you");
            GKFail.SetActive(true);
            if (sceneName == "Cup - GK" || sceneName == "Cup - Shot1" || sceneName == "Cup - Shot2")
            {
                knvbVP.Play();
            }
            else if (sceneName == "Euroborg - GK1" || sceneName == "Euroborg - GK2" || sceneName == "Euroborg - Shot")
            {
                euroborgVP.Play();
            }
            else if (sceneName == "International - GK" || sceneName == "International - Shot" || sceneName == "International - Penalty")
            {
                internationalVP.Play();
            }
        }

        if (isGoalkeepingLevel == true && Save.ballSaved == false && goalCheck.goalScored == false)
        {
            Debug.Log("Missed shot");
            GKSave.SetActive(true);
            if (sceneName == "Cup - GK" || sceneName == "Cup - Shot1" || sceneName == "Cup - Shot2")
            {
                knvbVP.Play();
            }
            else if (sceneName == "Euroborg - GK1" || sceneName == "Euroborg - GK2" || sceneName == "Euroborg - Shot")
            {
                euroborgVP.Play();
            }
            else if (sceneName == "International - GK" || sceneName == "International - Shot" || sceneName == "International - Penalty")
            {
                internationalVP.Play();
            }
        }
        
    }

    //Part of the input system
    void pButtonpressed(InputAction.CallbackContext context)
    {
        if (gkText.activeInHierarchy == true || stText.activeInHierarchy == true)
        tutorialRead = true;
    }
}
