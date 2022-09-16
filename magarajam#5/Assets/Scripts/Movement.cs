using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 7f;
    [SerializeField] float turnSpeed = 360;
    private Vector3 input;

    AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        Look();
        Move();
        PowerSound();

    }

    private void FixedUpdate()
    {
        
    }

    void GetInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }
    void Look()
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, turnSpeed * Time.deltaTime);
        }
        
    }

    void PowerSound()
    {
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<AudioSource>().enabled = false;
        }else
        GetComponent<AudioSource>().enabled = true;
    }
}
