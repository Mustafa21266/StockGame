using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PixelCrushers.DialogueSystem;

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

    public List<StockPurchase> stockPurchases;

    public GameObject audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        stockPurchases = new List<StockPurchase>();
        anim = GameObject.FindGameObjectWithTag("Character Body").GetComponent<Animator>();
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
            if(!GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive)
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
        if(stockPurchases.Count > 0){
            var totalShares = 0;
            for(var i = 0; i < stockPurchases.Count; i++){
                totalShares += stockPurchases[i].numOfShares;
            }
            stockAmount.GetComponent<TextMeshProUGUI>().text = totalShares.ToString();
        }else {
            stockAmount.GetComponent<TextMeshProUGUI>().text = "0";
        }
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
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Coin_Sound_Effect", typeof(AudioClip));
            if(!audioSrc.GetComponent<AudioSource>().isPlaying){
                audioSrc.GetComponent<AudioSource>().Play();
            }
            notificationObj.GetComponent<TextMeshProUGUI>().text = "Purchase Successeded!";
            notificationObj.GetComponent<TextMeshProUGUI>().color = new Color(0,0.4313726f,0,1f);
            //this.purchaseBtn.GetComponent<Button>().enabled = true;
            }else {
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
}
