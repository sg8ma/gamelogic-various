using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    List<GameObject> tiles;
    List<Vector2> startPositions;
    public int shuffleCount = 50;
    bool isClear;
    GameObject txtInfo;

    void Start()
    {
        txtInfo = GameObject.Find("Text");
        txtInfo.SetActive(false);
        tiles = new List<GameObject>();
        startPositions = new List<Vector2>();
        for(int i = 0; i < 16; i++)
        {
            GameObject obj = GameObject.Find("" + i);
            tiles.Add(obj);
            startPositions.Add(obj.transform.position);
        }
        for(int i = 0; i < shuffleCount; i++)
        {
            List<GameObject> moveAvailables = new List<GameObject>();
            foreach (GameObject obj in tiles)
            {
                if (null != GetExTile(obj))
                {
                    moveAvailables.Add(obj);
                }
            }
            if (0 < moveAvailables.Count)
            {
                int rnd = Random.Range(0, moveAvailables.Count);
                GameObject tile0 = GetExTile(moveAvailables[rnd]);
                ChangeTile(moveAvailables[rnd], tile0);
            }
        }
    }

    void Update()
    {
        if (isClear) return;
        isClear = true;
        for(int i = 0; i < tiles.Count; i++)
        {
            Vector2 pos = tiles[i].transform.position;
            if(startPositions[i] != pos)
            {
                isClear = false;
            }
        }
        if(isClear)
        {
            txtInfo.SetActive(true);
            for(int i = 0; i < tiles.Count; i++)
            {
                float x = Random.Range(-50, 50);
                float y = Random.Range(-50, 50);
                tiles[i].AddComponent<Rigidbody2D>().velocity = new Vector2(x, y);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10);
            if(hit.collider)
            {
                GameObject hitObj = hit.collider.gameObject;
                GameObject target = GetExTile(hitObj);
                ChangeTile(hitObj, target);
            }
        }
    }

    GameObject GetExTile(GameObject tile)
    {
        GameObject ret = null;
        Vector2 posa = tile.transform.position;
        foreach(GameObject obj in tiles)
        {
            Vector2 posb = obj.transform.position;
            float dist = Vector2.Distance(posa, posb);//‹——£
            if(1 == dist && obj.name.Equals("0"))
            {
                ret = obj;
                break;
            }
        }
        return ret;
    }

    void ChangeTile(GameObject tilea, GameObject tileb)
    {
        if (null == tilea || null == tileb) return;
        Vector2 tmp = tilea.transform.position;
        tilea.transform.position = tileb.transform.position;
        tileb.transform.position = tmp;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
