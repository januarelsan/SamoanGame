﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Puzzle : Singleton<GM_Puzzle> {

	private bool isPlaying = true;

	[SerializeField]
	private Text timeText;

	[SerializeField]
	private Sprite[] animalMultipleSprites;

	[SerializeField]
	private Sprite[] animalSprites;

	[SerializeField]
	private GameObject[] targetTiles;

	[SerializeField]
	private GameObject[] sourceTiles;

	private	int[] indexArray = new int[30];
	private int index;

	private int tileCompleted;

	[SerializeField]
	private Text indexText;

	private int nStars;

	//Completed Panel
	[SerializeField]
	private GameObject completedPanel;

	//Finished Panel
	[SerializeField]
	private GameObject finishedPanel;
	[SerializeField]
	private GameObject[] finishedStars;	
	[SerializeField]
	private Text finishedClockText;
	
	

	// Use this for initialization
	void Start () {

		//Assign Index Array
		for (int i = 0; i < 2; i++){
			indexArray[i] = i;
		}
	
		
		RandomArrayOrder();

		SetSourceTile();
		SetTargetTile();

		
	}
	
	// Update is called once per frame
	void Update () {

		if(isPlaying)
			timeText.text = TimeManager.Instance.GetTimeString();
	}

	void RandomArrayOrder(){
		for (int i = 0; i < 50; i++){
			int r = Random.Range(0,2);
			int r_ = Random.Range(0,2);
			

			int tempIndex = indexArray[r];
			indexArray[r] = indexArray[r_];
			indexArray[r_] = tempIndex;
		}

		//Show array value
		for (int i = 0; i < indexArray.Length; i++){
			Debug.Log(indexArray[i]);
		}
	}

	void SetTargetTile(){
		int index_ = indexArray[index];

		for (int i = 0; i < sourceTiles.Length; i++){			
			targetTiles[i].transform.GetChild(0).GetComponent<Image>().sprite = animalMultipleSprites[(index_ * 6) + i];
		}
	}

	void SetSourceTile(){

		int index_ = indexArray[index];

		for (int i = 0; i < sourceTiles.Length; i++){			
			sourceTiles[i].transform.GetChild(0).GetComponent<Image>().sprite = animalMultipleSprites[(index_ * 6) + i];
		}

		//Random Switch (Image and Number)
		for (int i = 0; i < 20; i++){
			int r = Random.Range(0,6);
			int r_ = Random.Range(0,6);

			Sprite tempsprite = sourceTiles[r].transform.GetChild(0).GetComponent<Image>().sprite;
			sourceTiles[r].transform.GetChild(0).GetComponent<Image>().sprite = sourceTiles[r_].transform.GetChild(0).GetComponent<Image>().sprite;
			sourceTiles[r_].transform.GetChild(0).GetComponent<Image>().sprite = tempsprite;

			int tempNumber = sourceTiles[r].transform.GetComponent<Tile>().GetNumber();
			sourceTiles[r].transform.GetComponent<Tile>().SetNumber(sourceTiles[r_].transform.GetComponent<Tile>().GetNumber()) ;
			sourceTiles[r_].transform.GetComponent<Tile>().SetNumber(tempNumber);
		}
		
	}

	public void AddTileCompleted(){
		tileCompleted++;

		if(tileCompleted == 6){
			CompletedIndex();
		}
	}

	void CompletedIndex(){

		index++;
		indexText.text = (index + 1) + "/30";

		if(index < 2){
			isPlaying = false;											
			completedPanel.SetActive(true);	

		} else {
			Finish();
		}
	}

	int GetCountedStars(){
		if (TimeManager.Instance.GetTime() < 15){
			nStars = 3;			
		} else if (TimeManager.Instance.GetTime() < 25){
			nStars = 2;
		} else {
			nStars = 1;
		}

		return nStars;
	}

	void Finish(){
		

		isPlaying = false;
				

		for (int i = 0; i < GetCountedStars(); i++)
		{
			finishedStars[i].SetActive(true);
		}


		finishedClockText.text = timeText.text;
		finishedPanel.SetActive(true);					
		
	}

	public void Reset(){

		TimeManager.Instance.ResetTime();
		isPlaying = true;

		for (int i = 0; i < 6; i++){
			
			// Transform tempTransform = targetTiles[i].transform;
			// targetTiles[i].transform.position = sourceTiles[i].transform.position;
			// sourceTiles[i].transform.position = tempTransform.position;
		
			targetTiles[i].SetActive(true);
			targetTiles[i].GetComponent<Tile>().ResetTransform();
			targetTiles[i].GetComponent<Tile>().SetNumber(i);

			sourceTiles[i].GetComponent<Tile>().ResetTransform();
			sourceTiles[i].GetComponent<Tile>().SetCanDrag(true);
			sourceTiles[i].GetComponent<Tile>().SetNumber(i);

		}

		SetSourceTile();
		SetTargetTile();
		tileCompleted = 0;
	}
}
