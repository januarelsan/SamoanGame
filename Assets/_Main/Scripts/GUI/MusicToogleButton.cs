using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToogleButton : MonoBehaviour
{
    [SerializeField] private Sprite[] musicSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        GetComponent<Image>().sprite = musicSprites[GameData.Instance.MainMusicOn];                
    }

    public void ToogleMusic(){
        if(GameData.Instance.MainMusicOn == 1){
            GameData.Instance.MainMusicOn = 0;
        } else {
            GameData.Instance.MainMusicOn = 1;
        }
    }
}
