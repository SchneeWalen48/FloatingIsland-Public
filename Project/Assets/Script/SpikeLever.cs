using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeLever : MonoBehaviour
{

    public Transform from;
    public Transform to;
    public float speed = 0.1F;
    public Transform Player;
    public AudioSource lever;

    [SerializeField]
    private Text leverText;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);

        if (dist <= 4f)
        {
            leverText.gameObject.SetActive(true);
            leverText.text = "(U) 버튼을 눌러 레버를 당기시오";

            if (Input.GetKeyDown(KeyCode.U))
            {
                lever.Play();
                leverText.text = "";
                leverText.gameObject.SetActive(false);
                from.rotation = to.rotation;
                Debug.Log("실험실 2 문 열림");
                GameObject.Find("secondlabDoor").GetComponent<DoorOpen>().isOperate = true;
                GameObject.Find("S4_Trigger6").GetComponent<BoxCollider>().enabled = true; // hy : 박스 콜라이드를 enable 시켜서 OnTriggerEnter시작되게 함

            }
        }
    }
}
