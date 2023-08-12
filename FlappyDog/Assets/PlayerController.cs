using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpVelocity = 400;
    Rigidbody2D rigidbody;
    Vector2 screenTop, screenBottom;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        screenTop = Camera.main.ViewportToWorldPoint(Vector2.one);
        screenBottom  = Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
            Debug.Log("jump");
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if(pos.y > screenTop.y)
        {
            rigidbody.velocity = Vector2.zero;
            pos.y = screenTop.y; //è„Ç…í¥Ç¶ÇƒÇ¢Ç©Ç»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ
        }
        if(pos.y < screenBottom.y)
        {
            Jump(); //â∫Ç‹Ç≈çsÇ¡ÇΩÇÁÉWÉÉÉìÉv
            pos.y = screenBottom.y;
        }
        transform.position = pos;
    }

    void Jump()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(0, jumpVelocity));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
