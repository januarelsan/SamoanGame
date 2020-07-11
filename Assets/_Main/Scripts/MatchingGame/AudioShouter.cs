using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchingGame
{
	public class AudioShouter : Singleton<AudioShouter> {

		[SerializeField] private AudioClip[] clips = null;

		public void ShoutClip(int clipIndex){
			GetComponent<AudioSource>().PlayOneShot(clips[clipIndex]);
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}

