using System.Collections;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    Vector2 noteSpawnPos;
    [SerializeField] float spawnTimer = 1.2f;
    [SerializeField] GameObject notePrefab;

    void Start()
    {
        StartCoroutine(spawnNoteCoroutine());
    }

    IEnumerator spawnNoteCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            float multiplier = i * 2;
            noteSpawnPos = new Vector2(transform.position.x + multiplier, transform.position.y);
            Instantiate(notePrefab, noteSpawnPos, Quaternion.identity);   
            
            yield return new WaitForSeconds(spawnTimer);
        }
        
    }
}
