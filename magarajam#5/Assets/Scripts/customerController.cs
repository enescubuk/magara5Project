using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerController : MonoBehaviour
{
    Vector3 nextPos;
    public GameObject customer;
    public GameObject movepoint1,movepoint2;
    public Text customerSaying;
    
    public GameObject marketElements;
    public Image[] allCustomers;

    public string[] normalTexts;
    public string[] susTexts;
    private bool isBusy = false;
    string customerName;
    bool isWay;
    bool goingCash;
    
    int detectCustomer;
    // Start is called before the first frame update
    private void Awake()  
    {
        //customerSaying = GameObject.Find("customerSaying").GetComponent<Text>();
    }
    void Start()
    {
        marketElements.SetActive(false);
        customer.transform.position = movepoint1.transform.position;
        moveCustomerIn();
        
        //moveCustomerIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("asd");
            moveCustomerOut();
        }
        if (goingCash == true)
        {
            if (isWay == true)
            {
                if (Vector3.Distance(customer.transform.position,movepoint2.transform.position) <= 0.1f)
                {
                    Debug.Log(1);
                    isWay = false;
                    randomCustomer();
                }
                else
                {
                    Debug.Log(2);
                    customer.transform.position = Vector3.MoveTowards(customer.transform.position,movepoint2.transform.position,Time.deltaTime *2);
                }
            }
        }
        else
        {
            if (isWay == true)
            {
                if (Vector3.Distance(customer.transform.position,nextPos) <= 0.1f)
                {
                    Debug.Log(3);
                    isWay = false;
                    
                }
                else
                {
                    customer.transform.position = Vector3.MoveTowards(customer.transform.position,nextPos,Time.deltaTime *2);
                }
            }
        }
        
    }
    void randomCustomer()
    {
        isBusy = true;
        int a = Random.Range(0,allCustomers.Length);
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
        // a konumundan b konumuna git
        
        isWay = true;
        goingCash = true;
        nextPos = movepoint2.transform.position;

    }
    void moveCustomerOut()
    {
        //b konumundan a konumuna git
        nextPos = movepoint1.transform.position;
        isWay = true;
        goingCash = false;
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
