using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBall : MonoBehaviour
{
    public InputActionReference triggerReference = null;
    public GameObject rightHand;

    public Rigidbody ballPrefab;
    private float powerMultiplier = 1f;
    public float minFrontLaunchForce;
    public float maxFrontLaunchForce;
    private float launchFrontForce;
    public float minTopLaunchForce;
    public float maxTopLaunchForce; 
    private float launchTopForce;

    public bool isPressed;


    void Update()
    {
        triggerReference.action.started += BoolTrue;
        triggerReference.action.canceled += BoolFalse;

        // while using the button, the power multiplier will increase
        if (isPressed == true)
        {
            powerMultiplier += Time.deltaTime;
        }

        // as soon as the button gets up, the timer stops and then the multiplier will apply to the original (minimal) power of the ball
        else if (isPressed == false && powerMultiplier > 1f)
        {
            Debug.Log(powerMultiplier);
            if(launchFrontForce < maxFrontLaunchForce && launchTopForce < maxTopLaunchForce)
            {
                launchFrontForce = (powerMultiplier * 10) * minFrontLaunchForce;
                launchTopForce = (powerMultiplier * 5) * minTopLaunchForce;
            }
            //calculate the angle of the shot on the y
            Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, rightHand.transform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);

            Rigidbody ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            //ball.AddForce(x, launchTopForce, launchFrontForce, ForceMode.Impulse);
            ball.AddForce(transform.TransformDirection(new Vector3(transform.rotation.x, launchTopForce, launchFrontForce)), ForceMode.Impulse);
            powerMultiplier = 1f;
            launchFrontForce = 5f;
            launchTopForce = 1f;
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
