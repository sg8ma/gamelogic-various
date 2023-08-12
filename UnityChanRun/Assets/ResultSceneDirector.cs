using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneDirector : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE:" + GameDirector.score;
    }

    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
