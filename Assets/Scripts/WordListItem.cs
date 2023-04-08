using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordListItem : MonoBehaviour
{
    
    public Image icon;
    public TextMeshProUGUI Word;
    public TextMeshProUGUI hint;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public Button_UI button;
    public Word word;

    
    public void SetWord(Word word)
    {
        this.word = word;
        if (word.isFinished) 
        {
            Word.text = word.letters;
            icon.sprite = GameAssets.instance.completedSprire;
        }
        else
        {

            Word.text = word.letters.Length.ToString() + " Letters";
            icon.sprite = GameAssets.instance.uncompletedSprite;
        }

        if(button == null)
        {
            button = GetComponent<Button_UI>();
        }


        hint.text = word.hint;
        score.text = word.score.ToString();
        time.text = Timer.FormatTime( word.time);

        button.ClickFunc = () => resetWordFinished();
        button.AddButtonSounds();

    }
    public void resetWordFinished()
    {
        if (word.isFinished)
        {
            GameHandler.instance.ResetWord(word);
            icon.sprite = GameAssets.instance.uncompletedSprite;
        }
    }




}
