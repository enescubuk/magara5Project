using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerController : MonoBehaviour
{
    public Sprite[] allCustomers;
    private bool isBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBusy == false)
        {
            randomCustomer();
        }
    }
    void randomCustomer()
    {
        isBusy = true;
        int a = Random.Range(0,allCustomers.Length);
        Debug.Log(a);
        Debug.Log(allCustomers[a].name);
    }
    void moveCustomerIn()
    {
        //a konumundan b konumuna git
    }
    void moveCustomerOut()
    {
        //b konumundan a konumuna git
        isBusy = false;
    }
    void defaultBuy()
    {
        //panel on
        //button ile kapancak
    }
    void inspectorCustomerBuy()
    {
        //kimlik image on
        //button ile kapancak
        //sus bar ++
        //moveCustomerOut();
    }
    void normalCustomerBuy()
    {

    }
    void increaseMoney()
    {
        //müşteri kim
        //ona özel tarifeyle art
        //bura kesin değişicek aq
    }
}
