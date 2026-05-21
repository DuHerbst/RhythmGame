using UnityEngine;

/// <summary>
/// This script manages the bpm, and the timing of the music in the game
/// </summary>
public class MusicManager : MonoBehaviour
{
    // the bpm for the music has to be 120 bpm 
    
    [SerializeField] private int bpm = 120;
    [SerializeField] private int currentBeat;
    // [SerializeField] private float secondsPerBeat = 0.5;
    
    [SerializeField] private int beatTimer;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Debug.Log("Tick "  + Time.time);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // add time.delta time to sync with beat timer?
        
    }
}
