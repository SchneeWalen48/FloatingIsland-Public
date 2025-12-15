using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    Vector3 pos; //현재위치
    public float delta; // 좌(우)로 이동가능한 (x)최대값
    public float speed; // 이동속도

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        GameObject Player = GameObject.Find("Player");

        if (gameObject.name == "upDownPlate")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate1")
        {
            LeftRightMove();
        }
        else if (gameObject.name == "BluePlate2")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate3")
        {
            LeftRightMove();
        }

        else if (gameObject.name == "BluePlate4")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate5")
        {
            LeftRightMove();
        }

        else if (gameObject.name == "BluePlate6")
        {
            ZLeftRightMove();
        }

        else if (gameObject.name == "BluePlate7")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate8")
        {
            ZLeftRightMove();
        }

        else if (gameObject.name == "BluePlate9")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate10")
        {
            UpDownMove();
        }

        else if (gameObject.name == "BluePlate11")
        {
            ZLeftRightMove();
        }

        if (Player.GetComponent<PlayerController>().isJump)
        {
            Debug.Log("자식 해제");
            Player.transform.parent = null;// 플레이어가 점프를 뛰면 발판과 플레이어의 부모자식 관계가 풀려서 플레이어 따로 이동이 가능하게 됨. 
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject Player = GameObject.Find("Player");
        Player.transform.SetParent(this.transform); // 좌우 발판의 경우 위에 박스 콜라이더를 넣어서 콜라이더 엔터면 발판이 플레이어의 부모로 올라가 움직일 때 플레이어도 같이 움직이게 함. 
    }

    public void UpDownMove()// 위아래 발판은 콜라이더 따로 적용 하지 않고 인스펙터에 값만 넣어주면 됨.
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    public void LeftRightMove()// 좌우 발판은 위에 박스 콜라이더(좀 작게) 넣어주고 인스펙터에 값 넣어주면 됨.
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    public void ZLeftRightMove()// 좌우 발판은 위에 박스 콜라이더(좀 작게) 넣어주고 인스펙터에 값 넣어주면 됨.
    {
        Vector3 v = pos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

}
