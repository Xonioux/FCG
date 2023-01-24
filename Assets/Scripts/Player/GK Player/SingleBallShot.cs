using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBallShot : MonoBehaviour
{
    public GameObject Border;
    public GameObject Ball;
    public GameObject invisBall;
    public CountdownTimer timer;

    private GameObject ballClone;
    private GameObject ballReal;
    public float XminAngleRot = 1f;
    public float XmaxAngleRot = 5f;
    public float YminAngleRot = 1f;
    public float YmaxAngleRot = 5f;

    public float forceMultiplier = 10f;

    public bool ballShot;
    public bool ballHit;
    public bool shotLoaded;

    void Update()
    {
        //Will be changed to after the tutorial screen has been closed
        if(timer.countdowntimerDone == true)
        {
            Shoot();
        }
    }

    // The first shot to calculate the ballmark for the goalkeeper
    public void Shoot()
    {
        if (!shotLoaded)
        {
            shotLoaded = true;
            var shotAngle = GetRandomAngle();
            transform.rotation = Quaternion.Euler(shotAngle.x, shotAngle.y, shotAngle.z);

            //ballClone = Instantiate(invisBall, transform.position, transform.rotation);
            invisBall.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * forceMultiplier, ForceMode.Impulse);

            StartCoroutine(shotDelay());
        }
        
    }

    // Shooting the real ball with a 3 second delay
    IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Fire in the hole");
        ballHit = true;
        Ball.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * forceMultiplier, ForceMode.Impulse);
        ballShot = true;
    }

    // Creating a random angle for the launcher (PROBABLY WONT BE NEEDED IN THE ACTUAL GAME, BUT ITS HANDY FOR TESTING)
    private Vector3 GetRandomAngle()
    {
        Vector3 rotationAngle;

        rotationAngle.x = Random.Range(XminAngleRot, XmaxAngleRot);
        rotationAngle.y = Random.Range(YminAngleRot, YmaxAngleRot);
        rotationAngle.z = transform.eulerAngles.z;

        return rotationAngle;
    }
}
