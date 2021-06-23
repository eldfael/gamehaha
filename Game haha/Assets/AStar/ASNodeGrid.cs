using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASNodeGrid : MonoBehaviour
{
    public Vector2 gridSize;
    public float nodeSize;
    ASNode[,] nodeGrid;
    LayerMask terrainMask;
    
    private void Start()
    {
        terrainMask = LayerMask.GetMask("Terrain");

        nodeGrid = new ASNode[(int)gridSize.y, (int)gridSize.x];
        for (int x = 0; x < gridSize.x; x ++) 
        {
            for (int y = 0; y < gridSize.y; y ++) 
            {
                Vector2 worldPos = new Vector2((0.5f + x - gridSize.x / 2 )*nodeSize, (0.5f + y - gridSize.y / 2) * nodeSize);
                nodeGrid[y, x] = new ASNode(worldPos, x, y, !Physics2D.OverlapBox(worldPos, Vector2.one, 0f, terrainMask));
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (nodeGrid != null)
        {
            foreach (ASNode node in nodeGrid)
            {
                Gizmos.color = Color.white;
                if (!node.walkable)
                {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawCube(node.worldPosition,Vector3.one * 0.2f);
            }
        }
    }
}
