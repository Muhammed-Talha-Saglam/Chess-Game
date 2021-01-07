using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Start Particle");

        Destroy(gameObject, 2.0f);
    }


}
