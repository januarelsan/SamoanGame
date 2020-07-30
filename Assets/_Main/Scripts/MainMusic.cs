﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
     private static MainMusic playerInstance;
    void Awake(){
        DontDestroyOnLoad (this);
            
        if (playerInstance == null) {
            playerInstance = this;
        } else {
            DestroyObject(gameObject);
        }
    }

    void Update(){
        if(SceneController.Instance.getSceneLoaded() == "YoutubePlayer"){
            if(GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Pause();
        } else {
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
    }
}
