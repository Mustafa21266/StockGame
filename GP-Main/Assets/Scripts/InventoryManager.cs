using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using  TMPro;
using System;

using System.Net;
using System.IO;

using System.Text;

[Serializable]
public class Profile{
    public string symbol;
  public double price;
  public float beta;
  public int volAvg;
  public int mktCap;
  public float lastDiv;
  public string range;
  public float changes;
  public string companyName;
  public string currency;
  public string industry;
  public string website;
  public string description;
  public string ceo;
  public string sector;
  public string country;
  public string phone;
  public string address;
  public string city;
  public string state;
}

[Serializable]
public class Symbol{
    public string symbol;
    public string name;
    public double price;
    public string type;
    public string exchangeShortName;
    public string exchange;
    // public string symbol;
    // public int id;
}
[Serializable]
public class SymbolInfo
{
    // public int id;
    // public string name;
    public Symbol[] symbols;
}
public class InventoryManager : MonoBehaviour
{

    public GameObject NotesPanel;
    public GameObject NewspaperPanel;
    public GameObject QuizPanel;
    public GameObject TradingPanel;

    public GameObject AppPanels;

    public List<dynamic> apps;

    public List<GameObject> notes;
    public List<GameObject> newspapers;

    public int activeAppIndex;

    public TextMeshProUGUI noteTitleInv;
    public TextMeshProUGUI noteContentInv;

    public GameObject NewspaperImageFromApp;

    public GameObject firstMissionChallengeParent;

    public int currentQuestionIndex = 0;

    public bool finishedQuiz = false;

    public GameObject stockDetailsPanel;

    public Profile currentStockProfile;
    public GameObject sellingDropdown;

    public GameObject purchaseBtn;

    public Slider numOfSharesSlider;
    public Slider numOfSharesSliderSelling;
    public GameObject numOfSharesInput;

    public GameObject scrollField;

    public string currentlySelectedStockToSell;

    public List<string> dropdownOptions;

    public GameObject audioSrc;

    public GameObject BuyingGameObject;
    public GameObject SellingGameObject;

    public List<QuizQuestion> quizQuestions;

    // Start is called before the first frame update
    void Awake(){
        apps = new List<dynamic>();
        notes = new List<GameObject>();
        //180
    }
    void Start()
    {
        apps.Add(new { appName = "Notes", appPanel =  NotesPanel.gameObject });
        apps.Add(new { appName = "Newspaper", appPanel =  NewspaperPanel.gameObject });
        apps.Add(new { appName = "Quiz", appPanel =  QuizPanel.gameObject });
        apps.Add(new { appName = "Trading", appPanel =  TradingPanel.gameObject });
        //getInfo();
        //getSymbolsList();
        updateDropDown();
 }
 public void updateDropDown(){
     var tempList = new List<string>();
        tempList.Add("Select Stock");
        this.dropdownOptions = new List<string>();
        for(var i = 0; i < GameObject.FindObjectOfType<PlayerMovement>().stockPurchases.Count; i++){
            var newOp = String.Format("Id: {0} - {1} - {2} - {3} @ {4}",GameObject.FindObjectOfType<PlayerMovement>().stockPurchases[i].id, GameObject.FindObjectOfType<PlayerMovement>().stockPurchases[i].stockProfile.symbol, GameObject.FindObjectOfType<PlayerMovement>().stockPurchases[i].purchaseDate, GameObject.FindObjectOfType<PlayerMovement>().stockPurchases[i].numOfShares, GameObject.FindObjectOfType<PlayerMovement>().stockPurchases[i].stockProfile.price);
            tempList.Add(newOp);
        }
        this.dropdownOptions = tempList;
        Debug.Log(sellingDropdown.GetComponent<TMP_Dropdown>());
        if(sellingDropdown.GetComponent<TMP_Dropdown>() != null){
            sellingDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
            sellingDropdown.GetComponent<TMP_Dropdown>().AddOptions(dropdownOptions);
        }
 }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.I)){
            SwitchInventory();
        }
        
    }

    public void handleOnChangeDropdownValue(){
        if(sellingDropdown.GetComponent<TMP_Dropdown>().itemText.ToString() == "Select Stock"){

        }else {
            currentlySelectedStockToSell = sellingDropdown.GetComponent<TMP_Dropdown>().options[sellingDropdown.GetComponent<TMP_Dropdown>().value].text;
            var tempId = sellingDropdown.GetComponent<TMP_Dropdown>().options[sellingDropdown.GetComponent<TMP_Dropdown>().value].text.Split(':')[1].Split('-')[0].Trim();
            Debug.Log(tempId);
            StartCoroutine(populateSellingFields(GameObject.FindObjectOfType<PlayerMovement>().stockPurchases.Find(p => p.id.ToString() == tempId)));
        }

        Debug.Log("New Oppppppppp "+ currentlySelectedStockToSell);
    }

    IEnumerator populateSellingFields(StockPurchase purch){
        yield return new WaitForSeconds(1f);
        Debug.Log(purch.purchaseDate);
        sellingDropdown.transform.parent.transform.GetChild(1).GetComponent<Image>().sprite = (Sprite) Resources.Load("Sprites/"+ purch.stockProfile.symbol + "_LOGO_BUTTON", typeof(Sprite));
        sellingDropdown.transform.parent.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = purch.stockProfile.symbol;
        sellingDropdown.transform.parent.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "By: " + purch.stockProfile.companyName;
        sellingDropdown.transform.parent.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Price: " + purch.stockProfile.price.ToString();
        sellingDropdown.transform.parent.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "# of Shares: " + purch.numOfShares.ToString();
        sellingDropdown.transform.parent.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Total Recieved After Sale: " + (purch.stockProfile.price * purch.numOfShares);
        numOfSharesSliderSelling.maxValue = purch.numOfShares;
        numOfSharesSliderSelling.value = purch.numOfShares;
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(8));
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TextMeshProUGUI>());
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TextMesh>());
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TextMeshPro>());
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<Tmpro>());
        // Debug.Log(sellingDropdown.transform.parent.transform.GetChild(sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TextMeshProUGUI>()));
        sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TMP_InputField>().text = purch.numOfShares.ToString();

    }
    void SwitchInventory(){
        
        if(gameObject.transform.GetChild(0).gameObject.activeSelf == true){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/phone_close", typeof(AudioClip));
        }else {
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/phone_open", typeof(AudioClip));
        }

        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
    }
    public void OpenNotesAppVoid(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(OpenNotesApp());
        
    }
    public void OpenNewspaperAppVoid(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(OpenNewspaperApp());
        
    }
    public void OpenQuizAppVoid(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        if(!this.finishedQuiz){
            StartCoroutine(OpenQuizApp());
        }
        
    }

    public void OpenTradingAppVoid(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(OpenTradingApp());
        
    }

    public void OpenStockProfileVoid(string stockName){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(OpenStockProfile(stockName));
        
    }
    IEnumerator OpenStockProfile(string stockName){
        getStockDetails(stockName);
        yield return new WaitForSeconds(1f);
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        //activeAppIndex = apps.IndexOf(apps[3]);
        //Thread.Sleep(1000);
        scrollField.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
        stockDetailsPanel.SetActive(true);
    }
    void getStockDetails(string stockName){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://financialmodelingprep.com/api/v3/profile/{0}?apikey={1}", stockName,"17235435147ccfaa61e7630318bbf3f9"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        // sb = new StringBuilder();
        //sb.Append("{ \"symbols\": ");
        string jsonResponse = reader.ReadToEnd();
        //sb.Append(jsonResponse + " }");
        Profile[] objects = JsonHelper.getJsonArray<Profile> (jsonResponse);
        //SymbolInfo symbolsList = JsonUtility.FromJson<SymbolInfo>(sb.ToString());
        var profile = stockDetailsPanel.transform.GetChild(0);
        this.currentStockProfile = objects[0];
        profile.transform.GetChild(0).GetComponent<Image>().sprite = (Sprite) Resources.Load("Sprites/"+ stockName + "_LOGO_BUTTON", typeof(Sprite));
        profile.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = objects[0].symbol;
        profile.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = objects[0].companyName;
        profile.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = objects[0].price.ToString();
        profile.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = objects[0].range;
        profile.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = objects[0].description;
        profile.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text + " " + objects[0].ceo;
        profile.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text + " " + objects[0].industry;
        profile.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text + " " + objects[0].sector;
        profile.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text + " " + objects[0].address + ", " + objects[0].city + ", " + objects[0].state + ", " + objects[0].country;
        profile.transform.GetChild(11).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(11).GetComponent<TextMeshProUGUI>().text + " " + objects[0].beta.ToString();
        profile.transform.GetChild(12).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(12).GetComponent<TextMeshProUGUI>().text + " " + objects[0].volAvg.ToString();
        profile.transform.GetChild(13).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(13).GetComponent<TextMeshProUGUI>().text + " " + objects[0].mktCap.ToString();
        profile.transform.GetChild(14).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(14).GetComponent<TextMeshProUGUI>().text + " " + objects[0].lastDiv.ToString();
        profile.transform.GetChild(15).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(15).GetComponent<TextMeshProUGUI>().text + " " + objects[0].changes.ToString();
        profile.transform.GetChild(16).GetComponent<TextMeshProUGUI>().text = profile.transform.GetChild(16).GetComponent<TextMeshProUGUI>().text + " " + objects[0].currency;
        print(objects.Length);

    }
    public void checkOnValueChangedNumOfShares(){
        StartCoroutine(checkOnValueChangedNumOfSharesCor());
    }
    public bool checkForObjForth() {
        return (this.finishedQuiz == true && this.currentQuestionIndex == 0 && this.quizQuestions.Count == 0) ? true : false;
    }
    IEnumerator checkOnValueChangedNumOfSharesCor(){
        yield return new WaitForSeconds(0.5f);
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        // Debug.Log(input);
        var newTotalDue = Mathf.Round(numOfSharesSlider.value) * Mathf.Round((float)this.currentStockProfile.price);
        numOfSharesInput.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Mathf.Round(numOfSharesSlider.value).ToString();
        Debug.Log(Mathf.Round((float)this.currentStockProfile.price));
        //var newTotalDue = int.Parse(newValue) * this.currentStockProfile.price;
        var profile = stockDetailsPanel.transform.GetChild(0);
        profile.transform.GetChild(19).GetComponent<TextMeshProUGUI>().text = "Total Due (# of Shares X Price): " + newTotalDue.ToString();
        profile.transform.GetChild(20).GetComponent<TextMeshProUGUI>().text = "Available Funds: " + GameObject.FindObjectOfType<PlayerMovement>().cashAmountForPlayer.ToString();
        profile.transform.GetChild(21).GetComponent<TextMeshProUGUI>().text = "Funds After Purchase: " + (GameObject.FindObjectOfType<PlayerMovement>().cashAmountForPlayer - newTotalDue).ToString();
        if(GameObject.FindObjectOfType<PlayerMovement>().cashAmountForPlayer >= newTotalDue && newTotalDue != 0){
            this.purchaseBtn.GetComponent<Image>().color = new Color(0,1,0,0.4f);
            this.purchaseBtn.GetComponent<Button>().enabled = true;
            }else {
                this.purchaseBtn.GetComponent<Image>().color = new Color(1,0,0,0.4f);
                this.purchaseBtn.GetComponent<Button>().enabled = false;
            }
    }

    public void checkOnValueChangedNumOfSharesSelling(){
        if(sellingDropdown.GetComponent<TMP_Dropdown>().itemText.ToString() != "Select Stock"){

            StartCoroutine(checkOnValueChangedNumOfSharesSellingCor());
        }
    }
    IEnumerator checkOnValueChangedNumOfSharesSellingCor(){
        yield return new WaitForSeconds(0.5f);
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        // Debug.Log(input);
        var tempId = sellingDropdown.GetComponent<TMP_Dropdown>().options[sellingDropdown.GetComponent<TMP_Dropdown>().value].text.Split(':')[1].Split('-')[0].Trim();
        var currentStockProfileTemp = GameObject.FindObjectOfType<PlayerMovement>().stockPurchases.Find(p => p.id.ToString() == tempId);
        var newTotalDue = Mathf.Round(numOfSharesSliderSelling.value) * Mathf.Round((float) currentStockProfileTemp.stockProfile.price);
        sellingDropdown.transform.parent.transform.GetChild(8).GetComponent<TMP_InputField>().text = Mathf.Round(numOfSharesSliderSelling.value).ToString();
        // Debug.Log(Mathf.Round((float)currentStockProfileTemp.price));
        //var newTotalDue = int.Parse(newValue) * this.currentStockProfileTemp.price;
        // var profile = stockDetailsPanel.transform.GetChild(0);
        // profile.transform.GetChild(19).GetComponent<TextMeshProUGUI>().text = "Total Due (# of Shares X Price): " + newTotalDue.ToString();
        // profile.transform.GetChild(20).GetComponent<TextMeshProUGUI>().text = "Available Funds: " + GameObject.FindObjectOfType<PlayerMovement>().cashAmountForPlayer.ToString();
        // profile.transform.GetChild(21).GetComponent<TextMeshProUGUI>().text = "Funds After Purchase: " + (GameObject.FindObjectOfType<PlayerMovement>().cashAmountForPlayer - newTotalDue).ToString();
        sellingDropdown.transform.parent.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "Total Recieved After Sale: " + (currentStockProfileTemp.stockProfile.price * Mathf.Round(numOfSharesSliderSelling.value));
        if(Mathf.Round(numOfSharesSliderSelling.value) != 0){
            sellingDropdown.transform.parent.transform.GetChild(10).GetComponent<Image>().color = new Color(0,1,0,0.4f);
            sellingDropdown.transform.parent.transform.GetChild(10).GetComponent<Button>().enabled = true;
            }else {
                sellingDropdown.transform.parent.transform.GetChild(10).GetComponent<Image>().color = new Color(1,0,0,0.4f);
                sellingDropdown.transform.parent.transform.GetChild(10).GetComponent<Button>().enabled = false;
            }
    }

    public void handleOnClickPurchaseBtn(GameObject notificationObj){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(GameObject.FindObjectOfType<PlayerMovement>().purchaseStock(Mathf.Round(numOfSharesSlider.value), this.currentStockProfile, notificationObj));
    }
    public void handleOnClickSellBtn(GameObject notificationObj){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        var tempId = sellingDropdown.GetComponent<TMP_Dropdown>().options[sellingDropdown.GetComponent<TMP_Dropdown>().value].text.Split(':')[1].Split('-')[0].Trim();
        var currentStockProfileTemp = GameObject.FindObjectOfType<PlayerMovement>().stockPurchases.Find(p => p.id.ToString() == tempId);
        StartCoroutine(GameObject.FindObjectOfType<PlayerMovement>().sellStock(Mathf.Round(numOfSharesSliderSelling.value), currentStockProfileTemp, notificationObj));
    }
    IEnumerator OpenNotesApp(){
        yield return new WaitForSeconds(2f);
        activeAppIndex = apps.IndexOf(apps[0]);
        //Thread.Sleep(1000);
        NotesPanel.SetActive(true);
    }

    IEnumerator OpenNewspaperApp(){
        yield return new WaitForSeconds(2f);
        activeAppIndex = apps.IndexOf(apps[1]);
        //Thread.Sleep(1000);
        NewspaperPanel.SetActive(true);
    }
    IEnumerator OpenQuizApp(){
        yield return new WaitForSeconds(0f);
        activeAppIndex = apps.IndexOf(apps[2]);
        //Thread.Sleep(1000);
        QuizPanel.SetActive(true);
        StartCoroutine(populateQuestions());
        
        // for(var i = 0 ; i< quizQuestions.Count; i++){
            
        // }
    }
    IEnumerator OpenTradingApp(){
        yield return new WaitForSeconds(2f);
        activeAppIndex = apps.IndexOf(apps[3]);
        //Thread.Sleep(1000);
        TradingPanel.SetActive(true);
    }
    void getSymbolsList(){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://financialmodelingprep.com/api/v3/quote/AAPL,MSFT,AMZN,TSLA,KO,PFE,FB,GOOG,BABA,MCD?apikey={0}", "17235435147ccfaa61e7630318bbf3f9"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        // sb = new StringBuilder();
        //sb.Append("{ \"symbols\": ");
        string jsonResponse = reader.ReadToEnd();
        //sb.Append(jsonResponse + " }");
        Symbol[] objects = JsonHelper.getJsonArray<Symbol> (jsonResponse);
        //SymbolInfo symbolsList = JsonUtility.FromJson<SymbolInfo>(sb.ToString());
        print(objects.Length);
        // for(var i = 0; i < 5; i++){
            
        // }
    }

  public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
        return wrapper.array;
    }
 
    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}
    void getInfo(){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://financialmodelingprep.com/api/v3/key-metrics-ttm/AAPL?limit=40&apikey={0}", "17235435147ccfaa61e7630318bbf3f9"));
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          StreamReader reader = new StreamReader(response.GetResponseStream());
          string jsonResponse = reader.ReadToEnd();

          //WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
          //return info;
          Debug.Log(jsonResponse);
    }

    public void checkAnswerSelected(GameObject btn){
        // InputManager.instance.controls.Player.Disable();
        this.finishedQuiz = false;
        bool isCorrect = false;
        for(var i = 2 ; i < 6; i++){
            firstMissionChallengeParent.transform.GetChild(i).GetComponent<Button>().enabled = false;
            if(firstMissionChallengeParent.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == quizQuestions[currentQuestionIndex].answers[quizQuestions[currentQuestionIndex].correctAnswerIndex]){
                firstMissionChallengeParent.transform.GetChild(i).GetComponent<Image>().color = new Color(0,1,0,0.6f);
                // isCorrect = true;
            }else {
                firstMissionChallengeParent.transform.GetChild(i).GetComponent<Image>().color = new Color(1,0,0,0.6f);
            }
        }
        if(btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == quizQuestions[currentQuestionIndex].answers[quizQuestions[currentQuestionIndex].correctAnswerIndex]){
            isCorrect = true;
        }else {
            isCorrect = false;
        }
        if(isCorrect){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Correct_Answer", typeof(AudioClip));
        }else {
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Error_Sound", typeof(AudioClip));
        }

        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        quizQuestions[currentQuestionIndex].playerAnswer = btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        quizQuestions[currentQuestionIndex].changeQuestionStatus();
        Debug.Log(quizQuestions[currentQuestionIndex].playerAnswer);
        this.currentQuestionIndex+=1;
        if(this.currentQuestionIndex < quizQuestions.Count){
            StartCoroutine(populateQuestions());
        }else {
            StartCoroutine(showResults());
            //Thread.Sleep(2000);
            
        }
        //firstMissionChallengeParent.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
    }

    IEnumerator showResults(){
        yield return new WaitForSeconds(2f);
        for(var i = 0; i < 6; i++){
                firstMissionChallengeParent.transform.GetChild(i).gameObject.SetActive(false);

            }
            var prize = 10000;
            var numOfQuestions = this.Reverse((quizQuestions.Count * prize).ToString());
            firstMissionChallengeParent.transform.GetChild(6).gameObject.SetActive(true);
            firstMissionChallengeParent.transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $@"
            ﻋﺪﺩ ﺍﻷﺳﺌﻠﺔ : {quizQuestions.Count} ){this.Reverse((quizQuestions.Count * prize).ToString())}(
            ﺍﻷﺟﺎﺑﺎﺕ ﺍﻟﺼﺤﻴﺤﺔ: {quizQuestions.FindAll(q => q.playerAnswer == q.answers[q.correctAnswerIndex]).Count} ){this.Reverse((quizQuestions.FindAll(q => q.playerAnswer == q.answers[q.correctAnswerIndex]).Count * prize).ToString())}(
            ﺍﻷﺟﺎﺑﺎﺕ ﺍﻟﺨﺎﻃﺌﺔ: {quizQuestions.FindAll(q => q.playerAnswer != q.answers[q.correctAnswerIndex]).Count} ){this.Reverse((quizQuestions.FindAll(q => q.playerAnswer != q.answers[q.correctAnswerIndex]).Count * prize).ToString())}-(
            ﺍﻟﺠﺎﺋﺰﺓ ﺍﻟﻨﻬﺎﺋﻴﺔ: ){this.Reverse((quizQuestions.FindAll(q => q.playerAnswer == q.answers[q.correctAnswerIndex]).Count * 10000).ToString())}(";
            this.finishedQuiz = true;
            this.currentQuestionIndex = 0;
            var playerReward = quizQuestions.FindAll(q => q.playerAnswer == q.answers[q.correctAnswerIndex]).Count * 10000;
            firstMissionChallengeParent.transform.GetChild(6).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerReward.ToString();
            GameObject.FindObjectOfType<PlayerMovement>().updateCashAmountForPlayer(playerReward);
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Coin_Sound_Effect", typeof(AudioClip));
            if(!audioSrc.GetComponent<AudioSource>().isPlaying){
                audioSrc.GetComponent<AudioSource>().Play();
            }
            quizQuestions = new List<QuizQuestion>();
            yield return new WaitForSeconds(10f);
            GameObject.FindObjectOfType<MissionOne>().quizQuestions.RemoveRange(0,5);
            firstMissionChallengeParent.transform.GetChild(6).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            firstMissionChallengeParent.transform.GetChild(6).gameObject.SetActive(false);
            for(var i = 0; i < 6; i++){
                firstMissionChallengeParent.transform.GetChild(i).gameObject.SetActive(true);
            }
            CloseCurrentApp();
            yield return new WaitForSeconds(10f);
            this.finishedQuiz = false;
    }
    public string Reverse( string s )
    {
    char[] charArray = s.ToCharArray();
    Array.Reverse( charArray );
    return new string( charArray );
    }
    IEnumerator populateQuestions(){
        this.finishedQuiz = false;
        if(currentQuestionIndex != 0){
            yield return new WaitForSeconds(2f);
        }
        quizQuestions = GameObject.FindObjectOfType<MissionOne>().quizQuestions.GetRange(0,5);
        for(var i = 2 ; i < 6; i++){
            firstMissionChallengeParent.transform.GetChild(i).GetComponent<Image>().color = new Color(1,1,1,0.6f);
            firstMissionChallengeParent.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }
        System.Random rand = new System.Random();
        var correctAnswerIndex = rand.Next(2, 6);
        List<int> indexes = new List<int>{ 2, 3, 4, 5 };

        indexes.RemoveAt(indexes.IndexOf(correctAnswerIndex));

        
        quizQuestions[currentQuestionIndex].answers.ForEach(e => {
            if(quizQuestions[currentQuestionIndex].answers.IndexOf(e) == quizQuestions[currentQuestionIndex].correctAnswerIndex){
                firstMissionChallengeParent.transform.GetChild(correctAnswerIndex).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e;
            }else {
                firstMissionChallengeParent.transform.GetChild(indexes[0]).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e;
                indexes.RemoveAt(0);
            }
        });
        firstMissionChallengeParent.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizQuestions[currentQuestionIndex].questionText;
        firstMissionChallengeParent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = currentQuestionIndex + 1 + "/" + quizQuestions.Count;
        // firstMissionChallengeParent.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizQuestions[currentQuestionIndex].CorrectAnswer;
        // firstMissionChallengeParent.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizQuestions[currentQuestionIndex].questionAnswerTwo;
        // firstMissionChallengeParent.transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizQuestions[currentQuestionIndex].questionAnswerThree;
        // firstMissionChallengeParent.transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quizQuestions[currentQuestionIndex].questionAnswerFour;
    }

    public void CloseCurrentApp(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        apps[this.activeAppIndex].appPanel.SetActive(false);
    }
    public void OpenBuyingTab(){
        BuyingGameObject.gameObject.SetActive(true);
        SellingGameObject.gameObject.SetActive(false);
        scrollField.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;

    }
    public void OpenSellingTab(){
        BuyingGameObject.gameObject.SetActive(false);
        SellingGameObject.gameObject.SetActive(true);
        scrollField.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;

    }
    public void exitStockProfile(){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        scrollField.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
        stockDetailsPanel.gameObject.SetActive(false);
    }
    public void OnClickNoteButton(GameObject g){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        // Debug.Log(g.GetComponent<Button>().transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        // noteTitleInv.text = g.GetComponent<Note>().title;
        // noteContentInv.text = g.GetComponent<Note>().content;
        for(var i = 0; i < notes.Count; i++){
            if(notes[i].GetComponent<Note>().title == g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text){
                noteTitleInv.text = notes[i].GetComponent<Note>().title;
                noteContentInv.text = notes[i].GetComponent<Note>().content;
            }
        }
    }    public void OnClickNewspaperButton(GameObject g){
        audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/app_open", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        // Debug.Log(g.GetComponent<Button>().transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        // noteTitleInv.text = g.GetComponent<Note>().title;
        // noteContentInv.text = g.GetComponent<Note>().content;
        for(var i = 0; i < newspapers.Count; i++){
            if(newspapers[i].GetComponent<Newspaper>().sprite.name == g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text){
                NewspaperImageFromApp.GetComponent<Image>().sprite= newspapers[i].GetComponent<Newspaper>().sprite;
                //noteContentInv.text = notes[i].GetComponent<Note>().content; 180
            }
        }
    }
}
