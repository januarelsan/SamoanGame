using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoutubeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] VideoItems;

    public void SetVideoItems(YTListPage listPage){
        //Reset - Disable all item
        foreach (var item in VideoItems)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < listPage.items.Length; i++)
        {   
            VideoItems[i].SetActive(true);         
            VideoItems[i].GetComponent<LoadTextureToImage>().SetTextureToImage(listPage.items[i].snippet.thumbnails.standard.url);
            VideoItems[i].transform.GetChild(0).GetComponent<Text>().text = listPage.items[i].snippet.title;
            VideoItems[i].GetComponent<YTVideoButton>().SetVideoId(listPage.items[i].snippet.resourceId.videoId);
        }
    }
    
    public void NextPage(){
        GetComponent<YoutubeAPI>().NextPage();
    }

    public void PrevPage(){
        GetComponent<YoutubeAPI>().PrevPage();
    }

    
}
