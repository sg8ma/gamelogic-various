using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    float moveForce = 5;
    float jumpForce = 5;
    Vector3 targetPosition;
    Animator anim;
    bool isJump, isJumpWait;
    float jumpWaitTimer;
    GameObject director;

    void Start()
    {
        anim = GetComponent<Animator>();
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject target = null;
            foreach(RaycastHit hit in Physics.RaycastAll(ray))
            {
                target = (hit.transform.name.Equals("Ground")) 
                        ? hit.transform.gameObject : null ;
                if (target != null) break;
            }
            if(target != null)
            {
                targetPosition = target.transform.position;
                transform.forward = targetPosition;
            }
        }
        if(Input.GetKeyUp("space"))
        {
            if(!isJump && !isJumpWait)
            {
                anim.Play("Jump", 0, 0);
                isJumpWait = true;
                jumpWaitTimer = 0.2f;
            }
        }
        if(isJumpWait)
        {
            jumpWaitTimer -= Time.deltaTime;
            if(0 > jumpWaitTimer)
            {
                GetComponent<Rigidbody>().velocity = transform.up * jumpForce;
                isJumpWait = false;
                isJump = true;
            }
        }
        targetPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(
            transform.position, 
            targetPosition, 
            moveForce * Time.deltaTime
        );
        //�Ђ�����Ԃ�h�~
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // isTrigger�Ƀ`�F�b�N��t����object�Ɠ����蔻�肪�������ꍇ�ɌĂ΂��
        // ��������object�̖��O
        string name = other.gameObject.name;
        if (!name.Contains("Ball")) return;
        Destroy(other.gameObject);
        if(name.Contains("Red"))
        {
            director.GetComponent<GameDirector>().AddScore();
        }
        else
        {
            moveForce *= 0.9f;
            director.GetComponent<GameDirector>().AddScore(-200);
        }
    }
}
