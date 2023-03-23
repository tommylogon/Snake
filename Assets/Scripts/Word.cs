using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word 
{
    string letters;
    string hint;
    bool finished;
    float time;

    public Word(string newletters, string desc)
    {
        letters = newletters;
        hint = desc;
        finished = false;
        time = 0;


    }

    public void UpdateWordStats(bool isFinished, float newTime)
    {
        finished = isFinished;
        if (newTime > time)
        {
            time = newTime;
        }

    }

    public int GetWordLengt()
    {
        return letters.Length;
    }

    public string GetWord()
    {
        return letters;
    }
    public string GetHint()
    {
        return hint;
    }
}
