using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // hy : 이미지 사용에 필요

// hy : This class must be applied to 'trigger'
// : 이 클래스는 트리거 통과 시 이미지의 알파값을 0으로 만들어 주는 함수이다. (투명해지게)

public class FadeIn : MonoBehaviour
{
    public float start = 1.0f; // hy : 처음 값 입력 1로 고정
    public float target = 0.0f; // hy : 목표 알파 값 (0 : 투명, 1 : 불투명)
    public Image img; // hy : 투명해지게 할 이미지 선택

    private Color colorT; // hy : 색깔 변수 생성
    private bool isDarkOff; // hy : 어두움 종료 버튼 false 기본

    // Start is called before the first frame update
    void Start()
    {
        colorT = img.color;
        colorT.a = start; // hy : 이미지는 이미 불투명 상태
        isDarkOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDarkOff && colorT.a > target) // hy : 어두움 버튼 Off이고 지정한 값만큼 투명해지게 
        {
            colorT.a -= Time.deltaTime; // hy : 색깔의 알파 값을 낮춤
            img.color = colorT;
        }else if (isDarkOff && colorT.a < target) // hy : 목표 값에 도달하면 이 update문 작동 중지
        {
            img.canvas.gameObject.SetActive(false);
            enabled = false;
        }
     
    }

    private void OnTriggerEnter(Collider other) // hy : 트리거를 하나 통과하면 투명해지는 버튼 on
    {
        isDarkOff = true;
    }

}