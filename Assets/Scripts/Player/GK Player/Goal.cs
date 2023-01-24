using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool goalScored;
    // Checking with the colliders of the goal if either the ball or the invisible ball hit the goal, so it can destroy it after 1 second
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("InvisBall"))
        {
            Destroy(col.gameObject, 4f);
        }

        if (col.gameObject.CompareTag("RealBall"))
        {
            FindObjectOfType<AudioManager>().Play("Ball Hit");
            goalScored = true;
            FindObjectOfType<AudioManager>().Play("Cheering");
        }
    }
}

