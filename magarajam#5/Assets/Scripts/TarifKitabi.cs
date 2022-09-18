using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarifKitabi : MonoBehaviour
{
    public GameObject _recipe, img1, img2;
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
        img2.gameObject.SetActive(false);
        _recipe.SetActive(false);
    }

    public void nextButton()
    {
        CollectionObject.recipeControl = false;
        img2.gameObject.SetActive(true);
    }
}
