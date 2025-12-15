using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 

public class Lever : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float speed = 0.1F;
    public Transform Player;
    public GameObject lava;
    public AudioSource lever;

    [SerializeField]
    private Text leverText;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);

        if (dist <= 2f)
        {
            leverText.text = "(U) 버튼을 눌러 레버를 당기시오";

            if (Input.GetKeyDown(KeyCode.U)) 
            {
                lever.Play();
                leverText.gameObject.SetActive(false);
                from.rotation = to.rotation;
                lava.SetActive(false);
                //DialogueLua.SetQuestField("S9_LeverOn", "State", "success"); // hy : 다이얼로그시스템 퀘스트 변수를 성공으로 바꿔줌
                
                GameObject.Find("S8_Conv_Trigger6").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
                GameObject.Find("S9_Conv_Trigger4").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함
            }
        }
    }
}
