using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdObjective : MonoBehaviour
{
    public GameObject quizPanel;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("checkThird", 1f, 2f);
    }

    // Update is called once per frame
    void checkThird()
        {
        if (GameObject.FindObjectOfType<InventoryManager>().gameObject.transform.GetChild(0).gameObject.active && quizPanel.gameObject.active)
        {
            gameObject.GetComponent<Objective>().isComplete = true;
            gameObject.transform.parent.parent.GetComponent<MissionOne>().changeMainObjective(gameObject);
        }
    }
}
