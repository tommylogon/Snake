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
    private GameObject foodGameObject;
    private SnakeController2D snake;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        

       
    }


    public void Setup(SnakeController2D snake)
    {
        this.snake = snake;
        
            SpawnFood();
        
        
    }
    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);
        

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }
    
    public bool TrySnakeEatFood(Vector2Int snakeGridposition)
    {
        if(snakeGridposition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            CMDebug.TextPopupMouse("Snake ate food");
            return true;
        }
        return false;
    }
}
