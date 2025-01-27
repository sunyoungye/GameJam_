using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision_Water : MonoBehaviour
{
    public float updatedWatering;

    public Image waterFill;
    public float maxWaterFill;

    public GameObject wateringCan;
    public GameObject flower;

    void Update()
    {
        waterFill.fillAmount = updatedWatering / maxWaterFill;
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            updatedWatering = updatedWatering - 50;
        }
    }
}
