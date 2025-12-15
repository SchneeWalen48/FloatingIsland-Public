using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // 2021.05.10 created by HY
    // 이 클래스는 다른 클래스에서 호출하여 사용
    public float shakeAmount = 0.1f; // hy : 카메라 흔들릴 정도 설정
    //public bool isShake; // hy : 흔들림 작동 외부 클래스에서 직접 true해줌
    private GameObject camera;

    void Start()
    {
        //shakeAmount = 0.1f;
        //isShake = false;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        /*if (isShake) // hy : 카메라 흔들림 작동
        {
            //Debug.Log("shake it");
            //Debug.Log(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
            //Debug.Log(Random.insideUnitSphere);
            //Debug.Log(shakeAmount);
            camera.transform.position += Random.insideUnitSphere * shakeAmount;
        }else // hy : 카메라 위치 다시 조정
        {
            //Debug.Log("stop shake it");
            camera.transform.localPosition = new Vector3(0, 1, 0);
        }
        */
        camera.transform.position += Random.insideUnitSphere * shakeAmount;
    }
}
