using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSideObjective : MonoBehaviour
{
    public GameObject investmentHubPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (investmentHubPanel.gameObject.active) {
            StartCoroutine(completeObjective());
        }
        
    }
    IEnumerator completeObjective() {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Objective>().isComplete = true;
        yield return new WaitForSeconds(10f);
        //investmentHubPanel.gameObject.SetActive(false);
        gameObject.transform.parent.parent.GetComponent<MissionOne>().changeSideObjective(gameObject);
    }
}
