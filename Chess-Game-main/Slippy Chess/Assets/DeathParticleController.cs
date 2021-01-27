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
        Destroy(gameObject, 2.0f);
    }

    void playSound()
    {
        audio.PlayOneShot(deathSound);
    }

}
