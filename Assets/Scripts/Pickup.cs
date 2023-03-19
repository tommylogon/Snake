using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    char letter;
    Vector2Int gridPosition;

    public Pickup(char assignedLetter, Vector2Int gridPos)
    {
        letter = assignedLetter;
        gridPosition = gridPos;
    }
}
