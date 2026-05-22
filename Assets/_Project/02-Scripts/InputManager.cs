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
                PressPianoKey(1);
                Debug.Log("Key A Pressed");
            }
        
            if (_keyboard.dKey.wasPressedThisFrame)
            {
                PressPianoKey(2);
                Debug.Log("Key D Pressed");
            }

            if (_keyboard.gKey.wasPressedThisFrame)
            {
                PressPianoKey(3);
                Debug.Log("Key G Pressed");
            }
        
            if (_keyboard.jKey.wasPressedThisFrame)
            {
                PressPianoKey(4);
                Debug.Log("Key J Pressed");
            }
            
        }
        
    }

    private void PressPianoKey(int column)
    {

        if (pianoNote == null)
        {
            return;
        }

        if (pianoNote.NoteColumn != column)
        {
            return;
        }
        

        if (pianoNote.NoteRow == rhythmGrid.PerfectRow || pianoNote.NoteRow == rhythmGrid.GoodRow || pianoNote.NoteRow == rhythmGrid.FairRow) // check if the note is in the correct row to give points
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // find the score manager in the scene
            scoreManager.UpdateScore(); // call the method to update the score based on the note's
            
            
            pianoNote.PianoKeyHit(); // call the method from the note script to destroy the note and give points to the player
            return; // exit the method after hitting the note
        }
        
    }
    

}
