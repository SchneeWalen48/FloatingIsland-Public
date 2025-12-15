using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNumber : MonoBehaviour
{
    private bool activated = false;

    [SerializeField]
    private Text text_Preview;
    [SerializeField]
    private Text text_Input;
    [SerializeField]
    private InputField if_text;

    [SerializeField]
    private GameObject go_Base;//항상 활성화 되는게 아니므로 불필요할 때 꺼줌. 

    [SerializeField]
    public Image image;

    [SerializeField]
    private ActionController thePlayer;

    public Transform a1;//제단 위에 있는 박스 콜라이더
    public Transform a2;
    public Transform a3;
    public Transform a4;
    public Transform a5;
    public Transform a6;
    public Transform a7;
    public Transform a8;
    public Transform a9;
    public Transform a10;
    public Transform a11;
    public Transform a2_1;
    public Transform a2_2;
    public Transform a2_3;
    public Transform a2_4;
    public Transform a2_5;
    public Transform a2_6;
    public Transform a2_7;
    public Transform a2_8;
    public Transform a2_9;
    public Transform a2_10;
    public Transform a2_11;
    public Transform a2_12;
    public Transform a2_13;
    public Transform a2_14;
    public Transform a2_15;
    public Transform a3_1;
    public Transform a3_2;
    public Transform a3_3;
    public Transform a3_4;
    public Transform a3_5;


    void Update()
    {
        if (activated)
        {
            if (Input.GetKeyDown(KeyCode.Return))//엔터 치면 ok버튼 누른 효과
                OK();
            else if (Input.GetKeyDown(KeyCode.Escape))//esc 누르면 취소버튼 누른 효과
                Cancel();
        }
    }

    public void Call()//다른 곳에서 부르면 이걸 띄움.
    {
        image.gameObject.SetActive(true);
        go_Base.SetActive(true);//화면 뜨게 함. 
        activated = true;
        if_text.text = "";
        text_Preview.text = DragSlot.instance.dragSlot.itemCount.ToString();//호출하자마자 아이템의 최대 개수가 넣어짐. 
    }

    public void Cancel()
    {
        image.gameObject.SetActive(false);
        activated = false;//취소하면 창 사라지고
        DragSlot.instance.SetColor(0);//드래그 색 변경
        go_Base.SetActive(false);//인벤 창 사라짐.
        DragSlot.instance.dragSlot = null;
    }

    public void OK()//ok버튼 눌렀을 때.
    {
        DragSlot.instance.SetColor(0);

        int num;
        if (text_Input.text != "")//공백이 아니고
        {
            if (CheckNumber(text_Input.text))//숫자인지 아닌지 체크함. -> 숫자면 다음의 내용 수행
            {
                num = int.Parse(text_Input.text);
                if (num > DragSlot.instance.dragSlot.itemCount)//가진 아이템의 숫자보다 큰 것을 버리려고 하면 개수가 최대로 맞춰짐. 
                    num = DragSlot.instance.dragSlot.itemCount;
            }
            else
                num = 1;//숫자 외의 문자이면 1로 처리.
        }
        else
            num = int.Parse(text_Preview.text);//아무것도 적지 않았을 때는 텍스트 프리뷰의 최대 개수를 넘겨줌.

        StartCoroutine(DropItemCorountine(num));//하나씩 빠르게 떨어뜨리도록 코루틴 함수 실행. 
    }

    IEnumerator DropItemCorountine(int _num)//다음의 코루틴 함수 실행.
    {
        float dist1 = Vector3.Distance(GameObject.Find("altar1").transform.position, thePlayer.transform.position);
        float dist2 = Vector3.Distance(GameObject.Find("altar2").transform.position, thePlayer.transform.position);
        float dist4 = Vector3.Distance(GameObject.Find("altar4").transform.position, thePlayer.transform.position);
        float dist3 = Vector3.Distance(GameObject.Find("altar3").transform.position, thePlayer.transform.position);
        float dist6 = Vector3.Distance(GameObject.Find("altar6").transform.position, thePlayer.transform.position);
        float dist5 = Vector3.Distance(GameObject.Find("altar5").transform.position, thePlayer.transform.position);
        float dist7 = Vector3.Distance(GameObject.Find("altar7").transform.position, thePlayer.transform.position);
        float dist8 = Vector3.Distance(GameObject.Find("altar8").transform.position, thePlayer.transform.position);
        float dist2_1 = Vector3.Distance(GameObject.Find("altar2_1").transform.position, thePlayer.transform.position);
        float dist2_2 = Vector3.Distance(GameObject.Find("altar2_2").transform.position, thePlayer.transform.position);
        float dist2_3 = Vector3.Distance(GameObject.Find("altar2_3").transform.position, thePlayer.transform.position);
        float dist2_4 = Vector3.Distance(GameObject.Find("altar2_4").transform.position, thePlayer.transform.position);
        float dist2_5 = Vector3.Distance(GameObject.Find("altar2_5").transform.position, thePlayer.transform.position);
        float dist2_6 = Vector3.Distance(GameObject.Find("altar2_6").transform.position, thePlayer.transform.position);
        float dist2_7 = Vector3.Distance(GameObject.Find("altar2_7").transform.position, thePlayer.transform.position);
        float dist2_8 = Vector3.Distance(GameObject.Find("altar2_8").transform.position, thePlayer.transform.position);
        float dist2_9 = Vector3.Distance(GameObject.Find("altar2_9").transform.position, thePlayer.transform.position);
        float dist3_1 = Vector3.Distance(GameObject.Find("altar3_1").transform.position, thePlayer.transform.position);
        float dist3_2 = Vector3.Distance(GameObject.Find("altar3_2").transform.position, thePlayer.transform.position);
        float dist3_3 = Vector3.Distance(GameObject.Find("altar3_3").transform.position, thePlayer.transform.position);
        float dist3_4 = Vector3.Distance(GameObject.Find("altar3_4").transform.position, thePlayer.transform.position);
        float dist3_5 = Vector3.Distance(GameObject.Find("altar3_5").transform.position, thePlayer.transform.position);

        if (dist1 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a1.transform.position,//a1으로 떨굼. 
                    a1.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2.transform.position,//a1으로 떨굼. 
                     a2.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist4 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3.transform.position,//a1으로 떨굼. 
                     a3.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist3 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a4.transform.position,//a1으로 떨굼. 
                     a4.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist6 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a5.transform.position,//a1으로 떨굼. 
                     a5.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist5 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a6.transform.position,//a1으로 떨굼. 
                     a6.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist7 <= 3.5f)
        {
            Debug.Log(DragSlot.instance.dragSlot.item.itemName);
            if (DragSlot.instance.dragSlot.item.itemName == "white_sblood")
            {
                Debug.Log("흰피");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a7.position,//a1으로 떨굼. 
                         a7.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "yellow_sblood")
            {
                Debug.Log("노란피");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a8.transform.position,//a1으로 떨굼. 
                         a8.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "black_sblood")
            {
                Debug.Log("검정피");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a9.transform.position,//a1으로 떨굼. 
                         a9.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "blue_sblood")
            {
                Debug.Log("파란피");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a10.transform.position,//a1으로 떨굼. 
                         a10.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }
        }
       
        else if (dist8 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a11.transform.position,//a1으로 떨굼. 
                     a11.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_1 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_1.transform.position,//a1으로 떨굼. 
                     a2_1.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_2 <= 9.5f)
        {
            Debug.Log(DragSlot.instance.dragSlot.item.itemName);
            if (DragSlot.instance.dragSlot.item.itemName == "magic_red")
            {
                Debug.Log("빨강");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_2.position,//a1으로 떨굼. 
                         a2_2.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "magic_orange")
            {
                Debug.Log("주황");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_3.transform.position,//a1으로 떨굼. 
                         a2_3.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "magic_yellow")
            {
                Debug.Log("노랑");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_4.transform.position,//a1으로 떨굼. 
                         a2_4.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "magic_green")
            {
                Debug.Log("초록");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_5.transform.position,//a1으로 떨굼. 
                         a2_5.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "magic_blue")
            {
                Debug.Log("파랑");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_6.transform.position,//a1으로 떨굼. 
                         a2_6.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "magic_purple")
            {
                Debug.Log("보라");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_7.transform.position,//a1으로 떨굼. 
                         a2_7.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }

            else if (DragSlot.instance.dragSlot.item.itemName == "rock_hangi")
            {
                Debug.Log("한기의 돌");
                Debug.Log(DragSlot.instance.dragSlot.item.itemName);
                for (int i = 0; i < _num; i++)
                {
                    Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                        a2_8.transform.position,//a1으로 떨굼. 
                         a2_8.transform.rotation);

                    DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                    yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
                }

                DragSlot.instance.dragSlot = null;//드래그 끝난 상태
                image.gameObject.SetActive(false);
                go_Base.SetActive(false);
                activated = false;
            }
        }

        else if (dist2_3 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_9.transform.position,//a1으로 떨굼. 
                     a2_9.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_4 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_10.transform.position,//a1으로 떨굼. 
                     a2_10.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_5 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_11.transform.position,//a1으로 떨굼. 
                     a2_11.transform.rotation);
                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_6 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_12.transform.position,//a1으로 떨굼. 
                     a2_12.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_7 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_13.transform.position,//a1으로 떨굼. 
                     a2_13.transform.rotation);


                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_8 <= 7.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_14.transform.position,//a1으로 떨굼. 
                     a2_14.transform.rotation);


                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist2_9 <= 7.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a2_15.transform.position,//a1으로 떨굼. 
                     a2_15.transform.rotation);


                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist3_1 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3_1.transform.position,//a1으로 떨굼. 
                     a3_1.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist3_2 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3_2.transform.position,//a1으로 떨굼. 
                     a3_2.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist3_3 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3_3.transform.position,//a1으로 떨굼. 
                     a3_3.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else if (dist3_4 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3_4.transform.position,//a1으로 떨굼. 
                     a3_4.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
        else if (dist3_5 <= 3.5f)
        {
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    a3_5.transform.position,//a1으로 떨굼. 
                     a3_5.transform.rotation);

                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }

        else 
        {
            GameObject.Find("Show Text").transform.Find("leverText").gameObject.SetActive(false);
            for (int i = 0; i < _num; i++)
            {
                Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,
                    thePlayer.transform.position + thePlayer.transform.forward,//메인 카메라 앞에 떨굼. 
                    Quaternion.identity);
                DragSlot.instance.dragSlot.SetSlotCount(-1);//하나 떨굴 때 마다 카운트 값 하나씩 줄어듦.
                yield return new WaitForSeconds(0.05f);//잠깐 대기하는 시간. 
            }

            DragSlot.instance.dragSlot = null;//드래그 끝난 상태
            image.gameObject.SetActive(false);
            go_Base.SetActive(false);
            activated = false;
        }
    }

    private bool CheckNumber(string _argString)//숫자인지 아닌지 확인. 문자열을 받아서 확인함.
    {
        char[] _tempCharArray = _argString.ToCharArray();//문자열을 자동으로 단일 문자로 바꿈. 가나다라마바사일 경우 0번째 배열에 가 1번째 배열에 나 이런식으로 들어와서 한글자씩 숫자인지 문자인지 비교.
        bool isNumber = true;//숫자이면

        for (int i = 0; i < _tempCharArray.Length; i++)//어레이의 길이만큼 반복문을 돌아서
        {
            if (_tempCharArray[i] >= 48 && _tempCharArray[i] <= 57)//i번째가 아스키 코드에서 48-57이 10진법으로 숫자임. 이를 배열에 넣고 한글자씩 비교하면서 확인함.
                continue;//만족하면 다음 줄 무시하고 반복문 돌아
            isNumber = false;//만족하지 못하면 반복문 빠져나와 숫자 아님을 알림.
        }
        return isNumber;
    }
}