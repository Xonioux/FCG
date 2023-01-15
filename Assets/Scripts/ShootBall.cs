using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBall : MonoBehaviour
{
    public InputActionReference triggerReference = null;
    public GameObject rightHand;

    public Rigidbody ballPrefab;
    public float powerMultiplier = 1f;
    public float minFrontLaunchForce;
    public float maxFrontLaunchForce;
    private float launchFrontForce;
    public float minTopLaunchForce;
    public float maxTopLaunchForce; 
    private float launchTopForce;

    public bool isPressed;
    private bool shotDone = false;


    void Update()
    {
        triggerReference.action.started += BoolTrue;
        triggerReference.action.canceled += BoolFalse;

        // while using the button, the power multiplier will increase
        if (isPressed == true && shotDone == false)
        {
            powerMultiplier += Time.deltaTime;
            if (powerMultiplier >= 3f)
            {
                powerMultiplier = 3f;
            }
        }

        // as soon as the button gets up, the timer stops and then the multiplier will apply to the original (minimal) power of the ball
        else if (isPressed == false && powerMultiplier > 1f)
        {
            Debug.Log(powerMultiplier);
            if((minFrontLaunchForce * powerMultiplier) < maxFrontLaunchForce && (minTopLaunchForce * powerMultiplier) < maxTopLaunchForce)
            {
                launchFrontForce = (powerMultiplier) * minFrontLaunchForce;
                launchTopForce = (powerMultiplier) * minTopLaunchForce;
            }
            else if ((launchFrontForce * powerMultiplier) >= maxFrontLaunchForce && (launchTopForce * powerMultiplier) >= maxTopLaunchForce)
            {
                launchFrontForce = maxFrontLaunchForce;
                launchTopForce = maxTopLaunchForce;
            }

            //calculate the angle of the shot on the y
            Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, rightHand.transform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
            ballPrefab.AddForce(transform.TransformDirection(new Vector3(transform.rotation.x, launchTopForce, launchFrontForce)), ForceMode.Impulse);
            Debug.Log(launchFrontForce);
            Debug.Log(launchTopForce);

            powerMultiplier = 1f;
            launchFrontForce = 0f;
            launchTopForce = 0f;
            shotDone = true;
        }
    }

    void BoolTrue(InputAction.CallbackContext context)
    {
        isPressed = true;
    }

    void BoolFalse(InputAction.CallbackContext context)
    {
        isPressed = false;
    }
}
