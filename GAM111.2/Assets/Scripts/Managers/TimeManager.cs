using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public static TimeManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public float currentTime = 0;
    public float timeUnitIncrease = 1;
    public Text wpmtext;
    public float wpm;

	void Update ()
    {
        // Count time and display UI
        currentTime += timeUnitIncrease * Time.deltaTime;
        wpmtext.text = string.Format("Your WPM: " + wpm);
    }
}
