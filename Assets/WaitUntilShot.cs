using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilShot : MonoBehaviour
{
    public SingleBallShot sBs;
    public OpponentRun oR;
    public float timeDelay = 2.3f;

    private void Start()
    {
        this.GetComponent<Animator>().Play("Fast Run");
        InvokeRepeating("AnimationOn", timeDelay, timeDelay);
    }
 
    private void AnimationOn()
    {
        if (sBs.shotLoaded == true && oR.hasArrived == true)
        {
            this.GetComponent<Animator>().Play("kick");
            //this.GetComponent<Animator>().enabled = true;
        }
    }

}
