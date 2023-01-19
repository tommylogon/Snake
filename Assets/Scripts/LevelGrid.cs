using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class LevelGrid 
{
    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    GameObject foodGameObject;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        SpawnFood();

        // FunctionPeriodic.Create(SpawnFood, 1f);
    }

    private void SpawnFood()
    {
        foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }
    
    public void SnakeMoved(Vector2Int snakeGridposition)
    {
        if(snakeGridposition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            CMDebug.TextPopupMouse("Snake ate food");
        }
    }
}
