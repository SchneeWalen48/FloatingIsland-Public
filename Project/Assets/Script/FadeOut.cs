using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // hy : 이미지 사용에 필요

// hy : This class must be applied to 'trigger'
// : 이 클래스는 트리거 통과 시 점점 어두워지는 함수이다.
public class FadeOut : MonoBehaviour
{
    // 2021.05.xx created by HY
    // Needs : Trigger
    // Field Setting : Directional Light bright(intensity) target value(0~1)

    
    public float startDark = 0;
    public float targetDark = 1; // hy : 목표 어둠 값 (0 : 투명, 1 : 어두움)
    public Image img; // hy : 어두워지게 할 이미지 선택

    private Color colorT; // hy : 색깔 변수 생성
    private bool isDarkOn; // hy : 어두워지기 시작 버튼 false 기본
    

    //public float targetIntensity = 0.5f; // hy : 목표 값 (0 : 어두움, 1 : 밝음)

    void Start()
    {
        colorT = img.color;
        colorT.a = startDark; // hy : 알파값은 지정한 값 부터 시작, 안그러면 예기치 못한 오류 발생

        //Debug.Log(img.color.a);
        //colorT.a = 0 ; // hy : 이미지의 투명도를 0으로 만들어줌
        isDarkOn = false;
    }

    void Update()
    {
        if(isDarkOn && colorT.a < targetDark) // hy : 어두움 버튼 On이고 지정한 어두움까지 어두워지게 
        {
            //Debug.Log(colorT.a);
            //Debug.Log(img.color.a);
            colorT.a += Time.deltaTime; // hy : 색깔의 알파 값을 높임
            img.color = colorT;
        }else if (isDarkOn && colorT.a > targetDark) // hy : 목표 값에 도달하면 이 update문 작동 중지
        {
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) // hy : 트리거를 하나 통과하면 어두워지는 버튼 on
    {
        img.enabled = true;
        isDarkOn = true;
    }

}
