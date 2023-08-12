using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speedZ = -0.04f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speedZ); 
        if(transform.position.z < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
