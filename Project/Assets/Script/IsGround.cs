using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hy : It needs 'trigger' beneath the gameObject
// 이 클래스는 오브젝트 아래에 trigger를 추가로 생성해줘야함 -> collider 만났을 때, true 반환됨
public class IsGround : MonoBehaviour
{
    // hy : 땅에 닿았는지 판별 -> 닿으면 true
    public bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isGround);
    }
    void OnTriggerEnter(Collider col)
    {
        isGround = true; // hy : 땅에 붙으면 true
    }
    void OnTriggerExit(Collider col)
    {
        isGround = false; // hy : 땅에서 떨어지면 false
    }
}
