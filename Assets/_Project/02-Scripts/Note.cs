using UnityEngine;

/// <summary>
/// This script handles the logic of the note and how it communicates it's location on the grid
/// Each note has its own type and can be tap once or held
/// each note has to know what it is so the spawner doenst overlap notes when one is held
/// </summary>

public class Note : MonoBehaviour

{

    public enum NoteType
    {
        Tap,
        Hold,
    }
    
    [SerializeField] private NoteType noteType;
    [SerializeField] private int holdBeats; // how many beats some notes can be held
    private bool _isBeingHeld;
    
    [SerializeField] private RhythmGrid rhythmGrid; // Reference to the RhythmGrid script
    [SerializeField] private PlayerHpManager playerHealth; // Reference to the PlayerHpManager script to reduce health if note is missed
    
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

    private void OnEnable()
    {
        MusicManager.OnBeat += SongBeatHappened; // subscribe to the event when the note is enabled
    }

    private void OnDisable()
    {
        MusicManager.OnBeat -= SongBeatHappened; // unsubscribe to the event when the note is disabled to prevent memory leaks
    }
    
    public void SongBeatHappened() // needs to be subscribed to the event 
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

            if (playerHealth != null)
            {
                
                playerHealth.MissedNote(1); // reduce player health by 1 if the note is missed

            }
            
            
            Destroy(gameObject);
        }
    }
    
    public void WhereIsTheNote(int column, int row, RhythmGrid grid, PlayerHpManager health) //locates the position of where the note will spawn always same row, different column depending on key?

    {
        
        noteColumn =  column;
        noteRow = row;
        rhythmGrid = grid;
        playerHealth = health; // find the player health manager in the scene to reduce health if note is missed
        
        transform.position = rhythmGrid.GetPositionInGrid(noteColumn, noteRow);
        
    }  
    
    public void PianoKeyHit()
    {
        Destroy(gameObject);
    }

    public void SetNoteType(NoteType type)
    {
        noteType = type;
        Debug.Log(noteType);
    }
    
    public void SetHoldBeats(int beats)
    {
        holdBeats = beats;

        transform.localScale = new Vector3(
            transform.localScale.x,
            beats,
            transform.localScale.z
        );
    }

    public int GetHoldBeats()
    {
        return holdBeats;
    }

    public bool IsHoldNote()
    {
        return noteType == NoteType.Hold;
    }
    
    public void StartHoldNote()
    {
        _isBeingHeld = true;
        Debug.Log("started holding a note!");
    }
    
    
}
