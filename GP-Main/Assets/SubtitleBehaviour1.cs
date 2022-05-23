using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;
using ArabicTool;
using Cinemachine;
public class SubtitleBehaviour1 : PlayableBehaviour
{
    public string subtitleText;
    //public Sprite avatar;
    //public GameObject followObject;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        //Cinemachine.CinemachineVirtualCamera cinimachine = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        //cinimachine.Follow = followObject.transform;
        //cinimachine.LookAt = followObject.transform;
        //Image img = GameObject.FindGameObjectWithTag("Subtitles - Avatar").GetComponent<Image>();
        //img.sprite = avatar;
        text.color = new Color(1,1,1,info.weight);
        
    }
}
