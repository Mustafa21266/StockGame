using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public GameObject player;
    public GameObject npc;

    public List<DialogueLine> dialogueLines;

    public Dialogue(GameObject player, GameObject npc, List<DialogueLine> dialogueLines)
    {
        this.player = player;
        this.npc = npc;
        this.dialogueLines = dialogueLines;
    }
    
}
