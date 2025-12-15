using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffChildrenLight : MonoBehaviour
{
    // 2021.05.17 created by HY
    // Needs : Trigger

    private Light[] lights; // hy : 발판을 밟을 때, 꺼질 포인트 라이트 모두 여기에 담음
    private Renderer[] renderers; // hy : emission off 시킬 객체들 모두 여기 담음

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lights = gameObject.transform.GetComponentsInChildren<Light>(); // hy : 자식의 Light 컴포넌트들을 모두 담음
            renderers = gameObject.transform.GetComponentsInChildren<Renderer>(); // hy : 자식의 renderer들 모두 담음

            foreach (Light light in lights)
            {
                light.enabled = false;
            }
            foreach (Renderer renderer in renderers)
            {
                renderer.material.DisableKeyword("_EMISSION"); // hy : 자식들의 material에 하나씩 접근하여 emission을 off시킴
                renderer.material.shader = Shader.Find("Standard"); // hy : 쉐이더를 바꿔버림(베이직으로)

                renderer.material.color = new Color(0f, 0f, 0f, 0.5f); // hy : 바꾼 쉐이더의 색을 블랙으로 함
            }
        }
    }
}
