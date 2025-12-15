using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    public Transform Target;
    // Start is called before the first frame update
    public void StoneFall()
    {
        Invoke("First", 3f);
        Invoke("Second", 4f);
        Invoke("Third", 5f);
    }

    public void First()
    {
        Vector3 velo = Vector3.zero;
        GameObject.Find("StoneOne").transform.position = Vector3.SmoothDamp(GameObject.Find("StoneOne").transform.position, Target.position, ref velo, 0.001f);
    }

    public void Second()
    {
        Vector3 velo = Vector3.zero;
        GameObject.Find("StoneTwo").transform.position = Vector3.SmoothDamp(GameObject.Find("StoneTwo").transform.position, Target.position, ref velo, 0.001f);
    }

    public void Third()
    {
        Vector3 velo = Vector3.zero;
        GameObject.Find("StoneThree").transform.position = Vector3.SmoothDamp(GameObject.Find("StoneThree").transform.position, Target.position, ref velo, 0.001f);
    }
}
