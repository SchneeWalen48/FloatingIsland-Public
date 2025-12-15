using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timeText;
    private float time;
    public bool isTimerStart = false;

    private void Awake()
    {
        time = 180f;
    }

    public void Update()
    {
        if (time > 0 && isTimerStart)
        {
            time -= Time.deltaTime;
            timeText.text = Mathf.Ceil(time).ToString();
        }

        if (Mathf.Ceil(time).ToString() == "0")
        {
            //Debug.Log("죽는 화면으로 이어지기");
            SceneManager.LoadScene("GameOver");
            timeText.text = "";
            isTimerStart = false;
            timeText.gameObject.SetActive(false);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // hy : 플레이어가 들어오면 문 작동 On 
        {
            timeText.gameObject.SetActive(true);
            isTimerStart = true;
        }
    }
    public void TimerStop()
    {
        timeText.gameObject.SetActive(false);
    }

}
