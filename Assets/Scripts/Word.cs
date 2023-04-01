using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Word 
{
    public string letters;
    public string hint;
    public bool finished;
    public float time;
    public int score;
    public string language;
    public int difficulty;

    public Word(string newletters, string desc, string newLanguage, int newDifficulty)
    {
        letters = newletters;
        hint = desc;
        finished = false;
        time = letters.Length;
        language = newLanguage;
        difficulty = newDifficulty;

    }

    public void UpdateWordStats(bool isFinished, float newTime, int newScore)
    {
        finished = isFinished;
        if (newTime > time)
        {
            time = newTime;
        }
        if(newScore > score)
        {
            score = newScore;
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
      
    public bool GetFinished()
    {
        return finished;
    }
    public int GetScore() { return score; }
    public float GetTime() { return time; }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Word))
        {
            return false;
        }

        Word other = (Word)obj;
        return letters == other.letters;
    }

    public override int GetHashCode()
    {
        return letters.GetHashCode();
    }
}
