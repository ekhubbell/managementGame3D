using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static event Action<float> TimesUp = delegate { };

    public float maxTime;
    public float remainingTime;

    float multiplier = 1f;

    public Image countdownTimer;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime * multiplier;
        if(remainingTime<=0)
        {
            TimesUp(0f);
            remainingTime = maxTime;
            multiplier += .1f;
        }
        else
        {
            TimesUp(remainingTime / maxTime);
        }
    }
}
