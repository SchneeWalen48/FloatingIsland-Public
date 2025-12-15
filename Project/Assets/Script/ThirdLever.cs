using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdLever : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float speed = 0.1F;
    public Transform Player;
    public AudioSource levers;

    [SerializeField]
    private Text leverText;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);

        if (dist <= 4f)
        {
            leverText.text = "(U) 버튼을 눌러 레버를 당기시오";

            if (Input.GetKeyDown(KeyCode.U))
            {
                leverText.gameObject.SetActive(false);
                levers.Play();
                from.rotation = to.rotation;
                Debug.Log("문 열림");

                GameObject.Find("S7_Trigger6").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이더를 enable하여 OnTriggerEnter되게 함 
                GameObject.Find("spaceDoor").GetComponent<DoorOpen>().isOperate = true;
                
            }
        }
    }
}
