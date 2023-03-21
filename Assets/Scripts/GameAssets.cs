using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;
    public Sprite snakeHeadSprite; 
    public Sprite snakeBodySprite;
    public Sprite foodSprite;

    public GameObject pickupPrefab;
    public GameObject PlayerPrefab;

    public SoundAudioClip[] soundAudioClipArray;

    public char[] alphabet = new char[26];

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('A' + i);
        }
    }

    public char RandomLetter()
    {
        return alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
    }

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    


    

}
