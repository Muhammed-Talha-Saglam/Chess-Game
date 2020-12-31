using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;



public class GameManager : MonoBehaviour
{


    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

            return _instance;
        }
    }



    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text gameOverText;

    int seconds = 0;
    public bool isGameOver;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer", 0, 1);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Timer()
    {
        if (!isGameOver)
        {
            seconds += 1;
            timeText.text = "Time: " + seconds;
        } else
        {
            gameOverText.enabled = true;
        }

    }

}
