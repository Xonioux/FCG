using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Save : MonoBehaviour
{
    GameObject ball;
    public static bool ballSaved;

    // Checking with the handcollider if the ball got hit by the hand
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("RealBall"))
        {
            ball = col.gameObject;
            ballSaved = true;
            
            // Creating a little haptic feedback for the controller when the ball gets saved
            GetComponentInParent<XRBaseController>().SendHapticImpulse(.5f, .25f);
            
        }
    }

}
