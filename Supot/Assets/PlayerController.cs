using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isStop;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop) return;
        transform.Rotate(new Vector3(0,1,0));
        transform.Translate(0, -0.001f, 0);
        if(1 > transform.position.y)
        {
            Vector3 pos = transform.position;
            pos.y = startY;
            transform.position = pos;
        }

    }

    //コライダーの当たり判定があった場合に呼び出される
    void OnCollisionEnter(Collision collision)
    {
        GameObject col_obj = collision.gameObject;
        if(col_obj.name.Equals("Clear"))
        {
            Debug.Log("Game Clear!!");
        }
    }

    public void Stop()
    {
        isStop = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
