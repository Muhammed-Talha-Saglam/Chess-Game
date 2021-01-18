using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPawnController : MonoBehaviour
{
    
    
    public GameObject gameController;
    GameManager gameControllerScript;

  //  [SerializeField] GameObject particle;

    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Button upButton;


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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.transform.position +  " --- " + hit.transform.gameObject.name );
                


                var x = hit.transform.position.x - transform.position.x;
                var z = hit.transform.position.z - transform.position.z;

                bool xRange1 = x < -2.5f && x > -4.0f;
                bool zRange1 = z > 2.5f && z < 4.0f;

                bool xRange2 = x > 2.5f && x < 4.0f;
                bool zRange2 = z > 2.5f && z < 4.0f;

                bool xRange3 = x > -1.0f && x < 1.0f;
                bool zRange3 = z > 2.5f && z < 4.0f;


                if (xRange1 && zRange1)
                {
                    if( CheckLeftMove())
                    {
                        MoveLeft();
                    }
                }

                if (xRange2 && zRange2)
                {
                    if( CheckRightMove() )
                    {
                        MoveRight();
                    }
                }

                if (xRange3 && zRange3)
                {
                    if (CheckForwardMove())
                    {
                        MoveForward();
                    }

                }

            
            
            }
        }

        
//        leftButton.gameObject.SetActive(CheckLeftMove());
//        rightButton.gameObject.SetActive(CheckRightMove());
//        upButton.gameObject.SetActive(CheckForwardMove());

    }

    //private void OnDestroy()
    //{
    //   Instantiate(particle, transform.position, transform.rotation);
    //}


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

            transform.position += new Vector3(-3.2f, 0, 3.0f);
        

    }


    public void MoveRight()
    {

        transform.position += new Vector3(3.2f, 0, 3.0f);
    
    }

    public void MoveForward()
    {
            transform.position += new Vector3(0, 0, 3.0f);
     
    }


    bool CheckLeftMove()
    {
        var left45 = (transform.forward - transform.right).normalized;

        Ray ray = new Ray(transform.position, left45);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);

        
        return hit.transform != null ;
    }

    bool CheckRightMove()
    {

        var right45 = (transform.forward + transform.right).normalized;

        Ray ray = new Ray(transform.position, right45);


        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);

        return hit.transform != null ;
    }

    bool CheckForwardMove()
    {

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4.0f);
        return hit.transform == null;
    }
}
