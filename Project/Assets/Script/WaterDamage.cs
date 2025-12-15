using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ต้ต้ต้");
        GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamageNone();
        if (GameManager.isWater == false)
        {
            GameManager.isWater = true;
        }
        else
        {
            GameManager.isWater = true;
        }
        Debug.Log(GameManager.isWater);
    }
}
