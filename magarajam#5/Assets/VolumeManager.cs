using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Text VolumeText;
    void Start()
    {
        AudioListener.volume = 0.5f;

        VolumeText.text = "" + Mathf.Round(AudioListener.volume * 100);
    }
    
    public void VolumeUp()
    {
        ChangeVol(0.05f);
    }

    public void VolumeDown()
    {
        ChangeVol(-0.05f);
    }
    public void ChangeVol(float newValue)
    {
        float newVol = AudioListener.volume;
        newVol += newValue;
        VolumeText.text =""+ Mathf.Round(AudioListener.volume * 100);
        if (Mathf.Round(AudioListener.volume * 100) < 0)
        {
            VolumeText.text = "" +  0;
            AudioListener.volume = 0;
        }
        if (Mathf.Round(AudioListener.volume * 100) > 100)
        {
            VolumeText.text = "" +  100;
            AudioListener.volume = 100;
        }
        AudioListener.volume = newVol;
    }
}

