using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;
using TMPro;

public class SnakeController2D : MonoBehaviour
{
    public enum Direction
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

    private List<PlayereMovePosition> playerMovePositionList;
    private List<PlayerBodyParts> playerBodyPartList;
    PlayereMovePosition previousPlayerMovePosition = null;
    [SerializeField]

    bool speedIncreases;
    bool hasMoved;

    public static SnakeController2D instance;

    public Word currentWord;

    private void Awake()
    {
        instance = this;
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = .5;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;

        playerMovePositionList = new List<PlayereMovePosition>();


        playerBodyPartList = new List<PlayerBodyParts>();
        state = State.Alive;


    }


    void Update()
    {
        switch (state)
        {
            case State.Alive:
                HandleInput();
                HandleGridMovement();
                break;
            case State.Dead:
                break;
        }


    }
    public void Setup(LevelGrid levelGrid, Word newHiddenWord)
    {
        this.levelGrid = levelGrid;
        currentWord = newHiddenWord;
        snakeBodySize = currentWord.GetWordLengt();
    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer > gridMoveTimerMax)
        {
            hasMoved = true;
            gridMoveTimer -= gridMoveTimerMax;

            ChangeSpeed(false);

            SoundManager.PlaySound(SoundManager.Sound.PayerMove);


            if (playerMovePositionList.Count > 0)
            {
                previousPlayerMovePosition = playerMovePositionList[0];
            }

            PlayereMovePosition snakeMovePosition = new PlayereMovePosition(previousPlayerMovePosition, gridPosition, gridMoveDirection);
            playerMovePositionList.Insert(0, snakeMovePosition);

            Vector2Int gridMoveDirectionVector = new Vector2Int(0, 0);


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
                SoundManager.PlaySound(SoundManager.Sound.PlayerPickup);


                ChangeSpeed(true);

            }

            if (playerMovePositionList.Count >= snakeBodySize + 1)
            {
                playerMovePositionList.RemoveAt(playerMovePositionList.Count - 1);
            }


            if (playerBodyPartList.Count < snakeBodySize)
            {
                foreach (char c in currentWord.GetWord())
                {
                    CreatePlayerBodyPart(c);
                }

            }
            UpdateSnakeBodyParts();


            foreach (PlayerBodyParts snakeBodyPart in playerBodyPartList)
            {
                Vector2Int bodypartGridPosition = snakeBodyPart.GetGridPosition();
                if (gridPosition == bodypartGridPosition)
                {
                    PlayerDied();


                }
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirectionVector) - 90);



        }

    }

    public void TryRevealLetter(char letter)
    {

        bool allLettersRevealed = true;
        bool thisLetterRevealed = false;


        //i need to check the playerBodyPartList for all bodyparets that are revealed. some bodyparts have the same letters, but needs to only be counted once. if all letters are revealed we can do the win condition




        foreach (var bodyPart in playerBodyPartList)
        {
            if (bodyPart.RevealLetter(letter))
            {
                Score.AddScore();
                thisLetterRevealed = true;


            }
            if (!bodyPart.LetterIsRevealed())
            {
                allLettersRevealed = false;
            }
            
        }



        if (allLettersRevealed)
        {
            Timer.instance.PauseTimer(true);
            GameHandler.PlayerWon();



        }

    }

    public void PlayerDied()
    {
        SoundManager.PlaySound(SoundManager.Sound.PlayerDie);
        state = State.Dead;
        GameHandler.PlayerDied();
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
        foreach (PlayereMovePosition snakeMovePosition in playerMovePositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }

        return gridPositionList;
    }
    private void CreatePlayerBodyPart(char letter)
    {
        if (GameAssets.instance.PlayerFollowPrefab != null)
        {
            GameObject playerBodyPartObject = Instantiate(GameAssets.instance.PlayerFollowPrefab);
            PlayerBodyParts playerBodyPart = playerBodyPartObject.GetComponent<PlayerBodyParts>();
            playerBodyPart.Setup(playerBodyPartList.Count, letter);
            playerBodyPartList.Add(playerBodyPart);
        }

    }

    private void UpdateSnakeBodyParts()
    {
        for (int i = 0; i < playerBodyPartList.Count; i++)
        {
            if (playerMovePositionList.Count > i)
            {
                playerBodyPartList[i].SetSnakeMovePosition(playerMovePositionList[i]);

            }
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
}
