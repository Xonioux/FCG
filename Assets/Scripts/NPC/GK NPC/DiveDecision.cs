using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveDecision : MonoBehaviour
{
    public GameObject[] diveOptions;
    public ShootBall sB;
    public int chosen;
    public bool jumpLeft;
    public bool jumpRight;

    void Pick()
    {
        chosen = Random.Range(0, diveOptions.Length);
        transform.position = new Vector3(transform.position.x, transform.position.y, diveOptions[chosen].transform.position.z);
        Debug.Log("Jumped for it" + diveOptions[chosen]);
    }

    void Update()
    {
        if (sB.isPressed == false && sB.powerMultiplier > 1f)
        {
            Debug.Log("Jump");
            Pick();
        }

        if (chosen == 1)
        {
            jumpLeft = true;
        }
        else if (chosen == 2)
        {
            jumpRight = true;
        }
        
    }
}
