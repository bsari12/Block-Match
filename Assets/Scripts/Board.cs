using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int Size = 8;
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Transform cellsTransform;

    private readonly Cell[,] cells = new Cell[Size, Size];
    private readonly int[,] data = new int[Size, Size];

    private readonly List<Vector2Int> hoverPoints = new();

    void Start()
    {
        for(var r = 0; r< Size; ++r)
        {
            for(var c = 0; c < Size; ++c)
            {
                cells[r, c] = Instantiate(cellPrefab, cellsTransform);
                cells[r, c].transform.position = new(c + 0.5f, r + 0.5f, 0.0f);
                cells[r, c].Hide();
            }
        }
    }

    public void Hover(Vector2Int point, int polyominoIndex)
    {
        var polyomino = Polyominos.Get(polyominoIndex);
        var polyominoRows = polyomino.GetLength(0);
        var polyominoColumns = polyomino.GetLength(1);

        Unhover();
        HoverPoints(point, polyominoRows, polyominoColumns, polyomino);
        if(hoverPoints.Count > 0)
        {
            Hover();
        }
    }

    private void HoverPoints(Vector2Int point, int polyominoRows, int polyominoColumns, int [,] polyomino)
    {
        for (var r = 0; r< polyominoRows; ++r)
        {
            for (var c = 0; c< polyominoColumns; ++c)
            {
                if(polyomino[r, c] > 0)
                {
                    var hoverPoint = point + new Vector2Int(c, r);
                    if(IsValidPoint(hoverPoint) == false)
                    {
                        hoverPoints.Clear();
                        return;
                    }
                    hoverPoints.Add(hoverPoint);
                }
            }
        }
    }

    private bool IsValidPoint(Vector2Int point)
    {
        if(point.x<0 || Size <= point.x) return false;
        if(point.y<0 || Size <= point.y) return false;
        if(data[point.y, point.x] > 0) return false;

        return true;
    }

    private void Hover()
    {
        foreach(var hoverPoint in hoverPoints)
        {
            data[hoverPoint.y, hoverPoint.x] = 1;
            cells[hoverPoint.y, hoverPoint.x].Hover();
        }
    }

    private void Unhover()
    {
        foreach(var hoverPoint in hoverPoints)
        {
            data[hoverPoint.y, hoverPoint.x] = 0;
            cells[hoverPoint.y, hoverPoint.x].Hide();
        }
        hoverPoints.Clear();
    }
}
