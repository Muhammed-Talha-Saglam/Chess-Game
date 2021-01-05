using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

        //      ShowMovePosition();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
          

            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.transform.gameObject.name);


                var x = Mathf.Abs(hit.transform.position.x - transform.position.x);
                var z = Mathf.Abs(hit.transform.position.z - transform.position.z);

                bool xRange1 = x > 3.0f && x < 4.0f;
                bool zRange1 = z > 6.0f && z < 8.0f;


                bool xRange2 = z > 3.0f && z < 4.0f;
                bool zRange2 = x > 6.0f && x < 8.0f;


                if (xRange1 && zRange1)
                {


                    if (hit.transform.gameObject.tag == "WhiteTile" || hit.transform.gameObject.tag == "blackTile")
                    {
                        Vector3 newPos = new Vector3(hit.transform.position.x, 5.6f, hit.transform.position.z);

                        transform.position = newPos;
                      

                    }
                    else
                    {

                        transform.position = hit.transform.position;
                 //       Destroy(hit.transform.gameObject);
                    }
                }
                
                else if(xRange2 && zRange2)
                {
                    if (hit.transform.gameObject.tag == "WhiteTile" || hit.transform.gameObject.tag == "blackTile")
                    {
                        Vector3 newPos = new Vector3(hit.transform.position.x, 5.6f, hit.transform.position.z);

                        transform.position = newPos;
                    
                    }
                    else
                    {
                        transform.position = hit.transform.position;
                   //     Destroy(hit.transform.gameObject);

                    }
                }
               
               
            }
        }
   
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            
            gameControllerScript.isGameOver = true;
            Destroy(gameObject);            
            
        }

      

    }


    void ShowMovePosition()
    {
        Ray ray = new Ray(transform.position, transform.up * -1);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1.0f);

        Debug.Log(hit.transform.name);




    }

    public void MoveLeft()
    {
       
       
        var left45 = (transform.forward - transform.right).normalized;

        Ray ray = new Ray(transform.position, left45);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);

       
        if(CheckLeftMove(hit))
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

        if(CheckRightMove(hit))
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

        return hit.transform != null;
    }

    bool CheckRightMove(RaycastHit hit)
    {

        return hit.transform != null;
    }

    bool CheckForwardMove(RaycastHit hit)
    {

        return hit.transform == null;
    }
}
