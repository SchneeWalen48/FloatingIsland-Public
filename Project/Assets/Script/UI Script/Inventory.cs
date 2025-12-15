using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    //필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;//부모 객체(안의 슬롯 전체)

    [SerializeField]
    private GameObject go_BookSlotsParent;//부모 객체(안의 슬롯 전체)

    [SerializeField]
    private Slot[] slots;

    [SerializeField]
    public static List<BookSlot> bookSlots;

    public Transform slotRoot;

    private ItemProperty itemProperty;

    public GameObject BookInven;
    public Box box;
    public GameObject BookUI;

    public Transform BookslotRoot;//slot 오브젝트들

    public Slot[] GetSlots() { return slots; }

    [SerializeField] private Item[] items;
    public void LoadToInven(int _arrayNum, string _itemName, int _itemNum)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemName == _itemName)
            {
                if (slots[i] != null)
                {
                    slots[_arrayNum].AddItem(items[i], _itemNum);
                }
            }
        }
    }

    public void ClearAllSlots()
    {
        for (int j = 0; j < slots.Length; j++)
        {
            slots[j].ClearSlot();
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();//이 배열 안에 모든 슬롯들이 다 들어가게 됨
        int slotCount = slotRoot.childCount;
        for (int i = 0; i < slotCount; i++)
        {
            var boxSlot = slotRoot.GetChild(i).GetComponent<BoxSlot>();
        }

        box.onSlotClick += InputItem;
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    void InputItem(ItemProperty item)
    {
        bookSlots = new List<BookSlot>();
        if (item.itemType == Item.ItemType.Book)//아이템 타입이 책인 경우에
        {
            int BookslotCount = BookslotRoot.childCount;//책 슬롯 개수 = 20

            for (int i = 0; i < BookslotCount; i++)//0부터 20까지 증가하면서 돌아
            {
                var bookSlot = BookslotRoot.GetChild(i).GetComponent<BookSlot>();//책 슬롯의 0번부터 가져와

                if (bookSlot.item.name == "")
                {
                    bookSlot.SetItem(item);//그 슬롯에 아이템을 넣어
                    bookSlot.GetComponent<UnityEngine.UI.Button>().interactable = true;//그 슬롯의 버튼을 활성화해 그래야 책 페이지가 보이니까
                    bookSlots.Add(bookSlot);
                    return;                    
                }
                /*else
                {
                    var nextBookSlot = BookslotRoot.GetChild(i + 1).GetComponent<BookSlot>();
                    nextBookSlot.SetItem(item);
                    nextBookSlot.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    bookSlots.Add(nextBookSlot);
                    return;
                }*/

            }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)//슬롯의 해당 인덱스에 빈자리가 있으면,
                {
                    slots[i].AddItem(new Item(item.name, item.sprite, item.itemType, item.itemPrefab)); // hy : [i]가 빠졌음,,, itemProperty 타입을 Item 타입으로 바꿔서 Add
                    return;
                }
            }
        }

    }
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))//I 버튼을 누르면 인벤토리 창이 열림.
        {
            inventoryActivated = !inventoryActivated; //true면 false로, false면 true로 바꿔줌.

            if (inventoryActivated)
                OpenInventory();//활성화 되면 창 열어
            else
                CloseInventory();// 활성화 안되면 창 닫아
        }
    }

    private void OpenInventory()
    {
        GameManager.isOpenInventory = true;
        go_InventoryBase.SetActive(true);//인벤토리 베이스가 활성화 된 상태
        BookInven.gameObject.SetActive(false);
        BookUI.gameObject.SetActive(false);

    }

    private void CloseInventory()
    {
        GameManager.isOpenInventory = false;
        go_InventoryBase.SetActive(false);//인벤토리 베이스가 활성화 되지 않은 상태
        BookUI.gameObject.SetActive(true);
    }

    public void AquireItem(Item _item, int _count = 1)//획득한 아이템을 인벤토리에 넣는 코드
    {
        if (Item.ItemType.Book != _item.itemType)//장비 아이템인 경우에는 개수 증가가 아니고 새 슬롯에 채워지므로 장비 아닌 경우에만 다음 반복문 돌게 함.(이 부분은 장비가 아니라 다른걸로 변경)
        {
            for (int i = 0; i < slots.Length; i++)//슬롯의 길이만큼 반복문을 돌아
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)//슬롯의 해당 인덱스의 아이템 이름이 파라미터의 아이템 이름과 일치하면(슬롯 안에 이미 이 아이템이 있으면)
                    {
                        slots[i].SetSlotCount(_count);//슬롯이 증가하지 않고 해당 아이템의 개수가 증가함.
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)//슬롯의 해당 인덱스에 빈자리가 있으면,
            {
                slots[i].AddItem(_item, _count);//그 빈자리에 파라미터의 아이템과 그 아이템의 개수를 채워줌.
                return;
            }
        }
    }
}

