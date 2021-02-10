using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigStoneController : MonoBehaviour
{

    void Start()
    {
        Invoke("MoveDown", 0);
        Invoke("Rotate", 0);

    }






    void Rotate()
    {
        transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, 180,0), 5.0f )
            .OnComplete( () => { Rotate(); } );
    }

    void MoveUp()
    {
        transform.DOMove(transform.position + new Vector3(0,5.0f,0), 15.0f)
            .OnComplete(() => { MoveDown(); });
    }

    void MoveDown()
    {
        transform.DOMove(transform.position - new Vector3(0, 5.0f, 0), 15.0f)
            .OnComplete( ()=> { MoveUp(); });
    }


}
