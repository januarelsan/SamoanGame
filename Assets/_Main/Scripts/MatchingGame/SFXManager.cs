﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchingGame
{
public class SFXManager : Singleton<SFXManager>
{

    [SerializeField]
    private GameObject confettiShower = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ActiveConfettiShower(){
        confettiShower.SetActive(true);
    }
}
    
}
