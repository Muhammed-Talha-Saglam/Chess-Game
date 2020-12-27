using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text time;
    int seconds = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Timer()
    {
        seconds += 1;
        time.text = "Time: " + seconds;
    }

}
