using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public Image[] hearts;

    public Image bloodScreen;
    public AudioSource death;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                if (i + 0.5 == currentHealth)
                {
                    hearts[i].sprite = halfHeart;
                }
                else
                {
                    hearts[i].sprite = fullHeart;
                }
            }
            else 
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        if (currentHealth < maxHealth)
        {
            InvokeRepeating("RegenHealth", 7f, 7f); // regenhealth 메소드를 2초 뒤에 자동으로 실행시켜주는 인보크 함수 삽입.
        }
    }
 
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 0.5f; // 데미지 입을 때 마다 0.5 = 하트 반개씩 깎임
            StartCoroutine(ShowBloodScreen()); //데미지 입으면 화면이 피 번진 것 처럼 보이게 코루틴 함수 실행. 나중에 여기에 카메라 흔들림 넣고 싶은데 어케 연동해야 하는지 모르겠음,, 카메라 쉐이크 스크립트의 함수가 업데이트 문이라서.

            if (currentHealth < 0)
            {
                currentHealth = 0; // 하트 다 까이면 죽는 화면으로 이어지게 나중에 연결하기!
                Debug.Log("뒤짐");
                SceneManager.LoadScene("GameOver");
            }
        }

    }
    public void TakeDamageSecond()
    {
        currentHealth -= 2.0f;
        StartCoroutine(ShowBloodScreen());
 
        if (currentHealth < 0)
        {
            currentHealth = 0; // 하트 다 까이면 죽는 화면으로 이어지게 나중에 연결하기!
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamageAll()
    {
        currentHealth -= 6.0f;
        StartCoroutine(ShowBloodScreen());
        currentHealth = 0;
        SceneManager.LoadScene("GameOver");
    }

    public void TakeDamageThird()
    {
        currentHealth -= 3.0f;
        StartCoroutine(ShowBloodScreen());
        if (currentHealth < 0)
        {
            currentHealth = 0; // 하트 다 까이면 죽는 화면으로 이어지게 나중에 연결하기!
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamageNone()
    {
        currentHealth -= 0.0f;
    }
    public void Heal()
    {
        if (currentHealth > 0)
        {
            currentHealth += 0.5f; // 힐 할때마다 0.5 = 하트 반개씩 올라

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth; 
            }
        }
    }

    public void RegenHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 0.5f;
            CancelInvoke("RegenHealth"); //실행중인 인보크 함수 중지
        }
    }

    IEnumerator ShowBloodScreen()//스크린에 이미지를 출력해주는 함수를 코루틴으로 구현하기 위해서 실행.
    {
        bloodScreen.color = new Color(1, 0, 0, Random.Range(0.5F, 0.7F)); //이미지의 색은 빨강, 투명도는 0.2에서 0.3 사이의 랜덤 값을 출력.
        yield return new WaitForSeconds(0.1f); //0.1초간 이미지가 보인 후 다시 이미지를 투명하게 만듦.
        bloodScreen.color = Color.clear;
    }
}
