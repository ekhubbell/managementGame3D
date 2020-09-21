using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnCanvas : MonoBehaviour
{
    public float minX;
    public float maxX;
    float xScale;

    public float minZ;
    public float maxZ;
    float zScale;

    float widthMin;
    float heightMin;

    public float xOffset;
    public float yOffset;

    float deltaX;
    float deltaZ;

    float rectWidth;
    float rectHeight;

    float rXscale;
    float rYscale;

    float aXlocal;
    float aZlocal;

    public GameObject prefab;
    public GameObject a;
    Transform aTrans;
    RectTransform rectTransform;

    

    // Start is called before the first frame update
    void Start()
    {

        a = Instantiate(prefab);
        aTrans = a.GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();

        rectWidth = rectTransform.rect.width;
        rectHeight = rectTransform.rect.height;

        widthMin = -(Screen.width - rectWidth - xOffset) / 2;
        heightMin = -(Screen.height - rectHeight - yOffset) / 2;
        

        xScale = (maxX - minX)/(widthMin * -2);
        zScale = (maxZ - minZ)/(heightMin * -2);

        //Debug.Log(maxX - minX +" " + (widthMin * -2));

        aXlocal = ((maxX - minX) / aTrans.lossyScale.x);
        aZlocal = ((maxZ - minZ) / aTrans.lossyScale.z);


        rXscale = rectWidth / (widthMin * -2);
        rYscale = rectHeight / (heightMin * -2);

        position();
        InitialScale();
    }

    // Update is called once per frame
    void Update()
    {
        position();
        //RectScale();
        //InitialScale();


        
    }

    void position()
    {
        //Debug.Log(rectTransform.anchoredPosition.x);
        deltaX = ((rectTransform.anchoredPosition.x - widthMin) * xScale);
        deltaZ = ((rectTransform.anchoredPosition.y - heightMin) * zScale);
        aTrans.position = new Vector3(minX + deltaX, aTrans.position.y, minZ + deltaZ);
    }

    void InitialScale()
    {
        float x = (rXscale * (maxX - minX)) / (aTrans.lossyScale.x / aTrans.localScale.x);
        float z = (rYscale * (maxZ - minZ)) / (aTrans.localScale.z / aTrans.localScale.z);

        aTrans.localScale = new Vector3(x, aTrans.localScale.y, z);
    }

    void RectScale()
    {
        rectWidth = rectTransform.rect.width;
        rectHeight = rectTransform.rect.height;

        rXscale = rectWidth / (widthMin * -2);
        rYscale = rectHeight / (heightMin * -2);
    }
}
