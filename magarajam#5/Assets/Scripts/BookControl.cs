using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    public GameObject bookCanvas;
    private int metarialA = 1, metarialB = 1, metarialC = 1, metarialD;
    
    void Start()
    {
        
    }

    void Update()
    {
        bookControl();
    }

    void bookControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            bookCanvas.SetActive(true);
        }
    }

    public void closeButton()
    {
        bookCanvas.SetActive(false);
    }

    public void buyButtonA()
    {
        if (metarialB > 0 && metarialC > 0)
        {
            Debug.Log("a alınabilir");
        }
    }
    public void buyButtonB()
    {
        if (metarialA > 0 && metarialC > 0)
        {
            Debug.Log("b alınabilir");
        }
    }
    public void buyButtonC()
    {
        if (metarialA > 0 && metarialB > 0)
        {
            Debug.Log("c alınabilir");
        }
    }
    public void buyButtonD()
    {
        if (metarialA > 0 && metarialB > 0 && metarialC > 0)
        {
            Debug.Log("d alınabilir");
        }
    }
}
