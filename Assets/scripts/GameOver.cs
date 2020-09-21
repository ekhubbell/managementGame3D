using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    public GameObject a;

    public static event Action Done = delegate { };
    private void Start()
    {
        Done += endScreen;
    }

    public static void End()
    {
        Done();
        Time.timeScale = 0;
    }

   void endScreen()
    {
        a.SetActive(true);
    }

    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
