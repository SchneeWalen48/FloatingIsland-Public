using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AltarParent : MonoBehaviour
{
    public GameObject Spike;
    //private List<Altar> alList;
    private bool isAllTrue = false; // hy : 자식 변수들이 모두 true인가?
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            if (!gameObject.transform.GetChild(i).GetComponent<Altar>().isAltarEnter) // hy : 자식 객체들의 Altar 스크립트에서 isEnterAltar 변수가 모두 true가 되면 실행
            {
                isAllTrue = false; // hy : 하나라도 true아니면 이 변수는 false인채로 false
                return;
            }
            else
            {
                isAllTrue = true; // hy : 모든 자식 변수들이 true이면 이 변수는 true됨
            }
        }

        if (isAllTrue)
        {
            Debug.Log("이제 문만 열면 됨");
        }
        */

        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            if (gameObject.transform.GetChild(30).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("3부 최종 문 열림");
                GameObject.Find("S8_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }

            else if (gameObject.transform.GetChild(26).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(27).GetComponent<Altar>().isAltarEnter &&
                gameObject.transform.GetChild(28).GetComponent<Altar>().isAltarEnter  && gameObject.transform.GetChild(29).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("3부 미로 다음 문 열림");
                GameObject.Find("Mazedoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S2_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }
            
            else if (gameObject.transform.GetChild(24).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(25).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부에서 3부로 향하는 문 2 열림");
                GameObject.Find("SecondFinalDoor").transform.localEulerAngles = new Vector3(-0.265f, -81.83f, 0.043f);
                GameObject.Find("S9_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함

            }
            

            if (gameObject.transform.GetChild(23).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 노랑 레버 넣음");
                
            }

            else if (gameObject.transform.GetChild(22).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 오렌지 레버 넣음");
                
            }

            else if (gameObject.transform.GetChild(21).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 파랑 레버 넣음");
                
            }

            else if (gameObject.transform.GetChild(20).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 분홍 레버 넣음");
                
            }

            else if (gameObject.transform.GetChild(19).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 초록 레버 넣음");
            }

            else if (gameObject.transform.GetChild(18).GetComponent<Altar>().isAltarEnter == true)
            {
                Debug.Log("2부 센터 1층 숨겨진 문, 한기의 문, 신전 앞 문 열림");
                GameObject.Find("secondportalDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("SinjunDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("CaveEnterDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S4_Trigger26").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }

            else if (gameObject.transform.GetChild(16).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(17).GetComponent<Altar>().isAltarEnter == true)
            {

                Debug.Log("2부 2층 중앙문 열림");
                GameObject.Find("CenterSecondDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S4_Trigger12").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }

            else if (gameObject.transform.GetChild(12).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(13).GetComponent<Altar>().isAltarEnter
               && gameObject.transform.GetChild(14).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(15).GetComponent<Altar>().isAltarEnter == true)
            {

                Debug.Log("2부 1층 중앙문 열림");
                GameObject.Find("CenterFirstDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S4_Trigger9").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }

            else if (gameObject.transform.GetChild(11).GetComponent<Altar>().isAltarEnter == true)
            {
                GameObject.Find("SpikeLeverDoor").GetComponent<DoorOpen>().isOperate = true;
                Spike.gameObject.SetActive(false);
                GameObject.Find("S4_Trigger4").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
                Debug.Log("2부 실험실 1의 가시 사라짐.");
            }

            else if (gameObject.transform.GetChild(10).GetComponent<Altar>().isAltarEnter == true)
            {
                GameObject.Find("S10_Conv_Trigger5").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
                Debug.Log("1부 마지막 이벤 시작");
            } 

            else if (gameObject.transform.GetChild(6).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(7).GetComponent<Altar>().isAltarEnter
                && gameObject.transform.GetChild(8).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(9).GetComponent<Altar>().isAltarEnter == true)
            {
                //DialogueLua.SetQuestField("S9_GetBlood", "State", "success"); // hy : 퀘스트 상태를 성공으로 바꿈
                GameObject.Find("S9_Conv_Trigger14").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함

                Debug.Log("사령의 힘이 모인 방 이벤 시작");
            } 

            else if (gameObject.transform.GetChild(2).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(3).GetComponent<Altar>().isAltarEnter
                && gameObject.transform.GetChild(4).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(5).GetComponent<Altar>().isAltarEnter == true)
            {
                //DialogueLua.SetQuestField("S9_GetBlood", "State", "success"); // hy : 퀘스트 상태를 성공으로 바꿈
                GameObject.Find("S9_Conv_Trigger9").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함


                Debug.Log("락캔디 방 이벤 시작");
            }

            else if (gameObject.transform.GetChild(0).GetComponent<Altar>().isAltarEnter && gameObject.transform.GetChild(1).GetComponent<Altar>().isAltarEnter == true)
            {
                //DialogueLua.SetQuestField("S8_DoorOpen", "State", "success"); // hy : 퀘스트 상태를 성공으로 바꿈
                GameObject.Find("S8_Conv_Trigger16").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함

                //Debug.Log(DialogueLua.GetQuestField("S8_DoorOpen", "State").asString);
                Debug.Log("석령 기억의 방 이벤 시작");
            }     

        }
    }
}