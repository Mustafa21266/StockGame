using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip1 : PlayableAsset
{
    public string subtitleText;
    //public GameObject followObject;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehaviour1>.Create(graph);

        SubtitleBehaviour1 subtitleBehaviour = playable.GetBehaviour();
        subtitleBehaviour.subtitleText = subtitleText;
        //subtitleBehaviour.followObject = followObject;
        return playable;
    }
}
