using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootPosition : MonoBehaviour
{
    public GameObject ShotBorder;
    public Transform SelectedObj;
    private GameObject RaycastOrigin;
    //public InputActionReference toggleReference = null;

    //void Awake()
    //{
    //    toggleReference.action.started += Toggle;
    //}

    //void OnDestroy()
    //{
    //    toggleReference.action.started -= Toggle;
    //}

    //void Toggle(InputAction.CallbackContext context)
    //{
    //    bool isActive = !gameObject.activeSelf;
    //    gameObject.SetActive(isActive);
    //}

    void Start()
    {
        RaycastOrigin = GameObject.Find("RaycastObj");
    }

    void Update()
    {
        var handray = new Ray(RaycastOrigin.transform.position, Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(RaycastOrigin.transform.position, Vector3.up);
        if(Physics.Raycast(handray, out hit))
        {
            SelectedObj = hit.transform;
        }
        else
        {
            return;
        }

        if(hit.collider.gameObject.name == "ShotBorder")
        {
            Debug.Log("Optional Shoot Chance");
        }
    }
}
