using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveDecision : MonoBehaviour
{
    public GameObject[] diveOptions;
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            Pick();
        }
    }

    IEnumerator backInPosition()
    {
        yield return new WaitForSeconds(3f);
        transform.position = new Vector3(diveOptions[0].transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("Gets Back");
    }
}
