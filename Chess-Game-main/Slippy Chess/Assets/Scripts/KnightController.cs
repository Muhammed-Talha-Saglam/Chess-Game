using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
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
    void Update()
    {

        if(!gameControllerScript.isGameOver)
        {

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            var x = Mathf.Abs(transform.position.x - player.transform.position.x);
            var z = Mathf.Abs(transform.position.z - player.transform.position.z);


            bool xRange1 = x > 2.5f && x < 3.5f;
            bool zRange1 = z > 5.0f && z < 7.0f;


            bool xRange2 = z > 2.5f && z < 3.5f;
            bool zRange2 = x > 5.0f && x < 7.0f;

            if (xRange1 && zRange1)
            {

                var newPosition = player.transform.position;
                Destroy(player);
                transform.position = newPosition;
                gameControllerScript.isGameOver = true;

            }
            else if (xRange2 && zRange2)
            {
                var newPosition = player.transform.position;
                Destroy(player);
                transform.position = newPosition;
                gameControllerScript.isGameOver = true;

            }
        }


    }
}
