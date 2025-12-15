using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    public GameObject BookInven;
    public GameObject BookUIButton;
    public GameObject inven;
    public GameObject boxinven;
    bool isActive = false;

    void Update()
    {
        if ((isActive == true) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            BookInven.SetActive(false);
            BookUIButton.SetActive(true);
            inven.SetActive(false);
            boxinven.SetActive(false);
            isActive = false;
        }
    }
    public void BookInvenActive()
    {
        BookInven.SetActive(true);
        BookUIButton.gameObject.SetActive(false);
        isActive = true;

        inven.gameObject.SetActive(false);
        boxinven.gameObject.SetActive(false);

    }
    
}
