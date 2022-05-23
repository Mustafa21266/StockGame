using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using ArabicTool;
public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;
    public Sprite avatar;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        Image img = GameObject.FindGameObjectWithTag("Subtitles - Avatar").GetComponent<Image>();
        img.sprite = avatar;
        text.color = new Color(1,1,1,info.weight);
        
    }
}
