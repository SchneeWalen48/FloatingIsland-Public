using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSlot : MonoBehaviour
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
        }
        else
        {
            image.enabled = true;//아이템이 존재하므로 이미지가 보여짐
            gameObject.name = item.name;
            image.sprite = item.sprite;
        }
    }
    private void Update()
    {
    
    }

    public void OnclickBook()
    {
        if (item.name.Equals("book1"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookOne();
        }

        else if (item.name.Equals("book2"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookTwo();
        }

        else if (item.name.Equals("book3"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookThree();
        }

        else if (item.name.Equals("book4"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookFour();
        }

        else if (item.name.Equals("book5"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookFive();
        }

        else if (item.name.Equals("book6"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookSix();
        }

        else if (item.name.Equals("book7"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookSeven();
        }

        else if (item.name.Equals("book8"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookEight();
        }

        else if (item.name.Equals("book9"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookNine();
        }

        else if (item.name.Equals("book10"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookTen();
        }

        else if (item.name.Equals("book11"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookEleven();
        }

        else if (item.name.Equals("book12"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookTwelve();
        }

        else if (item.name.Equals("book13"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookThirteen();
        }

        else if (item.name.Equals("book14"))
        {
            GameObject.Find("BookBuffer").GetComponent<Books>().BookFourteen();
        }
    }
   



}
