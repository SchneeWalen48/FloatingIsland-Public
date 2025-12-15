using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotate : MonoBehaviour
{
    void Start()
    {
        if (gameObject.name == "hourHand")
        {
            StartCoroutine(TimeRotation(this.gameObject, 3600f, 6f));
        }

        else if (gameObject.name == "minuteHand")
        {
            StartCoroutine(TimeRotation(this.gameObject, 63f, 6f));
        }

        else if (gameObject.name == "secondHand")
        {
            StartCoroutine(TimeRotation(this.gameObject, 1f, 6f));
        }
    }

   
    void Update()
    {
        
    }

    IEnumerator TimeRotation(GameObject target, float time, float yAngle)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            target.transform.Rotate(0, yAngle, 0);
        }

    }
}
