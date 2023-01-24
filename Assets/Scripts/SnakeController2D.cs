using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class SnakeController2D : MonoBehaviour
{
    private Vector2Int gridMovedirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;
    private int snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMovedirection = new Vector2Int(1, 0);
        snakeMovePositionList = new List<Vector2Int>();
        gridMoveTimerMax = .5f;
        gridMoveTimer = gridMoveTimerMax;

        snakeBodySize=0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleGridMomvemnt();
       
    }
    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    private void HandleGridMomvemnt()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer > gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            snakeMovePositionList.Insert(0, gridPosition);

            gridPosition += gridMovedirection;
            
            if(snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for(int i=0; i < snakeMovePositionList.Count; i++)
            {
                Vector2Int snakeMovePosition = snakeMovePositionList[i];
                World_Sprite ws = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
                FunctionTimer.Create(ws.DestroySelf, gridMoveTimerMax);
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMovedirection)-90);

            if (levelGrid.TrySnakeEatFood(gridPosition))
            {
                snakeBodySize++;
            }
        }
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMovedirection.y == 0)
        {
            gridMovedirection.y = 1;
            gridMovedirection.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gridMovedirection.y == 0)
        {
            gridMovedirection.y = -1;
            gridMovedirection.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMovedirection.x == 0)
        {
            gridMovedirection.y = 0;
            gridMovedirection.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gridMovedirection.x == 0)
        {
            gridMovedirection.y = 0;
            gridMovedirection.x = 1;
        }
    }
    
    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    public List<Vector2Int> GetFullSnakeGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int> { gridPosition };
        gridPositionList.AddRange(snakeMovePositionList);
        return gridPositionList;
    }
}
