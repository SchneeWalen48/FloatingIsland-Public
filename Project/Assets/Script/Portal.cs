using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    // 2021.07.07 created by HY
    // Needs : Trigger, Target Position(Create Trigger)
    public GameObject targetPos; // hy : 포탈에 들어가면 이동시킬 위치 지정(트리거를 만드는게 나을듯 좌표보다)
    public AudioSource teleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            teleport.Play();
            other.transform.position = targetPos.transform.position; // hy : 플레이어가 포탈에 닿으면 위치 이동시킴
            other.transform.rotation = targetPos.transform.rotation;
        }
    }
}
