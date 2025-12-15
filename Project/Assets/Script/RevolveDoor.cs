using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveDoor : MonoBehaviour
{
    public GameObject Door;

    void OnTriggerStay()
    {
        Door.transform.rotation *= Quaternion.AngleAxis(30.0f * Time.deltaTime, new Vector3(0, 0, 1));
    }
}
