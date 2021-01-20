using UnityEngine;
using DG.Tweening;
using System;




public class SpawnManager : MonoBehaviour
{

    

    [SerializeField] GameObject floors;
    [SerializeField] GameObject pad;
    
    public GameObject player;

    public GameObject pawn;
    public GameObject rook;
    public GameObject knight;
    public GameObject bishop;
    public GameObject king;




    string[,,] paths = {
    {
      {
        "p",
        "",
        "",
        ""
      },
      {
        "",
        "",
        "B",
        ""
      },
      {
        "",
        "",
        "",
        ""
      },
      {
        "",
        "R",
        "",
        "P"
      },
      {
        "N",
        "",
        "",
        "K"
      },
      {
        "",
        "",
        "P",
        ""
      },
      {
        "",
        "",
        "K",
        ""
      },
      {
        "",
        "",
        "",
        ""
      }
    },
    {
      {
        "",
        "p",
        "",
        ""
      },
      {
        "",
        "N",
        "R",
        ""
      },
      {
        "",
        "",
        "",
        "N"
      },
      {
        "",
        "",
        "",
        "R"
      },
      {
        "",
        "",
        "",
        ""
      },
      {
        "",
        "P",
        "",
        ""
      },
      {
        "",
        "",
        "",
        ""
      },
      {
        "",
        "",
        "",
        ""
      }
    }
  };

    Vector3[,] positions ={
      {
        new Vector3(-4.4f, 5.8f, 39.5f),
        new Vector3(-1.4f, 5.8f, 39.5f),
        new Vector3(1.6f, 5.8f, 39.5f),
        new Vector3(4.55f, 5.8f, 39.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 42.5f),
        new Vector3(-1.4f, 5.3f, 42.5f),
        new Vector3(1.6f, 5.3f, 42.5f),
        new Vector3(4.55f, 5.3f, 42.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 45.5f),
        new Vector3(-1.4f, 5.3f, 45.5f),
        new Vector3(1.6f, 5.3f, 45.5f),
        new Vector3(4.55f, 5.3f, 45.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 48.5f),
        new Vector3(-1.4f, 5.3f, 48.5f),
        new Vector3(1.6f, 5.3f, 48.5f),
        new Vector3(4.55f, 5.3f, 48.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 51.5f),
        new Vector3(-1.4f, 5.3f, 51.5f),
        new Vector3(1.6f, 5.3f, 51.5f),
        new Vector3(4.55f, 5.3f, 51.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 54.5f),
        new Vector3(-1.4f, 5.3f, 54.5f),
        new Vector3(1.6f, 5.3f, 54.5f),
        new Vector3(4.55f, 5.3f, 54.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 57.5f),
        new Vector3(-1.4f, 5.3f, 57.5f),
        new Vector3(1.6f, 5.3f, 57.5f),
        new Vector3(4.55f, 5.3f, 57.5f),
      },
      {
        new Vector3(-4.4f, 5.3f, 60.5f),
        new Vector3(-1.4f, 5.3f, 60.5f),
        new Vector3(1.6f, 5.3f, 60.5f),
        new Vector3(4.55f, 5.3f, 60.5f),      }
    };



    // Start is called before the first frame update
    void Start()
    {


       




        DOTween.Init();

    }



    private void OnTriggerEnter(Collider other)
    {



        if ( other.gameObject.name == "A1" )
        {
            //floors.gameObject.transform
            //    .DORotate(floors.gameObject.transform.eulerAngles + new Vector3(-90, 0, 0), 1.0f)
            //    .OnComplete(() => Invoke("SpawnNewPad", 0.5f));


            SpawnNewPad();
            SpawnEnemies();



        }


    }

    private void SpawnEnemies()
    {
        int randomPath = UnityEngine.Random.Range(0, 2);

        for (int a = 0; a < 8; a++)
        {
            for (int b = 0; b < 4; b++)
            {


                //Debug.Log(paths[randomPath, a, b]);

                switch(paths[randomPath, a, b])
                {
                    case "N":
                        Instantiate(knight, positions[a, b], transform.rotation);
                        break;
                    case "P":
                        Instantiate(pawn, positions[a,b], transform.rotation );
                        break;
                    case "p":
                        Instantiate(player, positions[a, b] - new Vector3(0, 0.4f, 0), transform.rotation);
                        break;
                    case "R":
                        Instantiate(rook, positions[a, b], transform.rotation);
                        break;
                    case "B":
                        Instantiate(bishop, positions[a, b], transform.rotation);
                        break;
                    case "K":
                        Instantiate(king, positions[a, b], transform.rotation);
                        break;
     
                }

            }



        }
    }

    private void SpawnNewPad()
    {
        Instantiate(pad, new Vector3(1.6f, 5.05f, 48.5f), transform.rotation);
       

    }
}
