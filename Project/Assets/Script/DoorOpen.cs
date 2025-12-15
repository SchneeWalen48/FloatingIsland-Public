using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // 2021.05.10 created by HY
    // Needs : Trigger, Child(Target)
    // Field Setting : Local Direction Number(x, -x, y, -y, z, -z => 0 ~ 5), speed, time
    public int directionNumber=0;
    public float speed = 3f; // hy : 열리는 속도 지정
    public float time = 3f; // hy(06_19) : 몇 초 동안 열리는지 지정
    public Vector3 originalPos; // hy(06_19) : 문의 원래 위치 저장해서 DoorClose에서 쓸 거임

    private Transform parentDoor; // hy(06_19) : 목표로 열 문 객체의 트랜스폼 정보를 받아옴
    private Vector3 tmp;
    private float timer = 0f; // hy : 타이머 0초부터 time초까지 작동할 것임
    public bool isOperate; // hy : 문이 작동할건지 체크

    void Start()
    {
        parentDoor = gameObject.transform.parent.transform;
        originalPos = parentDoor.position; // hy(06_19) : 문의 원래 위치 저장, 이 코드에서 안쓰이고 DoorClose.cs에서 쓰임
        //Debug.Log(gameObject.transform.parent+"\n"+originalPos);// hy(06_19) : 이 값 직접 inspector에 넣어야 DoorClose 정상 작동함
        tmp = new Vector3(0f, 0f, 0f);
        isOperate = false; // hy : 문은 미작동
    }

    
    void Update()
    {
        //Debug.Log(timer);
        if (timer < time && isOperate) // hy : 3초 이내면 문 작동시킴
        {
            switch (directionNumber)
            {
                case 0:
                    tmp.x = Time.deltaTime; // hy : tmp는 x축으로 이동시키는 값이 됨
                    break;
                case 1:
                    tmp.x = -Time.deltaTime; // hy : tmp는 -x축으로 이동시키는 값이 됨
                    break;
                case 2:
                    tmp.y = Time.deltaTime; // hy : tmp는 y축으로 이동시키는 값이 됨
                    break;
                case 3:
                    tmp.y = -Time.deltaTime; // hy : tmp는 -y축으로 이동시키는 값이 됨
                    break;
                case 4:
                    tmp.z = Time.deltaTime; // hy : tmp는 z축으로 이동시키는 값이 됨
                    break;
                case 5:
                    tmp.z = -Time.deltaTime; // hy : tmp는 -z축으로 이동시키는 값이 됨
                    break;
            }
            timer += Time.deltaTime;
            parentDoor.localPosition += tmp * speed; // hy : 로컬로 이동시키는 코드
        }
        else if(isOperate) // hy(06_19) : 시간 초과하면 그대로 멈춤(열리는 것까지-> 닫히는 코드는 DoorClose.cs)
        {
            //shake.enabled = false; // hy : 카메라 흔들리는 코드 중지
            isOperate = false;
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player") // hy : 플레이어가 들어오면 문 작동 On 
        {
            isOperate = true;
        }
    }
}
