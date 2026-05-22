using UnityEngine;

/// <summary>
/// This script manages the bpm, and the timing of the music in the game
/// </summary>
public class MusicManager : MonoBehaviour
{
    
    [SerializeField] private int bpm = 120; // how fast the song is
    [SerializeField] private int currentBeat; // counts how many beats have happened since the last one
    [SerializeField] private float secondsPerBeat = 0.5f; // how long a beat lasts. 60 seconds divided by bpm
    
    [SerializeField] private float beatTimer; // timers always need decimals, always floats-- counts the time until the next beat
    [SerializeField] private Note musicNote;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //calculate the seconds per beat using 60 divided by the bpm
        secondsPerBeat = 60f / bpm;
        beatTimer = secondsPerBeat; //timer is being set!
        Debug.Log("please give me the right beat!!" + secondsPerBeat);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        beatTimer -= Time.deltaTime;
        if (beatTimer <= 0)
        {
            currentBeat++;
            Debug.Log("The current beat is " + currentBeat);

            if (musicNote != null)
            {
                musicNote.SongBeatHappened();
            }

            beatTimer = secondsPerBeat;
        }
        
        
    }
    
    
    
}
