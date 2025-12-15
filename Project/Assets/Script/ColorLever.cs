using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLever : MonoBehaviour
{
    //public AudioSource lever;
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        Text leverText = GameObject.Find("Show Text").transform.Find("leverText").GetComponent<Text>();
        if (dist <= 4f)
        {
            leverText.text = "";

            if (GameObject.Find("a2_9").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_10").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_11").GetComponent<Altar>().isAltarEnter
                || GameObject.Find("a2_12").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_13").GetComponent<Altar>().isAltarEnter == true)
            {
                leverText.gameObject.SetActive(true);
                leverText.text = "(U) 버튼을 눌러 레버를 당기시오";
                GameObject.Find("Show Text").transform.Find("action Text").gameObject.SetActive(false);

                if (Input.GetKeyDown(KeyCode.U))
                {
                    GameObject.Find("Show Text").transform.Find("leverText").gameObject.SetActive(false);
                    GameObject.Find("Show Text").transform.Find("action Text").gameObject.SetActive(false);
                    if (transform.name == "greenlever")
                    {
                        transform.gameObject.GetComponent<ColorLever>().enabled = false;
                        transform.rotation = GameObject.Find("greenimsi").transform.rotation;

                        GameObject.Find("CaveLeverDoor").GetComponent<DoorOpen>().isOperate = true;
                        GameObject.Find("GreenRoomDoor").GetComponent<DoorOpen>().isOperate = true;
                        GameObject.Find("S7_R_Trigger5").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
                        Debug.Log("2부 초록 방 & 발판 방 문 열림");

                    }

                    else if (transform.name == "pinklever")
                    {
                        transform.gameObject.GetComponent<ColorLever>().enabled = false;
                        transform.rotation = GameObject.Find("pinkimsi").transform.rotation;

                        Vector3 velo = Vector3.zero;

                        GameObject.Find("pinkHammer").transform.position = Vector3.SmoothDamp(GameObject.Find("pinkHammer").transform.position, GameObject.Find("pinkWater").transform.position, ref velo, 0.009f);

                        Debug.Log("유리깨지는 소리");

                        Invoke("Pink", 2);

                    }

                    else if (transform.name == "bluelever")
                    {
                        transform.gameObject.GetComponent<ColorLever>().enabled = false;
                        transform.rotation = GameObject.Find("blueimsi").transform.rotation;

                        Vector3 velo = Vector3.zero;

                        GameObject.Find("blueHammer").transform.position = Vector3.SmoothDamp(GameObject.Find("blueHammer").transform.position, GameObject.Find("blueWater").transform.position, ref velo, 0.009f);

                        Debug.Log("유리깨지는 소리");

                        Invoke("Blue", 2);

                    }

                    else if (transform.name == "orangelever")
                    {
                        transform.gameObject.GetComponent<ColorLever>().enabled = false;
                        transform.rotation = GameObject.Find("orangeimsi").transform.rotation;

                        Debug.Log("유리깨지는 소리");

                        Invoke("Orange", 2);

                    }

                    else if (transform.name == "yellowlever")
                    {
                        transform.gameObject.GetComponent<ColorLever>().enabled = false;
                        transform.rotation = GameObject.Find("yellowimsi").transform.rotation;

                        GameObject.Find("StoneOne").GetComponent<StoneMove>().StoneFall();
                        GameObject.Find("S8_Trigger7").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
                        Debug.Log("노랑 방 문 열림");

                    }
                }

            }
            else
            {
                leverText.gameObject.SetActive(false);
            }
        }
        else
        {
            leverText.gameObject.SetActive(false);
        }
    }

    public void Pink()
    {
        GameObject.Find("PinkLeverDoor").GetComponent<DoorOpen>().isOperate = true;
        GameObject.Find("S8_Trigger2").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
        Debug.Log("분홍 방 문 열림");
    }

    public void Blue()
    {
        GameObject.Find("BlueLeverDoor").GetComponent<DoorOpen>().isOperate = true;
        GameObject.Find("S8_Trigger4").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
        Debug.Log("파랑 방 문 열림");
    }

    public void Orange()
    {
        GameObject.Find("S8_Trigger6").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
        GameObject.Find("OrangeLeverDoor").GetComponent<DoorOpen>().isOperate = true;
        Debug.Log("오랜지 방 문 열림");
    }

    
}
