﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordTyperController : MonoBehaviour
{
    public TextMesh textMesh;
    public WordParser wordParser;
    public float startTime;
    public GameObject Enemyprefab;
    public GameObject EnemyInstance;
    public ParticleSystem ps;

	// Use this for initialization
	void Start () {

        Invoke("ChooseNewWord", 0.5f);
    }
	
    public void ChooseNewWord()
    {
        textMesh.text = wordParser.GetCurrentWord();
        EnemyInstance = Instantiate(Enemyprefab);
        startTime = Time.timeSinceLevelLoad;
    }

    public void CompareWord(string typed)
    {
        if(textMesh.text == typed)
        {
            AudioManager.Instance.correctWordAudio();

            var WCData = new WordCorrectData();
            WCData.enteredString = typed;
            WCData.timeTaken = Time.timeSinceLevelLoad - startTime;

            GlobalEvents.OnWordCorrect.Invoke(WCData);
            Destroy(EnemyInstance);
            Instantiate(ps);
            ChooseNewWord();
        }
        else
        {
            AudioManager.Instance.wrongWordAudio();
        }
    }
}
