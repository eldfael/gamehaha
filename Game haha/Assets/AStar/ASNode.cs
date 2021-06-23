using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASNode
{

    public Vector2 worldPosition;
    public bool walkable;
    public int gridX, gridY;
    public float hCost, gCost;

    public float fCost
    {
        get
        {
            return hCost + gCost;
        }
    }

    public ASNode(Vector2 _worldPosition, int _gridX, int _gridY, bool _walkable)
    {
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
        walkable = _walkable;
    }

}
