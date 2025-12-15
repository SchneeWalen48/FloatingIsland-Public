using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

// hy : It needs 'IsGround' Script
// 이 클래스는 IsGround와 같이 오브젝트에 넣어줘야함 -> 땅에 닿으면 캐릭터와 위치를 변경시켜줌
public class ChangePlayerPos : MonoBehaviour
{
    // hy : 현재 오브젝트 위치를 저장하기 위한 변수
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<IsGround>().isGround && gameObject.transform.position.y > pos.y + 5) // hy : 오브젝트가 땅에 닿고 5m 이상 한 번 떠올라야 함
        {
            //Debug.Log(Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));



            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position; // hy : 플레이어의 위치를 공이 던져진 위치로 이동
            GameObject.Destroy(gameObject, 1); // hy : 위치를 바꾼 후 공은 1초 후 파괴

            //Debug.Log(gameObject.GetComponent<IsGround>().isGround);
            // hy 06.16 : lua 처리하기, 공이 바닥에 닿은 후, 퀘스트 failure, success 처리를 해야함 (success 처리는 다른 곳에서 됨, 여기서는 success가 아닐 때 failure 처리를 해줌)
            string state = DialogueLua.GetQuestField("S3_ThrowBall", "State").asString;
            if (state != "success")
            {
                DialogueLua.SetQuestField("S3_ThrowBall", "State", "failure");
            }
        }
    }
}
