using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionOn : MonoBehaviour
{
    // 2021.05.20 created by HY
    // Needs : Trigger, children who want emission

    private Renderer[] renderers; // hy : emission on 시킬 객체들 모두 여기 담음

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // hy : 트리거를 통과하면 자식 객체들의 emission on
    {
        if (other.tag == "Player")
        {
            renderers = gameObject.transform.GetComponentsInChildren<Renderer>(); // hy : 자식의 renderer들 모두 담음

            foreach (Renderer renderer in renderers)
            {
                renderer.material.EnableKeyword("_EMISSION"); // hy : 자식들의 material에 하나씩 접근하여 emission을 on시킴
            }
        }
    }
}
