using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KingController : MonoBehaviour
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
    void FixedUpdate()
    {

        CheckKingMove();      

    }

    void CheckKingMove()
    {
        var right45 = (transform.forward + transform.right).normalized;
        // since transform.left doesn't exist, you can use -transform.right instead
        var left45 = (transform.forward - transform.right).normalized;

        Ray ray1 = new Ray(transform.position, right45);
        Ray ray2 = new Ray(transform.position, right45 * -1);
        Ray ray3 = new Ray(transform.position, left45);
        Ray ray4 = new Ray(transform.position, left45 * -1);

        Ray ray5 = new Ray(transform.position, transform.forward);
        Ray ray6 = new Ray(transform.position, transform.forward * -1);
        Ray ray7 = new Ray(transform.position, transform.right);
        Ray ray8 = new Ray(transform.position, transform.right * -1);



     /*   Debug.DrawRay(ray1.origin, ray1.direction, Color.blue);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.blue);
        Debug.DrawRay(ray3.origin, ray3.direction, Color.blue);
        Debug.DrawRay(ray4.origin, ray4.direction, Color.blue);*/


     /*   Debug.DrawRay(ray5.origin, ray5.direction, Color.blue);
        Debug.DrawRay(ray6.origin, ray6.direction, Color.blue);
        Debug.DrawRay(ray7.origin, ray7.direction, Color.blue);
        Debug.DrawRay(ray8.origin, ray8.direction, Color.blue);*/

        RaycastHit hit1;
        Physics.Raycast(ray1, out hit1, 4.0f);

        RaycastHit hit2;
        Physics.Raycast(ray2, out hit2, 4.0f);

        RaycastHit hit3;
        Physics.Raycast(ray3, out hit3, 4.0f);

        RaycastHit hit4;
        Physics.Raycast(ray4, out hit4, 4.0f);


        RaycastHit hit5;
        Physics.Raycast(ray5, out hit5, 4.0f);

        RaycastHit hit6;
        Physics.Raycast(ray6, out hit6, 4.0f);

        RaycastHit hit7;
        Physics.Raycast(ray7, out hit7, 4.0f);

        RaycastHit hit8;
        Physics.Raycast(ray8, out hit8, 4.0f);

        CanBeatPlayer(hit1);
        CanBeatPlayer(hit2);
        CanBeatPlayer(hit3);
        CanBeatPlayer(hit4);

        CanBeatPlayer(hit5);
        CanBeatPlayer(hit6);
        CanBeatPlayer(hit7);
        CanBeatPlayer(hit8);
    }

    void CanBeatPlayer(RaycastHit hit)
    {

        if (hit.transform != null)
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {

                Vector3 newPosition = hit.transform.position;

                Destroy(hit.transform.gameObject);
                if (gameControllerScript.isSoundOn == "on")
                {
                    audio.PlayOneShot(deathSound);
                }

                gameObject.transform.DOMove(newPosition, 1.0f);

                gameControllerScript.FinishGame();

            }
        }
    }
}
