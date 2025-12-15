using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 

public class BackGroundMusicStop : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource s;
    private bool isStop = false; // hy : 음악을 켤 때, 얘를 true시킴

    // Start is called before the first frame update
    void Start()
    {
        //s1 = GameObject.Find("bgs1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("음악 멈춰");
        if (isStop)
        {
            s.Stop();
            enabled = false;
        }
    }
    private void OnTriggerStay(Collider other) // 플레이어가 들어가 있는 동안 계속 실행돼야함(변수가 true가 되는 순간을 캐치해야 하므로)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("여기1");
            if (!DialogueLua.GetVariable("isBgmOn").asBool) // 만약 메시지를 받은쪽이 이 변수를 true로 만들면
            {
                //DialogueManager.StopConversation();
                //s1.Play();
                isStop = true;
            }
        }
    }
}
