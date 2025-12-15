using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoorOpen : MonoBehaviour
{
    public Transform Player;

    void Update()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);
        if (dist < 10f) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                if (gameObject.name == "jackHDoor")
                {
                    jackDoorOpen();
                }
                else if (gameObject.name == "lunaHDoor")
                {
                    lunaDoorOpen();
                }
            }
        }
    }

    public void jackDoorOpen() 
    {
        Debug.Log("잭집문");
        gameObject.transform.localEulerAngles = new Vector3(-90, 180, 10);
    }

    public void lunaDoorOpen()
    {
        Debug.Log("루나집문");
        gameObject.transform.localEulerAngles = new Vector3(-90, 0, 130);
    }
}
