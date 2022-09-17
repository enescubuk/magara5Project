using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMPControl : MonoBehaviour
{
    public TextMeshProUGUI MetilaminText,SudafedText,DustText,AtesDüsürücüText,AgriKesiciText;
    public static int meti = 5, suda = 5, dus = 5, atesd=5,agrik=5;
    void Update()
    {
        MetilaminText.text = "" + meti;
        SudafedText.text = "" + suda;
        DustText.text = "" + dus;
        AtesDüsürücüText.text = "" + atesd;
        AgriKesiciText.text = "" + agrik;
    }
}
