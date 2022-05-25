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

    private GameObject image;

    private TextMeshProUGUI currentObjectiveText;

    private TextMeshProUGUI currentObjectiveText2;

    public GameObject currentObjectiveTextGameObject;
    public GameObject currentSideObjectiveTextGameObject;


    // Start is called before the first frame update
    void Start()
    {
        //missions = new List<Mission>();

        //missions.Add(Instantiate<Mission>(new MissionOne()));
        // activeMission = Instantiate<Mission>(missions[0]);
        activeMission = missions[0];
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
    public void updateObjectiveTest(Objective obj){
        //Debug.Log(obj.title);
        //Debug.Log(currentObjectiveText.text);
        currentObjectiveTextGameObject.GetComponent<TextMeshProUGUI>().text = string.IsNullOrEmpty(obj.title) ?  "" : obj.title;
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
    void Update()
    {
        
    }
}
