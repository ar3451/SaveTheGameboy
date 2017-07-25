﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float timeLeft = 30f;
    public Text timeRemaining;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeRemaining.text = "Time Remaining" + "\n" + timeLeft.ToString("F1");
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameDrop");
        }
    }
}