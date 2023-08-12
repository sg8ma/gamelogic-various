using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject prefabBlock;
    float waitTimer;
    public float totalTimer;
    public bool isStop;

    void Start()
    {
        isStop = true;
    }

    void Update()
    {
        if (isStop) return;
        waitTimer -= Time.deltaTime;
        totalTimer += Time.deltaTime;
        if(0 > waitTimer)
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(-5, 5);
            GameObject obj = Instantiate(prefabBlock, pos, Quaternion.identity);
            BlockController controll = obj.GetComponent<BlockController>();
            controll.moveSpeed = -(100 + (totalTimer * 1.5f));
            float min = 2 - (totalTimer / 100);
            if (0.01f > min) min = 0.01f;
            float max = min * 2;
            waitTimer = Random.Range(min, max);
        }
    }
}
