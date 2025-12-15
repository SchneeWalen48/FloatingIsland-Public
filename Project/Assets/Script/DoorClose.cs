using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    // 2021.06.19 created by HY
    // Needs : Trigger, DoorOpen Component
    // Field Setting : speed, time
    // Start is called before the first frame update

    public float speed = 3f; // hy : 열리는 속도 지정
    public float time = 3f; // hy : 몇 초 동안 열리는지 지정

    private Transform parentDoor; // hy : 목표로 열 문 객체의 트랜스폼 정보를 받아옴
    private DoorOpen doorOpen; // hy : 문 여는 코드 컴포넌트 넣을 변수
    private Vector3 originPos; // hy : 문 원래 위치 받아올 변수
    private Vector3 tmp;
    private float timer = 0f; // hy : 타이머 0초부터 time초까지 작동할 것임
    private int direction; // hy : 닫힐 방향 계산해서 넣을 변수
    private bool isOperate = false; // hy : 문이 작동할건지 체크

    void Start()
    {
        parentDoor = gameObject.transform.parent.transform;
        doorOpen = gameObject.transform.parent.GetComponentInChildren<DoorOpen>(); // 부모 아래에 dooropen 코드가 두 개 있으면 오류남 
        this.originPos = doorOpen.originalPos;
        //Debug.Log(originPos);
        tmp = new Vector3(0f, 0f, 0f);
        direction = doorOpen.directionNumber; // hy : 이 방향은 문 열리는 방향이라서 반대 방향으로 넣어줘야 함

        if(direction % 2 == 1) // hy : 방향이 (-)방향이면 (+)방향으로 바꿔줌
        {
            direction = direction - 1;
        }else // hy : 방향이 (+)방향이면 (-)방향으로 바꿔줌 -> 이해 안가면 DoorOpen의 directionNumber변수 설명 참고
        {
            direction = direction + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < time && isOperate) // hy : 3초 이내면 문 작동시킴
        {
            switch (direction)
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
        else if(isOperate) // hy : 시간 초과하면 문 원래 위치로 이동
        {
            isOperate = false;
            parentDoor.position = originPos;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") // hy : 플레이어가 들어오면 문 작동 On 
        {
            isOperate = true;
        }
    }
}
