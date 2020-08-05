using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchingGame
{	
public class GameManager : Singleton<GameManager> {

	private int gameType;
	private int gameLevel;

	private int matched;
	private int goals;
	private int[] openedTileNumbers = {-1,-1};
	private GameObject[] openedTile = new GameObject[2];

	private bool gameIsPlaying = true;

	[SerializeField] private GameObject gameMusic = null;
	[SerializeField] private AudioClip matchedClip;
	[SerializeField] private AudioClip wrongClip;
	
	[SerializeField] private AudioClip[] fruitClips = null;

	//GameType things
	//15 //30 //55 //70 //1.55 //2.35 //3.10 //4 //4.50 //6.40
	private float[] timeLimits = {70f,90f,115f,130f,175f,215f,250f,300f,350f,460f};

	void Awake(){


	}

	// Use this for initialization
	void Start () {

		ShowAdsManager.Instance.RequestAndLoadInterstitialAd();
				
		gameType = 0 ;
		gameLevel = 0 ;
		

		switch (gameType)
		{
			case 1:
				SetTimeChallange();
				break;
			case 2:
				
				break;
			default:
				
				break;
		}	

		
	}
	
	// Update is called once per frame
	void Update () {
		
		TimeManager.Instance.SetTimeIsRunning(gameIsPlaying);		
		GUIManager.Instance.UpdateClockText();		
		
		switch (gameType)
		{
			case 1:
				TimeChallange();
				break;
			case 2:
				
				break;
			default:
				
				break;
		}	
		
	}

	void SetTimeChallange(){		
		TimeManager.Instance.SetTimeCountDown(true,timeLimits[gameLevel]);		
	}

	void TimeChallange(){
				
		GUIManager.Instance.UpdateClockImageFilled(timeLimits[gameLevel],TimeManager.Instance.GetTime());

		if(TimeManager.Instance.GetTime() <= 0){
			GameOver();
		}
	}

	void GameOver(){

		TimeManager.Instance.ResetTime();
		GUIManager.Instance.SetClockTextToZero();

		GUIManager.Instance.ActiveGameOverPanel();

		//Disable Game Music
		gameMusic.GetComponent<AudioSource>().volume = 0.05f;
		
		gameIsPlaying = false;

	}

	public void PauseGame(){
		gameIsPlaying = false;
		gameMusic.GetComponent<AudioSource>().volume = 0.05f;
	}

	public void UnPauseGame(){
		gameIsPlaying = true;
		gameMusic.GetComponent<AudioSource>().volume = 0.4f;
	}
	

	public void SetOpenedTileNumber(GameObject tile){
		
		gameIsPlaying = true;
		
		if(openedTileNumbers[0] == -1){
			
			openedTile[0] = tile;
			openedTileNumbers[0] = tile.GetComponent<Tile>().GetNumber();

			
			
		} else if(openedTileNumbers[1] == -1){
			openedTile[1] = tile;
			openedTileNumbers[1] = tile.GetComponent<Tile>().GetNumber();
			CheckTileNumbersMatched();
		} else{

			

			openedTile[0].GetComponent<Tile>().CloseTile();
			openedTile[1].GetComponent<Tile>().CloseTile();

			openedTile[0] = tile;
			openedTileNumbers[0] = tile.GetComponent<Tile>().GetNumber();

			openedTileNumbers[1] = -1;
		}

		
	}

	void CheckTileNumbersMatched(){
		
		if(openedTile[0].GetComponent<Tile>().GetNumber() == openedTile[1].GetComponent<Tile>().GetNumber()){
			Matched(openedTile[0].GetComponent<Tile>().GetNumber());
		}else{
			UnMatched();
		}
	}

	bool Matched(int tileNumber){
		Debug.Log("Matched");
		openedTileNumbers[0] = -1;
		openedTileNumbers[1] = -1;

		openedTile[0].GetComponent<Tile>().SetMatched(true);
		openedTile[1].GetComponent<Tile>().SetMatched(true);

		GameObject.Find("FruitAudioSource").GetComponent<AudioSource>().PlayOneShot(fruitClips[tileNumber]);
		GetComponent<AudioSource>().PlayOneShot(matchedClip);
		

		matched++;
		if(matched >= goals){
			Finish();
		}

		return true;
	}

	void Finish(){

		GUIManager.Instance.ActiveFinishPanel();

		//Disable Game Music
		gameMusic.GetComponent<AudioSource>().volume = 0.05f;

		ShowAdsManager.Instance.ShowInterstitialAd();

		gameIsPlaying = false;
	}

	bool UnMatched(){
		Debug.Log("UnMatched");
		openedTileNumbers[0] = -2;
		openedTileNumbers[1] = -2;

		

		return false;
		
	}

	public void WrongAudio(){
		GetComponent<AudioSource>().PlayOneShot(wrongClip);
	}

	public void SetGoals(int goals){
		this.goals = goals;
	}
}
}
