using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreekickShot : MonoBehaviour
{
    public SingleBallShot sBs;
    public float timeDelay = 2.3f;

    private void Start()
    {
        this.GetComponent<Animator>().Play("idle");
        InvokeRepeating("AnimationOn", timeDelay, timeDelay);
    }
 
    private void AnimationOn()
    {
        if (sBs.shotLoaded == true)
        {
            this.GetComponent<Animator>().Play("kick");
            //this.GetComponent<Animator>().enabled = true;
        }
    }
}
