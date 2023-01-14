using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Checking with the colliders of the goal if either the ball or the invisible ball hit the goal, so it can destroy it after 1 second
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball") || col.gameObject.CompareTag("RealBall"))
        {
            Destroy(col.gameObject, 4f);
        }
    }
}

