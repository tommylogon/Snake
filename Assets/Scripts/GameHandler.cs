using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private SnakeController2D snake;
    //i would rather make level static
    private LevelGrid levelGrid;

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Gamehandler.start");

        levelGrid = new LevelGrid(20, 20);

        //GameObject snakeHeadGameObject = new GameObject();
        //SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        //snakeSpriteRenderer.sprite = GameAssets.instance.snakeHeadSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
