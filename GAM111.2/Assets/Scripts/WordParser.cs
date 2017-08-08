using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Splits a textasset string by newlines for random selection
/// </summary>
public class WordParser : MonoBehaviour
{
    int currentWord = 9;
    //text data or dictionary
    public TextAsset textDataCurrentLevel;

    //collection of words
    public List<string> allWords = new List<string>();

    //what we separate our string by
    private readonly char[] WORD_SEPARATOR = new char[] { '\n', ' ', '\r' };

    //get current word
    public string GetCurrentWord()
    {
        for (int i = 0; i < currentWord -1; i++)
        {
            Debug.Log("Boo");
            return allWords[currentWord];
        }
        return allWords[currentWord];
    }

    //parse data source and create the list
    private void Start()
    {
        var stringArrayCurrent = textDataCurrentLevel.text.Split(WORD_SEPARATOR);

        //convert to List
        allWords = stringArrayCurrent.ToList();

        //remove emptys
        allWords.RemoveAll(x => string.IsNullOrEmpty(x));
    }
}
