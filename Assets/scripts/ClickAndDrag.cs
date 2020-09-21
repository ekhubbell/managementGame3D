using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickAndDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool drag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(drag)
        {
            transform.position = Input.mousePosition;
        }   
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
    }
}
