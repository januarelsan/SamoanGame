using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextureToImage : MonoBehaviour
{
    void Start(){
        // SetTextureToImage("https://i.ytimg.com/vi/qBxWDnHNF34/sddefault.jpg");
    }
    public void SetTextureToImage(string url)
    {
        StartCoroutine(SetImage(url)); //balanced parens CAS
    }

    IEnumerator SetImage(string url) {
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            // Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download failed");
        }
        else
        {
            // Debug.Log("Download succes");
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            GetComponent<Image>().sprite = sprite;
        }
    }
}
