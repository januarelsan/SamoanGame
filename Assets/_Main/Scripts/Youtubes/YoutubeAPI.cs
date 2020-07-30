using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class YoutubeAPI : MonoBehaviour
{
    private const string API_KEY = "AIzaSyCkdChLKDjJAJUOEtfbGy9gJ50rPPN9NdI";

    private YTListPage listPage;

    void Start()
    {
        //Load first page
        StartCoroutine(GetRequest("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=3&playlistId=PLSjav_e4lsWRIxiFe7LmAb3mNOIM5qUr2&key=AIzaSyCkdChLKDjJAJUOEtfbGy9gJ50rPPN9NdI"));

    }

    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                
                Debug.Log(webRequest.downloadHandler.text);
                
                listPage = JsonUtility.FromJson<YTListPage>(webRequest.downloadHandler.text);
                SetVideoItemUI();
                // Debug.Log(listPage.kind);
                // Debug.Log(listPage.etag);
                // Debug.Log(listPage.nextPageToken);
                // Debug.Log(listPage.prevPageToken);
                // foreach (var item in listPage.items)
                // {
                //     Debug.Log("Item Snippet Title: " + item.snippet.title);
                //     Debug.Log("Item Snippet Pos: " + item.snippet.position);
                //     Debug.Log("Item Snippet Thumbnail URL: " + item.snippet.thumbnails.standard.url);
                    
                // }
            }
        }
    }

    void SetVideoItemUI(){
        GetComponent<YoutubeManager>().SetVideoItems(listPage);
    }

    public void NextPage(){
        if(listPage.nextPageToken != null){
            StartCoroutine(GetRequest("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=3&playlistId=PLSjav_e4lsWRIxiFe7LmAb3mNOIM5qUr2&key=AIzaSyCkdChLKDjJAJUOEtfbGy9gJ50rPPN9NdI&pageToken=" + listPage.nextPageToken));
        }
    }

    public void PrevPage(){
        if(listPage.prevPageToken != null){
            StartCoroutine(GetRequest("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=3&playlistId=PLSjav_e4lsWRIxiFe7LmAb3mNOIM5qUr2&key=AIzaSyCkdChLKDjJAJUOEtfbGy9gJ50rPPN9NdI&pageToken=" + listPage.prevPageToken));
        }
    }
    
}
