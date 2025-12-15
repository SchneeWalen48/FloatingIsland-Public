using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;
    int failCount = 0;
    public Text HintText;
    public AudioSource wrongN;
    public AudioSource bbi;

    public string code = "";
    public string attemptedCode;

    public void Update()
    {
        if (failCount == 2)
        {
            Debug.Log("두번 실수");
            HintText.text = "Hint 1 : 단어가 아니다.";
        }
        else if (failCount == 3)
        {
            Debug.Log("세번 실수");
            HintText.text = "Hint 2 : 순서이며 6자리이다.";
        }

        else if (failCount >= 4)
        {
            Debug.Log("네번 이상 실수");
            HintText.text = "Hint 3 : 각각의 알파벳 순서를 나열하라.";
        }
    }

    private void Start()
    {
        codeLength = code.Length;
    }
    void CheckCode()
    {
        if (attemptedCode == code)
        {
            Debug.Log("암호 정답");
            HintText.gameObject.SetActive(false);
            if (gameObject.name == "KEYBASE")
            {
                GameObject.Find("AnesDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S6_Trigger5").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
            }
            else if (gameObject.name == "SECONDKEYBASE")
            {
                GameObject.Find("keyDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("TimmerTrigger").GetComponent<Timer>().TimerStop();
                GameObject.Find("S4_Trigger24").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
            }
    
        }

        else
        {
            Debug.Log("암호 틀림");
            wrongN.Play();
            failCount++;
        }
    }

    public void SetValue(string value)
    {
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            bbi.Play();
            attemptedCode += value;
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
