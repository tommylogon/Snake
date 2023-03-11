using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class SnakeController2D : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right, 
        Up,
        Down
    }

    private enum State
    {
        Alive,
        Dead
    }

    private State state;
    private Direction gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;
    [SerializeField]
    private int snakeBodySize;
    private List<SnakeMovePosition> snakeMovePositionList;
    private List<SnakeBodyPart> snakeBodyPartList;
    SnakeMovePosition previousSnakeMovePosition = null;

    private bool hasMovedSinceDirectionChanged = false;

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = .5f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;

        snakeMovePositionList = new List<SnakeMovePosition>();
        //snakeBodySize = 0;

        snakeBodyPartList = new List<SnakeBodyPart>();
        state = State.Alive;
        

        
    }
 

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Alive:
                HandleInput();
                HandleGridMomvemnt();
                break;
            case State.Dead:
                break;
        }
        
       
    }
    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    private void HandleGridMomvemnt()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer > gridMoveTimerMax )
        {

            gridMoveTimer -= gridMoveTimerMax;
            

            if(snakeMovePositionList.Count > 0)
            {
                previousSnakeMovePosition = snakeMovePositionList[0];
            }

            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(previousSnakeMovePosition, gridPosition, gridMoveDirection);
            snakeMovePositionList.Insert(0,snakeMovePosition);

            Vector2Int gridMoveDirectionVector = new Vector2Int(0,0);
            

                switch (gridMoveDirection)
                {
                    default:
                    case Direction.Right: gridMoveDirectionVector = new Vector2Int(1, 0); break;
                    case Direction.Left: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                    case Direction.Up: gridMoveDirectionVector = new Vector2Int(0, 1); break;
                    case Direction.Down: gridMoveDirectionVector = new Vector2Int(0, -1); break;
                }
                
               
            


            gridPosition += gridMoveDirectionVector;
            gridPosition = levelGrid.ValidateGridPosition(gridPosition);

            if (levelGrid.TrySnakeEatFood(gridPosition))
            {
                snakeBodySize++;
                CreateSnakeBody();
            }

            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }


            if (snakeBodyPartList.Count<snakeBodySize )
            {
                CreateSnakeBody();
            }
            UpdateSnakeBodyParts();


            foreach (SnakeBodyPart snakeBodyPart in snakeBodyPartList)
            {
                Vector2Int snakeBodypartGridPosition = snakeBodyPart.GetGridPosition();
                if(gridPosition == snakeBodypartGridPosition)
                {
                    
                    state = State.Dead;
                    GameHandler.SnakeDied();
                }
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirectionVector) -90);

            
           
        }
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDirection != Direction.Down)
        {
            gridMoveDirection = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDirection != Direction.Up)
        {
            gridMoveDirection = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDirection != Direction.Right)
        {
            gridMoveDirection = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDirection != Direction.Left)
        {
            gridMoveDirection = Direction.Right;
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
        foreach(SnakeMovePosition snakeMovePosition in snakeMovePositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }

        return gridPositionList;
    }
    private void CreateSnakeBody()
    {
            snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count));                
    }

    private void UpdateSnakeBodyParts()
    {
        for (int i = 0; i < snakeBodyPartList.Count; i++)
        {
            
        snakeBodyPartList[i].SetSnakeMovePosition(snakeMovePositionList[i]);
        } 
    }

    private class SnakeBodyPart
    {
        private SnakeMovePosition snakeMovePosition;
        private Transform transform;

        public SnakeBodyPart(int bodyIndex)
        {
            GameObject snakeBodyGameobject = new GameObject("SnakeBody", typeof(SpriteRenderer));
            snakeBodyGameobject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeBodySprite;
            snakeBodyGameobject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = snakeBodyGameobject.transform;

        }
        public void SetSnakeMovePosition(SnakeMovePosition snakeMovePosition)
        {
            this.snakeMovePosition = snakeMovePosition;
            transform.position = new Vector3(snakeMovePosition.GetGridPosition().x, snakeMovePosition.GetGridPosition().y);
            float angle;
            switch (snakeMovePosition.GetDirection())
            {
                default:
                case Direction.Up:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = 0; break;
                        case Direction.Left: angle = 0 + 45; break;
                        case Direction.Right: angle = 0 - 45; break;

                    }
                    break;
                case Direction.Right:                    
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = -90;break;
                        case Direction.Down: angle = 45; break;
                        case Direction.Up: angle = -45; break;

                    }
                    break;
                                        
                case Direction.Down:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = 180; break;
                        case Direction.Left: angle = 180-45; break;
                        case Direction.Right: angle = 180+45; break;

                    }
                    break;
                case Direction.Left:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = 90; break;
                        case Direction.Down: angle = -45; break;
                        case Direction.Up: angle = 45; break;

                    }
                    
                    break;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public Vector2Int GetGridPosition()
        {
            return snakeMovePosition.GetGridPosition();
        }
    }

    private class SnakeMovePosition
    {
        private SnakeMovePosition previousSnakeMovePosition;
        private Vector2Int gridPosition;
        private Direction direction;

        public SnakeMovePosition(SnakeMovePosition previousSnakeMovePosition,Vector2Int gridPosition, Direction direction)
        {
            this.previousSnakeMovePosition = previousSnakeMovePosition;
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition;
        }
        public Direction GetDirection()
        {
            return direction;
        }

        public Direction GetPreviousDirection()
        {
            if(previousSnakeMovePosition == null)
            {
                return Direction.Right;
            }
            return previousSnakeMovePosition.direction;
        }
    }
}
