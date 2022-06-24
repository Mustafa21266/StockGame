using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    // This class is responsible of chatting application on the tablet
    public GameObject TopLeftMessage;
    public GameObject TopRightMessage;

    public GameObject chatPanel;

    public GameObject choicesPanel;

    public GameObject choiceBtn;

    public List<List<string>> conversation;

    public List<List<string>> npcChoices;

    public List<List<string>> userChoices;

    public List<List<string>> choices;

    public bool finishedChoices = false;

    public int childC = 0;

    public GameObject audioSrc;

    public Text status;
    // Start is called before the first frame update
    void Start()
    {
        // This method for the chat conversation hard coded because of lack of unity support for the Arabic language
        conversation = new List<List<string>>();

        npcChoices = new List<List<string>>();

        userChoices = new List<List<string>>();

        choices = new List<List<string>>();

        var newConv = new List<string>() { "؟ ﺢﺻ ﻥﺎﻣﺍ ﺔﺻﺭﻮﺒﻟﺍ ﺶﻣ ﻲﻫ ﺲﺑ ﺶﻠﻌﻣ", "ﺎﻬﻳﺮﻤﺜﺘﺴﻤﻟ ﻥﺎﻣﺍ ﺮﺒﻛﺍ ﻖﻘﺤﺗ ﺎﻬﻧﺍ ًﺎﻤﻳﺩ ﻲﻌﺴﺘﺑﻭ ﻩﺍ" };


        conversation.Add(new List<string>() { "ﻣﻌﻠﺶ ﺑﺲ ﻫﻲ ﻣﺶ ﺍﻟﺒﻮﺭﺻﺔ ﺍﻣﺎﻥ ﺻﺢ ؟", "ﺍﻩ ﻭﺑﺘﺴﻌﻲ ﺩﻳﻤﺎً ﺍﻧﻬﺎ ﺗﺤﻘﻖ ﺍﻛﺒﺮ ﺍﻣﺎﻥ ﻟﻤﺴﺘﺜﻤﺮﻳﻬﺎ" });

        conversation.Add(new List<string>() { "ﺍﻧﺎ ﻗﺮﺍﺕ ﺍﺧﺒﺎﺭ ﻧﺼﺐ ﻳﺎﻣﺎ ﻓﺈﺯﺍ ﻳﺎﻣﺎﻥ !؟", "ﻓﻲ ﺍﻏﻠﺐ ﺍﻟﻮﻗﺖ ﺑﻴﻜﻮﻥ ﻋﺪﻡ ﺣﺮﺹ ﻣﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ" });



        userChoices.Add(new List<string>() { "ﺍﺯﺍﻱ ؟", "ﺩﻩ ﺗﻬﺮﺏ ﻣﻦ ﺗﺤﻤﻞ ﺍﻟﻤﺴﺆﻭﻟﻴﺔ ﺍﻛﺘﺮ ﺻﺢ ؟ ﻻﻥ ﻣﺴﺘﺤﻴﻞ ﻛﻞ ﺩﻩ ﻋﺪﻡ ﺣﺮﺹ ﻣﻦ ﺍﻟﻤﺴﺘﺨﺪﻡ" });

        npcChoices.Add(new List<string>() { "ﻋﻠﻰ ﺣﺴﺐ ﻃﺒﻴﻌﺔ ﻋﻤﻠﻴﻪ ﺍﻟﻨﺼﺐ", "ﻣﺶ ﺗﻬﺮﺏ ﻭﻟﻜﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺍﻭﻗﺎﺕ ﻛﺘﻴﺮ ﺑﻴﻤﻀﻲ ﻋﻠﻰ ﻭﺭﻕ ﻫﻮ ﻣﻘﺮﺍﻫﻮﺵ ﺍﻭ ﻋﻘﻮﺩ ﺑﻴﻀﺎﺀ" });


        choices.Add(new List<string>() { "ﺍﺯﺍﻱ ؟", "ﻋﻠﻰ ﺣﺴﺐ ﻃﺒﻴﻌﺔ ﻋﻤﻠﻴﻪ ﺍﻟﻨﺼﺐ" });

        choices.Add(new List<string>() { "ﺩﻩ ﺗﻬﺮﺏ ﻣﻦ ﺗﺤﻤﻞ ﺍﻟﻤﺴﺆﻭﻟﻴﺔ ﺍﻛﺘﺮ ﺻﺢ ؟ ﻻﻥ ﻣﺴﺘﺤﻴﻞ ﻛﻞ ﺩﻩ ﻋﺪﻡ ﺣﺮﺹ ﻣﻦ ﺍﻟﻤﺴﺘﺨﺪﻡ", "ﻣﺶ ﺗﻬﺮﺏ ﻭﻟﻜﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺍﻭﻗﺎﺕ ﻛﺘﻴﺮ ﺑﻴﻤﻀﻲ ﻋﻠﻰ ﻭﺭﻕ ﻫﻮ ﻣﻘﺮﺍﻫﻮﺵ ﺍﻭ ﻋﻘﻮﺩ ﺑﻴﻀﺎﺀ" });

        choices.Add(new List<string>() { "ﻣﺜﻼ ﺷﺨﺺ ﻟﻘﻰ ﺍﻧﻪ ﻣﺘﻜﺒﺪ ﺧﺴﺎﺋﺮ ﻛﺒﻴﺮﻩ ﻓﻲ ﻋﻤﻠﻴﺎﺕ ﻣﻦ ﻏﻴﺮ ﻋﻠﻤﻪ", "ﺩﻩ ﺑﻴﻜﻮﻥ ﺍﻧﻪ ﻣﻘﺮﺍﺵ ﺍﻟﻮﺭﻕ ﻛﻮﻳﺲ ﻗﺒﻞ ﺍﻟﺘﻮﻗﻴﻊ ﻋﻠﻴﻪ ﺍﻭ ﻣﻀﻰ ﻋﻠﻰ ﻭﺭﻕ ﻋﻠﻰ ﺑﻴﺎﺽ ﻣﻬﻤﺎ ﻛﺎﻧﺖ ﺛﻘﺘﻚ ﺑﺎﻟﺸﺮﻛﺔ ﺍﻻﻓﺮﺍﻁ ﻓﻲ ﺍﻟﺜﻘﺔ ﻳﻌﺘﺒﺮ ﻣﻦ ﺍﺳﻮﺍ ﺍﻟﺠﺮﺍﺋﻢ ﻭﻫﻨﺎ ﻣﺶ ﺑﻴﻜﻮﻥ ﻓﻲ" +
            " ﺇﻳﺪ ﺍﻟﺒﻮﺭﺻﺔ ﺍﻧﻬﺎ ﺗﻌﻤﻞ ﺣﺎﺟﻪ ﻷﻧﻪ ﻫﻮ ﺍﻟﻠﻲ ﻭﻗﻊ ﻧﻔﺴﻪ ﻓﻲ ﺩﻩ ﻭﻣﻤﻜﻦ ﻳﻠﺠﺎ ﻟﻠﺤﻞ ﺍﻟﻘﻀﺎﺋﻲ" });
        
        
        choices.Add(new List<string>() { "ﺑﺲ ﺍﻟﺒﻮﺭﺻﺔ ﻻﺯﻡ ﺗﺎﺧﺪ ﻣﻮﻗﻒ ﺿﺪ ﺍﻟﻌﻤﻠﻴﺎﺕ ﺩﻱ ﻭﺗﻜﻮﻥ ﻣﻊ ﺍﻟﻤﻨﺼﻮﺏ ﻋﻠﻴﻪ ﻣﺶ ﺗﺴﻴﺒﻬﻢ", "ﺩﻩ ﺑﻴﻜﻮﻥ ﺍﻧﻪ ﻣﻘﺮﺍﺵ ﺍﻟﻮﺭﻕ ﻛﻮﻳﺲ ﻗﺒﻞ ﺍﻟﺘﻮﻗﻴﻊ ﻋﻠﻴﻪ ﺍﻭ ﻣﻀﻰ ﻋﻠﻰ ﻭﺭﻕ ﻋﻠﻰ ﺑﻴﺎﺽ ﻣﻬﻤﺎ ﻛﺎﻧﺖ ﺛﻘﺘﻚ ﺑﺎﻟﺸﺮﻛﺔ ﺍﻻﻓﺮﺍﻁ ﻓﻲ ﺍﻟﺜﻘﺔ ﻳﻌﺘﺒﺮ ﻣﻦ ﺍﺳﻮﺍ ﺍﻟﺠﺮﺍﺋﻢ ﻭﻫﻨﺎ ﻣﺶ ﺑﻴﻜﻮﻥ ﻓﻲ ﺇﻳﺪ ﺍﻟﺒﻮﺭﺻﺔ ﺍﻧﻬﺎ ﺗﻌﻤﻞ ﺣﺎﺟﻪ ﻷﻧﻪ ﻫﻮ ﺍﻟﻠﻲ ﻭﻗﻊ ﻧﻔﺴﻪ ﻓﻲ ﺩﻩ ﻭﻣﻤﻜﻦ ﻳﻠﺠﺎ ﻟﻠﺤﻞ ﺍﻟﻘﻀﺎﺋﻲ" });

        userChoices.Add(new List<string>() { "ﻣﺜﻼ ﺷﺨﺺ ﻟﻘﻰ ﺍﻧﻪ ﻣﺘﻜﺒﺪ ﺧﺴﺎﺋﺮ ﻛﺒﻴﺮﻩ ﻓﻲ ﻋﻤﻠﻴﺎﺕ ﻣﻦ ﻏﻴﺮ ﻋﻠﻤﻪ", "ﺑﺲ ﺍﻟﺒﻮﺭﺻﺔ ﻻﺯﻡ ﺗﺎﺧﺪ ﻣﻮﻗﻒ ﺿﺪ ﺍﻟﻌﻤﻠﻴﺎﺕ ﺩﻱ ﻭﺗﻜﻮﻥ ﻣﻊ ﺍﻟﻤﻨﺼﻮﺏ ﻋﻠﻴﻪ ﻣﺶ ﺗﺴﻴﺒﻬﻢ" });

        conversation.Add(new List<string>() { "ﻓﻬﻤﺖ ﺷﻜﺮﺍ ﺟﺪﺍ ﻟﺤﻀﺮﺗﻚ", "ﺍﻟﻌﻔﻮ ﻋﻠﻲ ﺍﻳﻪ" });



        StartCoroutine(populate());
    }
    void FixedUpdate()
    {
        if (childC == 1000)
        {
            StartCoroutine(close());
            childC = 0;
        }
        /*if (finishedChoices == true) {
            
        }*/
    }
    IEnumerator close() {
        // closing method to check if the conversation completed to change the objective
        yield return new WaitForSeconds(20f);
        StartCoroutine(run(conversation[conversation.Count - 1]));
        gameObject.GetComponent<Objective>().isComplete = true;
        yield return new WaitForSeconds(30f);
        gameObject.transform.parent.parent.GetComponent<MissionOne>().changeSideObjective(gameObject);
        //gameObject.SetActive(false);

    }
    IEnumerator populate() {

        // populate the conversation
        StartCoroutine(run(conversation[0]));

        yield return new WaitForSeconds(10f);

        StartCoroutine(run(conversation[1]));

        yield return new WaitForSeconds(5f);

        
       StartCoroutine(populateChoices());
    }

    IEnumerator run(List<string> conv) {
        // this method to run the audio sound of typing status
        audioSrc.GetComponent<AudioSource>().Stop();
        audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/typing", typeof(AudioClip));
        audioSrc.GetComponent<AudioSource>().Play();
        // chaning the status of the chat if typing
        StartCoroutine(sendMessage(conv, 0));
        yield return new WaitForSeconds(5f);
        status.text = "Typing";
        status.color = new Color(0,255,0,0.8f);
        StartCoroutine(sendMessage(conv, 1));
        yield return new WaitForSeconds(5f);
    }

    IEnumerator sendMessage(List<string> conv, int index) {
        yield return new WaitForSeconds(5f);
        if (index == 0)
        {
            // running the sending massage and massage delivered sounds 
            audioSrc.GetComponent<AudioSource>().Stop();
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/sent_msg", typeof(AudioClip));
            audioSrc.GetComponent<AudioSource>().Play();
            var newOne = Instantiate(TopRightMessage, new Vector3(500, 0, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[0];
            newOne.transform.SetParent(chatPanel.transform);
            newOne.gameObject.SetActive(true);
        }
        else {
            audioSrc.GetComponent<AudioSource>().Stop();
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/msg_delivered", typeof(AudioClip));
            audioSrc.GetComponent<AudioSource>().Play();
            // editing the status to make it online when the chat is active
            var newTwo = Instantiate(TopLeftMessage, new Vector3(500, 0, 0), Quaternion.identity);
            newTwo.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[1];
            newTwo.transform.SetParent(chatPanel.transform);
            newTwo.gameObject.SetActive(true);
            status.text = "Online";
            status.color = new Color(255, 255, 255, 1f);
        }
    }
    IEnumerator populateChoices()
    {   // this method populating the choices to the player in a form of buttons
        yield return new WaitForSeconds(5f);
        for (var i = 0; i < choices.Count; i++) {
            var newOne = Instantiate(choiceBtn, new Vector3(500, 0, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = choices[i][0];
            newOne.transform.SetParent(choicesPanel.transform);
            newOne.gameObject.SetActive(true);
            newOne.GetComponent<Button>().onClick.AddListener(delegate { this.reply(newOne.gameObject); });
            childC++;
        }

    }

    public void reply(GameObject instance) {
        // reply method to send the reply depending on the player choices
        var parent = instance.transform.parent;
        for (var i = 0; i < choices.Count; i++)
        {
            if (choices[i][0] == instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)
            {
                //var idx = choices[i].IndexOf();
                StartCoroutine(run(new List<string> { instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text, choices[i][1] }));
                Destroy(instance.gameObject);
                childC--;
                if (childC == 0) {
                    childC = 1000;
                }
                if (choicesPanel.gameObject.transform.childCount == 0)
                {
                    finishedChoices = true;
                }
            }
        }


    }
}
