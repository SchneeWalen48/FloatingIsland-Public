using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Darken : MonoBehaviour
{

    // 2021.06.14 created by HY
    // Needs : Trigger, Intensity value

    public float emissionIntensity = 0; // hy : 물체들의 빛나는 정도 지정

    private GameObject crystals; //  hy : emission down 시킬 크리스탈 parent
    private GameObject cave; // hy : 동굴 오브젝트 담음
    private Renderer[] renderers; // hy : renderer들 담을 배열
    // private Light[] lights; // hy : 라이트 모두 여기에 담음

    // Start is called before the first frame update
    void Start()
    {
        crystals = GameObject.Find("Cave Crystal");
        cave = GameObject.Find("Cave");
        renderers = crystals.transform.GetComponentsInChildren<Renderer>(); // hy : emission down 시킬 객체들 모두 여기 담음


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // 플레이어가 들어가 있는 동안 계속 실행돼야함(변수가 true가 되는 순간을 캐치해야 하므로)
    {
        if (other.tag == "Player")
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.material.SetColor("_EmissionColor", renderer.material.color * emissionIntensity);
                cave.transform.GetComponent<Renderer>().material.SetColor("_EmissionColor", cave.GetComponent<Renderer>().material.color * emissionIntensity * 3);
                //Debug.Log(renderer.material.color);
            }
        }

    }
}
