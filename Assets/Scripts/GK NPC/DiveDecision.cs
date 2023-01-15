using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveDecision : MonoBehaviour
{
    public GameObject[] diveOptions;
    public ShootBall sB;
    int chosen;
    void Pick()
    {
        chosen = Random.Range(0, diveOptions.Length);
        transform.position = new Vector3(diveOptions[chosen].transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("Jumped for it");
        StartCoroutine(backInPosition());
    }

    void Update()
    {
        if (sB.isPressed == false && sB.powerMultiplier > 1f)
        {
            Debug.Log("Jump");
            Pick();
        }
    }

    IEnumerator backInPosition()
    {
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(diveOptions[0].transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("Gets Back");
    }
}
