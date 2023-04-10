using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
   public enum Language
    {
        English,
        Norwegian,
        Thai,        
        Japanese,        
        German,
        Spannish,
        French      

    }

    public Language selectedLanguage;
    public static GameAssets instance;
    public Sprite snakeHeadSprite; 
    public Sprite snakeBodySprite;
    public Sprite foodSprite;
    public Sprite completedSprire;
    public Sprite uncompletedSprite;


    public GameObject pickupPrefab;
    public GameObject PlayerFollowPrefab;

    public SoundAudioClip[] soundAudioClipArray;

    public char[] alphabet = new char[26];




    private void Awake()
    {
        instance = this;

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('A' + i);
        }

        if (PlayerPrefs.HasKey("Language"))
        {
            selectedLanguage = (Language)Enum.Parse(typeof(Language), PlayerPrefs.GetString("Language"));
        }
        else
        {
            selectedLanguage = Language.English;
        }
    }

    public char RandomLetter()
    {
        return alphabet[UnityEngine.Random.Range(0, alphabet.Length)];

        
        
    }

    public void SelectLanguage(Language newLanguage)
    {
        selectedLanguage = newLanguage;
        PlayerPrefs.SetString("Language", selectedLanguage.ToString());
        PlayerPrefs.Save();
    }



    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    


    

}
