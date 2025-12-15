using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSlot : MonoBehaviour
{
    [HideInInspector]//인스펙터 창에서 안보이게 함
    public ItemProperty item;

    public UnityEngine.UI.Image image;

    public void SetItem(ItemProperty item)//아이템을 받아서 넣어주는 함수
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;//아이템이 존재하지 않으므로 빈 이미지
            gameObject.name = "Empty";
            Debug.Log("없어");
        }
        else
        {
            image.enabled = true;//아이템이 존재하므로 이미지가 보여짐

            gameObject.name = item.name;
            image.sprite = item.sprite;
        }
    }
}



 
