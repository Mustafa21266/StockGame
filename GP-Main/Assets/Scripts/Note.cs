using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note :  MonoBehaviour
{
    public delegate void NotifyClosenessToNote(GameObject nearNote);
    public static event NotifyClosenessToNote onNotifyClosenessToNote;

    public string title;

    public string content;

    public GameObject attatchedObject;

    public bool isOpened = false;

    private void Awake() {
         this.attatchedObject = gameObject;
    }

    private void FixedUpdate() {
        if(Vector3.Distance(gameObject.transform.position , GameObject.FindGameObjectWithTag("Player").transform.position) <= 5){
            if(onNotifyClosenessToNote != null && !isOpened){
                onNotifyClosenessToNote(gameObject);
                Behaviour halo = (Behaviour) gameObject.GetComponent("Halo");
                halo.enabled = true; // false
                
                //gameObject.GetComponent<Halo>();
            }
        }
    }
    public void disableEffects(){
        gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
        Behaviour halo = (Behaviour) gameObject.GetComponent("Halo");
        halo.enabled = false; // false
    }
}
