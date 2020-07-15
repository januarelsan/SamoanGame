using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MatchingGame
{
public class GUIManager : Singleton<GUIManager> {


	[SerializeField] private GameObject finishPanel = null;
	
	[SerializeField] private GameObject gameOverPanel = null;
	[SerializeField] private Text clockText = null;
	[SerializeField] private Text finishClockText = null;
	[SerializeField] private GameObject[] stars = null;

	[SerializeField] private Image clockImageFilled = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActiveGameOverPanel(){
		gameOverPanel.SetActive(true);
		gameOverPanel.GetComponent<Animator>().SetTrigger("PopUp");
		
	}

	public void ActiveFinishPanel(){
		finishPanel.SetActive(true);
				
		finishClockText.text = clockText.text;
		
	}

	

	public void UpdateClockText(){
		clockText.text = TimeManager.Instance.GetTimeString();
	}

	public void SetClockTextToZero(){
		clockText.text = "00:00";
	}

	public void UpdateClockImageFilled(float timeLimit, float time){
		clockImageFilled.gameObject.SetActive(true);
		clockImageFilled.fillAmount = time / timeLimit;
		// Debug.Log("R: " + time / timeLimit);
	}
}
	
}
