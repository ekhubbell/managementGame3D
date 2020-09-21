using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelActive : MonoBehaviour
{
    public GameObject panel;

    public Vector3 down;
    Vector3 start;

    private void Start()
    {
        panel.SetActive(true);
        start = panel.transform.position;
        down = start - down;
        panel.transform.position = down;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(panel.transform.position != start)
            {
                panel.transform.position = start;
            }
            else
            {
                panel.transform.position = down;
            }
        }
    }
}
