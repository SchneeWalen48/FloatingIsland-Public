using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundShow : MonoBehaviour
{
    public GameObject ground;
    private void OnTriggerEnter(Collider other)
    {
        ground.gameObject.SetActive(true);
    }

}
