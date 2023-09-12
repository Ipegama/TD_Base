using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator 
{
    private int height, width;
    private List<Vector2Int> pathCells;
    public PathGenerator(int height, int width)
    {
        this.height = height;
        this.width = width;
    }

    public void GeneratePath()
    {
        pathCells = new List<Vector2Int>();
    }
}
