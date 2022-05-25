using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSideObjective : MonoBehaviour
{
    public GameObject investmentHubPanel;
    public GameObject chatPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!investmentHubPanel.gameObject.active && chatPanel.gameObject.active)
        {
            StartCoroutine(completeObjectiveSecond());
        }
    }
    IEnumerator completeObjectiveSecond()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Objective>().isComplete = true;
        gameObject.transform.parent.parent.GetComponent<MissionOne>().changeSideObjective(gameObject);
    }
}
