using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerController : MonoBehaviour
{   
    
    public Transform movepoint,movepoint1;
    public GameObject[] allCustomerTypes;
    public Sprite[] allCustomerProfiles;
    public List<int> randomProbabilityCustomer = new List<int>();
    private Vector3 nextPos;
    public GameObject customer;
    private bool isWay;
    public GameObject marketElements;
    public GameObject profileImage;
    private int randomCustomerNumber;
    private int randomTalkingNumber;
    public bool inCash;
    public Text customerSaying;
    
    public string[] sickTexts;
    public string[] feverTexts;
    public string[] addictTexts;
    public string[] copTexts;
    private int money = 100;
    public Text moneyText;
    private Slider susSlider;
    void Start()
    {
        spawnCustomer();
        
    }
    void Awake()
    {
        susSlider = GameObject.Find("SuspectBar").GetComponent<Slider>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (randomTalkingNumber)
            {
                case 0 : 
                //hasta kişi
                    money+=15;
                    Debug.Log("01 arttı 23 azladı");
                    randomProbabilityCustomer.Add(0);
                    randomProbabilityCustomer.Add(1);
                    randomProbabilityCustomer.Remove(2);
                    randomProbabilityCustomer.Remove(3);
                    susSlider.value -= 10;
                        break;
                case 1:
                //ateşli kişi
                    money += 15;
                    Debug.Log("01 arttı 23 azaldı");
                    randomProbabilityCustomer.Add(0);
                    randomProbabilityCustomer.Add(1);
                    randomProbabilityCustomer.Remove(2);
                    randomProbabilityCustomer.Remove(3);
                    susSlider.value -= 10;
                        break;
                case 2:
                //bağımlı kişi
                    money += 15;
                    Debug.Log("01 azaldı 23 arttı");
                    randomProbabilityCustomer.Remove(0);
                    randomProbabilityCustomer.Remove(1);
                    randomProbabilityCustomer.Add(2);
                    randomProbabilityCustomer.Add(3);
                    susSlider.value += 10;
                        break;
                case 3:
                //polis kişi
                    money += 50;
                    Debug.Log("01 azaldı 3 arttı 2 sabit");
                    randomProbabilityCustomer.Remove(0);
                    randomProbabilityCustomer.Remove(1);
                    randomProbabilityCustomer.Add(3);
                    randomProbabilityCustomer.Add(3);
                    susSlider.value += 10;
                        break;
            }
            moneyText.text = money+"$";
            moveCustomerOut();
            inCash = false;
        }
        if (inCash == false)
        {
            if (isWay == true)
            {
                customer.transform.position = Vector3.MoveTowards(customer.transform.position,nextPos,Time.deltaTime * 5);
                if (Vector3.Distance(customer.transform.position,nextPos) <= 0.1f)
                {
                    isWay = false;
                    if (Vector3.Distance(customer.transform.position,movepoint.position) > Vector3.Distance(customer.transform.position,movepoint1.position))
                    {
                        //cashe yakın
                        inCash = true;
                        shopping();
                    }
                    else
                    {
                        Destroy(customer);
                        waitingNewCustomer(3);
                        
                    }
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
    void shopping()
    {
        //marketElements.SetActive(true);
        profileImage.GetComponent<Image>().sprite = allCustomerProfiles[randomCustomerNumber];
        createRandomCustomer();
        
    }

    void createRandomCustomer()
    {
        randomTalkingNumber = randomProbabilityCustomer[Random.Range(0,randomProbabilityCustomer.Count)];
        switch (randomTalkingNumber)
        {
            case 0:
                customerSaying.text =sickTexts[Random.Range(0,sickTexts.Length)];
                    break;
            case 1:
                customerSaying.text =feverTexts[Random.Range(0,feverTexts.Length)];
                    break; 
            case 2:
                customerSaying.text =addictTexts[Random.Range(0,addictTexts.Length)];
                    break;
            case 3:
                customerSaying.text =copTexts[Random.Range(0,copTexts.Length)];
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
}
