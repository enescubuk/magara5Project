using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerController : MonoBehaviour
{
    public Transform movepoint,movepoint1;
    public GameObject[] allCustomerTypes;
    public Sprite[] allCustomerProfiles;
    private Vector3 nextPos;
    public GameObject customer;
    private bool isWay;
    public GameObject marketElements;
    public GameObject profileImage;
    private int randomCustomerNumber;
    private int randomTalkingNumber;
    public Text customerSaying;
    
    public string[] sickTexts;
    public string[] addictTexts;
    public string[] copTexts;
    void Start()
    {
        spawnCustomer();
    }
    void Update()
    {
        if (isWay == true)
        {
            customer.transform.position = Vector3.MoveTowards(customer.transform.position,nextPos,Time.deltaTime * 2);
            if (Vector3.Distance(customer.transform.position,nextPos) <= 0.1f)
            {
                isWay = false;
                Debug.Log(1);
                if (Vector3.Distance(customer.transform.position,movepoint.position) > Vector3.Distance(customer.transform.position,movepoint1.position))
                {
                    //cashe yakın
                    inCash();
                }
                else
                {
                    Debug.Log("başa döndü");
                    Destroy(customer);
                    waitingNewCustomer(3);
                    
                }
            }
        }
        
    }
    void spawnCustomer()
    {
        randomCustomerNumber = Random.Range(0,allCustomerTypes.Length);
        customer = Instantiate(allCustomerTypes[randomCustomerNumber],movepoint.position,Quaternion.identity);
        moveCustomerIn();
    }
    void moveCustomerIn()
    {
        nextPos = movepoint1.position;
        isWay = true;
    }
    void inCash()
    {
        marketElements.SetActive(true);
        profileImage.GetComponent<Image>().sprite = allCustomerProfiles[randomCustomerNumber];
        randomTalkingNumber = Random.Range(0,3);
        switch (randomTalkingNumber)
        {
            case 0:
                customerSaying.text = sickTexts[Random.Range(0,sickTexts.Length)];
                    break;
            case 1:
                customerSaying.text = sickTexts[Random.Range(0,addictTexts.Length)];
                    break;
            case 2:
                customerSaying.text = sickTexts[Random.Range(0,copTexts.Length)];
                    break;
        }
    }

    void waitingNewCustomer(int second)
    {
        StartCoroutine(wait(second));
    }
    IEnumerator wait(int second)
    {
        yield return new WaitForSecondsRealtime(second);
        spawnCustomer();
    }


    void moveCustomerOut()
    {
        nextPos = movepoint.position;
        isWay = true;
    }
    public void closePanelwithButton()
    {
        moveCustomerOut();
        marketElements.SetActive(false);
    }
}
