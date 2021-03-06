﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{

    public GameObject gameController;
    GameManager gameControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!gameControllerScript.isGameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * gameControllerScript.gameSpeed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
          
        }
    }

}
