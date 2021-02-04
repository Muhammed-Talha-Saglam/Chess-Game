using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnightController : MonoBehaviour
{

    public GameObject gameController;
    GameManager gameControllerScript;


    [SerializeField] AudioClip deathSound;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameManager>();

        audio = GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        if (!gameControllerScript.isGameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * gameControllerScript.gameSpeed);
        }


        if (!gameControllerScript.isGameOver)
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
                gameObject.transform.DOMove(newPosition, 1.0f);
               // transform.position = newPosition;
                gameControllerScript.isGameOver = true;

            }
            else if (xRange2 && zRange2)
            {
                var newPosition = player.transform.position;
                Destroy(player);
                audio.PlayOneShot(deathSound);

                gameObject.transform.DOMove(newPosition, 1.0f);
                
                gameControllerScript.FinishGame();

            }
        }


    }
}
