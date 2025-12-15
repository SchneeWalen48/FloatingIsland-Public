using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true;//플레이어 움직임 제어
    public static bool isOpenInventory = false; //인벤토리 활성화
    public static bool isOpenBoxInven = false;
    public static bool isPause = false; // hy :일시 정지 메뉴 비활성화

    public static bool isWater = false;//물 속인지 아닌지 판별, 외부에서도 접근이 가능해야 하므로(물 안이면 공격이나 다른거 못함) 전역변수로 선언함.
    
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)//시스템 상에서 존재하고 있지 않을 때
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }
    public Vector3 playerPos; // 플레이어의 위치 저장
    public Vector3 playerRot; // 플레이어의 회전 저장
    public string SceneName = "SampleScene";


    // 슬롯은 직렬화가 불가능. 직렬화가 불가능한 애들이 있다.
    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<int> invenItemNumber = new List<int>();

    void Update()
    {
        SceneName = SaveNLoad.saveData.SceneName;
        if (isOpenInventory)
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            canPlayerMove = false;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            canPlayerMove = true;
        }

        if (isOpenBoxInven)
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            canPlayerMove = false;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            canPlayerMove = true;
        }
        if (isOpenInventory || isOpenBoxInven || isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            canPlayerMove = false;
        }
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

}
