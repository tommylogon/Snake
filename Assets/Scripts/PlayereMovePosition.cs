using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SnakeController2D;

public class PlayereMovePosition
    {
        private PlayereMovePosition previousSnakeMovePosition;
        private Vector2Int gridPosition;
        private Direction direction;

        public PlayereMovePosition(PlayereMovePosition previousSnakeMovePosition, Vector2Int gridPosition, Direction direction)
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
            if (previousSnakeMovePosition == null)
            {
                return Direction.Right;
            }
            return previousSnakeMovePosition.direction;
        }
    }

