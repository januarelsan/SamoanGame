using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	[SerializeField]
	private bool resetData;

	// Use this for initialization
	void Start () {
		if(resetData)
			ResetData();
	}

	void ResetData(){
		if(resetData)
			PlayerPrefs.DeleteAll();
	}

	public int MainMusicOn
	{
		get { return PlayerPrefs.GetInt("MainMusicOn",1);}
		set { PlayerPrefs.SetInt("MainMusicOn",value);}
	}

	public int FlashCardCategory
	{
		get { return PlayerPrefs.GetInt("FlashCardCategory",0);}
		set { PlayerPrefs.SetInt("FlashCardCategory",value);}
	}

	public string YoutubeVideoId
	{
		get { return PlayerPrefs.GetString("YoutubeVideoId");}
		set { PlayerPrefs.SetString("YoutubeVideoId",value);}
	}

	
	
	
	
}
