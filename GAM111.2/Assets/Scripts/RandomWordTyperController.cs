using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Compares user entered to randomly selected word from parser
/// </summary>
public class RandomWordTyperController : MonoBehaviour
{
    public TextMesh textMesh;
    public WordParser wordParser;
    public float startTime;
    public GameObject Enemy;
    public ParticleSystem ps;

	// Use this for initialization
	void Start () {

        Invoke("ChooseNewWord", 0.5f);
    }
	
    public void ChooseNewWord()
    {
        textMesh.text = wordParser.GetRandomWord();
        Instantiate(Enemy);
        startTime = Time.timeSinceLevelLoad;
    }

    public void CompareWord(string typed)
    {
        if(textMesh.text == typed)
        {
            Debug.Log("Winnar");

            var WCData = new WordCorrectData();
            WCData.enteredString = typed;
            WCData.timeTaken = Time.timeSinceLevelLoad - startTime;

            GlobalEvents.OnWordCorrect.Invoke(WCData);
            Destroy(GameObject.Find(Enemy.name + "(Clone)"));
            Instantiate(ps);
            ChooseNewWord();
        }
        else
        {
            Debug.Log("WRONG, you lose sir");
        }
    }
}
