using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float moveSpeed = -100;
    Vector2 screenMin;

    void Start()
    {
        screenMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0));
    }

    void Update()
    {
        if(transform.position.x + transform.localScale.x < screenMin.x)
        {
            Destroy(gameObject);
        }
    }
}
