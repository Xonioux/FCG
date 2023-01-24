using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRun : MonoBehaviour
{
    public Transform destination;
    public float speed = 10;
    public LevelManager lM;
    public bool hasArrived;
    public Transform ball;

    void Start()
    {
        ball = GameObject.Find("RealBall").transform;
    }
    void Update()
    {
        if(lM.goalkeepingTutorial.activeInHierarchy == false && lM.shootingTutorial.activeInHierarchy == false)
        {
            float step = speed * Time.deltaTime;
            transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

            if (transform.position == destination.position)
            {
                hasArrived = true;
            }
            else
            {
                hasArrived = false;
            }

            Vector3 ballLook = new Vector3(ball.position.x, transform.position.y, ball.position.z);

            if (this.GetComponent<WaitUntilShot>() == null && hasArrived == true)
            {
                this.GetComponent<Animator>().Play("Idle");
                transform.LookAt(ballLook);
            }
        }
    }
}
