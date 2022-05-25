using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForthSideObjective : MonoBehaviour
{
    public GameObject TopLeftReply;
    public GameObject TopRightReply;


    public GameObject topLeftReply;
    public GameObject topRightReply;


    public GameObject postPanel;

    public GameObject choiceBtn;

    public GameObject choicesPanel;


    public GameObject choicesPanelInvestmentHub;

    public List<List<string>> choices;

    public bool finishedChoices = false;

    public GameObject AdjustBtn;

    public GameObject audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        choices = new List<List<string>>();

        choices.Add(new List<string>() { "ﺩﻩ ﺑﻴﻜﻮﻥ ﻓﻲ ﺍﻻﻏﻠﺐ ﺍﻧﻚ ﻣﻀﻴﺖ ﻭﺭﻕ ﻋﻠﻰ ﺑﻴﺎﺽ ﻭﻋﻠﻴﻚ ﺗﻌﻴﺪ ﻗﺮﺍﺀﻩ ﻋﻘﻮﺩﻙ ﺗﺎﻧﻲ", "ﺷﻜﺮﺍ ﺟﺪﺍ ﻫﺤﺎﻭﻝ ﺗﺴﻠﻢ ﻳﺎﺭﺏ" });


        choices.Add(new List<string>() { "ﺍﺗﺠﻪ ﻟﻠﺤﻞ ﺍﻟﻘﻀﺎﺋﻲ", "ﺷﻜﺮﺍ ﺟﺪﺍ ﻫﺤﺎﻭﻝ ﺗﺴﻠﻢ ﻳﺎﺭﺏ" });

        //StartCoroutine(run(choices[0]));
        StartCoroutine(populateChoices());

    }
    void FixedUpdate()
    {
        if (finishedChoices == true)
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionOne>().changeSideObjective(gameObject);
            StartCoroutine(close());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(30f);
        //gameObject.SetActive(false);

    }
    IEnumerator run(List<string> conv)
    {
        /*if (choicesPanel.transform.childCount == 0)
        {
            
        }
*/
        StartCoroutine(sendMessage(conv, 0));
        yield return new WaitForSeconds(10f);
        StartCoroutine(sendMessage(conv, 1));
        if (choices[0][0] == conv[0])
        {
            GameObject.FindObjectOfType<PlayerMovement>().updateCashAmountForPlayer(10000);
        }
        else if (choices[1][0] == conv[0])
        {
            GameObject.FindObjectOfType<PlayerMovement>().updateCashAmountForPlayer(8000);
        }
        audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Coin_Sound_Effect", typeof(AudioClip));
        if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(10f);
        
    }

    IEnumerator sendMessage(List<string> conv, int index)
    {
        yield return new WaitForSeconds(5f);
        if (index == 0)
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/comment", typeof(AudioClip));
            if (!audioSrc.GetComponent<AudioSource>().isPlaying)
            {
                audioSrc.GetComponent<AudioSource>().Play();
            }
            topRightReply.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[0];
            topRightReply.gameObject.SetActive(true);
            topRightReply.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Me";
            /*var newOne = Instantiate(TopRightReply, new Vector3(0, -182, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[0];
            newOne.transform.SetParent(postPanel.transform);
            newOne.gameObject.SetActive(true);*/
        }
        else
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/reply", typeof(AudioClip));
            if (!audioSrc.GetComponent<AudioSource>().isPlaying)
            {
                audioSrc.GetComponent<AudioSource>().Play();
            }
            topLeftReply.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[1];
            topLeftReply.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = topLeftReply.transform.parent.gameObject.transform.GetChild(0).GetComponent<Post>().avatar;
            topLeftReply.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = topLeftReply.transform.parent.gameObject.transform.GetChild(0).GetComponent<Post>().name;
            topLeftReply.gameObject.SetActive(true);
            
            /*var newTwo = Instantiate(TopLeftReply, new Vector3(0, -354, 0), Quaternion.identity);
            newTwo.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conv[1];
            newTwo.transform.SetParent(postPanel.transform);
            newTwo.gameObject.SetActive(true);*/
        }



    }

    IEnumerator populateChoices()
    {
        yield return new WaitForSeconds(5f);
        for (var i = 0; i < choices.Count; i++)
        {
            var newOne = Instantiate(choiceBtn, new Vector3(500, 0, 0), Quaternion.identity);
            newOne.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = choices[i][0];
            newOne.transform.SetParent(choicesPanel.transform);
            newOne.gameObject.SetActive(true);
            newOne.GetComponent<Button>().onClick.AddListener(delegate { this.reply(newOne.gameObject); });
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
    public void reply(GameObject instance)
    {
        //newOne.GetComponent<Button>().onClick.AddListener(delegate { this.reply(newOne.gameObject); });
        //StartCoroutine(sendMessage(new List<string> { instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text, ""}, 0));
        var parent = instance.transform.parent;
        for (var i = 0; i < choices.Count; i++)
        {
            if (choices[i][0] == instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)
            {
                //var idx = choices[i].IndexOf();
                StartCoroutine(run(new List<string> { instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text, choices[i][1] }));
                
                if (instance.transform.parent.GetChild(0) == instance && instance.transform.parent.childCount == 1)
                {
                    //StartCoroutine(run(conversation[conversation.Count - 1]));
                    finishedChoices = true;
                }
                for (var x = 0; x < instance.transform.parent.childCount; x++) { 
                    Destroy(instance.transform.parent.GetChild(x).gameObject);
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
}
