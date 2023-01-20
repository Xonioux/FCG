using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForeshadowing : MonoBehaviour
{
    private Transform ball;
    public Vector3 hitpointBall;

    // Checking if there is a invisible ball (cloned / instantiated) in the scene (NEEDS OPTIMIZATION!)
    // More explaination: Unity calls a lot of errors because this ball will get destroyed after a short while, meaning that this code can't find the ball anymore.
    // I have been trying to find a solution to this but still can't seem to find a way that works properly...
    private void Update()
    {
        ball = GameObject.Find("InvisibleBall").transform;
    }

    // Checking if the invisible ball hit the border object and choosing the position where the ballmark is going to get placed
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("InvisBall"))
        {
            hitpointBall = col.ClosestPoint(ball.position);
            if (Vector3.Distance(hitpointBall, ball.position) < 0.03f)
            {
                HitMark(hitpointBall, .7f);
                Debug.Log("Hit Border");
                this.GetComponent<BallForeshadowing>().enabled = false;
            }
        }
    }

    // Creating the ballmark for the goalkeeper
    private void HitMark(Vector3 point, float scale)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = Vector3.one * scale;
        sphere.transform.position = point;
        sphere.transform.parent = transform.parent;
        sphere.GetComponent<Collider>().enabled = false;
        Destroy(sphere, 3f);
    }
}
