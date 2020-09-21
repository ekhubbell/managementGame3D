using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnCollision : MonoBehaviour
{
    Color color;
    GameObject a;
    private void Start()
    {
        color = gameObject.transform.GetComponent<Image>().color;
        a = GetComponent<FollowOnCanvas>().a;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        color = gameObject.transform.GetComponent<Image>().color;
        //Debug.Log("tag " + !collision.gameObject.CompareTag("Circle"));
        //Debug.Log("r " + (gameObject.transform.GetComponent<Image>().color.r == collision.gameObject.GetComponent<Image>().color.r));
        //Debug.Log("g " + Mathf.Approximately(gameObject.transform.GetComponent<Image>().color.g, collision.gameObject.GetComponent<Image>().color.g));
        //Debug.Log("b " + (gameObject.transform.GetComponent<Image>().color.b + " " + collision.gameObject.GetComponent<Image>().color.b));

        if (!collision.gameObject.CompareTag("Circle") && Mathf.Approximately(color.r, collision.gameObject.GetComponent<Image>().color.r)
            && Mathf.Approximately(color.g, collision.gameObject.GetComponent<Image>().color.g)
            && Mathf.Approximately(color.b, collision.gameObject.GetComponent<Image>().color.b))
        {
            Destroy(a);
            Destroy(gameObject);
        }
    }
}
