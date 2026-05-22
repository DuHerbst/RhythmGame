using UnityEngine;

/// <summary>
/// This script handles the logic of the note and how it communicates it's location on the grid
/// </summary>

public class Note : MonoBehaviour

{
    [SerializeField] private RhythmGrid rhythmGrid; // Reference to the RhythmGrid script
    [SerializeField] private int noteColumn; // The column this note belongs to
    [SerializeField] private int noteRow;
    
    public int NoteColumn => noteColumn;
    public int NoteRow => noteRow;
    
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
    
    // Observer Note receives that announcement and decreases its location on the rows. Communicates with the grid where should it go
    // Note moves to the new position and checks if it is in the score position, if it is, it gives points to the player and destroys itself. If it goes past the score position, it destroys itself without giving points to the player.

    public void SongBeatHappened()
    {
        noteRow++;
        transform.position = rhythmGrid.GetPositionInGrid(noteColumn, noteRow);
        
        if (noteRow == rhythmGrid.ScoreRow) // check for the row that gives the score
        {
            // give points to the player
            Debug.Log("Note is in the score zone");
        }
        
        else if (noteRow > rhythmGrid.ScoreRow) // check if the note has gone past the score row
        {
            // note missed, destroy without giving points
            Debug.Log("Note missed! No points");
            Destroy(gameObject);
        }
    }
    
    public void NoteHit()
    {
        Debug.Log("Note Hit!");
        Destroy(gameObject);
    }
    
    
}
