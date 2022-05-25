using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
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


        //userChoices.Add(new List<string>() { "ﻣﺜﻼ ﺷﺨﺺ ﻟﻘﻰ ﺍﻧﻪ ﻣﺘﻜﺒﺪ ﺧﺴﺎﺋﺮ ﻛﺒﻴﺮﻩ ﻓﻲ ﻋﻤﻠﻴﺎﺕ ﻣﻦ ﻏﻴﺮ ﻋﻠﻤﻪ", "ﺑﺲ ﺍﻟﺒﻮﺭﺻﺔ ﻻﺯﻡ ﺗﺎﺧﺪ ﻣﻮﻗﻒ ﺿﺪ ﺍﻟﻌﻤﻠﻴﺎﺕ ﺩﻱ ﻭﺗﻜﻮﻥ ﻣﻊ ﺍﻟﻤﻨﺼﻮﺏ ﻋﻠﻴﻪ ﻣﺶ ﺗﺴﻴﺒﻬﻢ" });

        //conversation.Add(new List<string>() { "", "ﺩﻩ ﺑﻴﻜﻮﻥ ﺍﻧﻪ ﻣﻘﺮﺍﺵ ﺍﻟﻮﺭﻕ ﻛﻮﻳﺲ ﻗﺒﻞ ﺍﻟﺘﻮﻗﻴﻊ ﻋﻠﻴﻪ ﺍﻭ ﻣﻀﻰ ﻋﻠﻰ ﻭﺭﻕ ﻋﻠﻰ ﺑﻴﺎﺽ ﻣﻬﻤﺎ ﻛﺎﻧﺖ ﺛﻘﺘﻚ ﺑﺎﻟﺸﺮﻛﺔ ﺍﻻﻓﺮﺍﻁ ﻓﻲ ﺍﻟﺜﻘﺔ ﻳﻌﺘﺒﺮ ﻣﻦ ﺍﺳﻮﺍ ﺍﻟﺠﺮﺍﺋﻢ ﻭﻫﻨﺎ ﻣﺶ ﺑﻴﻜﻮﻥ ﻓﻲ ﺇﻳﺪ ﺍﻟﺒﻮﺭﺻﺔ ﺍﻧﻬﺎ ﺗﻌﻤﻞ ﺣﺎﺟﻪ ﻷﻧﻪ ﻫﻮ ﺍﻟﻠﻲ ﻭﻗﻊ ﻧﻔﺴﻪ ﻓﻲ ﺩﻩ ﻭﻣﻤﻜﻦ ﻳﻠﺠﺎ ﻟﻠﺤﻞ ﺍﻟﻘﻀﺎﺋﻲ" });
        
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
        yield return new WaitForSeconds(20f);
        StartCoroutine(run(conversation[conversation.Count - 1]));
        gameObject.GetComponent<Objective>().isComplete = true;
        yield return new WaitForSeconds(30f);
        gameObject.transform.parent.parent.GetComponent<MissionOne>().changeSideObjective(gameObject);
        //gameObject.SetActive(false);

    }
    IEnumerator populate() {


        StartCoroutine(run(conversation[0]));

        yield return new WaitForSeconds(10f);

        StartCoroutine(run(conversation[1]));

        yield return new WaitForSeconds(5f);

        
       StartCoroutine(populateChoices());

        /*var newThree = Instantiate(TopRightMessage, new Vector3(500, 0, 0), Quaternion.identity);
        newThree.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conversation[1][0];
        newThree.transform.SetParent(chatPanel.transform);
        newThree.gameObject.SetActive(true);
        var newFour = Instantiate(TopLeftMessage, new Vector3(500, 0, 0), Quaternion.identity);
        newFour.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conversation[1][1];
        newFour.transform.SetParent(chatPanel.transform);
        newFour.gameObject.SetActive(true);*/


    }

    IEnumerator run(List<string> conv) {
        /*if (choicesPanel.transform.childCount == 0)
        {
            
        }
*/
        audioSrc.GetComponent<AudioSource>().Stop();
        audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/typing", typeof(AudioClip));
        audioSrc.GetComponent<AudioSource>().Play();
        /*if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }*/
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
            audioSrc.GetComponent<AudioSource>().Stop();
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/sent_msg", typeof(AudioClip));
            audioSrc.GetComponent<AudioSource>().Play();
/*            if (!audioSrc.GetComponent<AudioSource>().isPlaying)
            {
                audioSrc.GetComponent<AudioSource>().Play();
            }*/
            var newOne = Instantiate(TopRightMessage, new Vector3(500, 0, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[0];
            newOne.transform.SetParent(chatPanel.transform);
            //audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/typing", typeof(AudioClip));
            newOne.gameObject.SetActive(true);
        }
        else {
            audioSrc.GetComponent<AudioSource>().Stop();
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/msg_delivered", typeof(AudioClip));
            audioSrc.GetComponent<AudioSource>().Play();
            /*if (!audioSrc.GetComponent<AudioSource>().isPlaying)
            {
                audioSrc.GetComponent<AudioSource>().Play();
            }*/
            
            var newTwo = Instantiate(TopLeftMessage, new Vector3(500, 0, 0), Quaternion.identity);
            newTwo.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[1];
            newTwo.transform.SetParent(chatPanel.transform);
            newTwo.gameObject.SetActive(true);
            status.text = "Online";
            status.color = new Color(255, 255, 255, 1f);
        }

        

    }
    IEnumerator populateChoices()
    {
        yield return new WaitForSeconds(5f);
        for (var i = 0; i < choices.Count; i++) {
            var newOne = Instantiate(choiceBtn, new Vector3(500, 0, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = choices[i][0];
            newOne.transform.SetParent(choicesPanel.transform);
            newOne.gameObject.SetActive(true);
            newOne.GetComponent<Button>().onClick.AddListener(delegate { this.reply(newOne.gameObject); });
            childC++;
        }
        /*if (index == 0)
        {
            
        }
        else
        {
            var newTwo = Instantiate(TopLeftMessage, new Vector3(500, 0, 0), Quaternion.identity);
            newTwo.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[1];
            newTwo.transform.SetParent(chatPanel.transform);
            newTwo.gameObject.SetActive(true);
        }*/



    }

    public void reply(GameObject instance) {
        //newOne.GetComponent<Button>().onClick.AddListener(delegate { this.reply(newOne.gameObject); });
        //StartCoroutine(sendMessage(new List<string> { instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text, ""}, 0));
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
            /*for (var j = 0; i < choices[i].Count; j++)
            {
                if (userChoices[i][j] == instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)
                {
                    //var idx = choices[i].IndexOf();
                    StartCoroutine(run(new List<string> { userChoices[i][userChoices[i].IndexOf(instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)], npcChoices[i][userChoices[i].IndexOf(instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)] }));
                    Destroy(instance.gameObject);
                }
                else
                {
                    Debug.Log("pRO");
                    Debug.Log("I: " + i);
                    Debug.Log("J: " + j);
                }

            }*/
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
