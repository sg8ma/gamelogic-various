using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static int score;
    public GameObject ballRed;
    public GameObject ballBlack;
    float gameTimer = 60;
    int blackRatio = 3;
    float generateWaitTime = 3;
    float generateTimer;
    GameObject txtTimer, txtScore;

    void Start()
    {
        generateTimer = generateWaitTime;
        txtTimer = GameObject.Find("TxtTimer");
        txtScore = GameObject.Find("TxtScore");
        score = 0;
    }

    void Update()
    {
        gameTimer -= Time.deltaTime;
        txtTimer.GetComponent<Text>().text = gameTimer.ToString("F1");
        generateTimer -= Time.deltaTime;
        if(0 > generateTimer)
        {
            int rnd = Random.Range(0, 10);
            GameObject ins;
            if(rnd < blackRatio)
            {
                ins = Instantiate(ballBlack);
            }
            else
            {
                ins = Instantiate(ballRed);
            }
            float x = Random.Range(-1, 2);
            float y = (0 == Random.Range(0, 2)) ? 0.25f : 1.5f;
            ins.transform.position = new Vector3(x, y, 10);
            float next = generateWaitTime;
            if(10 > gameTimer)
            {
                next = generateWaitTime * 0.1f;
            }
            else if(20 > gameTimer)
            {
                next = generateWaitTime * 0.2f;
            }
            else if (30 > gameTimer)
            {
                next = generateWaitTime * 0.4f;
            }
            else if (40 > gameTimer)
            {
                next = generateWaitTime * 0.5f;
            }
            else if (50 > gameTimer)
            {
                next = generateWaitTime * 0.7f;
            }
            if(0 > gameTimer)
            {
                SceneManager.LoadScene("ResultScene");
            }
            generateTimer = next;
        }
    }

    public void AddScore(int v = 100)
    {
        score += v;
        txtScore.GetComponent<Text>().text = "SCORE:" + score;
    }
}
