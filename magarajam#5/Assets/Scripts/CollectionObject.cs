using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionObject : MonoBehaviour
{
    [Header("İLAÇLAR")]
    private int dust, metilamin, sudafed, B69k, K57s,ilac,ilac2;
    public GameObject dustTable, metiTable, sudaTable,k57sTable,b69kTable,ilacTable,ilacTable2;
    private bool dustCont, metiCont, sudaCont, ilacCont,ilacCont2, handControl = true;
    [Header("TARİF KİTABI")]
    public static bool recipeControl;

    [Header("HUD RESİMLER")] 
    public Image dustImage;
    public Image metilaminImage;
    public Image sudafedImage;
    public Image ilacImage;
    public Image ilac2Image;
    void Update()
    {
        Combiningk57s();
        Combiningb69k();
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
        if (other.gameObject.CompareTag("Recipe"))
        {
            recipeControl = true;
        }
        if (other.gameObject.CompareTag("Dust"))
        {
            if (metilamin == 0 && sudafed == 0 && ilac == 0 && ilac2 == 0)
            {
                dust += 1;
                if (handControl)
                {
                    TMPControl.dus -= 1;
                    handControl = false;
                }

                dustImage.gameObject.SetActive(true);
                metilaminImage.gameObject.SetActive(false);
                sudafedImage.gameObject.SetActive(false);
                ilacImage.gameObject.SetActive(false);
                ilac2Image.gameObject.SetActive(false);
            }
            

        }
        if (other.gameObject.CompareTag("Metilamin"))
        {
            if (dust == 0 && sudafed == 0 && ilac == 0 && ilac2 == 0)
            {
                metilamin += 1;
                if (handControl)
                {
                    TMPControl.meti -= 1;
                    handControl = false;
                }
            
                dustImage.gameObject.SetActive(false);
                metilaminImage.gameObject.SetActive(true);
                sudafedImage.gameObject.SetActive(false);
                ilacImage.gameObject.SetActive(false);
                ilac2Image.gameObject.SetActive(false);
            }

            
        }
        if (other.gameObject.CompareTag("Sudafed"))
        {
            if (dust == 0 && metilamin == 0 && ilac == 0 && ilac2 == 0)
            {
                sudafed += 1;
                if (handControl)
                {
                    TMPControl.suda -= 1;
                    handControl = false;
                }
                dustImage.gameObject.SetActive(false);
                metilaminImage.gameObject.SetActive(false);
                sudafedImage.gameObject.SetActive(true);
                ilacImage.gameObject.SetActive(false);
                ilac2Image.gameObject.SetActive(false);
            }

            
        }

        if (other.gameObject.CompareTag("Ilac"))
        {
            if (dust == 0 && sudafed == 0 && metilamin == 0 && ilac2 == 0)
            {
                ilac += 1;
                if (handControl)
                {
                    TMPControl.agrik -= 1;
                    handControl = false;
                }
                
                dustImage.gameObject.SetActive(false);
                metilaminImage.gameObject.SetActive(false);
                sudafedImage.gameObject.SetActive(false);
                ilacImage.gameObject.SetActive(false);
                ilac2Image.gameObject.SetActive(true);
            }
            
        }
        
        if (other.gameObject.CompareTag("Ilac3"))
        {
            if (dust == 0 && sudafed == 0 && ilac == 0 && metilamin == 0)
            {
                ilac2 += 1;
                if (handControl)
                {
                    TMPControl.atesd -= 1;
                    handControl = false;
                }
                
                dustImage.gameObject.SetActive(false);
                metilaminImage.gameObject.SetActive(false);
                sudafedImage.gameObject.SetActive(false);
                ilacImage.gameObject.SetActive(true);
                ilac2Image.gameObject.SetActive(false); 
            }
           
        }
        //çöp kutusu

        if (other.gameObject.CompareTag("Trash"))
        {
            if (dust >= 1)
            {
                dust -= 1;
                handControl = true;
                dustImage.gameObject.SetActive(false);
            }else if (metilamin >= 1)
            {
                metilamin -= 1;
                handControl = true;
                metilaminImage.gameObject.SetActive(false);
            }else if (sudafed >= 1)
            {
                sudafed -= 1;
                handControl = true;
                sudafedImage.gameObject.SetActive(false);
            }else if (ilac >= 1)
            {
                ilac -= 1;
                handControl = true;
                ilac2Image.gameObject.SetActive(false);
            }else if (ilac2 >= 1)
            {
                ilac2 -= 1;
                handControl = true;
                ilacImage.gameObject.SetActive(false); 
            }
        }
        
        //ilaçlar
        
        if (other.gameObject.CompareTag("Combining"))
        {
            if (sudafed > 0)
            {
                if (!sudaTable.activeSelf)
                {
                    handControl = true;
                }
                sudaTable.SetActive(true);
                sudaCont = true;
                sudafed -= 1;
                //sudafedImage.gameObject.SetActive(false);
                
            }else if (metilamin > 0)
            {
                if (!metiTable.activeSelf)
                {
                    handControl = true;
                }
                metiTable.SetActive(true);
                
                metiCont = true;
                metilamin -= 1;
                //metilaminImage.gameObject.SetActive(false);
                
            }else if (dust > 0)
            {
                if (!dustTable.activeSelf)
                {
                    handControl = true;
                }
                dustTable.SetActive(true);
                dustCont = true;
                dust -= 1;
                // dustImage.gameObject.SetActive(false);
                
            }else if (ilac > 0)
            {
                if (!ilacTable.activeSelf)
                {
                    handControl = true;
                }
                ilacTable.SetActive(true);
                ilacCont = true;
                ilac -= 1;
                //ilacImage.gameObject.SetActive(false);
                
            }else if (ilac2 > 0)
            {
                if (!ilacTable.activeSelf)
                {
                    handControl = true;
                }
                ilacTable2.SetActive(true);
                ilacCont2 = true;
                ilac2 -= 1;
                //ilac2Image.gameObject.SetActive(false); 
                
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
