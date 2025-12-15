using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject go_BaseUI; // 일시 정지 UI 패널
    [SerializeField] private SaveNLoad theSaveNLoad;
    private PlayerController player;
    bool isSound;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        isSound = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.isPause)
                CallMenu();
            else
                CloseMenu();
        }
    }

    private void CallMenu()
    {
        GameManager.isPause = true;
        go_BaseUI.SetActive(true);
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
        //player.enabled = false;
    }

    private void CloseMenu()
    {
        GameManager.isPause = false;
        go_BaseUI.SetActive(false);
        Time.timeScale = 1f; // 1배속 (정상 속도)
        //player.enabled = true;
    }

    public void ClickSave()
    {
        Debug.Log("세이브");
        theSaveNLoad.SaveData();
    }

    public void ClickLoad()
    {
        Debug.Log("로드");
        theSaveNLoad.LoadData();
    }

    public void ClickSound()
    {
        if (isSound)
        {
            isSound = !isSound;
            Debug.Log("소리 끔");
            AudioListener.volume = 0;
        }
        else
        {
            isSound = !isSound;
            Debug.Log("소리 켬");
            AudioListener.volume = 1;
        }
    }

    public void ClickTitle()
    {
        Debug.Log("타이틀");
        SceneManager.LoadScene("TitleNoTimeLine");
    }

}
