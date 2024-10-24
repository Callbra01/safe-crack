using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    public float targetTime = 120.0f;
    public bool startTimer = false;
    public SceneManagerScript sms;
    public bool isEndless = false;

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                timerEnd();
            }
        }
    }

    public void DecreaseTime(float amount)
    {
        targetTime -= amount;
    }

    public void IncreaseTime(float amount)
    {
        targetTime += amount;
    }

    void timerEnd()
    {
        if (isEndless)
        {
            sms.LoadScene("EndlessScoreScreen");
        }
        else
        {
            sms.LoadScene("FailScreen");
        }
    }
}
