using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject player;
    public GameObject textScore;
    public GameObject textInfo;
    public GameObject btnRetry;
    public BlockManager blockMng;
    float startTimer;
    enum MODE
    {
        NONE,
        READY,
        MAIN,
        RESULT
    };
    MODE nowMode, nextMode;

    void Start()
    {
        startTimer = 3.9f;
        btnRetry.SetActive(false);
        player.GetComponent<Rigidbody2D>().simulated = false;
        nowMode = MODE.READY;
        nextMode = MODE.NONE;
    }

    void Update()
    {
        if(MODE.READY == nowMode)
        {
            startTimer -= Time.deltaTime;
            textInfo.GetComponent<Text>().text = "" + Mathf.Floor(startTimer);
            if(1 > startTimer)
            {
                textInfo.GetComponent<Text>().text = "START!!";
            }
            if(0 > startTimer)
            {
                player.GetComponent<Rigidbody2D>().simulated = true;
                blockMng.isStop = false;
                textInfo.SetActive(false);
                nextMode = MODE.MAIN;
            }
        }
        else if(MODE.MAIN == nowMode)
        {
            if(null == player)
            {
                textInfo.GetComponent<Text>().text = "GAME OVER";
                textInfo.SetActive(true);
                btnRetry.SetActive(true);
                nextMode = MODE.RESULT;
            }
            textScore.GetComponent<Text>().text = "" + Mathf.Floor(blockMng.totalTimer);
        }
        if (MODE.NONE != nextMode)
        {
            nowMode = nextMode;
            nextMode = MODE.NONE;
        }
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
