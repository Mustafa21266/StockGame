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
        if (gameObject.transform.parent.parent.TryGetComponent(out MissionOne m1))
        {
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.parent.parent.GetComponent<MissionOne>().cutscenePoints[this.cutsceneIndex].gameObject.transform.position) <= 5)
            {
                gameObject.GetComponent<Objective>().isComplete = true;
                gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
                /*if (onCompleteObj != null)
                {
                    onCompleteObj();
                }*/
            }
            
        }
        else if (gameObject.transform.parent.parent.TryGetComponent(out MissionTwo m2))
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionTwo>().changeMainObjective(gameObject);
            // gameObject.transform.parent.parent.GetComponent<MissionTwo>().changeMainObjective(gameObject);
        }
        else if (gameObject.transform.parent.parent.TryGetComponent(out MissionThree m3))
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionThree>().changeMainObjective(gameObject);
        }
        else if (gameObject.transform.parent.parent.TryGetComponent(out MissionFour m4))
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionFour>().changeMainObjective(gameObject);
        }


    }
}
