using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;
    HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PowerSound();
        }
    }
    void PowerSound()
    {
        if (hinge.useSpring == true)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(impact, 1f);
        }
        

    }
}
