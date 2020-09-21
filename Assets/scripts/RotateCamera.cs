using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speedX;

    public float horizAngle;

    public static bool lockPosition;

    // Start is called before the first frame update
    void Start()
    {
        lockPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Mouse X")<0 && horizAngle>-20)||(Input.GetAxis("Mouse X") > 0 && horizAngle < 20))
        {
            horizAngle += speedX * Input.GetAxis("Mouse X");
        }
        
        if(!lockPosition)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, horizAngle, 0f);
        }
        
    }


}
