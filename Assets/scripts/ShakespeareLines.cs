using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShakespeareLines : MonoBehaviour, IPointerDownHandler
{
    public string[] lines;

    Text text;

    int l;
    string correctString;
    string currentString;

    float previousA;

    bool go = false;

    // Start is called before the first frame update
    void Start()
    {
        l = 0;
        text = GetComponent<Text>();
        CountDownTimer.TimesUp += nextLine;
    }

    void nextLine(float a)
    {
        if(a<=1f && !go)
        {
            go = true;
            Show(lines[l]);
            l++;
        }
        else if(a<=0f)
        {
            go = false;
            if(text.text != correctString)
            {
                GameOver.End();
            }
        }

        if(l>=lines.Length)
        {
            l = 0;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, a);

    }

    void Show(string a)
    {
        correctString = a;
        if (Random.Range(0, 2) > 0)
        {
            currentString = a.Substring(0, 15) + "Uhhhhhhh" + a.Substring(15);
            text.color = new Color(1, 0, 0);
        }
        else
        {
            currentString = a;
            text.color = new Color(0, 0, 0);
        }

        text.text = currentString;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (text.text != correctString)
        {
            text.text = correctString;
            text.color = new Color(0, 0, 0);
        }
    }
}
