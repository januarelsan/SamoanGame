﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : Singleton<SceneController> {

	void Awake(){
		
		
	}

	public void restartScene (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void goToScene(string sceneName){
		ShowAdsManager.Instance.DestroyAllAds();
		SceneManager.LoadScene (sceneName);

	}

	
	public void goToFlashCard(int category){
		GameData.Instance.FlashCardCategory = category;
		SceneManager.LoadScene ("FlashCard");
	}

	public void quitGame(){		
		Application.Quit ();
	}

	public string getSceneLoaded(){
		return Application.loadedLevelName;
	}
		
}
