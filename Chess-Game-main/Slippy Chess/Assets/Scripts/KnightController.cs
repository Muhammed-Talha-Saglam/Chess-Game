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


            bool xRange1 = x > 3.0f && x < 4.0f;
            bool zRange1 = z > 6.0f && z < 8.0f;


            bool xRange2 = z > 3.0f && z < 4.0f;
            bool zRange2 = x > 6.0f && x < 8.0f;

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
