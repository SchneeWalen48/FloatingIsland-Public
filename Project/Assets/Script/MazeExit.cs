using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().jumpForce = 5;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().runSpeed = 20;
            Debug.Log("Επΐε");
        }

    }
}
