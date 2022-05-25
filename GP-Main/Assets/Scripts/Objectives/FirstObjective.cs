using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstObjective : MonoBehaviour
{
    public int cutsceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position,gameObject.transform.parent.parent.GetComponent<MissionOne>().cutscenePoints[this.cutsceneIndex].gameObject.transform.position) <= 5)
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
            /*if (onCompleteObj != null)
            {
                onCompleteObj();
            }*/
        }
    }
}
