using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private Keyboard _keyboard;
    [SerializeField] private Note pianoNote;
    [SerializeField] private RhythmGrid rhythmGrid;
    
    private void Start()
    {
        _keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (_keyboard != null) // check for null always
        {
            
            if (_keyboard.aKey.wasPressedThisFrame)
            {
                PressPianoKey(0);
            }
        
            if (_keyboard.sKey.wasPressedThisFrame)
            {
                PressPianoKey(1);
            }

            if (_keyboard.dKey.wasPressedThisFrame)
            {
                PressPianoKey(2);
            }
        
            if (_keyboard.fKey.wasPressedThisFrame)
            {
                PressPianoKey(3);
            }
            
        }
        
    }

    private void PressPianoKey(int column)
    {

        if (pianoNote == null)
        {
            Debug.Log("There is no note to hit right now");
            return;
        }

        if (pianoNote.NoteColumn != column)
        {
            Debug.Log("Wrong lane");
            return;
        }
        
        
        Debug.Log("note in the correct lane now");
        

        if (pianoNote.NoteRow == rhythmGrid.ScoreRow)
        {
            Debug.Log("Note on the correct row");
            pianoNote.NoteHit(); // call the method from the note script to destroy the note and give points to the player
            return;
        }
        
        
        Debug.Log("Not on the score row");
        
    }
    

}
