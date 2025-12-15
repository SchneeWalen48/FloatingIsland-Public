using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2021.08.02 created by HY
// NEED : Trigger, TargetTrigger(measure direction) 
// 책 튀어나오는 코드, 부모 객체에 적용, enabled를 true해주는 순간 실행됨

public class RandomScatter : MonoBehaviour
{
    public float waitSecond = 0; // hy : 몇 초 후에 튀어나올 건지 결정
    public float randomForce = 1; // hy : 어느정도 랜덤으로 할지
    public float scatterForce = 1; // hy : 튀어나오는 힘
    public int randomPercent = 100; // hy : 얼마나 랜덤으로 적용시킬지
    public Transform targetTrigger; // hy : 방향 판단에 쓰일 트리거
    public GameObject triggerEnter; // hy : ontriggerenter 되면 작동함
    public bool isStart = false; // hy : 바로 시작하는지 체크
    
    private Vector3 direction; // hy : 흩뿌려질 방향
    private float force; // hy : 랜덤 계산 최종 계산 값
    private Transform[] children; // hy : 자식 객체들의 transform값

    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>(); // hy : 자식 객체 transform 하나씩 받아옴
        
        if (isStart)
        {
            StartCoroutine(Wait());
        }
        else
        {
            enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());
        enabled = false;
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitSecond); // hy : waitSecond만큼 기다림
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Random.value * 100 > randomPercent) // hy : 확률 계산 randomPercent보다 크면 흩뿌려지지 않음
                continue;

            direction = targetTrigger.position - children[i].position; // hy : 튀어나갈 방향
            force = Random.value * randomForce * scatterForce; // hy : 튀어나가는 힘
            //children[i].Translate(direction * force, Space.World);
            Rigidbody rigidBody = children[i].gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
            rigidBody.useGravity = true;
            rigidBody.AddForce(direction * force);
            rigidBody.mass = 1; // Set the GO's mass to 2 via the Rigidbody.
        }
    }
}
