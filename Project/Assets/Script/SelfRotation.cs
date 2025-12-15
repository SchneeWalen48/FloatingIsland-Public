using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public float speed = 30.0f;         //회전속도
    private void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
    
}
