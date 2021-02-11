using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PawnController : MonoBehaviour
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
        var right45 = (transform.forward + transform.right).normalized;
        // since transform.left doesn't exist, you can use -transform.right instead
        var left45 = (transform.forward - transform.right).normalized;


        Ray ray1 = new Ray(transform.position, right45 * -1);
        Ray ray2 = new Ray(transform.position, left45 * -1);

       /* Debug.DrawRay(ray1.origin, ray1.direction, Color.blue);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.blue);*/

        RaycastHit hit1;
        Physics.Raycast(ray1, out hit1, 4.0f);

        RaycastHit hit2;
        Physics.Raycast(ray2, out hit2, 4.0f);

        CheckMove(hit1);
        CheckMove(hit2);


    }


    void CheckMove(RaycastHit hit)
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
