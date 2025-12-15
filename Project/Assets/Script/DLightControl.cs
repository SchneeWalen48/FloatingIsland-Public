using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLightControl : MonoBehaviour
{
    // 2021.05.17 created by HY
    // Needs : Trigger
    // Field Setting : Directional Light bright(intensity) target value(0~1)

    public float targetIntensity = 0.5f; // hy : 목표 값 (0 : 어두움, 1 : 밝음)
    
    //private bool isExecute; // hy : 빛 조절 시작 버튼 false 기본
    private GameObject[] directionals; // hy : 모든 directional light 넣을 변수

    void Start()
    {
        //isExecute = false;
    }

    void Update()
    {
        /*if (isExecute)
        {
            foreach(GameObject light in directionals) // hy : 모든 directional light들의 빛을 조절함
            {
                light.GetComponent<Light>().intensity = targetIntensity;
            }
        }*/
    }

    private void OnTriggerEnter(Collider other) // hy : 트리거를 하나 통과하면 빛 조절 버튼 on
    {
        //isExecute = true;
        if (other.tag == "Player")
        {
            directionals = GameObject.FindGameObjectsWithTag("DirectionalLight"); // hy : 디렉셔널 라이트 전부 집어넣음

            foreach (GameObject light in directionals) // hy : 모든 directional light들의 빛을 조절함
            {
                light.GetComponent<Light>().intensity = targetIntensity;
            }

        }
    }
}
