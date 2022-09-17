using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarifKitabi : MonoBehaviour
{
    public GameObject _recipe;
    void Update()
    {
        if (CollectionObject.recipeControl)
        {
            _recipe.SetActive(true);
        }
    }
    public void exitButton()
    {
        CollectionObject.recipeControl = false;
        _recipe.SetActive(false);
        
    }
}
