using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class LevelGrid  : MonoBehaviour
{
    private Vector2Int pickupGridPosition;
    private int width;
    private int height;
    private List<GameObject> pickupList; 
    private GameObject pickupGameObject;
    private SnakeController2D snake;
    private int spawnedPickUps;


    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        pickupList = new List<GameObject>();
    }


    public void Setup(SnakeController2D snake, Word newWord)
    {
        this.snake = snake;

        foreach(char c in newWord.GetWord().ToCharArray())
        {
            SpawnFood(c);
            spawnedPickUps++;
        }

        while (spawnedPickUps < newWord.GetWordLengt())
        {
             
            SpawnFood(GameAssets.instance.RandomLetter());
            spawnedPickUps++;
        }


    }

    private void SpawnFood(char letter)
    {


        do
        {
            pickupGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(pickupGridPosition) != -1 || GetFullFoodGridPositionList().IndexOf(pickupGridPosition) != -1);


        pickupGameObject = Instantiate( GameAssets.instance.pickupPrefab);
        pickupGameObject.GetComponent<Pickup>().SetLetter(letter);
        pickupGameObject.GetComponent<Pickup>().setPos(pickupGridPosition);
        //pickupGameObject = new GameObject("Puckup", typeof(SpriteRenderer));
        //pickupGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

        pickupGameObject.transform.position = new Vector3(pickupGridPosition.x, pickupGridPosition.y);

        pickupList.Add(pickupGameObject);

        pickupGameObject = null;
    }
    
    public bool TrySnakeEatFood(Vector2Int snakeGridposition)
    {
        
            if (GetFullFoodGridPositionList().IndexOf(snakeGridposition) > -1)
            {
            pickupGameObject = pickupList[GetFullFoodGridPositionList().IndexOf(snakeGridposition)];
            snake.TryRevealLetter(pickupGameObject.GetComponent<Pickup>().GetLetter());
            pickupList.Remove(pickupGameObject);
                Object.Destroy(pickupGameObject);
                //SpawnFood();
                Score.AddScore();
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
        foreach ( var food in pickupList)
        {
            Vector2Int pos = new Vector2Int();
            pos.x = (int)food.transform.position.x;
            pos.y = (int)food.transform.position.y;
            gridPositionList.Add(pos);
        }

        return gridPositionList;
    }
}
