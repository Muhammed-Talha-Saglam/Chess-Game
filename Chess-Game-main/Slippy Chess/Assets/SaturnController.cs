using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaturnController : MonoBehaviour
{

    void Start()
    {
     
        Invoke("RotateX", 0); 
        Invoke("RotateY", 0);

    }


    void RotateY()
    {
        transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 200.0f, 0), 20.0f)
            .OnComplete(() => { RotateY(); });
    }

    void RotateX()
    {
        transform.DORotate(transform.rotation.eulerAngles + new Vector3(100.0f, 0, 70.0f), 20.0f)
            .OnComplete(() => { RotateX(); });
    }
    

    void MoveUp()
    {
        transform.DOMove(transform.position + new Vector3(0, 2.0f, 0), 5.0f)
            .OnComplete(() => { MoveDown(); });
    }

    void MoveDown()
    {
        transform.DOMove(transform.position - new Vector3(0, 2.0f, 0), 5.0f)
            .OnComplete(() => { MoveUp(); });
    }
}
