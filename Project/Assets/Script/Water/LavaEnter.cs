using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamageAll();
            //Debug.Log("죽는 화면으로 이어지기");
            SceneManager.LoadScene("GameOver");
        }

    }
}
