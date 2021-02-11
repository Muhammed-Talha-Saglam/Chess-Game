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
    int points = 0;
    public bool isGameOver;
    public bool isGameStarted;
    public string isSoundOn;


    // Start is called before the first frame update
    void Start()
    {

        DOTween.Init(true, true);

        isGameOver = true;
        isSoundOn = PlayerPrefs.GetString("isSoundOn", "on");
        toggleMusic.GetComponent<Toggle>().SetIsOnWithoutNotify(isSoundOn == "on" ? true : false);

    }

    public void startGame()
    {
        startButton.gameObject.SetActive(false);

        GameObject.Find("Camera").transform.DOMove(new Vector3(0.18f, 18.39f, -17.82f), 1.0f)
            .OnComplete(() =>
            {
                isGameOver = false;


                Invoke("IncreaseSpeed", 5.0f);
                Invoke("IncreaseSpeed", 10.0f);

            });

        GameObject.Find("Camera").transform.rotation.eulerAngles.Set(25.552f, 0f, 0f);
    }

    void IncreaseSpeed()
    {
        gameSpeed += 1.0f;
    }

   public void IncreasePoints()
    {
        points += 1;

        if (points < 10)
        {
            timeText.text = "Points: 00" + points;
        } 

        else if (points < 100){
            timeText.text = "Points: 0" + points;
        } 

        else
        {
            timeText.text = "Points: " + points;
        }


    }

    public void toggleSound()
    {
        if(toggleMusic.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetString("isSoundOn", "on");
            isSoundOn = "on";

        } else
        {
            PlayerPrefs.SetString("isSoundOn", "off");
            isSoundOn = "off";
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
