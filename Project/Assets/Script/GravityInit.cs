using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 


// 2021.07.13 created by HY
// Needs : Trigger 
// 중력 초기화 클래스

public class GravityInit : MonoBehaviour
{
    public int jumpForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // hy : 다이얼로그 시스템 변수 받으면 중력 초기화시키는 메소드
    private void OnTriggerStay(Collider other) // hy : 플레이어가 들어가 있는 동안 계속 실행돼야함(변수가 true가 되는 순간을 캐치해야 하므로)
    {
        if (other.tag == "Player")
        {
            if (DialogueLua.GetVariable("isTrue").asBool) // hy : 만약 메시지를 받은쪽이 이 변수를 true로 만들면
            {
                PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                playerController.jumpForce = jumpForce;// hy : 중력 초기화 진행
            }
        }

    }
}
