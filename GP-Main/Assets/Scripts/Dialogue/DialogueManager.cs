using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using static ArabicSupport;
using System;
using System.Linq;

public class DialogueManager : MonoBehaviour
{
    public NpcDialogue npc;
    bool isTalking = false;
    float distance;
    float curResponseTracker = 0;
    public GameObject player;
    public GameObject dialogueUI;
    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    public Dialogue activeDialogue;

    private string currentText;
    private int currentTextLength = 0;
    private int currentDialogueLineIndex = 0;

    private TextFixer fixer;

    //private float r=1f,g=1f,b=1f,a=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        fixer = dialogueUI.transform.GetChild(2).GetComponent<TextFixer>();
        
        dialogueUI.SetActive(false);
    }

    void FixedUpdate(){
        // if(this.activeDialogue == null){
            
        // }else{
        // if(!isTalking && currentDialogueLineIndex < this.activeDialogue.dialogueLines.Count){
        //     StartCoroutine(changeLine());
        // }
        // }

        // if(npcDialogueBox.cachedTextGenerator.lines.Count >= 2){ 
        //     npcDialogueBox.text =  "";
        //     System.Threading.Thread.Sleep(3000);
        // }
    }
    IEnumerator changeLine(){
        yield return new WaitForSeconds(2f);
        if(currentDialogueLineIndex >= this.activeDialogue.dialogueLines.Count - 1){
                yield return new WaitForSeconds(1f);
                this.activeDialogue = null;
                dialogueUI.SetActive(false);
                isTalking = false;
                curResponseTracker = 0;
        //dialogueUI.SetActive(true);
                npcName.text =  "";
                currentText = null;
                npcDialogueBox.text =  "";
        }else {
        currentDialogueLineIndex++;
        npcName.text =  this.activeDialogue.dialogueLines[currentDialogueLineIndex].speakerName;
        npcDialogueBox.text = "";
        var finalText = new string[0];
        currentText = this.activeDialogue.dialogueLines[currentDialogueLineIndex].content;
        // if(currentText.Length > 7){
        //     for(var i = 0; i < currentText.Length; i++){
        //         Debug.Log(i % 8);
        //         if(i % 4 == 0 && i != 0){
        //             finalText = finalText.Concat(new string[]{   currentText[i] + "\n" }).ToArray();
        //         }else {
        //             finalText = finalText.Concat(new string[]{ currentText[i] }).ToArray();
        //         }
        //     }
        //     currentText = finalText;
        // }
        currentTextLength = 0;
        InvokeRepeating("displayLine",0.1f, 0.1f);
        }
        // if(isTalking){
        //     displayLine();
        // }else{
        //     yield return new WaitForSeconds(2f);

        // } 
    }
    public void StartDialogue(Dialogue activeDialogue){
        this.activeDialogue = activeDialogue;
        dialogueUI.SetActive(true);
        isTalking = true;
        curResponseTracker = 0;
        //dialogueUI.SetActive(true);
        npcName.text =  this.activeDialogue.dialogueLines[currentDialogueLineIndex].speakerName;
        //currentText = this.activeDialogue.dialogueLines[currentDialogueLineIndex].content);
        var finalText = new string[0];
        currentText = this.activeDialogue.dialogueLines[currentDialogueLineIndex].content;
        // if(currentText.Length > 7){
        //     for(var i = 0; i < currentText.Length; i++){
        //         if(i % 7 == 0){
        //             Debug.Log("saddddddddddddddddddddddddddddddddddddd");
        //             finalText = finalText.Concat(new string[]{ "\n" }).ToArray();
        //         }
        //         finalText = finalText.Concat(new string[]{ currentText[i] }).ToArray();
        //     }
        //     currentText = finalText;
        // }
        
        currentTextLength = 0;
        npcDialogueBox.text =  "";
        TextFixer.onChangeText += animateText;
        InvokeRepeating("displayLine", 0.1f, 0.1f);
    }

    void displayLine(){
        if(currentTextLength < currentText.Length){
            fixer.changeHolder(currentText);

            //fixer.EnterText = currentText;
            // npcDialogueBox.text = fixer.EnterText;
            currentTextLength++;
        }
        // if(currentTextLength < ){
        //     //isTalking = true;
        //     //npcDialogueBox.text =  currentText[currentTextLength] + " " + npcDialogueBox.text;
            
        //     npcDialogueBox.text =  currentText[currentTextLength] + " " + npcDialogueBox.text;
        //     fixer.EnterText = currentText[currentTextLength] + " " + fixer.EnterText;
        //     //npcDialogueBox
        //     currentTextLength--;
        //     // if(npcDialogueBox.cachedTextGenerator.lines.Count < 2){
        //     //     // var text = npcDialogueBox.text.Split('\n');
        //     //     // npcDialogueBox.text = "";
        //     //     // // for(var i = text.Length - 1; i >= 0; i--){
        //     //     // //     npcDialogueBox.text += text[i];
        //     //     // // }
        //     //     //  for(var i = 0; i < text.Length; i++){
        //     //     //     npcDialogueBox.text += text[i];
        //     //     // }
        //     // }else {
                
                
        //     // }
        //     // npcDialogueBox.cachedTextGenerator.lineCount
            
        //     // var i =;
        //    // Debug.Log(currentText[currentTextLength]);
        //     //npcDialogueBox.text = npcDialogueBox.text);
            
        // }
        else {
            isTalking = false;
            CancelInvoke("displayLine");
            StartCoroutine(changeLine());
        //     if(currentDialogueLineIndex >= this.activeDialogue.dialogueLines.Count - 1){
        //         this.activeDialogue = null;
        //         dialogueUI.SetActive(false);
        //         isTalking = false;
        //         curResponseTracker = 0;
        // //dialogueUI.SetActive(true);
        //         npcName.text =  "";
        //         currentText = "";
        //         npcDialogueBox.text =  "";
        //     }else{
        //     }
        }
    }


    void animateText(string text){
        //this.currentText = text;
        //Debug.Log(text);
        //this.currentText
        // if(a == 1f){
        //     a = 0.2f;
        // }
        //npcDialogueBox.color = new Color(r,g,b,a);
        //InvokeRepeating("animate", 0.2f, 0.2f);
    }
    void animate(){
        // a = a + 0.1f;
        // npcDialogueBox.tex = new Color(r,g,b,a);
        // if(a >= 1f){
        //     a = 0.2f;
        //     CancelInvoke("lightUpText");
        // }

        //npcDialogueBox.text = "" + npcDialogueBox.text.Split('\n')[0] + ;

        if(currentTextLength < currentText.Length){
            npcDialogueBox.text =  currentText[currentTextLength] + " " + npcDialogueBox.text;
        }else {
            CancelInvoke("animate");
        }
        
    }
    // void OnMouseOver()
    // {
    //     distance = Vector3.Distance(player.transform.position, this.transform.position);
        
    //     if(distance <= 7f)
    //     {
    //         if(Input.GetAxis("Mouse ScrollWheel") < 0f)
    //         {
    //             curResponseTracker++;
    //             if(curResponseTracker >= npc.playerDialogue.Length -1)
    //             {
    //                 curResponseTracker = npc.playerDialogue.Length -1;
    //             }
    //         }
    //         else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
    //         {
    //             curResponseTracker--;
    //             if(curResponseTracker < 0)
    //             {
    //                 curResponseTracker = 0;
    //             }
    //         }

    //         //trigger dialogue
    //         if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
    //         {
    //             StartConversation();
    //         }
    //         else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
    //         {
    //             EndDialogue();
    //         }

    //         if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
    //         {
    //             playerResponse.text = npc.playerDialogue[0];
    //             if(Input.GetKeyDown(KeyCode.Return))
    //             {
    //                 npcDialogueBox.text = npc.dialogue[1];
    //             }
    //         }
    //         else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
    //         {
    //             playerResponse.text = npc.playerDialogue[1];
    //             if(Input.GetKeyDown(KeyCode.Return))
    //             {
    //                 npcDialogueBox.text = npc.dialogue[2];
    //             }
    //         }
    //         else if(curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
    //         {
    //             playerResponse.text = npc.playerDialogue[2];
    //             if(Input.GetKeyDown(KeyCode.Return))
    //             {
    //                 npcDialogueBox.text = npc.dialogue[3];
    //             }
    //         }
    //     }
    //     void StartConversation()
    //     {
    //         isTalking = true;
    //         curResponseTracker = 0;
    //         dialogueUI.SetActive(true);
    //         npcName.text = npc.name;
    //         npcDialogueBox.text = npc.dialogue[0];
    //     }

        
    //     void EndDialogue()
    //     {
    //         isTalking = false;
    //         dialogueUI.SetActive(false);
            
    //     }
    // }

    
}
