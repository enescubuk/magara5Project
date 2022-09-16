using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerController : MonoBehaviour
{
    public Text customerSaying;
    
    public GameObject marketElements;
    public Image[] allCustomers;

    public string[] normalTexts;
    public string[] susTexts;
    private bool isBusy = false;
    string customerName;
    
    int detectCustomer;
    // Start is called before the first frame update
    private void Awake()  
    {
        //customerSaying = GameObject.Find("customerSaying").GetComponent<Text>();
    }
    void Start()
    {
        randomCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void randomCustomer()
    {
        isBusy = true;
        int a = Random.Range(0,allCustomers.Length);
        Debug.Log(a);
        allCustomers[a].enabled = true;
        marketElements.SetActive(true);
        customerName = allCustomers[a].name;
        detection();
    }
    void detection()
    {
        if (customerName.Contains("normal"))
        {
            detectCustomer = 0;
        }
        else if (customerName.Contains("sus"))
        {
            detectCustomer = 1;
        }
        whatCustomerSay();
    }
    
    void whatCustomerSay()
    {
        switch (detectCustomer)
        {
            case 0: 
                Debug.Log("normal");
                customerSaying.text = normalTexts[Random.Range(0,normalTexts.Length)];
                    break;
            case 1: 
                Debug.Log("sus");
                customerSaying.text = susTexts[Random.Range(0,susTexts.Length)];
                    break;
        }
    }
    public void toProduction()
    {
        marketElements.SetActive(false);
    }
    void moveCustomerIn()
    {
        //a konumundan b konumuna git
    }
    void moveCustomerOut()
    {
        //b konumundan a konumuna git
        isBusy = false;
        randomCustomer();
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
