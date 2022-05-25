using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Objective : MonoBehaviour
{
    public delegate void CompleteObjective();
    public static event CompleteObjective onCompleteObj;

    public string title;

    public bool isComplete = false;

    public Objective instance;

    void Start()
    {
        this.instance = this;
    }
    // public bool checkIfComplete(GameObject player, GameObject secretary){ 
    //     return true;
    // }
    // public bool checkIfComplete(GameObject player, GameObject secretary){
    //     if(Vector3.Distance(player.transform.position,secretary.transform.position) <= 7){
    //         if(onCompleteObj != null){
    //             onCompleteObj();
    //             isComplete = true;
    //             return true;
    //         }
    //             //Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
    //         }else {
    //             return false;
    //         }
    //          return false;
    //     }
    }
