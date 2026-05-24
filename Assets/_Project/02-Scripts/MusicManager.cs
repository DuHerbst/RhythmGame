using UnityEngine;

/// <summary>
/// This script manages the bpm, and the timing of the music in the game
/// needs and event that announces to the notes when a beat happens so they can move down the grid
/// the bpm will always be at 120 for now
/// 
/// </summary>
public class MusicManager : MonoBehaviour
{
    
    [SerializeField] private int bpm = 120; // how fast the song is
    [SerializeField] private int currentBeat; // counts how many beats have happened since the last one
    [SerializeField] private float secondsPerBeat = 0.5f; // how long a beat lasts. 60 seconds divided by bpm
    
    [SerializeField] private float beatTimer; // timers always need decimals, always floats-- counts the time until the next beat
    public static event System.Action OnBeat; // other scripts will subscribe to this event 
    
    //AUDIO MANAGEMENT
    [SerializeField] private bool isSongPlaying;
    
    [SerializeField] private AudioSource audioSource;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //calculate the seconds per beat using 60 divided by the bpm
        secondsPerBeat = 60f / bpm;
        beatTimer = secondsPerBeat; //timer is being set!
        //StartSong();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isSongPlaying) // if the song is not playing then stop
        {
            return;
        }
       
        beatTimer -= Time.deltaTime;
        if (beatTimer <= 0)
        {
            currentBeat++;
            AnnounceBeat(); 
            beatTimer = secondsPerBeat;
            
        }
        
        
    }

    public void StartSong(AudioClip song)
    {
        
        audioSource.clip = song;
        audioSource.Play();
        
        beatTimer = secondsPerBeat;
        isSongPlaying = true;
        
    }

    public void StopSong()
    {
        isSongPlaying = false;
    }
    
    //can this be an event bus? Like everytime theres a beat -- when the beat happens, the music manager can announce to all the notes that a beat has happened
    // notes move down the grid after listenign to the beat


    private void AnnounceBeat()
    {
        OnBeat?.Invoke();
    }
}
