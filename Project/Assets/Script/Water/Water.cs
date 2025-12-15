using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public AudioSource into;//오디오 소스
    public AudioSource outto;//오디오 소스

    [SerializeField] private float waterDrag;//물 속 중력
    private float originDrag;//원래의 중력으로 돌아감

    [SerializeField] private Color waterColor;//물 속 색깔
    [SerializeField] private float waterFogDensity;//물의 탁한 정도

    private Color originColor;//물의 원래 색깔
    private float originFogDensity;//물의 원래 탁한 정도

    [SerializeField] private float breathTime;
    private float currentBreathTime;

    [SerializeField] private float totalOxygen;
    private float currentOxygen;
    private float temp;

    public bool isIntoWater = false;

    [SerializeField] private GameObject go_BaseUI;//필요할 때만 보여지는 UI
    [SerializeField] private Text text_totalOxygen;
    [SerializeField] private Text text_currentOxygen;
    [SerializeField] private Image image_gauge;

    //private StatusController thePlayerStat;

    void Start()
    {
        originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;//원래의 물 색과 탁한 정도를 초기화

        originDrag = 0;//player의 rigidbody의 drag(저항력) 초기값
        currentOxygen = totalOxygen;
        text_totalOxygen.text = totalOxygen.ToString();  
    }

  
    void Update()
    {
        if (GameManager.isWater)
        {
            currentBreathTime += Time.deltaTime;
            if (currentBreathTime >= breathTime)
            {
                currentBreathTime = 0;
            }
        }
        DecreaseOxygen();
        if (!GameManager.isWater)
        {
            currentOxygen = totalOxygen;
        }
    }

    private void DecreaseOxygen()
    {
        if (GameManager.isWater)
        {
            currentOxygen -= Time.deltaTime;
            text_currentOxygen.text = Mathf.RoundToInt(currentOxygen).ToString();
            image_gauge.fillAmount = currentOxygen / totalOxygen; //물 속일 때, 산소 양이 1초에 1개씩 줄고 이미지도 백분율로 줄어듦.

            if (currentOxygen <= 0)
            {
                currentOxygen = 0;
                temp += Time.deltaTime;
                if (temp >= 1)
                {
                    GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamage();
                    temp = 0;
                    Debug.Log("산소 부족!!");
                    if (GameObject.Find("HealthController").GetComponent<HealthController>().currentHealth == 0)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                    //여기서 물 안에 들어갈 때 낙하데미지 안받게 해야하고 물 안에서 데미지 깎이고 자동 회복도 안되게 해야 함 & 물 밖에 나왔다가 다시 들어가면 게이지 다시 안차는 오류도 수정!!
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetWater(other);//플레이어 태그이면 충돌했을 때 다음의 함수 실행
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetOutWater(other);
        }
    }

    public void GetWater(Collider _player)
    {
        isIntoWater = true;
        into.Play();
        go_BaseUI.SetActive(true);
        GameManager.isWater = true;
       _player.transform.GetComponent<Rigidbody>().drag = waterDrag;//플레이어의 저항력을 물 저항력으로 바꿔줌. 저항이 높아지면서 천천히 가라앉아.

        RenderSettings.fogColor = waterColor; 
        RenderSettings.fogDensity = waterFogDensity;//물 속이므로 물의 색과 물의 탁한 정도로 바꿔줌.

        
    }

    private void GetOutWater(Collider _player)
    {
        isIntoWater = false;
        if (GameManager.isWater)
        {
            into.Stop();
            outto.Play();
            go_BaseUI.SetActive(false);
            currentOxygen = totalOxygen;
            GameManager.isWater = false;//물 밖으로 빠져나왔으므로 false로 바꿔줌
            _player.transform.GetComponent<Rigidbody>().drag = originDrag;//플레이어의 저항력을 원래의 저항력으로 바꿔줌.

            RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = originFogDensity;//물 밖이므로 원래 물의 색과 원래 물의 탁한 정도로 바꿔줌.
        }
    }
}
