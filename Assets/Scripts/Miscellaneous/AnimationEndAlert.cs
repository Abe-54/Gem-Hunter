﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEndAlert : MonoBehaviour
{
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlertObservers(string _message)
    {
        message = _message;
    }
}
