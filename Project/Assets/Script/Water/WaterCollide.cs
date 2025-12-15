using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollide : MonoBehaviour
{
    public Transform greenHammer;
    public Transform greenWater;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 velo = Vector3.zero;

        greenHammer.position = Vector3.SmoothDamp(greenHammer.position, greenWater.position , ref velo , 0.009f);

        Debug.Log("유리깨지는 소리");
    }
}
