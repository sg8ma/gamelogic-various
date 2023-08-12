using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスが離された場合
        if(Input.GetMouseButtonUp(0))
        {
            // 離されたマウスの場所へレイ（光線）を飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 dir = ray.direction;

            // ショット
            // Instantiate: スクリプトの中からGameObject生成
            GameObject bullet = Instantiate(prefabBullet);
            bullet.transform.position = transform.position;//カメラのポジションが取得される(GunControllerが付いてるので)
            bullet.GetComponent<BulletController>().Shoot(dir.normalized * 3000);
        }
    }
}
