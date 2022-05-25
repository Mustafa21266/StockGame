using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondObjective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("check", 5f, 2f);
    }
    void check() {
        if (!GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive)
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
            //gameObject.transform.parent.parent.GetComponent<MissionOne>().quizAppButton.onClick.AddListener(delegate { gameObject.transform.parent.parent.GetComponent<MissionOne>().quizAppButtonClicked(new Objective()); });
            /*            if (onCompleteObj != null)
                        {

                            *//*if (objectives.IndexOf(obj) == 16)
                            {
                                notesParent.transform.GetChild(2).gameObject.SetActive(true);
                                notes.Add(notesParent.transform.GetChild(2).gameObject);
                                notes[2].AddComponent<Note>();
                                notes[2].GetComponent<Note>().title = "Your Code";
                                notes[2].GetComponent<Note>().content = "YXWQEQW920000232";
                            }*//*

                            //this.activeCutScene = null;
                            //this.prepareFirstQuiz();
                            //Debug.Log("dONE 2");
                        }*/
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
