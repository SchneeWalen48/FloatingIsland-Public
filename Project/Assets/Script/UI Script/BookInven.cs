using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInven : MonoBehaviour
{
    public Transform rootSlot;

    [SerializeField]
    public static List<BookSlot> bookSlots;
    //public Box box;
    public GameObject BookIv;
    public GameObject BookUIButton;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        int slotCnt = rootSlot.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BookUIButton.SetActive(true);
            isActive = false;
            BookIv.SetActive(false);
        }
    }
    /*
    public void SetBook()
    {
        Debug.Log("Ã¥µé¾î¿È");
        bookSlots = new List<BookSlot>();

        int slotCount = rootSlot.childCount;
        for (int i = 0; i < slotCount; i++)
        {
            var bookSlot = rootSlot.GetChild(i).GetComponent<BookSlot>();

            if (i < )
            {
                bookSlot.SetItem(bookSlots);
                bookSlot.GetComponent<UnityEngine.UI.Button>().interactable = true;
            }

            else 
            {
                bookSlot.image.enabled = false;
                bookSlot.item = null;
                bookSlot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
            bookSlots.Add(bookSlot);
           
        }

    }*/


}
