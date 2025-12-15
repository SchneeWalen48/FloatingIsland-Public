using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2021.07.31 created by HY
// NEED : Trigger 
// 불 깜빡깜빡 코드, 트리거 통과하면 시작됨


public class BlinkBlink : MonoBehaviour
{
    public bool isOperate; // hy : true면 작동 바로 시작
    private GameObject[] directionals; // hy : 모든 Directional Light 넣을 변수
    public float interval = 0.5f; // hy : 몇 초에 한 번씩 깜빡이게 할 건지(ex 0.5) 
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        isOperate = false;
        timer = interval;
        directionals = GameObject.FindGameObjectsWithTag("DirectionalLight"); // hy : 디렉셔널 라이트 전부 집어넣음
    }

    // Update is called once per frame
    void Update()
    {
        if (isOperate)
        {
            timer -= Time.deltaTime; 

            if (timer < 0) { // 0보다 작아지면 타이머 초기화, 빛 0과 1 바꾸기
                timer = interval; // hy : 타이머 초기화
                foreach (GameObject light in directionals) // hy : 모든 directional light들의 빛을 조절함
                {
                    light.GetComponent<Light>().intensity = 1 - light.GetComponent<Light>().intensity; // hy : 현재 0이면 1, 1이면 0됨
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isOperate = true; // hy : 플레이어가 트리거에 들어가면 작동 시작함
        }
    }
}
