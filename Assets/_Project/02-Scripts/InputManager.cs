using UnityEngine;
using UnityEngine.InputSystem;



public class InputManager : MonoBehaviour
{
    //private Keyboard _keyboard;
    [SerializeField] private RhythmGrid rhythmGrid;
    [SerializeField] private ScoreManager scoreManager;
    
    //NewInputActions reference
    NewInputActions _newInputActions;

    void Awake()
    {
        //grabbing the instance
        _newInputActions = new NewInputActions();
    }

    /*
    private void Start()
    {
        _keyboard = Keyboard.current;
    }
     */
    
    void OnEnable()
    {
        // subscribing to the input events
        _newInputActions.Enable();
        
        _newInputActions.Player.AKey.performed += KeyPressedA;
        _newInputActions.Player.DKey.performed += KeyPressedD;
        _newInputActions.Player.GKey.performed += KeyPressedG;
        _newInputActions.Player.JKey.performed += KeyPressedJ;
        
    }

    void OnDisable()
    {
        // Unsubscribing from input events ondisable
        _newInputActions.Disable();
        
        _newInputActions.Player.AKey.performed -= KeyPressedA;
        _newInputActions.Player.DKey.performed -= KeyPressedD;
        _newInputActions.Player.GKey.performed -= KeyPressedG;
        _newInputActions.Player.JKey.performed -= KeyPressedJ;
    }

    /*
     private void Update()
    {
        if (_keyboard != null) // check for null always
        {

            if (_keyboard.aKey.wasPressedThisFrame)
            {
                PressPianoKey(0);
            }

            if (_keyboard.dKey.wasPressedThisFrame)
            {
                PressPianoKey(1);
            }

            if (_keyboard.gKey.wasPressedThisFrame)
            {
                PressPianoKey(2);
            }

            if (_keyboard.jKey.wasPressedThisFrame)
            {
                PressPianoKey(3);
            }

        } 
        
    }
     */

    private void PressPianoKey(int column)
    {

        Note[] activeNotes = FindObjectsByType<Note>(FindObjectsSortMode.None); // Find all active notes in the scene, we need to check if any of them are in the column that was pressed and if they are in the perfect, good or fair row, then we can update the score accordingly

        Note bestNote = null;

        foreach (Note note in activeNotes)
            
        {
            if (note.NoteColumn != column)
            {
                continue;
            }

            if (bestNote == null)
            {

                bestNote = note;

            }

            else if
                (note.NoteRow >
                 bestNote.NoteRow) // check if the note is closer to the perfect row than the current best note, we want to check the note that is closest to the perfect row to give the most accurate score
            {
                bestNote = note;
            }

        }

        if (bestNote == null)
        {
            return;
        }
        
        scoreManager.UpdateScore(bestNote); // update the score based on the note that was hit, we need to make sure that we are updating the score based on the note that was hit and not just any note in the column

        if (bestNote.CanBePlayed()) // check if the note can be played, if it is in the perfect, good or fair row
        {
            if (bestNote.IsHoldNote())
            {
                bestNote.StartHoldNote();
                Debug.Log("Hold note started!");
            }
            
            else
            {
                Destroy(bestNote.gameObject); // destroy the note if it can be played, we need to make sure that the note is destroyed after it is played to prevent it from being scored multiple times
            }
        }
    }
    
    //keypressed methods

    private void KeyPressedA(InputAction.CallbackContext context)
    {
        //Debug.Log("Key pressed A");
        PressPianoKey(0);
    }

    private void KeyPressedD(InputAction.CallbackContext context)
    {
        //Debug.Log("Key pressed D");
        PressPianoKey(1);
    }

    private void KeyPressedG(InputAction.CallbackContext context)
    {
        //Debug.Log("Key pressed G");
        PressPianoKey(2);
    }
    private void KeyPressedJ(InputAction.CallbackContext context)
    {
        //Debug.Log("Key pressed J");
        PressPianoKey(3);
    }


}
