using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CollectionObject : MonoBehaviour
{
    [Header("İLAÇLAR")]
    private int dust, metilamin, sudafed, B69k, K57s,ilac,ilac2;
    public GameObject dustTable, metiTable, sudaTable,k57sTable,b69kTable,ilacTable,ilacTable2;
    private bool dustCont, metiCont, sudaCont, ilacCont,ilacCont2, handControl = true;
    public GameObject go1, go2, go3, go4, go5,go6;
    public GameObject dustBall, metiBall, sudaBall, ilacBall, ilac2Ball;
    [Header("TARİF KİTABI")]
    public static bool recipeControl;
    
    public AudioClip impact;
    AudioSource audioSource;

    private Animator anim;

    

    [Header("HUD RESİMLER")] 
    public Image dustImage;
    public Image metilaminImage;
    public Image sudafedImage;
    public Image ilacImage;
    public Image ilac2Image;
    public Image k57sImage;
    public Image b69KImage;

    private void Start()
    {
        audioSource = GameObject.Find("TakeSound").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    void PowerSound()
    {
       
        
        audioSource.PlayOneShot(impact, 1f);

    }
    void Update()
    {
        Combiningk57s();
        Combiningb69k();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dust"))
        {
            go1.SetActive(true);
            if (metilamin == 0 && sudafed == 0 && ilac == 0 && ilac2 == 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Take Sound
                    PowerSound();
                    anim.SetTrigger("Pick");
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
        }
        if (other.gameObject.CompareTag("Metilamin"))
        {
            go2.SetActive(true);
            if (dust == 0 && sudafed == 0 && ilac == 0 && ilac2 == 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Take Sound
                    PowerSound();
                    anim.SetTrigger("Pick");
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
        }
        if (other.gameObject.CompareTag("Sudafed"))
        {
            go3.SetActive(true);
            if (dust == 0 && metilamin == 0 && ilac == 0 && ilac2 == 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Take Sound
                    PowerSound();
                    anim.SetTrigger("Pick");
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
        }
        if (other.gameObject.CompareTag("Ilac"))
        {
            go4.SetActive(true);
            if (dust == 0 && sudafed == 0 && metilamin == 0 && ilac2 == 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Take Sound
                    PowerSound();
                    anim.SetTrigger("Pick");
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

        }
        if (other.gameObject.CompareTag("Ilac3"))
        {
            go5.SetActive(true);
            if (dust == 0 && sudafed == 0 && ilac == 0 && metilamin == 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Take Sound
                    PowerSound();
                    anim.SetTrigger("Pick");
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

        }
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
        if (other.gameObject.CompareTag("Recipe"))
        {
            go6.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                recipeControl = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.CompareTag("Dust"))
         {
             go1.SetActive(false);
         }
         if (other.gameObject.CompareTag("Metilamin"))
         {
             go2.SetActive(false);
         }
         if (other.gameObject.CompareTag("Sudafed"))
         {
             go3.SetActive(false);
            
         }
         if (other.gameObject.CompareTag("Ilac"))
         {
             go4.SetActive(false);

         }
         if (other.gameObject.CompareTag("Ilac3"))
         {
             go5.SetActive(false);
         }

         if (other.gameObject.CompareTag("Recipe"))
         {
             go6.SetActive(false);
         }
    }


    private void OnTriggerEnter(Collider other)
    {
        
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
            }else if (B69k >=1)
            {
                B69k -= 1;
                handControl = true;
                b69KImage.gameObject.SetActive(false);
            }else if (K57s >=1)
            {
                K57s -= 1;
                handControl = true;
                k57sImage.gameObject.SetActive(false);
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
                anim.SetTrigger("Pick");
                sudaCont = true;
                sudafed = 0;
                sudaBall.gameObject.SetActive(true);
                sudafedImage.gameObject.SetActive(false);
                
            }else if (metilamin > 0)
            {
               
                if (!metiTable.activeSelf)
                {
                    handControl = true;
                }
                metiTable.SetActive(true);
                anim.SetTrigger("Pick");
                metiCont = true;
                metilamin = 0;
                metiBall.gameObject.SetActive(true);
                metilaminImage.gameObject.SetActive(false);
                
            }else if (dust > 0)
            {
                
                if (!dustTable.activeSelf)
                {
                    handControl = true;
                }
                dustTable.SetActive(true);
                anim.SetTrigger("Pick");
                dustCont = true;
                dust = 0;
                dustBall.gameObject.SetActive(true);
                dustImage.gameObject.SetActive(false);
                
            }else if (ilac > 0)
            {
                
                if (!ilacTable.activeSelf)
                {
                    handControl = true;
                }
                ilacTable.SetActive(true);
                anim.SetTrigger("Pick");
                ilacCont = true;
                ilac = 0;
                ilac2Ball.gameObject.SetActive(true);
                ilac2Image.gameObject.SetActive(false);
                
            }else if (ilac2 > 0)
            {
                
                if (!ilacTable.activeSelf)
                {
                    handControl = true;
                }
                ilacTable2.SetActive(true);
                anim.SetTrigger("Pick");
                ilacCont2 = true;
                ilac2 = 0;
                ilacBall.gameObject.SetActive(true);
                ilacImage.gameObject.SetActive(false); 
                
            }
        }

    }

    void Combiningk57s()
    {
        if (dustCont && sudaCont && metiCont)
        {
            if (Input.GetKey(KeyCode.E))
            {
                k57sTable.SetActive(true);
                sudaTable.SetActive(false);
                metiTable.SetActive(false);
                dustTable.SetActive(false);
                
                dustBall.gameObject.SetActive(false);
                ilacBall.gameObject.SetActive(false);
                metiBall.gameObject.SetActive(false);
                sudaBall.gameObject.SetActive(false);
                ilac2Ball.gameObject.SetActive(false);
                
                
            }
            if (Input.GetKey(KeyCode.Q))
            {
                k57sImage.gameObject.SetActive(true);
                k57sTable.SetActive(false);
                K57s += 1;
            }
        }
        
        
    }
    void Combiningb69k()
    {
        if (ilacCont2 && dustCont)
        {
            if (Input.GetKey(KeyCode.H))
            {
                b69kTable.SetActive(true);
                ilacTable.SetActive(false);
                dustTable.SetActive(false);
                dustBall.gameObject.SetActive(false);
                ilacBall.gameObject.SetActive(false);
                metiBall.gameObject.SetActive(false);
                sudaBall.gameObject.SetActive(false);
                ilac2Ball.gameObject.SetActive(false);
                
            }
            if (Input.GetKey(KeyCode.Q))
            {
                b69KImage.gameObject.SetActive(true);
                b69kTable.SetActive(false);
                B69k += 1;
            }
        }
       
    }
    
    
}
