using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // hy : 플레이어인지 확인 안해주면 씬 시작하자마자 실행되어버림(왜 그런지는 잘..)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().jumpForce = 0;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().runSpeed = 0;
            Debug.Log("입장");
        }
    }
}
