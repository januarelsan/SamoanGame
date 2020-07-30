using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVoice : MonoBehaviour
{
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0,clips.Length);
        GetComponent<AudioSource>().clip = clips[i];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
