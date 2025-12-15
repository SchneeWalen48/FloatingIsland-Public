using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    GameObject waterFall1;
    GameObject waterFall2;
    GameObject waterFall3;
    GameObject waterFall4;
    GameObject waterFall5;

    public AudioSource waterfallSound;//오디오 소스



    void Start()
    {
        /*
        waterFall1 = GameObject.Find("WaterFall1");

        waterFall2 = GameObject.Find("WaterFall2");

        waterFall3 = GameObject.Find("WaterFall3");

        waterFall4 = GameObject.Find("WaterFall4");

        waterFall5 = GameObject.Find("WaterFall5");
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("들어옴");
        if (other.tag == "Player") 
        {
            //Debug.Log("잘들어옴");
            //waterFall1.SetActive(true);

            waterfallSound.Play(); // hy : 폭포 떨어지는 소리
            gameObject.transform.GetChild(0).gameObject.SetActive(true); // hy : 폭포를 자식에다가 넣어서 자식을 setactive시켜줌
            GetComponent<BoxCollider>().enabled = false; // 한 번만 실행되고 끝남
        }
    }
}
