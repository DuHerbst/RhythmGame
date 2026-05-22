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
    
    //VISUALS
    [SerializeField] private Material normalColour;
    [SerializeField] private Material perfectColour;
    [SerializeField] private Material goodColour;
    [SerializeField] private Material fairColour;
    [SerializeField] private Material missedColour;
    private MeshRenderer _noteMeshRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this note has to ask the rhythm grid where in the world is my position on the grid
        //move to that position
        _noteMeshRenderer = GetComponent<MeshRenderer>();
        _noteMeshRenderer.material = normalColour;
        transform.position = rhythmGrid.GetPositionInGrid(noteColumn, noteRow);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Observer Note receives that announcement and decreases its location on the rows. Communicates with the grid where should it go
    // Note moves to the new position and checks if it is in the score position, if it is, it gives points to the player and destroys itself. If it goes past the score position, it destroys itself without giving points to the player.

    public bool CanBePlayed() // more direct - the note itself knows when it can be played
    {
        if (noteRow == rhythmGrid.PerfectRow || noteRow == rhythmGrid.GoodRow || noteRow == rhythmGrid.FairRow)
            
        {
            return true;
        }
        
        return false;
        
    }
    public void SongBeatHappened()
    {
        noteRow++;
        transform.position = rhythmGrid.GetPositionInGrid(noteColumn, noteRow);
        
        if (noteRow == rhythmGrid.PerfectRow)
        {
            _noteMeshRenderer.material = perfectColour; // change the colour of the note to indicate that it is in the score zone
        }

        if (noteRow == rhythmGrid.GoodRow)
        {
            _noteMeshRenderer.material = goodColour;
        }

        if (noteRow == rhythmGrid.FairRow)
        {
            _noteMeshRenderer.material = fairColour;
        }
        
        else if (noteRow > rhythmGrid.PerfectRow) // check if the note has gone past the score row
        {
            // note missed, destroy without giving points
            _noteMeshRenderer.material = missedColour;
            Debug.Log("Note missed! No points");
            Destroy(gameObject);
        }
    }
    
    public void PianoKeyHit()
    {
        Destroy(gameObject);
    }
    
    
}
