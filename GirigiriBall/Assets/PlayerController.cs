using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject groundObj;
    public GameObject textObj;

    Vector2 startPos;
    Rigidbody2D rb;
    float frictionForce = 0.98f;
    bool gameEnd;
    int touchCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd) return;

        //mouse down event
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        //mouse up event
        else if (Input.GetMouseButtonUp(0))
        {
            if (0 < touchCount)
            {
                Vector2 endPos = Input.mousePosition;
                //additional value
                Vector2 addForce = endPos - startPos;
                rb.AddForce(addForce);
                touchCount--;
            }
        }

        // 摩擦
        rb.velocity *= frictionForce;
        // テキスト更新
        float startx = transform.position.x;
        float starty = transform.position.y;
        float endx = groundObj.transform.localScale.x / 2;
        float deltax = endx - startx;
        if (deltax < 0)
        {
            deltax = -100;
        }
        textObj.GetComponent<Text>().text = "残り　" + deltax.ToString("N1");

        // game clear condition
        if (0 < deltax && deltax < 1)
        {
            if (0.01f > rb.velocity.x)
            {
                textObj.GetComponent<Text>().text = "Success!!";
                //omake
                textObj.GetComponent<Text>().color = Color.black;
                groundObj.GetComponent<SpriteRenderer>().color = Color.black;
                GetComponent<SpriteRenderer>().color = Color.black;
                Camera.main.GetComponent<Camera>().backgroundColor = Color.white;

                gameEnd = true;
            }
        }
        else if (-10 > starty)
        {
            textObj.GetComponent<Text>().text = "Fail...";
            gameEnd = true;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
