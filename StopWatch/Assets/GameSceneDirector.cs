using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneDirector : MonoBehaviour
{
    public GameObject txtStopWatch;
    public GameObject btnStop;
    public GameObject btnReset;

    float timer;
    bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop) return;
        timer += Time.deltaTime;
        string timer_str = timer.ToString("N2");
        txtStopWatch.GetComponent<Text>().text = "" + timer_str;

        if(3 < timer)
        {
            //3秒超えたら点滅
            //activeSelfは現在の状態を取得。→点滅になる
            txtStopWatch.SetActive(!txtStopWatch.activeSelf);
        }
        if(5 < timer)
        {
            //5秒を超えたら消す
            txtStopWatch.SetActive(false);
        }
    }

    public void Stop()
    {
        isStop = true;
        txtStopWatch.SetActive(true);
        print("得点：" + timer);
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
