using System.Collections;
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
		SceneManager.LoadScene (sceneName);
	}

	public void quitGame(){		
		Application.Quit ();
	}

	public string getSceneLoaded(){
		return Application.loadedLevelName;
	}
		
}
