using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SnakeController2D;

public class PlayerBodyParts : MonoBehaviour
{
    private PlayereMovePosition playerMovePosition;
    
    [SerializeField]
    private GameObject textGameObject;

    [SerializeField]
    private TextMeshPro letterText;

    public void Setup(int bodyIndex, char letter)
    {
       
        // new GameObject("SnakeBody", typeof(SpriteRenderer));
        
        //snakeBodyGameobject.GetComponent<SpriteRenderer>().sprite = GameAssets.instane.snakeBodySprite;


        GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
        letterText.text = letter.ToString();


    }
    public void SetSnakeMovePosition(PlayereMovePosition snakeMovePosition)
    {
        this.playerMovePosition = snakeMovePosition;
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
                    default: angle = -90; break;
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
        textGameObject.transform.eulerAngles = new Vector3(0, 0, angle - angle);
    }

    public Vector2Int GetGridPosition()
    {
        return playerMovePosition.GetGridPosition();
    }
    public void SetText(string text)
    {
        letterText.text = text;
    }
}
