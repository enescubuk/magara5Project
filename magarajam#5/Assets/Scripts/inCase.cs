using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCase : MonoBehaviour
{
    public GameObject marketElements;
    public customerController customerController;
    public bool canSell;
    void Update()
    {
        if (customerController.inCash == false)
        {
            marketElements.SetActive(false);
        }
        if (canSell == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                customerController.selling();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (customerController.inCash == true)
            {
                marketElements.SetActive(true);
                canSell = true;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("adsasdasd");
            marketElements.SetActive(true);
        }

        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            marketElements.SetActive(false);
            canSell = false;
        }
    }
}
