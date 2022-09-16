using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockModifier : MonoBehaviour
{
    private Transform clockHandTransform;
    Timer timer;
    private float ClockTime;

    public AudioClip impact;
    AudioSource audioSource;

    public bool ringPlay;
    void Start()
    {

        timer = GameObject.Find("Timer").GetComponent<Timer>();
        clockHandTransform = transform.Find("ClockHandler");
        clockHandTransform.eulerAngles = new Vector3(0, 0, 90);
        ClockTime = timer.timerLeft;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.timerLeft != 0)
        {
            clockHandTransform.Rotate(Vector3.forward * 240 / -ClockTime * Time.deltaTime);
        }

        
    }
    private void FixedUpdate()
    {
        if (timer.dayEnd)
        {
            PowerSound();
            timer.dayEnd = false;
        }
    }
    void PowerSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(impact, 0.2F);

    }


}
