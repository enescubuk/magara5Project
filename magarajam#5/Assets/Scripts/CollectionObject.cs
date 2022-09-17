using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionObject : MonoBehaviour
{
    private int dust, metilamin, sudafed, B69k, K57s,ilac;
    public GameObject dustTable, metiTable, sudaTable,k57sTable,b69kTable,ilacTable;
    private bool dustCont, metiCont, sudaCont,ilacCont;
    void Update()
    {
        Combiningk57s();
        Combiningb69k();
        
    }

    private void PrintName(GameObject go)
    {
        if (gameObject.tag == "Dust")
        {
            Debug.Log("flskgjdf");
        }
        print(go.name);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dust2"))
        {
             
            if (Input.GetKey(KeyCode.R))
            {
                dust += 1;
                dustTable.SetActive(false);
            }
            
        }
        if (other.gameObject.CompareTag("Metilamin2"))
        {
            if (Input.GetKey(KeyCode.R))
            {
                metilamin += 1;
                metiTable.SetActive(false);  
            }
            
        }
        if (other.gameObject.CompareTag("Sudafed2"))
        {
            if (Input.GetKey(KeyCode.R))
            {
                sudafed += 1;
                sudaTable.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("Ilac2"))
        {
            if (Input.GetKey(KeyCode.R))
            {
                ilac += 1;
                ilacTable.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dust"))
        {
            dust += 1;
        }
        if (other.gameObject.CompareTag("Metilamin"))
        {
            metilamin += 1;
        }
        if (other.gameObject.CompareTag("Sudafed"))
        {
            sudafed += 1;
        }

        if (other.gameObject.CompareTag("Ilac"))
        {
            ilac += 1;
        }
        //çöp kutusu

        if (other.gameObject.CompareTag("Trash"))
        {
            if (dust >= 1)
            {
                dust -= 1;
            }else if (metilamin >= 1)
            {
                metilamin -= 1;
            }else if (sudafed >= 1)
            {
                sudafed -= 1;
            }else if (ilac >= 1)
            {
                ilac -= 1;
            }
        }
        
        //ilaçlar
        
        if (other.gameObject.CompareTag("Combining"))
        {
            if (sudafed > 0)
            {
                sudaTable.SetActive(true);
                sudaCont = true;
                sudafed -= 1;
            }else if (metilamin > 0)
            {
                metiTable.SetActive(true);
                metiCont = true;
                metilamin -= 1;
            }else if (dust > 0)
            {
                dustTable.SetActive(true);
                dustCont = true;
                dust -= 1;
            }else if (ilac > 0)
            {
                ilacTable.SetActive(true);
                ilacCont = true;
                ilac -= 1;
            }
        }

    }

    void Combiningk57s()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (dustCont && sudaCont && metiCont)
            {
                k57sTable.SetActive(true);
                sudaTable.SetActive(false);
                metiTable.SetActive(false);
                dustTable.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            k57sTable.SetActive(false);
            K57s += 1;
        }
        
    }
    void Combiningb69k()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (ilacCont && dustCont)
            {
                b69kTable.SetActive(true);
                ilacTable.SetActive(false);
                dustTable.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            b69kTable.SetActive(false);
            B69k += 1;
        }
    }
    
    
}
