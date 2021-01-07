using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject BlackTilePrefab;
    public GameObject WhiteTilePrefab;

    public GameObject[] chessPieces;

    float spawnZ = 23.5f;
    float spawnY = 5.05f;


    // Start is called before the first frame update
    void Start()
    {       
       // InvokeRepeating("SpawnTiles2", 0.0f, 4.0f);
       // InvokeRepeating("SpawnTiles1", 2.0f, 4.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("blackTile"))
        {
            SpawnTiles1();
        } 
        else if (other.gameObject.CompareTag("WhiteTile"))
        {
            SpawnTiles2();
        }
    }

    void SpawnTiles1()
    {


        Instantiate(BlackTilePrefab, new Vector3(-4.8f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(WhiteTilePrefab, new Vector3(-1.6f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(BlackTilePrefab, new Vector3(1.6f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(WhiteTilePrefab, new Vector3(4.8f, spawnY, spawnZ), Quaternion.identity);


        GameObject c = chessPieces[Random.Range(0, 12)];
        if(c.tag != "Empty")
        {
            Instantiate(c, new Vector3(-4.8f, spawnY + 0.5f, spawnZ), Quaternion.identity);

        }
        c = chessPieces[Random.Range(0, 12)];
        if (c.tag != "Empty")
        {
            Instantiate(c, new Vector3(-1.6f, spawnY + 0.5f, spawnZ), Quaternion.identity);

        }

        c = chessPieces[Random.Range(0, 12)];
        if (c.tag != "Empty")
        {
            Instantiate(c, new Vector3(1.6f, spawnY + 0.5f, spawnZ), Quaternion.identity);

        }

        c = chessPieces[Random.Range(0, 12)];
        if (c.tag != "Empty")
        {
            Instantiate(c, new Vector3(4.8f, spawnY + 0.5f, spawnZ), Quaternion.identity);

        }


    }

    void SpawnTiles2()
    {

        Instantiate(WhiteTilePrefab, new Vector3(-4.8f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(BlackTilePrefab, new Vector3(-1.6f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(WhiteTilePrefab, new Vector3(1.6f, spawnY, spawnZ), Quaternion.identity);
        Instantiate(BlackTilePrefab, new Vector3(4.8f, spawnY, spawnZ), Quaternion.identity);

    }

}
