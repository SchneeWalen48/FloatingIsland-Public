using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;


public class TreasureBox : MonoBehaviour
{
    public GameObject Box;
    public Transform player;
    public Camera theCamera;
    [SerializeField]
    public GameObject go_BoxInvenBase;
    public GameObject go_InvenBase;
    public GameObject go_BookUI;
    //public GameObject box_head;

    private RaycastHit hitinfo;//충돌체 정보 저장.

    public string boxName;
    public AudioSource open;
    public AudioSource close;


    void Update()
    {
        Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hitinfo))
        {
            Debug.DrawLine(player.position, hitinfo.transform.position, Color.red);
            if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer("box"))
            {
                boxName = hitinfo.collider.name;//충돌한 박스의 이름을 박스.cs에 넘겨서 그 이름이 해당 이름과 일치하면 리스트 안에 설정한 아이템들이 박스 슬롯으로 들어가서 박스 인벤에 보이게 설정하기 위함.
                Debug.Log(boxName);
                if (GameManager.isOpenBoxInven == false)//이거 넣어야 박스 인벤 열린 상태에서 상자 열고 닫는 소리 안남. 
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Debug.Log(transform.GetChild(0).GetChild(0).GetChild(0).name);
                        //transform.Find("Bone").gameObject.transform.Rotate(-70.0f, 0, 0);
                        //box_head.transform.Rotate(-70.0f, 0, 0);
                        Box.SetActive(Box.active);
                        OpenBoxInven();
                        open.Play();
                        GameManager.isOpenInventory = true;
                        go_BookUI.gameObject.SetActive(false);


                    }
                }
                
                else if (Input.GetMouseButtonDown(1))
                {
                    //Debug.Log(boxName);

                    if (boxName == "T1")
                    {
                        GameObject.Find("S3_Conv_Trigger5").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 

                    }
                    else if (boxName == "T9")
                    {
                        DialogueLua.SetQuestField("S9_BoxOpen", "State", "success"); // hy : 퀘스트 상태를 성공으로 바꿈
                        GameObject.Find("S9_Conv_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                        
                    }
                    else if (boxName == "T14")
                    {
                        DialogueLua.SetQuestField("S9_BoxOpen", "State", "success"); // hy : 퀘스트 상태를 성공으로 바꿈
                        GameObject.Find("S9_Conv_Trigger7").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T15")
                    {
                        GameObject.Find("S10_Conv_Trigger2").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T2_2")
                    {
                        GameObject.Find("S2_L_Trigger2").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T2_10")
                    {
                        GameObject.Find("S4_Trigger22").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T2_13")
                    {
                        GameObject.Find("S7_R_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T2_14")
                    {
                        GameObject.Find("S8_Trigger1").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T2_15")
                    {
                        GameObject.Find("S8_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    else if (boxName == "T3_6")
                    {
                        GameObject.Find("S7_Trigger3").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                    }
                    close.Play();
                    Box.SetActive(!Box.active);
                    CloseBoxInven();
                    GameManager.isOpenInventory = false;
                    go_BookUI.gameObject.SetActive(true);

          
                }
            }
        }

    }

    private void OpenBoxInven()
    {
        GameManager.isOpenBoxInven = true;
        GameManager.isOpenInventory = true;
        go_BoxInvenBase.SetActive(true);//인벤토리 베이스가 활성화 된 상태
        go_InvenBase.SetActive(true);

    }
    public void CloseBoxInven()
    {
        GameManager.isOpenBoxInven = false;
        GameManager.isOpenInventory = false;
        go_BoxInvenBase.SetActive(false);//인벤토리 베이스가 활성화 된 상태
        go_InvenBase.SetActive(false);
      
    }
}

