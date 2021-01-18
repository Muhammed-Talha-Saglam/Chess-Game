using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Newtonsoft.Json;




public class SpawnManager : MonoBehaviour
{



    [SerializeField] GameObject floors;
    [SerializeField] GameObject pad;

    public GameObject[] chessPieces;

     
   



    // Start is called before the first frame update
    void Start()
    {

     

        DOTween.Init();
    
    }

   

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("RedTile"))
        {
            floors.gameObject.transform
                .DORotate(floors.gameObject.transform.eulerAngles + new Vector3(-90, 0, 0), 1.0f)
                .OnComplete(() => Invoke("SpawnNewPad", 0.5f));
              

            
        }


    }

    void SpawnNewPad()
    {
        Instantiate(pad, new Vector3(1.6f, 5.05f, 7f), transform.rotation);
    }


    

}
