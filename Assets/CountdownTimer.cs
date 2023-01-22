using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdown = 3f;
    public TextMeshProUGUI countdownText;
    public LevelManager lM;
    public bool countdowntimerDone = false;

    void Start() 
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown() 
    {
        while (countdown > 0) 
        {
            countdownText.gameObject.SetActive(true);
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        
        if(countdown <= 0)
        {
            countdownText.gameObject.SetActive(false);
            countdowntimerDone = true;
        }
        
    }
}
