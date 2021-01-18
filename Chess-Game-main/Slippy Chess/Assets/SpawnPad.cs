using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPad : MonoBehaviour
{

    [SerializeField] GameObject pad;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Spawn Pad triggered by player");

            Vector3 pos = new Vector3(1.6f, 5.05f, transform.position.z + 27.0f );
            Instantiate(pad, pos, pad.transform.rotation);
            SpawnChessPieces();

        }
    }

    private void SpawnChessPieces()
    {
        throw new NotImplementedException();
    }
}
