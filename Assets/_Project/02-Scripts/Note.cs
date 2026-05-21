using UnityEngine;

/// <summary>
/// This script handles the logic of the note and how it communicates it's location on the grid
/// </summary>

public class Note : MonoBehaviour

{
    [SerializeField] private RhythmGrid rhythmGrid; // Reference to the RhythmGrid script
    [SerializeField] private int noteColumn; // The column this note belongs to
    [SerializeField] private int noteRow;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this note has to ask the rhythm grid where in the world is my position on the grid
        //move to that position
        transform.position = rhythmGrid.GetPositionInGrid(noteColumn, noteRow);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
