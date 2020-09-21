using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDImmer : MonoBehaviour
{
    Light lit;

    public float maxIntensity;

    float previousScale;

    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer.TimesUp += DimLight;
        lit = GetComponent<Light>();
        previousScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(lit.intensity + (maxIntensity * 0.1f) < maxIntensity)
            {
                lit.intensity += maxIntensity * 0.1f;
            }
            else
            {
                lit.intensity = maxIntensity;
            }
        }
        else if (lit.intensity <= 0f)
        {
            GameOver.End();
        }
    }

    void DimLight(float scale)
    {
        lit.intensity -= maxIntensity * (previousScale - scale);

        if(scale <=0)
        {
            previousScale = 1;
        }
        else
        {
            previousScale = scale;
        }

    }
}
