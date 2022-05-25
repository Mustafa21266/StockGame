using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthObjective : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindObjectOfType<InventoryManager>().checkForObjForth())
        {
                gameObject.GetComponent<Objective>().isComplete = true;
                gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
        }
    }
}
