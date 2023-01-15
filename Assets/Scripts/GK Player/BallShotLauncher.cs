using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShotLauncher : MonoBehaviour
{
    public GameObject Border;
    public GameObject Ball;
    public GameObject invisBall;

    private GameObject ballClone;
    private GameObject ballReal;
    public float XminAngleRot = 1f;
    public float XmaxAngleRot = 5f;
    public float YminAngleRot = 1f;
    public float YmaxAngleRot = 5f;

    private float currentTime;
    public float shootingInterval;
    private float nextShootTime;

    public float forceMultiplier = 10f;

    // Running the void when the interval is over
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > nextShootTime)
        {
            Shoot();
            nextShootTime = currentTime + shootingInterval;
        }

    }

    // The first shot to calculate the ballmark for the goalkeeper
    public void Shoot()
    {
        var shotAngle = GetRandomAngle();
        transform.rotation = Quaternion.Euler(shotAngle.x, shotAngle.y, shotAngle.z);

        ballClone = Instantiate(invisBall, transform.position, transform.rotation);
        ballClone.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * forceMultiplier, ForceMode.Impulse);

        StartCoroutine(shotDelay());
    }

    // Shooting the real ball with a 3 second delay
    IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Fire in the hole");
        ballReal = Instantiate(Ball, transform.position, transform.rotation);
        ballReal.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * forceMultiplier, ForceMode.Impulse);
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
