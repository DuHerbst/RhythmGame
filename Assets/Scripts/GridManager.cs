using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<Vector2Int> cellPositions = new List<Vector2Int>();
    
    void Start()
    {
        
        cellPositions.Add(new Vector2Int(0, -0));
        cellPositions.Add(new Vector2Int(0, -1));
        cellPositions.Add(new Vector2Int(0, -2));
        cellPositions.Add(new Vector2Int(0, -3));
        cellPositions.Add(new Vector2Int(0, -4));
        cellPositions.Add(new Vector2Int(0, -5));
        
    }
    
}
