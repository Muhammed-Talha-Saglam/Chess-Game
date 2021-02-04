using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using DG.Tweening;


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
    [SerializeField] Toggle toggleMusic;

    [SerializeField] Button restartButton;
    [SerializeField] Button startButton;


    public float gameSpeed = 2.0f;
    int points = 1;
    public bool isGameOver;
    public bool isGameStarted;



    // Start is called before the first frame update
    void Start()
    {

        DOTween.Init(true, true);

        isGameOver = true;


    }

    public void startGame()
    {
        startButton.gameObject.SetActive(false);

        GameObject.Find("Camera").transform.DOMove(new Vector3(0, 28.7f, -16.74f), 1.0f)
            .OnComplete(() =>
            {
                isGameOver = false;


                Invoke("IncreaseSpeed", 5.0f);
                Invoke("IncreaseSpeed", 10.0f);
                Invoke("IncreaseSpeed", 15.0f);
            });

    }

    void IncreaseSpeed()
    {
        gameSpeed += 1.0f;
    }

   public void IncreasePoints()
    {
           points += 1;
           timeText.text = "Points: " + points;
            
        
    }

    public void toggleSound()
    {
        if(toggleMusic.GetComponent<Toggle>().isOn)
        {
            GetComponent<AudioSource>().Play();

        } else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    public void FinishGame()
    {
        isGameOver = true;
        Invoke("RestartGame", 2.0f);
    }


   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
