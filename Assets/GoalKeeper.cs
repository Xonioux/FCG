using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public GameObject dD;
    
    

    private void Start()
    {
        AnimationOn();
    }
 
    private void AnimationOn()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().Play("mixamo_com");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().Play("mixamo_com 1");
        }
        else if (dD.transform.position == new Vector3(dD.transform.position.x, dD.transform.position.y, dD.GetComponent<DiveDecision>().diveOptions[0].transform.position.z))
        {
            this.GetComponent<Animator>().enabled = false;
        }
    }
}
