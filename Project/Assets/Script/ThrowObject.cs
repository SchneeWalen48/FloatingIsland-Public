using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playercam;
    public AudioSource throwmarvel;

    public float ShortThrowforce = 10;//짧게 던질 때
    public float LongThrowforce = 10;//길게 던질 때
    bool hasPlayer = false;
    bool beingCarried = false;
    private bool touched = false;
    public float DestroyTime = 3.0f;

    void Start()
    {

    }

    void Update()
    {

        // hy : 캐릭터, 카메라 위치 추가
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playercam = player.GetChild(0).transform;

        //Debug.Log(player.position);

        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        //Debug.Log(dist);
        if (dist <= 200f)
        {
            hasPlayer = true;
        }//이 거리 내에 플레이어가 존재하면 true
        else
        {
            hasPlayer = false;
        }//존재하지 않는 경우 false
        if (hasPlayer && Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playercam.transform;
            beingCarried = true;
        }//플레이어가 있고 E를 누르면 -> beingCarried가 true가 됨.
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if (Input.GetMouseButton(0))
            {
                Debug.Log("왼쪽 버튼 누름");
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playercam.transform.forward * ShortThrowforce);
            }//왼쪽 마우스 버튼 누르면 짧게 던지기.
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("L 버튼 누름");
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playercam.transform.forward * LongThrowforce);
                throwmarvel = GameObject.Find("throwsound").GetComponent<AudioSource>();
                throwmarvel.Play();
            }//L버튼을 누르면 길게 던지기.

            else if (Input.GetMouseButton(1))
            {
                Debug.Log("오른쪽 버튼 누름");
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }//오른쪽 마우스 버튼을 누르면 든거 그대로 내려둠.
        }

        /*void OnTriggerEnter()
        {
            if (beingCarried)
            {
                touched = true;
            }
        }
        */
        GameObject bball = GameObject.Find("Ball(Clone)");
        CarryItem(bball);
    }
    public void CarryItem(GameObject itemPrefab)

    {
        //Debug.Log(itemPrefab);
        //itemPrefab.GetComponent<Rigidbody>().isKinematic = true;

        //itemPrefab.transform.SetParent(playercam.transform);
        //GameObject Ball = Resources.Load("Prefabs/Ball") as GameObject;
        //GameObject instance = PrefabUtility.InstantiatePrefab(Ball) as GameObject;
        //Debug.Log(instance);
        //instance.transform.parent = playercam.transform;
        //beingCarried = true;
        //GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent = playercam.transform;
        //itemPrefab.transform.SetParent(playercam.transform);
        //itemPrefab.transform.parent = playercam.transform;
        //beingCarried = true;
        if (Input.GetMouseButton(0))
        {
            Debug.Log("왼쪽 버튼 누름");
            itemPrefab.GetComponent<Rigidbody>().isKinematic = false;
            itemPrefab.transform.parent = null;
            beingCarried = false;
            itemPrefab.GetComponent<Rigidbody>().AddForce(playercam.transform.forward * ShortThrowforce);
        }//왼쪽 마우스 버튼 누르면 짧게 던지기.
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L 버튼 누름");
            itemPrefab.GetComponent<Rigidbody>().isKinematic = false;
            itemPrefab.transform.parent = null;
            beingCarried = false;
            itemPrefab.GetComponent<Rigidbody>().AddForce(playercam.transform.forward * LongThrowforce);
            throwmarvel = GameObject.Find("throwsound").GetComponent<AudioSource>();
            throwmarvel.Play();
            Destroy(itemPrefab, DestroyTime);// 두번째 공 던지는거 안던져진게 기존꺼가 남아있어서 였기 때문에 3초뒤에 인스턴스된 프리팹이 자동으로 파괴되도록 설정함.
        }
  
    
        //L버튼을 누르면 길게 던지기.

        else if (Input.GetMouseButton(1))
        {
            Debug.Log("오른쪽 버튼 누름");
            itemPrefab.GetComponent<Rigidbody>().isKinematic = false;
            itemPrefab.transform.parent = null;
            beingCarried = false;
        }//오른쪽 마우스 버튼을 누르면 든거 그대로 내려둠.
    }
    
}

