using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 


public class BackGoundMusicPlay : MonoBehaviour
{
    public AudioSource s;
    private bool isPlay = false; // hy : 음악을 켤 때, 얘를 true시킴
    private SaveNLoad theSaveNLoad;
    // Start is called before the first frame update
    void Start()
    {
        //s1 = GameObject.Find("bgs1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            s.Play();
            enabled = false;
        }
    }
    private void OnTriggerStay(Collider other) // 플레이어가 들어가 있는 동안 계속 실행돼야함(변수가 true가 되는 순간을 캐치해야 하므로)
    {
        if (other.tag == "Player")
        {
            /*FindObjectOfType<Inventory>().ClearAllSlots();
            theSaveNLoad = FindObjectOfType<SaveNLoad>();
            theSaveNLoad.LoadInvenData();

            Debug.Log("인벤까지 모두 로드 완료");*/
            if (DialogueLua.GetVariable("isBgmOn").asBool) // 만약 메시지를 받은쪽이 이 변수를 true로 만들면
            {
                //DialogueManager.StopConversation();
                //s1.Play();

                //Debug.Log("오디오나옴");
                isPlay = true;


            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Inventory>().ClearAllSlots();
            theSaveNLoad = FindObjectOfType<SaveNLoad>();
            theSaveNLoad.LoadInvenData();
            Debug.Log("인벤까지 모두 로드 완료");
            GameObject.Find("PauseMenu").GetComponent<EscapeMenu>().ClickSave();
        }
    }
}
    