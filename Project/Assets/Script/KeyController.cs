using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    CodeLock codeLock;

    int reachRange = 100;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
            Debug.Log("누를때 마다 소리");
        }
    }
 

    void CheckHitObj() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, reachRange))
        {
            codeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

            if (codeLock != null)
            {
                string value = hit.transform.name;
                codeLock.SetValue(value);
            }
        }
    }
}
