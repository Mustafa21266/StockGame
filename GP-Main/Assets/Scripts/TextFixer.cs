using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ArabicSupport;

public class TextFixer : MonoBehaviour {

    public delegate void ChangeText(string text);
    public static event ChangeText onChangeText;

    private int idx = 0;

    //The UI text 
    Text myText;


    //used in cutting the lines 
    int startIndex;
    int endIndex;
    int length;
    int j;
    //*************************

  [TextArea]
    public string EnterText;
    private int currentTextLength = 0;
   string[] FixedText= new string[30];
   string[] Holder= new string[5];
    string TextHolder = "";

    private void OnEnable() {
        myText = GetComponent<Text>();

        Holder = EnterText.Split('\n');
        StartCoroutine(FixText());
    }
    private void OnDisable() {
        myText = GetComponent<Text>();
        EnterText = "";
        Holder = EnterText.Split('\n');
        //StartCoroutine(FixText());
    }
    void Start() {
        // myText = GetComponent<Text>();

        // Holder = EnterText.Split('\n');
        // StartCoroutine(FixText());

        //Debug.Log("WPRKING");


    }

    public void changeHolder(string text){
        TextHolder = "";
        Holder = text.Split('\n');
        StartCoroutine(FixText());
    }

    // void FixedUpdate(){
    //     Holder = EnterText.Split('\n');
    //     StartCoroutine(FixText());
    // }

    IEnumerator FixText() {

       

            for (int i = 0; i < Holder.Length; i++)
            {
                myText.text = ArabicSupport.Fix(Holder[i], false, false);
                Canvas.ForceUpdateCanvases();
            for (int k = 0; k < FixedText.Length; k++)
            {
                FixedText[k] = "";
            }

                for (int k = 0; k < myText.cachedTextGenerator.lines.Count; k++)
                {
                    startIndex = myText.cachedTextGenerator.lines[k].startCharIdx;
                    endIndex = (k == myText.cachedTextGenerator.lines.Count - 1) ? myText.text.Length
                       : myText.cachedTextGenerator.lines[k + 1].startCharIdx;
                    length = endIndex - startIndex;
                    Debug.Log(myText.text.Substring(startIndex, length));
                    FixedText[k] = myText.text.Substring(startIndex, length);
                }
                myText.text = "";
                for (int k = FixedText.Length - 1; k >= 0; k--)
                {
                    if (FixedText[k] != "" && FixedText[k] != "\n" && FixedText[k] != null)
                    {

                        TextHolder += FixedText[k] + "\n";
                    }
                }
            }
            myText.text = TextHolder;
            // if(TextHolder.Length > 0){
            //     animateText();
            // }
            //Debug.Log(TextHolder);
            
            // if(onChangeText != null){
            //     onChangeText(TextHolder);
            // }

            yield return new WaitForEndOfFrame();
        

    }
    void animateText(){
        //this.currentText = text;
        //this.currentText
        // if(a == 1f){
        //     a = 0.2f;
        // }
        //npcDialogueBox.color = new Color(r,g,b,a);
        InvokeRepeating("animate", 0.2f, 0.2f);
    }
    void animate(){
        // a = a + 0.1f;
        // npcDialogueBox.tex = new Color(r,g,b,a);
        // if(a >= 1f){
        //     a = 0.2f;
        //     CancelInvoke("lightUpText");
        // }

        //npcDialogueBox.text = "" + npcDialogueBox.text.Split('\n')[0] + ;
        if(idx < TextHolder.Split(' ').Length){
            //Debug.Log(TextHolder.Split(' ')[0]);
            myText.text =  myText.text + " " + TextHolder.Split(' ')[idx];
            idx++;
        }
        // if(currentTextLength < currentText.Length){
        //     npcDialogueBox.text =  currentText[currentTextLength] + " " + npcDialogueBox.text;
        // }
        else {
            idx = 0;
            CancelInvoke("animate");
        }
        
    }
    // public static void fixText(){
    //     for (int i = 0; i < Holder.Length; i++)
    //         {
    //             myText.text = ArabicSupport.Fix(Holder[i], false, false);
    //             Canvas.ForceUpdateCanvases();
    //         for (int k = 0; k < FixedText.Length; k++)
    //         {
    //             FixedText[k] = "";
    //         }

    //             for (int k = 0; k < myText.cachedTextGenerator.lines.Count; k++)
    //             {
    //                 startIndex = myText.cachedTextGenerator.lines[k].startCharIdx;
    //                 endIndex = (k == myText.cachedTextGenerator.lines.Count - 1) ? myText.text.Length
    //                    : myText.cachedTextGenerator.lines[k + 1].startCharIdx;
    //                 length = endIndex - startIndex;
    //                 Debug.Log(myText.text.Substring(startIndex, length));
    //                 FixedText[k] = myText.text.Substring(startIndex, length);
    //             }
    //             myText.text = "";
    //             for (int k = FixedText.Length - 1; k >= 0; k--)
    //             {
    //                 if (FixedText[k] != "" && FixedText[k] != "\n" && FixedText[k] != null)
    //                 {

    //                     TextHolder += FixedText[k] + "\n";
    //                 }
    //             }
    //         }
    //         myText.text = TextHolder;
    //         Debug.Log(TextHolder);
    // }

 
	
}
