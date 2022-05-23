using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGroup : MonoBehaviour
{
    public List<GameObject> groupMembers;
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0 ; i < gameObject.transform.childCount;i++){
            groupMembers.Add(gameObject.transform.GetChild(i).gameObject);
        }
        
        InvokeRepeating("animateNPCS", 2.0f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // StartCoroutine(animate());
    }
    void animateNPCS(){
        // Debug.Log("iN");
        // yield return new WaitForSeconds(0f);
        System.Random rand = new System.Random();
        var npcIndex = rand.Next(0, groupMembers.Count);
        groupMembers[npcIndex].GetComponent<Animator>().SetBool("isTalking", true);
        Debug.Log(groupMembers[npcIndex].GetComponent<Animator>().GetBool("isTalking"));
        for(var i = 0; i < groupMembers.Count; i++){
            if(i == npcIndex){
                continue;
            }else {
                groupMembers[i].GetComponent<Animator>().SetBool("isTalking", false);
            }
            // if(groupMembers[npcIndex].GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("Idle")){
                
            // }
        }
    }
}
