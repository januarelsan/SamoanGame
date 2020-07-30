using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTVideoButton : MonoBehaviour
{

    public string videoId;
    
    public void SetVideoId(string videoId){
        this.videoId = videoId;
    }

    public string GetVideoId(){
        return videoId;
    }

    public void GoToYoutubePlayer(){
        SceneController.Instance.goToScene("YoutubePlayer");
        GameData.Instance.YoutubeVideoId = videoId;

    }
}
