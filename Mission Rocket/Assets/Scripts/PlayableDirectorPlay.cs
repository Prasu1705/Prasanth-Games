using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class PlayableDirectorPlay : MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelineAssets;
    public GameObject titleLoad;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();    
        }
        
    }
    void PlayfromTimeline(int index)
    {
        TimelineAsset selectedAsset;
        if (timelineAssets.Count <= index)
        {
            selectedAsset = timelineAssets[timelineAssets.Count - 1];
        }
        else
        {
            selectedAsset = timelineAssets[index];
        }
       
        playableDirectors[0].Play(selectedAsset);
    }

}
