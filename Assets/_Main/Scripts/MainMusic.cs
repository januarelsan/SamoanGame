using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
     private static MainMusic playerInstance;
    void Awake(){
        DontDestroyOnLoad (this);
            
        if (playerInstance == null) {
            playerInstance = this;
        } else {
            DestroyObject(gameObject);
        }
    }
}
