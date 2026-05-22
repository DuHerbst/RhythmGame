using UnityEngine;

/// <summary>
/// this script is responsible for mapping the grid in which the notes are gonna travel through
/// we need a starting point for the grid, total amount of column and a total amount of rows to create the grid
/// we need the width and height of the cells to the power of 2 to make sure the notes are perfectly aligned with the grid
/// </summary>

public class RhythmGrid : MonoBehaviour
{
    [SerializeField] private Transform gridStartPoint;
    [SerializeField] private Transform gridScoreLocation;
    
    [SerializeField] private int totalColumns = 4;
    [SerializeField] private int totalRows = 7;
    
    public int ScoreRow => scoreRow;
    
    [SerializeField] private int scoreRow = 6;
    [SerializeField] private float cellWidth;
    [SerializeField] private float cellHeight;

    private float _verticalPosition;
    private float _horizontalPosition;

    //private Vector2Int _cellsize = new Vector2Int(1,1); // to make the note move on a cell but lerp visuals?
    //private Vector2 _celldistance;

    void Start()
    {
        
        Debug.Log(totalColumns);
        Debug.Log(totalRows);
        Debug.Log("This where the grid starts " + gridStartPoint.position);
        Debug.Log("Score position for lane 1 " + GetScorePosition(0));
        
    }
    
    public Transform GridStartPoint => gridStartPoint; // other scripts can be observers of the grid?
    
    //if you get a row number and a column number, select that position in the world

    public Vector3 GetPositionInGrid(int column, int row) // gives back a new v3 position on the grid
    {
        // calculate the position based on the starting point and the cell size
        _horizontalPosition = gridStartPoint.position.x + (column * cellWidth);
        _verticalPosition = gridStartPoint.position.y - (row * cellHeight); // subtracting on y because notes travel downwards 
        return new Vector3(_horizontalPosition, _verticalPosition, gridStartPoint.position.z); // return the final position
    }

    public Vector3 GetScorePosition(int column) // position of score location?
    {
        
        // uses this column and scoreRow and returns the position where the scoring happens
        // notes will ask if they are in the position, detecting each step on the grid
        
        return GetPositionInGrid(column, scoreRow);
        
    }
    
}
