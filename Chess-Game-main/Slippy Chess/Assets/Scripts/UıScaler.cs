using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UıScaler : MonoBehaviour
{
    public float resoX;
    public float resoY;

    private CanvasScaler canvasScaler;
    // Start is called before the first frame update
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        SetInfo();
           
    }

    void SetInfo()
    {
        resoX = (float)Screen.currentResolution.width;
        resoY = (float)Screen.currentResolution.height;

        canvasScaler.referenceResolution = new Vector3(resoX, resoY);
    }


}
