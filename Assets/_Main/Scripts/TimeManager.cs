using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    private float time;
	private float minutes;
	private float seconds;

	
	private string timeString;
    // Start is called before the first frame update
    void Start()
    {

        minutes = Mathf.Floor (time / 60);
		seconds = time % 60;
		timeString = Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

		minutes = Mathf.Floor (time / 60);
		seconds = time % 60;

		timeString = Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
        
    }

    public string FloatTimeToString(float time){		
		float minutes = Mathf.Floor (time / 60);
		float seconds = time % 60;
		return Mathf.RoundToInt (minutes).ToString ("00") + ":" + Mathf.RoundToInt (seconds).ToString ("00");
	}

	public string GetTimeString (){
		return timeString;
	}

	public float GetTime (){
		return time;
	}

	public void ResetTime(){
		time = 0;
	}

}
