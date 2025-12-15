using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;//아이템 습득 가능한 최대 거리

    private bool pickupActivated = false;//습득 가능할 시 true.

    private RaycastHit hitinfo;//충돌체 정보 저장.

    [SerializeField]
    private LayerMask layerMask;//땅을 바라보고 있을 때 획득되면 안되므로 아이템 레이어에만 반응하도록 레이어 마스크를 설정.

    [SerializeField]
    private Text actionText;

    [SerializeField]
    private Inventory theInventory;

    public Transform a1;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitinfo))
        {
            if (hitinfo.transform.tag == "item")
            {
                if (GameObject.Find("a2_9").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_10").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_11").GetComponent<Altar>().isAltarEnter
                    || GameObject.Find("a2_12").GetComponent<Altar>().isAltarEnter || GameObject.Find("a2_13").GetComponent<Altar>().isAltarEnter == true)
                {
                    Debug.Log("정보 안나타남");
                    ItemInfoDisappear();
                }
                ItemInfoAppear();
            }

            else 
            {
                ItemInfoDisappear();
            }
        }



    //CheckItem();
    TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //CheckItem();
            CanPickUp();
        }
    }

    //private void CheckItem()
    //{
    //if(Physics.Raycast(transform.position, transform.forward, out hitinfo, range, layerMask))
    //{
    //if (hitinfo.transform.tag == "Item")
    //{
    // ItemInfoAppear();//아이템의 정보를 띄움. 
    //Debug.Log("아이템 찾음");
    //}
    //}
    //else
    //ItemInfoDisappear();
    //}

    public void ItemInfoAppear()
    {
        Debug.Log("아이템 찾음");
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득" + "<color=yellow>" + "(E)" + "</color>";

    }

    public void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitinfo.transform != null)
            {
                Debug.Log(hitinfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다.");  // 인벤토리 넣기
                theInventory.AquireItem(hitinfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitinfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
