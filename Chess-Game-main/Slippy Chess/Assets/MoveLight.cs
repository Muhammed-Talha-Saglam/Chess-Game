using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveDown", 0);

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
