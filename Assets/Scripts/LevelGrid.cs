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
    private List<GameObject> foodList; 
    private GameObject foodGameObject;
    private SnakeController2D snake;
    private int spawnedFoods;


    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        foodList = new List<GameObject>();
    }


    public void Setup(SnakeController2D snake, int maxFood)
    {
        this.snake = snake;
        while(spawnedFoods < maxFood)
        {
            SpawnFood();
            spawnedFoods++;
        }
        
        
    }
    private void SpawnFood()
    {


        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1 || GetFullFoodGridPositionList().IndexOf(foodGridPosition) != -1);

       

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);

        foodList.Add(foodGameObject);

        foodGameObject = null;
    }
    
    public bool TrySnakeEatFood(Vector2Int snakeGridposition)
    {
        
            if (GetFullFoodGridPositionList().IndexOf(snakeGridposition) > -1)
            {
            foodGameObject = foodList[GetFullFoodGridPositionList().IndexOf(snakeGridposition)];
            foodList.Remove(foodGameObject);
                Object.Destroy(foodGameObject);
                SpawnFood();
                GameHandler.AddScore();
                return true;
            }
        

        
        return false;
    }
    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = width-1;
        }
        if(gridPosition.x > width-1)
        {
            gridPosition.x = 0;
        }
            if (gridPosition.y < 0)
        {
            gridPosition.y = height-1;
        }
        if (gridPosition.y > height-1)
        {
            gridPosition.y = 0;
        }

        return gridPosition;
    }
    public List<Vector2Int> GetFullFoodGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        foreach ( var food in foodList)
        {
            Vector2Int pos = new Vector2Int();
            pos.x = (int)food.transform.position.x;
            pos.y = (int)food.transform.position.y;
            gridPositionList.Add(pos);
        }

        return gridPositionList;
    }
}
