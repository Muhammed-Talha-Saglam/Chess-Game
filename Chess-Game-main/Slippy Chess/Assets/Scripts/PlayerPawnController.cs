using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawnController : MonoBehaviour
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

        


        if (!gameControllerScript.isGameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 1.5f);
        }

         ShowMovePosition();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.transform.position);

                var x = Mathf.Abs(transform.position.x - hit.transform.position.x);
                var z = transform.position.z - hit.transform.position.z;

                var x2 = transform.position.x - hit.transform.position.x;


                bool xRange1 = x >= 0.0f && x <= 2.0f;
                bool zRange1 = z <= -2.5f && z >= -4.0f;

                bool xRange2 = x2 > 2.5f && x2 <= 5.0f;
                bool zRange2 = z > 3.0f && z < 4.0f;

                bool xRange3 = x2 <= -2.5f && x2 >= -5.0f;
                bool zRange3 = z > 3.0f && z < 4.0f;

                if ( xRange1 && zRange1)
                {
                    MoveForward();
                } 

                if(xRange2 && zRange2)
                {
                    MoveLeft();
                }

                if (xRange3 && zRange3)
                {
                    MoveRight();
                }


            }
        }
    }

    void ShowMovePosition()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        



        var left45 = (transform.forward - transform.right).normalized;
        Ray ray2 = new Ray(transform.position, left45);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.blue);

        var right45 = (transform.forward + transform.right).normalized;
        Ray ray3 = new Ray(transform.position, right45);
        Debug.DrawRay(ray3.origin, ray3.direction, Color.blue);
    }


    public void MoveLeft()
    {


        var left45 = (transform.forward - transform.right).normalized;

        Ray ray = new Ray(transform.position, left45);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);

     


        if (CheckLeftMove(hit))
        {
            transform.position += new Vector3(-3.2f, 0, 3.2f);

        }

    }


    public void MoveRight()
    {

        var right45 = (transform.forward + transform.right).normalized;

        Ray ray = new Ray(transform.position, right45);


        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);

        


        if (CheckRightMove(hit))
        {
            transform.position += new Vector3(3.2f, 0, 3.2f);
        }


    }

    public void MoveForward()
    {

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);



        if (CheckForwardMove(hit))
        {
            transform.position += new Vector3(0, 0, 3.2f);
        }


    }



    bool CheckLeftMove(RaycastHit hit)
    {
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject);

        }
        return hit.transform != null || hit.transform.gameObject.tag == "Empty";
    }

    bool CheckRightMove(RaycastHit hit)
    {
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject);

        }
        return hit.transform != null || hit.transform.gameObject.tag == "Empty";
    }

    bool CheckForwardMove(RaycastHit hit)
    {

        if(hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject);

        }

        return hit.transform == null || hit.transform.gameObject.tag == "Empty";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {

            gameControllerScript.isGameOver = true;
            Destroy(gameObject);

        }

      
    }
}
