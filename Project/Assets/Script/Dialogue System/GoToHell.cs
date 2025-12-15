using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2021.05.17 created by HY
// Needs : Trigger

public class GoToHell : MonoBehaviour
{
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
            other.transform.position = new Vector3(-554.4f, 81.47f, 116.06f);
        }
    }
}
