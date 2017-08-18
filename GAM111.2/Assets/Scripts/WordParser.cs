using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordParser : MonoBehaviour
{
    public static WordParser Instance;

    void Awake()
    {
        Instance = this;
    }

    public int currentWord = -1;
    public TextAsset textDataCurrentLevel;
    public string Level1Condition = "stop";
    public string Level2Condition = "close";
    public string Level3Condition = "letter";
    public string Level4Condition = "however";
    public string Level5Condition = "occasion";

    //collection of words
    public List<string> allWords = new List<string>();

    //what we separate our string by
    private readonly char[] WORD_SEPARATOR = new char[] { '\n', ' ', '\r' };

    //get current word
    public string GetCurrentWord()
    {
        if (string.Equals(GatherStringInput.Instance.userInput, Level1Condition))
        {
            CurrentLevelParser.Instance.fsm.ChangeState(CurrentLevelParser.States.Level2);
        }
        else
        {
            currentWord = currentWord + 1;
        }
        return allWords[currentWord];
    }

    //parse data source and create the list
    public void Start()
    {
        var stringArrayCurrent = textDataCurrentLevel.text.Split(WORD_SEPARATOR);

        //convert to List
        allWords = stringArrayCurrent.ToList();

        //remove emptys
        allWords.RemoveAll(x => string.IsNullOrEmpty(x));
    }
}
