using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtLoad : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(Random.Range(-430,430), Random.Range(-250, 250), 0);
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            rectTransform.anchoredPosition = new Vector3(Random.Range(-430, 430), Random.Range(-250, 250), 0);

        }
    }

}
