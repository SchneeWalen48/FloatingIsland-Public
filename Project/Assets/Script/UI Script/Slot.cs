using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
//클릭을 담당하는 인터페이스, 드래그 위해 마우스 좌클릭하면 발생하는 함수, 드래그를 시작했을 때 발생하는 함수, 드래그를 멈췄을 때 발생하는 함수, 마우스 클릭을 끝냈을 때 발생하는 함수
{
    private Vector3 originPos;

    public Item item; //획득한 아이템.
    public int itemCount; //획득한 아이템의 개수.
    public Image itemImage; //아이템의 이미지.
    public Transform playercam;
    public Transform arm;
    public AudioSource potionSound;
    public GameObject message;
    public GameObject pot;
    public GameObject CloseBtnn;
    public GameObject InvenBase;

    //필요한 컴포넌트
    [SerializeField]//이제 이거 쓰면 private변수라도 외부에서 접근 가능함. 데이터를 전송과 저장이 가능한 상태로 직렬화 하는 작업.
    private Text text_Count;//아이템 하나 당 얻은 개수
    [SerializeField]
    private GameObject go_CountImage;//카운트 되는 동그라미 이미지

    private List<BookSlot> bookSlots;

    private Rect baseRect;
    private InputNumber theInputNumber;


    void Start()
    {
        originPos = transform.position;//현재 플레이어의 위치
        //theWeaponManager = FindObjectOfType<WeaponManager>();
        baseRect = transform.parent.parent.GetComponent<RectTransform>().rect;//인벤토리 베이스의 rect 값을 가져옴
        theInputNumber = FindObjectOfType<InputNumber>();
    }

    private void SetColor(float _alpha)//알파값 변경을 위한 함수,아이템 이미지가 아무것도 없으면 흰 여백이 뜨는데 평상시에 알파값이 0이고 아이템 있으면 255로 초기화되므로 이미지의 투명도 조절 함수.
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;//이렇게 하면 아이템 있어도 255로 초기화 되지 않음. 
    }

    public void AddItem(Item _item, int _count = 1)//아이템 얻으면 자동으로 1이 카운트 됨. 아이템 획득 함수.
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;//아이템 형식이 sprite라서 .sprite를 하지 않으면 형변환 오류가 뜸.

        if (item.itemType != Item.ItemType.Equipment)//장비인 경우에 개수가 늘어나지 않고 칸 자체가 늘어나도록 하는건데 우리 장비 안넣으니까 이부분 빼거나 변경하기!
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        if (_count == 1)
        {
            go_CountImage.SetActive(false);
        }

        go_CountImage.SetActive(true);//아이템이 들어왔기 때문에 해당 프리팹의 active를 활성화하여 개수와 그 이미지가 화면에 보여지게 함. 
        text_Count.text = itemCount.ToString();//int타입은 텍스트로 변환이 안되므로 얻은 아이템 개수만큼 형변환함.

        SetColor(1);
    }


    public void SetSlotCount(int _count)//아이템을 사용한 경우에 슬롯이 변경되는 함수
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)//만약 아이템을 다 쓴 경우에는 슬롯 자체를 삭제
            ClearSlot();
    }

    public void ClearSlot()//슬롯 초기화 함수
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);//겉에 덮인 이미지 삭제하고 색도 투명하게 함.

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)//자동으로 구현된 인터페이스 함수(껍데기만 있음)
    {
        if (eventData.button == PointerEventData.InputButton.Right)//이 스크립트 적용된 객체에 마우스 가져대고 우클릭을 하면 다음 함수 실행
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment)//장비 타입이면 장착하는 코드
                {
                    Debug.Log("장착 아이템");
                    GameObject ball = Instantiate(item.itemPrefab, arm.transform.position, Quaternion.identity);
                    ball.transform.parent = playercam.transform;
                    ball.GetComponent<ThrowObject>().CarryItem(ball);
                    SetSlotCount(-1);

                }
                else if (item.itemType == Item.ItemType.five)
                {
                    Debug.Log("5퍼 먹음");
                    SetSlotCount(-1);
                    PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                    playerController.jumpForce = 8;
                    potionSound.Play();
                }

                else if (item.itemType == Item.ItemType.ten)
                {
                    Debug.Log("10퍼 먹음");
                    SetSlotCount(-1);
                    PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                    playerController.jumpForce = 12;
                    potionSound.Play();
                }

                else if (item.itemType == Item.ItemType.thirty)
                {
                    Debug.Log("30퍼 먹음");
                    SetSlotCount(-1);
                    PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                    playerController.jumpForce = 20;
                    potionSound.Play();
                }
                else if (item.itemType == Item.ItemType.fifty)
                {
                    Debug.Log("50퍼 먹음");
                    SetSlotCount(-1);
                    PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                    playerController.jumpForce = 30;
                    potionSound.Play();
                }
                else if (item.itemType == Item.ItemType.Paper)
                {
                    if (item.itemName == "message")
                    {
                        Debug.Log("암호 종이");
                        message.gameObject.SetActive(true);
                        CloseBtnn.gameObject.SetActive(true);
                    }

                    else if (item.itemName == "POT")
                    {
                        Debug.Log("POT 종이");
                        pot.gameObject.SetActive(true);
                        CloseBtnn.gameObject.SetActive(true);
                    }
                }
                else if (item.itemName == "key")
                {
                    float dist = Vector3.Distance(GameObject.Find("roobitHDoor").gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
                    
                    if (dist < 10f)
                    {
                        Debug.Log("루빗집 문");
                        SetSlotCount(-1);
                        GameObject.Find("roobitHDoor").gameObject.transform.localEulerAngles = new Vector3(-90, 0, 130);
                    }
                }
            }
        }
    }

    public void ClosePaper()
    {
        CloseBtnn.gameObject.SetActive(false);
        if (message.gameObject.activeSelf == true) // SetActive true인 경우에
        {
            message.gameObject.SetActive(false);
        }

        else if (pot.gameObject.activeSelf == true)
        {
            pot.gameObject.SetActive(false);
        }

        GameManager.canPlayerMove = true;
    }
    // 마우스 드래그가 시작 됐을 때 발생하는 이벤트
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
            DragSlot.instance.transform.position = eventData.position;
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        if (DragSlot.instance.transform.localPosition.x < baseRect.xMin
            || DragSlot.instance.transform.localPosition.x > baseRect.xMax
            || DragSlot.instance.transform.localPosition.y < baseRect.yMin
            || DragSlot.instance.transform.localPosition.y > baseRect.yMax)//인벤토리 베이스의 영역 밖으로 벗어난 경우
        {
            if (DragSlot.instance.dragSlot != null)
            {
                theInputNumber.Call();
            }
        }

        else
        {
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
        }
    }

    // 해당 슬롯에 무언가가 마우스 드롭 됐을 때 발생하는 이벤트
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();
    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }

}