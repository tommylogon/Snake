using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController2D : MonoBehaviour
{
    private Vector2Int gridMovedirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMovedirection = new Vector2Int(1, 0);
        gridMoveTimerMax = 1f;
        gridMoveTimer = gridMoveTimerMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        NHandleGridMomvemnt();
       
    }

    private void NHandleGridMomvemnt()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer > gridMoveTimerMax)
        {
            gridPosition += gridMovedirection;
            gridMoveTimer -= gridMoveTimerMax;
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
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
}
