using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2021.07.23 created by HY
// Needs : Trigger , sizeRatio(Default : 1.0)
// 플레이어 사이즈 조절 클래스

public class PlayerSize : MonoBehaviour
{
    public float sizeRatio = 1.0f; // hy : 인스펙터에서 정하는 사이즈 비율
    Vector3 size; // hy : transform에 직접 넣을 변수

    // Start is called before the first frame update
    void Start()
    {
        size = new Vector3(sizeRatio, sizeRatio, sizeRatio); // hy : transform에 직접 넣을 변수
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.localScale = size; // hy : 사이즈 조절 코드 적용
        }
    }
}
