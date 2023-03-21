using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    char letter;
    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    Vector2Int gridPosition;

    

    public Pickup(char assignedLetter, Vector2Int gridPos)
    {
        letter = assignedLetter;
        gridPosition = gridPos;
    }

    public char GetLetter()
    {
        return letter;
    }

    public void SetLetter(char newLetter)
    {
        letter = newLetter;
        text.text = letter.ToString();
    }
    public Vector2Int GetPos()
    {
        return gridPosition;
    }
    public void setPos(Vector2Int newGridPositio)
    {
        gridPosition = newGridPositio;
        transform.position = new Vector3(newGridPositio.x, newGridPositio.y,0);
    }
}
