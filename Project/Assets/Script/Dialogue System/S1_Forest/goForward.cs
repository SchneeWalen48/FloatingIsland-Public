using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 

public class goForward : MonoBehaviour
{
    // 2021.06.07 created by HY
    // Needs : Trigger, LuaVariable("isTrue")

    // Start is called before the first frame update

    public int goDistance = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // hy : 다이얼로그 시스템에게 메시지를 보내는 스크립트
    private void OnTriggerStay(Collider other) // 플레이어가 들어가 있는 동안 계속 실행돼야함(변수가 true가 되는 순간을 캐치해야 하므로)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("여기1");
            if (DialogueLua.GetVariable("isTrue").asBool) // 만약 메시지를 받은쪽이 이 변수를 true로 만들면
            {
                //DialogueManager.StopConversation();
                other.transform.Translate(new Vector3(0, 0, goDistance)); // 위치이동 진행
                //other.transform.GetChild(0).transform.Translate(new Vector3(0, 0, 10));
                //GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = new Vector3(0, 1, 0);
                //Debug.Log("여");
            }
        }

    }
    /*
    public void OnConversationEnd(Transform actor)
    {
        DialogueManager.StopConversation();
        actor.transform.Translate(new Vector3(0, 0, 10)); // 위치이동 진행
        GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = new Vector3(0, 1, 0);
    }
    */
}
