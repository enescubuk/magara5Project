using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atomm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10f);
    }

    public void Execute()
    {

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
