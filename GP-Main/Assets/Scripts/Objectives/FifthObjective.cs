using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthObjective : MonoBehaviour
{
    public GameObject resultsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindObjectOfType<InventoryManager>().gameObject.transform.GetChild(0).gameObject.active && Input.GetKey(KeyCode.I) && !resultsPanel.gameObject.active)
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
            /*if (onCompleteObj != null)
            {
                onCompleteObj();
                obj.instance.isComplete = true;
                //Debug.Log("dONE 2");
            }*/

        }
    }
}
