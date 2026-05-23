using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    //Vector2 _noteSpawnPos;
    [SerializeField] float spawnTimer = 1.2f;

    [SerializeField] private RhythmGrid rhythmGrid;
   
    [SerializeField] GameObject notePrefab;
    [SerializeField] private int startingRow;

    void Start()
    {
        StartCoroutine(SpawnNoteCoroutine());
    }
    

    IEnumerator SpawnNoteCoroutine()
    {

        //choose a column to spawn
        //instantiate a note prefab on that column
        //get the note script from the object that was instantiated
        //tell the note where to go, starting row where is it and the grid is rhythm grid
        //wait spawntimer or beat timer in seconds

        while (true)
        {
            
            int randomColumn = Random.Range(1, 5);
            GameObject spawnedNoteGameObject = Instantiate(notePrefab, transform.position, Quaternion.identity);
            Note spawnedNoteScript = spawnedNoteGameObject.GetComponent<Note>();
            
            if (spawnedNoteScript == null)
            {
                yield break; // Exit the coroutine if the Note script is missing IMPORTANT!!
            }
            
            
            spawnedNoteScript.WhereIsTheNote(randomColumn, startingRow, rhythmGrid);
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
}
