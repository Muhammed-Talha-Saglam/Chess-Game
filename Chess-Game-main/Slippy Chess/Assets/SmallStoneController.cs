using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmallStoneController : MonoBehaviour
{
    void Start()
    {
        Invoke("MoveUp", 0);
        Invoke("Rotate", 0);

    }


 


    void Rotate()
    {
        transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 180, 0), 5.0f)
            .OnComplete(() => { Rotate(); });
    }

    void MoveUp()
    {
        transform.DOMove(transform.position + new Vector3(0, 5.0f, 0), 15.0f)
            .OnComplete(() => { MoveDown(); });
    }

    void MoveDown()
    {
        transform.DOMove(transform.position - new Vector3(0, 5.0f, 0), 15.0f)
            .OnComplete(() => { MoveUp(); });
    }

}
