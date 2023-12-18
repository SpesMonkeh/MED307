using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.Video;

public class PlayPauseVideo : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private PuzzleSignDisplayø PuzzleSignDisplayø;
    

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    

    private void PlayVideoClip()
    {
        _videoPlayer.Play();
    }
    
    private void PauseVideoClip()
    {
        _videoPlayer.Pause();
    }
}
