using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine
{
    private GameObject speaker;
    public string speakerName;

    private int order;

    public string content;

    private bool isSaid = false;

    public DialogueLine(GameObject speaker, string speakerName, int order, string content)
    {
        this.speaker = speaker;
        this.speakerName = speakerName;
        this.order = order;
        this.content = content;
        
    }
    public void changeLineStatus(){
        this.isSaid = !this.isSaid;
    }
}
