using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class LevelGrid 
{
    private Vector2Int pickupGridPosition;
    private int width;
    private int height;
    private List<GameObject> pickupList; 
    private GameObject pickupGameObject;
    private SnakeController2D player;
    private int spawnedPickUps;


    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        
    }


    public void Setup(SnakeController2D player, Word newWord)
    {
        this.player = player;
        pickupList = new List<GameObject>();

        foreach (char c in newWord.GetWord().ToCharArray())
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
        } while (player.GetFullSnakeGridPositionList().IndexOf(pickupGridPosition) != -1 || GetFullPickupGridPositionList().IndexOf(pickupGridPosition) != -1);


       pickupGameObject = GameAssets.Instantiate(GameAssets.instance.pickupPrefab);
       Pickup pickup = pickupGameObject.GetComponent<Pickup>();
       pickup.SetLetter(letter);
       pickup.setPos(pickupGridPosition);
        //pickupGameObject = new GameObject("Puckup", typeof(SpriteRenderer));
        //pickupGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;

       pickupGameObject.transform.position = new Vector3(pickupGridPosition.x, pickupGridPosition.y);

        pickupList.Add(pickupGameObject);

        pickupGameObject = null;
    }
    
    public bool TrySnakeEatFood(Vector2Int PlayerGridposition)
    {
        pickupGameObject = GetPickupFromPlayerPosition(PlayerGridposition);
            if (pickupGameObject != null)
            {
            
                player.TryRevealLetter(pickupGameObject.GetComponent<Pickup>().GetLetter());
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
    private List<Vector2Int> GetFullPickupGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        
            foreach (var pickup in pickupList)
            {
                Vector2Int pos = new Vector2Int();
                pos.x = (int)pickup.transform.position.x;
                pos.y = (int)pickup.transform.position.y;
                gridPositionList.Add(pos);
            }
        
        

        return gridPositionList;
    }

    private GameObject GetPickupFromPlayerPosition(Vector2Int playerGridposition)
    {
        
        foreach(var pickup in pickupList)
        {
            if(pickup.GetComponent<Pickup>().GetPos() == playerGridposition)
            {
                return pickup;
            }
        }


        return null;
    }
}
