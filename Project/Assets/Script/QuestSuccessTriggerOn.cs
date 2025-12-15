using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestSuccessTriggerOn : MonoBehaviour
{

    // 2021.07.07 created by HY
    // Needs : Trigger, QuestName, TargetBoxTrigger
    public string luaQuestName;
    public GameObject targetTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) // hy : 플레이어가 트리거에 들어와있는동안
    {
        if(other.tag == "Player")
        {
            if(DialogueLua.GetQuestField(luaQuestName, "State").asString == "success") // hy : 퀘스트를 성공하면
            {
                targetTrigger.GetComponent<BoxCollider>().enabled = true; // hy : 대화시스템이 들어있는 이 트리거 on시켜줌
            }
        }
    }
}
