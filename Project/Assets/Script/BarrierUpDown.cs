using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierUpDown : MonoBehaviour
{
    public Transform Player;
    public Transform desPos;
    public AudioSource upsound;
    private bool isPlay = true;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);

        if (dist <= 24f)
        {
            Debug.Log("올라간다");
            if (isPlay) { 
                upsound.Play();
                isPlay = false;
            }
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, desPos.position, ref velo, 0.2f);
        }
    }

}
