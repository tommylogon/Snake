using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;
using TMPro;

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
    private double gridMoveTimer;

    [SerializeField]
    private double gridMoveTimerMax;
    private LevelGrid levelGrid;
    [SerializeField]
    private int snakeBodySize;
    private List<SnakeMovePosition> snakeMovePositionList;
    private List<SnakeBodyPart> snakeBodyPartList;
    SnakeMovePosition previousSnakeMovePosition = null;
    [SerializeField]
    bool speedIncreases;
    bool hasMoved;

    public static SnakeController2D instance;
    


    private void Awake()
    {
        instance=this;
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
            hasMoved = true;
            gridMoveTimer -= gridMoveTimerMax;

            ChangeSpeed(false);

            SoundManager.PlaySound(SoundManager.Sound.SnakeMove);
            

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
                SoundManager.PlaySound(SoundManager.Sound.SnakeEat);
                snakeBodySize++;
                CreateSnakeBody();

                ChangeSpeed(true);
                Timer.instance.AddTime();
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
                    SnakeDied();

                    
                }
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirectionVector) -90);

            
           
        }
        
    }

    public void SnakeDied()
    {
        SoundManager.PlaySound(SoundManager.Sound.SnakeDie);
        state = State.Dead;
        GameHandler.SnakeDied();
    }

    private void HandleInput()
    {
        if (hasMoved)
        {
            

            if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDirection != Direction.Down)
            {
                gridMoveDirection = Direction.Up;
                hasMoved = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDirection != Direction.Up)
            {
                gridMoveDirection = Direction.Down;
                hasMoved = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDirection != Direction.Right)
            {
                gridMoveDirection = Direction.Left;
                hasMoved = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDirection != Direction.Left)
            {
                gridMoveDirection = Direction.Right;
                hasMoved = false;
            }
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

    public void ChangeSpeed(bool increase)
    {
        if (speedIncreases)
        {

            if (!increase)
            {
                gridMoveTimerMax *= 1.1; ;
            }
            else
            {
                gridMoveTimerMax *= 0.5;
            }

            gridMoveTimerMax = Mathf.Clamp((float)gridMoveTimerMax, 0.05f, 0.5f);

        }
    }
    private class SnakeBodyPart
    {
        private SnakeMovePosition snakeMovePosition;
        private Transform transform;
        private GameObject textGameObject;
        private TextMeshProUGUI textmesh;

        public SnakeBodyPart(int bodyIndex)
        {
            GameObject snakeBodyGameobject = new GameObject("SnakeBody", typeof(SpriteRenderer));

            snakeBodyGameobject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeBodySprite;
            snakeBodyGameobject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;

            textGameObject = new GameObject("Letter " + bodyIndex.ToString(), typeof(TextMeshProUGUI));
            textmesh = textGameObject.GetComponent<TextMeshProUGUI>();
            textmesh.text = "A";
            textmesh.fontSize = 5;
            textmesh.alignment = TextAlignmentOptions.Center;
            textGameObject.transform.parent = snakeBodyGameobject.transform;
            textGameObject.transform.localPosition = Vector3.zero;
            textGameObject.transform.localRotation = Quaternion.identity;


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
                        case Direction.Down: angle = 225; break;
                        case Direction.Up: angle = -45; break;

                    }
                    break;
                                        
                case Direction.Down:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = 180; break;
                        case Direction.Left: angle = 135; break;
                        case Direction.Right: angle = 225; break;

                    }
                    break;
                case Direction.Left:
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default: angle = 90; break;
                        case Direction.Down: angle = 135; break;
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
        public void SetText(string text)
        {
            textmesh.text = text;
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
