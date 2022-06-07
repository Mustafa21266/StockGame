using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PixelCrushers.DialogueSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f; 
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    private Animator  anim;
    Vector3 velocity;

    public bool isGrounded;
    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public GameObject cutscenesParent;

    public bool allowedToMove = true;

    public GameObject cashAmount;
    public GameObject stockAmount;

    public int cashAmountForPlayer = 0;
    public int stockAmountForPlayer = 0;

    public List<StockPurchase> stockPurchases;

    public GameObject audioSrc;

    public GameObject promptPanel;

    // Start is called before the first frame update
    void Start()
    {
        stockPurchases = new List<StockPurchase>();
        anim = GameObject.FindGameObjectWithTag("Character Body").GetComponent<Animator>();
        Load();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(x != 0 || z != 0){
            // anim.Rebind();
            if(!GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive && !promptPanel.gameObject.active)
            {
                MovePlayer();
            }
        }else {
            if(gameObject.GetComponent<AudioSource>().isPlaying){
                gameObject.GetComponent<AudioSource>().Stop();
            }
            anim.SetBool("isWalking", false);
        }


        if(Input.GetButtonDown("Jump") && isGrounded){
            //this.allowedToMove ||
            if (!GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            //anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
        }

        if(!Input.GetButtonDown("Jump")){
            anim.SetBool("isJumping", false);
        }
        velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            // anim.SetBool("isJumping", false); 180
        GameObject.FindGameObjectWithTag("Character Body").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y - 2.16f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
        // Debug.Log(Mathf.Floor(this.cashAmountForPlayer));
        cashAmount.GetComponent<TextMeshProUGUI>().text = this.cashAmountForPlayer.ToString();
        stockAmount.GetComponent<TextMeshProUGUI>().text = this.stockAmountForPlayer.ToString();
        /*if(stockPurchases.Count > 0){
            var totalShares = 0;
            for(var i = 0; i < stockPurchases.Count; i++){
                totalShares += stockPurchases[i].numOfShares;
            }
            stockAmountForPlayer = totalShares;
            stockAmount.GetComponent<TextMeshProUGUI>().text = totalShares.ToString();
        }else {
            stockAmount.GetComponent<TextMeshProUGUI>().text = "0";
        }*/
    }
    public void updateCashAmountForPlayer(int newAmount){
        this.cashAmountForPlayer += newAmount;
    }
    void MovePlayer(){
    float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        anim.SetBool("isWalking", true);
        gameObject.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Player_Walk_Audio", typeof(AudioClip));
        if(!gameObject.GetComponent<AudioSource>().isPlaying){
            gameObject.GetComponent<AudioSource>().Play();
        }
        controller.Move(move * speed * Time.deltaTime);
        
    }
    void JumpPlayer(){
    float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        anim.SetBool("isWalking", true);
        controller.Move(move * speed * Time.deltaTime);  
    }

    void FixedUpdate() {
        // for(var i = 0; i < cutscenesParent.transform.childCount; i++){
        //     if(cutscenesParent.transform.GetChild(i).gameObject.active){
        //         this.allowedToMove = false;
        //         return;
        //     }
        // }
    }
    public IEnumerator purchaseStock(float stockNum,Profile stockProfile, GameObject notificationObj){
        yield return new WaitForSeconds(1f);
        var newTotalDue = stockNum * Mathf.Round((float)stockProfile.price);
        if(this.cashAmountForPlayer >= newTotalDue && newTotalDue != 0){
            stockPurchases.Add(new StockPurchase(stockPurchases.Count + 1,(int)stockNum, newTotalDue, stockProfile , System.DateTime.Now));
            GameObject.FindObjectOfType<InventoryManager>().updateDropDown();
            this.cashAmountForPlayer = this.cashAmountForPlayer - (int)newTotalDue;
            this.stockAmountForPlayer += (int)stockNum;
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Coin_Sound_Effect", typeof(AudioClip));
            if(!audioSrc.GetComponent<AudioSource>().isPlaying){
                audioSrc.GetComponent<AudioSource>().Play();
            }
            notificationObj.GetComponent<TextMeshProUGUI>().text = "Purchase Successeded!";
            notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0,0.4313726f,0,1f);
           // ES3.Save("stockPurchasesLength", stockPurchases.Count);
            ES3.Save("stockPurchasesLength", stockPurchases.Count);
            for (var i = 0; i< stockPurchases.Count;i++) {
                ES3.Save("stockPurchaseStockProfileAddress_" + i, stockPurchases[i].stockProfile.address);
                ES3.Save("stockPurchaseStockProfileBeta_" + i, stockPurchases[i].stockProfile.beta);
                ES3.Save("stockPurchaseStockProfileCEO_" + i, stockPurchases[i].stockProfile.ceo);

                ES3.Save("stockPurchaseStockProfileChanges_" + i, stockPurchases[i].stockProfile.changes);
                ES3.Save("stockPurchaseStockProfileCity_" + i, stockPurchases[i].stockProfile.city);
                ES3.Save("stockPurchaseStockProfileCompanyName_" + i, stockPurchases[i].stockProfile.companyName);
                ES3.Save("stockPurchaseStockProfileCountry_" + i, stockPurchases[i].stockProfile.country);
                ES3.Save("stockPurchaseStockProfileCurrency_" + i, stockPurchases[i].stockProfile.currency);
                ES3.Save("stockPurchaseStockProfileDescription_" + i, stockPurchases[i].stockProfile.description);
                ES3.Save("stockPurchaseStockProfileIndustry_" + i, stockPurchases[i].stockProfile.industry);


                ES3.Save("stockPurchaseStockProfileLastDiv_" + i, stockPurchases[i].stockProfile.lastDiv);
                ES3.Save("stockPurchaseStockProfileMktCap_" + i, stockPurchases[i].stockProfile.mktCap);
                ES3.Save("stockPurchaseStockProfilePhone_" + i, stockPurchases[i].stockProfile.phone);
                ES3.Save("stockPurchaseStockProfilePrice_" + i, stockPurchases[i].stockProfile.price);
                ES3.Save("stockPurchaseStockProfileRange_" + i, stockPurchases[i].stockProfile.range);
                ES3.Save("stockPurchaseStockProfileSector_" + i, stockPurchases[i].stockProfile.sector);
                ES3.Save("stockPurchaseStockProfileState_" + i, stockPurchases[i].stockProfile.state);
                ES3.Save("stockPurchaseStockProfileSymbol_" + i, stockPurchases[i].stockProfile.symbol);
                ES3.Save("stockPurchaseStockProfileVolAvg_" + i, stockPurchases[i].stockProfile.volAvg);
                ES3.Save("stockPurchaseStockProfileWebsite_" + i, stockPurchases[i].stockProfile.website);


                ES3.Save("stockPurchaseId_" + i, stockPurchases[i].id);
                ES3.Save("stockPurchaseNumOfShares_" + i, stockPurchases[i].numOfShares);
                ES3.Save("stockPurchasePurchaseDate_" + i, stockPurchases[i].purchaseDate);
                ES3.Save("stockPurchaseTotalDue_" + i, stockPurchases[i].totalDue);
            }
            //this.purchaseBtn.GetComponent<Button>().enabled = true;
        }
        else {
                audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Error_Sound", typeof(AudioClip));
                if(!audioSrc.GetComponent<AudioSource>().isPlaying){
                    audioSrc.GetComponent<AudioSource>().Play();
                }
                notificationObj.GetComponent<TextMeshProUGUI>().text = "Purchase Failed!";
                notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0.589f,0,0,1f);
                //this.purchaseBtn.GetComponent<Button>().enabled = false;
            }


    }
    public IEnumerator sellStock(float stockNum,StockPurchase stockProfile, GameObject notificationObj){
        yield return new WaitForSeconds(1f);
        if((int)stockNum == stockProfile.numOfShares){
            var totalEarned = stockNum * stockProfile.stockProfile.price;
            this.updateCashAmountForPlayer((int)totalEarned);
            stockPurchases.RemoveAt(stockPurchases.IndexOf(stockProfile));
            GameObject.FindObjectOfType<InventoryManager>().updateDropDown();
        }else {
            var totalEarned = stockNum * stockProfile.stockProfile.price;
            this.updateCashAmountForPlayer((int)totalEarned);
            var tempPur = stockPurchases[stockPurchases.IndexOf(stockProfile)];
            tempPur.totalDue = ((tempPur.numOfShares - stockNum) * Mathf.Round((float)tempPur.stockProfile.price));
            tempPur.numOfShares = (int)Mathf.Round(tempPur.numOfShares - stockNum);
            // stockPurchases.RemoveAt();
            GameObject.FindObjectOfType<InventoryManager>().updateDropDown();
        }
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Coin_Sound_Effect", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        notificationObj.GetComponent<TextMeshProUGUI>().text = "Sale Successeded!";
        notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0,0.4313726f,0,1f);
        // var newTotalDue = stockNum * Mathf.Round((float)stockProfile.price);
        // if(this.cashAmountForPlayer >= newTotalDue && newTotalDue != 0){
        //     stockPurchases.Add(new StockPurchase(stockPurchases.Count + 1,(int)stockNum, newTotalDue, stockProfile , System.DateTime.Now));
        //     GameObject.FindObjectOfType<InventoryManager>().updateDropDown();
        //     this.cashAmountForPlayer = this.cashAmountForPlayer - (int)newTotalDue;
        //     notificationObj.GetComponent<TextMeshProUGUI>().text = "Purchase Successeded!";
        //     notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0,0.4313726f,0,1f);
        //     //this.purchaseBtn.GetComponent<Button>().enabled = true;
        //     }else {
        //         notificationObj.GetComponent<TextMeshProUGUI>().text = "Purchase Failed!";
        //         notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0.589f,0,0,1f);
        //         //this.purchaseBtn.GetComponent<Button>().enabled = false;
        //     }
    }
    void OnApplicationQuit()
    {
        ES3.Save("cashAmountForPlayer", cashAmountForPlayer);
        ES3.Save("stockAmountForPlayer", stockAmountForPlayer);
    }
    void Load() {
        cashAmountForPlayer = ES3.Load<int>("cashAmountForPlayer");
        stockAmountForPlayer = ES3.Load<int>("stockAmountForPlayer");
        //stockPurchases = ES3.Load<List<StockPurchase>>("stockPurchases");
        //ES3.Save("stockPurchasesLength", stockPurchases.Count);
        var stockLength = ES3.Load<int>("stockPurchasesLength");
        for (var i = 0; i < stockLength; i++)
        {
            var sP = new Profile()
            {
                address = ES3.Load<string>("stockPurchaseStockProfileAddress_" + i),
                beta =    ES3.Load<float>("stockPurchaseStockProfileBeta_" + i),
                ceo = ES3.Load<string>("stockPurchaseStockProfileCEO_" + i),
                changes = ES3.Load<float>("stockPurchaseStockProfileChanges_" + i),
                city = ES3.Load<string>("stockPurchaseStockProfileCity_" + i),
                companyName = ES3.Load<string>("stockPurchaseStockProfileCompanyName_" + i),
                country = ES3.Load<string>("stockPurchaseStockProfileCountry_" + i),
                currency = ES3.Load<string>("stockPurchaseStockProfileCurrency_" + i),
                description = ES3.Load<string>("stockPurchaseStockProfileDescription_" + i),
                industry = ES3.Load<string>("stockPurchaseStockProfileIndustry_" + i),
                lastDiv = ES3.Load<float>("stockPurchaseStockProfileLastDiv_" + i),
                mktCap = ES3.Load<int>("stockPurchaseStockProfileMktCap_" + i),
                phone = ES3.Load<string>("stockPurchaseStockProfilePhone_" + i),
                price = ES3.Load<double>("stockPurchaseStockProfilePrice_" + i),
                range = ES3.Load<string>("stockPurchaseStockProfileRange_" + i),
                sector = ES3.Load<string>("stockPurchaseStockProfileSector_" + i),
                state = ES3.Load<string>("stockPurchaseStockProfileState_" + i),
                symbol = ES3.Load<string>("stockPurchaseStockProfileSymbol_" + i),
                volAvg = ES3.Load<int>("stockPurchaseStockProfileVolAvg_" + i),
                website = ES3.Load<string>("stockPurchaseStockProfileWebsite_" + i)

            };
            stockPurchases.Add(new StockPurchase(ES3.Load<int>("stockPurchaseId_" + i), ES3.Load<int>("stockPurchaseNumOfShares_" + i), ES3.Load<float>("stockPurchaseTotalDue_" + i), sP, ES3.Load<DateTime>("stockPurchasePurchaseDate_" + i)));
        }
        GameObject.FindObjectOfType<InventoryManager>().updateDropDown();
        var notesLengthMissionOne = ES3.Load<int>("notesCollectedLengthMission_1",0);
        for (var i = 0; i < notesLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionOne>() != null) {

                GameObject.FindObjectOfType<MissionOne>().prepareNote(i);
            }
            
        }
        var newsPaperLengthMissionOne = ES3.Load<int>("newsPaperCollectedLengthMission_1", 0);
        for (var i = 0; i < newsPaperLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionOne>() != null)
            {

                GameObject.FindObjectOfType<MissionOne>().prepareNewspaper(i);
            }

        }

        var notesLengthMissionTwo = ES3.Load<int>("notesCollectedLengthMission_2", 0);
        for (var i = 0; i < notesLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionTwo>() != null)
            {

                GameObject.FindObjectOfType<MissionTwo>().prepareNote(i);
            }

        }
        var newsPaperLengthMissionTwo = ES3.Load<int>("newsPaperCollectedLengthMission_2", 0);
        for (var i = 0; i < newsPaperLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionTwo>() != null)
            {

                GameObject.FindObjectOfType<MissionTwo>().prepareNewspaper(i);
            }

        }

        var notesLengthMissionThree = ES3.Load<int>("notesCollectedLengthMission_3", 0);
        for (var i = 0; i < notesLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionThree>() != null)
            {

                GameObject.FindObjectOfType<MissionThree>().prepareNote(i);
            }

        }
        var newsPaperLengthMissionThree = ES3.Load<int>("newsPaperCollectedLengthMission_3", 0);
        for (var i = 0; i < newsPaperLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionThree>() != null)
            {

                GameObject.FindObjectOfType<MissionThree>().prepareNewspaper(i);
            }

        }

        var notesLengthMissionFour = ES3.Load<int>("notesCollectedLengthMission_4", 0);
        for (var i = 0; i < notesLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionThree>() != null)
            {

                GameObject.FindObjectOfType<MissionThree>().prepareNote(i);
            }

        }
        var newsPaperLengthMissionFour = ES3.Load<int>("newsPaperCollectedLengthMission_4", 0);
        for (var i = 0; i < newsPaperLengthMissionOne; i++)
        {
            if (GameObject.FindObjectOfType<MissionThree>() != null)
            {

                GameObject.FindObjectOfType<MissionThree>().prepareNewspaper(i);
            }

        }

        /*
                ES3.Load("cashAmountForPlayer", cashAmountForPlayer);
                ES3.Save("cashAmountForPlayer", stockAmountForPlayer);*/
    }
}
