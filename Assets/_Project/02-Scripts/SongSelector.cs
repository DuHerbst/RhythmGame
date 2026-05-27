using UnityEngine;
using System.Collections;

/// <summary>
/// script to get a song selector to have more than 1 song
/// </summary>
public class SongSelector : MonoBehaviour
{
    
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private AudioClip[] songs; // Array to hold the different songs
    
    [SerializeField] private NoteSpawner noteSpawner;
    
    [SerializeField] private float noteStartDelay;
    
    //when player clicks one of the buttons a 3,2,1 counter will start so the song starts playing
    //when song starts playing, notes will start apearing
    
    public void SelectSong(int songIndex)
    {
        if (songIndex >= 0 && songIndex < songs.Length)
        {
            StartCoroutine(StartSongRoutine(songs[songIndex]));
        }
        
        else
        {
            Debug.LogError("Invalid song index: " + songIndex);
        }
    }
    
    private IEnumerator StartSongRoutine(AudioClip selectedSong)
    {
        
        noteSpawner.StopSpawning(); // stop spawning notes while the countdown is happening
        
        yield return new WaitForSeconds(3f);
        
        musicManager.StartSong(selectedSong);
        yield return new WaitForSeconds(noteStartDelay);
        noteSpawner.StartSpawning();
    }
    
}
