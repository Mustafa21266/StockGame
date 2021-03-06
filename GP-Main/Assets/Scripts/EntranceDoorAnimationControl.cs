using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoorAnimationControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool isDoorClosed = true;
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // this method is for door open and close depending on how far or close the player from the door 
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 10f && isDoorClosed == true){
            StartDoorAnimations();
            
        }else if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= 10f && isDoorClosed == false) {
            //Debug.Log(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position));
            // StartCoroutine(;
            
        } else if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) >= 10f && isDoorClosed == false) {
            EndDoorAnimations();
            
        } else if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) >= 10f && isDoorClosed == true) {
            // EndDoorAnimations();
            // resetBools();
        }
    }
    void StartDoorAnimations(){
        // activate the door animations 
        anim.SetBool("startDoorAnim", true);
        anim.SetBool("exitAnim", true);
        isDoorClosed = false;
        // anim.SetBool("exitAnim", true);
        // anim.SetBool("isOpen", true);
        // anim.StopPlayback();
        // anim.SetBool("isNearDoor", true);
        // anim.SetBool("IntControl", false);
        // anim.SetBool("IntControl", true);
        
        // anim.SetBool("startDoorAnim", false);
    }
    void EndDoorAnimations(){
        // deactivate the door animations 
        anim.SetBool("startSlideDown", true);
        anim.SetBool("endDoorAnim", true);
        anim.SetBool("startDoorAnim", false);
        isDoorClosed = true;
    }
    void resetBools(){
        // reset the door animations after opening or closing 
        anim.SetBool("startDoorAnim", false);
        anim.SetBool("exitAnim", false);
        anim.SetBool("startSlideDown", false);
        anim.SetBool("endDoorAnim", false);
    }
    
    
}
