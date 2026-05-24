using System.Collections;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    //Vector2 _noteSpawnPos;
    [SerializeField] float spawnTimer = 1.2f;

    [SerializeField] private RhythmGrid rhythmGrid;
    [SerializeField] GameObject notePrefab;
    [SerializeField] private PlayerHpManager playerHpManager;
    [SerializeField] private int startingRow;
    
    [SerializeField] private bool canSpawnNotes;

    void Start()
    {
        StartCoroutine(SpawnNoteCoroutine());
    }

    private IEnumerator SpawnNoteCoroutine()
    {

        while (true)
        {
            if(!canSpawnNotes)
            {
                yield return null;
                continue;
            }
            
            int randomColumn = Random.Range(0, 4);
            GameObject spawnedNoteGameObject = Instantiate(notePrefab, transform.position, Quaternion.identity);
            Note spawnedNoteScript = spawnedNoteGameObject.GetComponent<Note>();
            
            if (spawnedNoteScript == null)
            {
                yield break; // Exit the coroutine if the Note script is missing IMPORTANT!!
            }
            
            
            spawnedNoteScript.WhereIsTheNote(randomColumn, startingRow, rhythmGrid, playerHpManager);
            
            //when a note spawnes, it chooses a random column, a not type between tap or hold
            // if the note is a hold note, choose random hold duration from 1 to 4 beats
            // make the note be that type and have the correct hold duration if it's a hold note, then spawn it in the correct column and row, then wait for the spawn timer to spawn the next note
            
            int randomNoteType = Random.Range(0, 2);
            if (randomNoteType == 0)
            {
                spawnedNoteScript.SetNoteType(Note.NoteType.Tap);
            }
            else
            {
                spawnedNoteScript.SetNoteType(Note.NoteType.Hold);

                int randomHoldBeats = Random.Range(1, 5);
                spawnedNoteScript.SetHoldBeats(randomHoldBeats);
                
            }

            yield return new WaitForSeconds(spawnTimer);
            
        } 
        
        
        
        // for (int i = 0; i < 5; i++)
        // {
        //     float multiplier = i * 2;
        //     _noteSpawnPos = new Vector2(transform.position.x + multiplier, transform.position.y);
        //     Instantiate(notePrefab, _noteSpawnPos, Quaternion.identity);   
        //     
        //     yield return new WaitForSeconds(spawnTimer);
        // }
        
    }
    
    public void StartSpawning()
    {
        canSpawnNotes = true;
    }
        
    public void StopSpawning()
    {
        canSpawnNotes = false;
    }
    
    
    
}
