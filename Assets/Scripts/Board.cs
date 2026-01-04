using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    private const int Size = 8;
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Transform cellsTransform;

    private readonly Cell[,] cells = new Cell[Size, Size];

    void Start()
    {
        for(var r = 0; r< Size; ++r)
        {
            for(var c = 0; c < Size; ++c)
            {
                cells[r, c] = Instantiate(cellPrefab, cellsTransform);
                cells[r, c].transform.position = new(c + 0.5f, r + 0.5f, 0.0f);
            }
        }
    }
}
