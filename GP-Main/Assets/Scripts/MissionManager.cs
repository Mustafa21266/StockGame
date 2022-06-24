using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PixelCrushers.DialogueSystem;

public class MissionManager : MonoBehaviour
{
    // this class created to manage the missions
    public GameObject sub;
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
        // starting by activate the mission and assign the current mission 
        Load();
        if (currentActiveMissionIndex < missions.Count) { 
            activeMission = missions[currentActiveMissionIndex];
        }
    }
    void Load() {
        // loading the next mission when the current mission is over
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

        // changing the titles of the mission to finished when the player finish it
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
        }
    }
    public void startNewMission() { 
        // starting new mission after destroying the current mission and if it have a cut scence it will activate it
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
        // closing prompt panel 
        promptPanel.gameObject.SetActive(false);
    }
    public void updateObjectiveTest2(Objective obj)
    {
        currentSideObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = string.IsNullOrEmpty(obj.title) ? "" : obj.title;
    }
    void updateObjectives(Objective obj){
        // update the mission objectives as every mission have an objectives inside it
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
        // update the second objective of the mission
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
        // get the player distance from the mission to display the prompt panel
        if (missionStartPoints.Count > 0 && currentActiveMissionIndex < missionStartPoints.Count) { 
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, missionStartPoints[currentActiveMissionIndex  +  1].gameObject.transform.position) <= 5)
        {
            promptPanel.gameObject.SetActive(true);
        }
        if (GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive)
        {
            gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "";
        }
        }
        }
}
