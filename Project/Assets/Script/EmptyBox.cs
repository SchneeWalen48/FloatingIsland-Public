using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBox : MonoBehaviour
{
    public GameObject Boxx;
    public Transform playerr;
    public Camera theCameraa;
    [SerializeField]
    public GameObject go_BoxInvenBasee;
    public GameObject go_InvenBasee;
    public GameObject go_BookUII;

    private RaycastHit hitinfoo;//충돌체 정보 저장.
    public AudioSource openn;
    public AudioSource closee;

    // Update is called once per frame
    void Update()
    {

        Ray ray = theCameraa.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hitinfoo))
        {
            Debug.DrawLine(playerr.position, hitinfoo.transform.position, Color.red);
            if (hitinfoo.transform.gameObject.layer == LayerMask.NameToLayer("emptybox"))//레이어를 바꿔줘야지 일반 상자와 다르게 상자 인벤이 열림.
            {;
                if (GameManager.isOpenBoxInven == false)//이거 넣어야 박스 인벤 열린 상태에서 상자 열고 닫는 소리 안남. 
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Boxx.SetActive(Boxx.active);
                        OpenBoxInven();
                        openn.Play();
                        GameManager.isOpenInventory = true;
                        go_BookUII.gameObject.SetActive(false);


                    }
                }

                else if (Input.GetMouseButtonDown(1))
                {
                    closee.Play();
                    Boxx.SetActive(!Boxx.active);
                    CloseBoxInven();
                    GameManager.isOpenInventory = false;
                    go_BookUII.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OpenBoxInven()
    {
        GameManager.isOpenBoxInven = true;
        GameManager.isOpenInventory = true;
        go_BoxInvenBasee.SetActive(true);//인벤토리 베이스가 활성화 된 상태
        go_InvenBasee.SetActive(true);

    }
    public void CloseBoxInven()
    {
        GameManager.isOpenBoxInven = false;
        GameManager.isOpenInventory = false;
        go_BoxInvenBasee.SetActive(false);//인벤토리 베이스가 활성화 된 상태
        go_InvenBasee.SetActive(false);

    }
}
