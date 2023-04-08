using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
   public enum Language
    {
        English,
        Thai,
        Chinese,
        Japanese,
        Korean,
        German,
        Spannish,
        French,
        Russian,

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
    char[] thaiAlphabet = new char[]
{
    'ก', 'ข', 'ฃ', 'ค', 'ฅ', 'ฆ', 'ง', 'จ', 'ฉ', 'ช',
    'ซ', 'ฌ', 'ญ', 'ฎ', 'ฏ', 'ฐ', 'ฑ', 'ฒ', 'ณ', 'ด',
    'ต', 'ถ', 'ท', 'ธ', 'น', 'บ', 'ป', 'ผ', 'ฝ', 'พ',
    'ฟ', 'ภ', 'ม', 'ย', 'ร', 'ฤ', 'ล', 'ฦ', 'ว', 'ศ',
    'ษ', 'ส', 'ห', 'ฬ', 'อ', 'ฮ',
    'ะ', 'ั', 'า', 'ำ', 'ิ', 'ี', 'ึ', 'ื', 'ุ', 'ู', 'ฤ', 'ฦ'//'ฤๅ',
                                                           //, 'ฦๅ'
};



    private void Awake()
    {
        instance = this;

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('A' + i);
        }

        selectedLanguage = (Language)Enum.Parse(typeof(Language), PlayerPrefs.GetString("Language"));
    }

    public char RandomLetter()
    {
        switch (selectedLanguage)
        {
            case Language.English:
                return alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
            case Language.Thai:
                return thaiAlphabet[UnityEngine.Random.Range(0, thaiAlphabet.Length)];
            default:
                return alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
        }
        
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
