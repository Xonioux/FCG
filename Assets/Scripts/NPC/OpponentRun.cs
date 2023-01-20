using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRun : MonoBehaviour
{
    public Transform destination;
    public float speed = 2;
    public LevelManager lM;

    void Update()
    {
        if(lM.goalkeepingTutorial.activeInHierarchy == false && lM.shootingTutorial.activeInHierarchy == false)
        {
            float step = speed * Time.deltaTime;
            transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        }
    }
}
