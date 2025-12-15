using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public AudioSource itemin;
    public bool isAltarEnter = false; 
    public string itemName = "";
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "들어옴");
        
        if (other.name == itemName)
        {
            itemin.Play();
            isAltarEnter = true; // hy : altar가 잘 들어왔으면 변수를 true로 바꿔줌
            Debug.Log("잘들어옴");
            
        }
    }
}
