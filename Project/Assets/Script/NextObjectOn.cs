using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NextObjectOn : MonoBehaviour
{
    // 2021.05.12 created by HY
    // Needs : Trigger, Same name objects with consecutive numbers only (ex. obj1, obj2, obj3...)
 
    private string objName; // hy : 하나씩 켤 오브젝트 이름(숫자 제외 부분)
    private string objNum; // hy : 오브젝트 넘버
    private string next; // hy : 다음 오브젝트 이름
    public AudioSource lightPadEffect;
    private bool balEnter = false;

    void Start()
    {
        objName = gameObject.name; // hy : 오브젝트 이름 문자 + 숫자 들어감

        // hy : Regex는 문자열의 특정 패턴을 찾아내거나 다른 것으로 치환하는 일을 하는 클래스
        objNum = Regex.Replace(objName, @"\D", ""); // hy : objName 변수에서 숫자만 추출해줌
        objName = objName.Replace(objNum, ""); // hy : 오브젝트 이름에서 숫자를 없앰
        //Debug.Log(objName);
        next = objName + (int.Parse(objNum) + 1).ToString(); // hy : 현재 objNum에 1을 더해서 다음 오브젝트 이름을 설정함
        //Debug.Log(next);
    }

    void Update()
    {
        if (balEnter)
        {
            lightPadEffect.Play();
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) // hy : 플레이어가 트리거 입장 시, 다음 오브젝트 보이게 setActive설정
    {
        if(other.tag == "Player")
        {
            gameObject.transform.parent.Find(next).gameObject.SetActive(true); // hy : Find함수를 사용하면 동적 변수로도 이름을 가진 오브젝트에 접근이 가능하다.
            balEnter = true;
        }
    }
}
