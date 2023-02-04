using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;
    public Sprite snakeHeadSprite; 
    public Sprite snakeBodySprite;
    public Sprite foodSprite;

    private void Awake()
    {
        instance = this;
    }
}
