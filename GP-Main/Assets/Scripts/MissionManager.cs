using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    [SerializeField]
    public Mission activeMission;

    public List<Mission> missions = new List<Mission>();

    public List<GameObject> missionStartPoints;

    public int currentActiveMissionIndex = 0;

    private GameObject image;

    private TextMeshProUGUI currentObjectiveText;

    private TextMeshProUGUI currentObjectiveText2;

    public GameObject currentObjectiveTextGameObject;
    public GameObject currentSideObjectiveTextGameObject;

    public GameObject promptPanel;

    public GameObject cutscenesParent;

    // Start is called before the first frame update
    void Start()
    {
        //missions = new List<Mission>();

        //missions.Add(Instantiate<Mission>(new MissionOne()));
        // activeMission = Instantiate<Mission>(missions[0]);
        Load();
        if (currentActiveMissionIndex < missions.Count) { 
            activeMission = missions[currentActiveMissionIndex];
        }
        //image = gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(activeMission.objectives[0].title);
        //currentObjectiveText = image.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        //currentObjectiveText.text = activeMission.objectives[0].title;
        //currentObjectiveText.text = "";


        //currentObjectiveText2 = image.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();

        //currentObjectiveText2.text = activeMission.sideObjectives[0].title;
        //updateObjectives(activeMission.objectives[0]);
        //MissionOne.onChangeObj += updateObjectiveTest;
        //MissionOne.onChangeObjSide += updateObjectiveTest2;
    }
    void Load() {
        currentActiveMissionIndex = ES3.Load<int>("currentActiveMissionIndex", 0);
        Debug.Log("Heeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeey " + currentActiveMissionIndex);
        if (currentActiveMissionIndex < 4)
        {
            for (var i = 0; i < currentActiveMissionIndex; i++)
            {
                Destroy(cutscenesParent.transform.GetChild(i).gameObject);
                //cutscenesParent.transform.GetChild(i).gameObject.SetActive(false);
                Destroy(missions[i].gameObject);
                missionStartPoints[i].gameObject.SetActive(false);

            }
            if (currentActiveMissionIndex + 1 < missionStartPoints.Count)
            {
                //Destroy(cutscenesParent.transform.GetChild(0).gameObject);
                cutscenesParent.transform.GetChild(0).gameObject.SetActive(true);
                //currentActiveMissionIndex++;
                //Destroy(missionStartPoints[i].gameObject);
                //Destroy(missionStartPoints[currentActiveMissionIndex].gameObject);
                //Destroy(missionStartPoints[currentActiveMissionIndex].gameObject);
                //missionStartPoints.RemoveAt(i);
            }
            else
            {
                //Destroy(cutscenesParent.transform.GetChild(0).gameObject);
                cutscenesParent.transform.GetChild(0).gameObject.SetActive(true);
                currentActiveMissionIndex = missions.Count - 1;
            }
            //cutscenesParent.transform.GetChild(1).gameObject.SetActive(true);
            missions[currentActiveMissionIndex].gameObject.SetActive(true);
            activeMission = missions[currentActiveMissionIndex];
            if (currentActiveMissionIndex + 1 < missionStartPoints.Count)
            {
                missionStartPoints[currentActiveMissionIndex + 1].gameObject.SetActive(true);
            }
            else
            {
                missionStartPoints[missionStartPoints.Count - 1].gameObject.SetActive(true);
            }
            GameObject.FindGameObjectWithTag("Player").transform.position = missionStartPoints[currentActiveMissionIndex].transform.position - new Vector3(4f, 0f, -2.5f);
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(new Vector3(0f, 90f, 0f), Space.Self);

            promptPanel.gameObject.SetActive(false);
            //ES3.Save<int>("currentActiveMissionIndex", currentActiveMissionIndex);
            if (currentActiveMissionIndex == 1)
            {
                GameObject.FindObjectOfType<MissionTwo>().StartCutsceneWithConversation();
            }
            else if (currentActiveMissionIndex == 2)
            {
                GameObject.FindObjectOfType<MissionThree>().StartCutsceneWithConversation();
            }
            else if (currentActiveMissionIndex == 3)
            {
                GameObject.FindObjectOfType<MissionFour>().StartCutsceneWithConversation();
            }






            /*

                    cutscenesParent.transform.GetChild(0).gameObject.SetActive(true);
                            missions[currentActiveMissionIndex].gameObject.SetActive(true);
                            activeMission = missions[currentActiveMissionIndex];
                            //missionStartPoints[1].gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("Player").transform.position = missionStartPoints[0].transform.position - new Vector3(4f, 0f, -2.5f);
                            GameObject.FindGameObjectWithTag("Player").transform.Rotate(new Vector3(0f, 90f, 0f), Space.Self);
                            promptPanel.gameObject.SetActive(false);
                            //Destroy(missionStartPoints[0].gameObject);
                    if (currentActiveMissionIndex == 1)
                    {
                        GameObject.FindObjectOfType<MissionTwo>().StartCutsceneWithConversation();
                    }
                    else if (currentActiveMissionIndex == 2)
                    {
                        GameObject.FindObjectOfType<MissionThree>().StartCutsceneWithConversation();
                    }
                    else if (currentActiveMissionIndex == 3)
                    {
                        GameObject.FindObjectOfType<MissionFour>().StartCutsceneWithConversation();
                    }*/
        }
        else {
            for (var i = 0; i < currentActiveMissionIndex; i++)
            {
                Destroy(cutscenesParent.transform.GetChild(i).gameObject);
                //cutscenesParent.transform.GetChild(i).gameObject.SetActive(false);
                Destroy(missions[i].gameObject);
                Destroy(missionStartPoints[i].gameObject);
                //missionStartPoints[i].gameObject.SetActive(false);
                currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = "";
            }

        }
        
    }
    public void updateObjectiveTest(Objective obj) {
        //Debug.Log(obj.title);
        //Debug.Log(currentObjectiveText.text);
        if (!obj.title.Contains("Finished")) {
            currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = obj.title;
        } else if (obj.title == "Finished Final")
        {
            for (var i = 0; i < missionStartPoints.Count; i++)
            {
                //Destroy(cutscenesParent.transform.GetChild(i).gameObject);
                //cutscenesParent.transform.GetChild(i).gameObject.SetActive(false);
                //Destroy(missions[i].gameObject);
                Destroy(missionStartPoints[i].gameObject);
                //missionStartPoints[i].gameObject.SetActive(false);

            }
            //Destroy(missionStartPoints[missionStartPoints.Count - 1].gameObject);
            Destroy(cutscenesParent.transform.GetChild(cutscenesParent.transform.childCount - 1).gameObject);
            Destroy(missions[missions.Count - 1].gameObject);
            currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = "";
            ES3.Save<int>("currentActiveMissionIndex", 4);
        }
        else {
            currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = "";
            if (currentActiveMissionIndex < missionStartPoints.Count)
            {
                Destroy(missionStartPoints[currentActiveMissionIndex].gameObject);
                if (currentActiveMissionIndex + 1 < missionStartPoints.Count)
                {
                    missionStartPoints[currentActiveMissionIndex + 1].gameObject.SetActive(true);
                }
                else {
                    currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = "";
                }

            }
/*            else if (currentActiveMissionIndex == missions.Count)
            {
                Destroy(missionStartPoints[currentActiveMissionIndex - 1].gameObject);
                Destroy(missions[currentActiveMissionIndex - 1].gameObject);
                ES3.Save<int>("currentActiveMissionIndex", currentActiveMissionIndex);
            }*/
        }
    }
    public void startNewMission() { 
            Destroy(activeMission.gameObject);
        Debug.Log("CURRENT INDEX : " + currentActiveMissionIndex);
        ES3.Save<int>("currentActiveMissionIndex", currentActiveMissionIndex);
        if (currentActiveMissionIndex + 1 < missionStartPoints.Count)
        {
            Destroy(cutscenesParent.transform.GetChild(0).gameObject);
            cutscenesParent.transform.GetChild(1).gameObject.SetActive(true);
            currentActiveMissionIndex++;
            missions[currentActiveMissionIndex].gameObject.SetActive(true);
            activeMission = missions[currentActiveMissionIndex];
            missionStartPoints[currentActiveMissionIndex].gameObject.SetActive(true);
            promptPanel.gameObject.SetActive(false);
        }
        else
        {
            Destroy(cutscenesParent.transform.GetChild(0).gameObject);
            cutscenesParent.transform.GetChild(1).gameObject.SetActive(true);
            currentActiveMissionIndex = missions.Count;
            //currentActiveMissionIndex = 4;
            missions[currentActiveMissionIndex - 1].gameObject.SetActive(true);
            activeMission = missions[currentActiveMissionIndex - 1];
            missionStartPoints[currentActiveMissionIndex - 1].gameObject.SetActive(true);
            promptPanel.gameObject.SetActive(false);
        }
        
            
            
            ES3.Save<int>("currentActiveMissionIndex", currentActiveMissionIndex);
        if (currentActiveMissionIndex == 1) {
            GameObject.FindObjectOfType<MissionTwo>().StartCutsceneWithConversation();
        } else if (currentActiveMissionIndex == 2) {
            GameObject.FindObjectOfType<MissionThree>().StartCutsceneWithConversation();
        }
        else if (currentActiveMissionIndex == 3 || currentActiveMissionIndex == 4)
        {
            GameObject.FindObjectOfType<MissionFour>().StartCutsceneWithConversation();
            
            //ES3.Save<int>("currentActiveMissionIndex", currentActiveMissionIndex);

        }
    }
    public void closePromptPanel() {
        promptPanel.gameObject.SetActive(false);
    }
    public void updateObjectiveTest2(Objective obj)
    {
        currentSideObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = string.IsNullOrEmpty(obj.title) ? "" : obj.title;
    }
    void updateObjectives(Objective obj){
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = image.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        TextMeshProUGUI text = textGO.GetComponent<TextMeshProUGUI>();
        //text.font = arial;
        text.text = obj.title;
        text.fontSize = 22;
        //text.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -10, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
        // GameObject.CreatePrimitive()
    }
    void updateObjectives2(SideObjective obj)
    {
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = image.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        TextMeshProUGUI text = textGO.GetComponent<TextMeshProUGUI>();
        //text.font = arial;
        text.text = obj.title;
        text.fontSize = 22;
        //text.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -10, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
        // GameObject.CreatePrimitive()
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (missionStartPoints.Count > 0 && currentActiveMissionIndex < missionStartPoints.Count) { 
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, missionStartPoints[currentActiveMissionIndex  +  1].gameObject.transform.position) <= 5)
        {
            promptPanel.gameObject.SetActive(true);
        }
        
        }
        }
}
