using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleController : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Invoke("playSound", 0);
        Invoke("playSound", 1);
        Invoke("playSound", 2);
        Destroy(gameObject, 3.0f);
    }

    void playSound()
    {
        audio.PlayOneShot(deathSound);
    }

}
