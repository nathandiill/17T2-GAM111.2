using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Splits a textasset string by newlines for random selection
/// </summary>
public class WordParser : MonoBehaviour
{
    //text data or dictionary
    public TextAsset textDataCurrentLevel;
    public int currentWord = -1;

    //collection of words
    public List<string> allWords = new List<string>();

    //what we separate our string by
    private readonly char[] WORD_SEPARATOR = new char[] { '\n', ' ', '\r'};

    //get current word
    public string GetCurrentWord()
    {
        if (currentWord > 10)
        {
            return allWords[currentWord];
        }
        else
        {
            Debug.Log("Bam");
            return allWords[currentWord + 1];
        }
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
