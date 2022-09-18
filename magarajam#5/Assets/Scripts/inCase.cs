using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCase : MonoBehaviour
{
    public GameObject marketElements;
    public customerController customerController;
    void Update()
    {
        if (customerController.inCash == false)
        {
            marketElements.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (customerController.inCash == true)
            {
                marketElements.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            marketElements.SetActive(false);
        }
    }
}
