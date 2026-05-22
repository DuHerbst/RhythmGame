using UnityEngine;

public class NoteScript : MonoBehaviour
{        
    GridManager gridManager;
    Vector2Int notePosition;

    void Awake()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
    }
    
    void Update()
    {
        notePosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        gridManager.cellPositions.Add(notePosition);

        if (notePosition == gridManager.cellPositions[0])
        {
            Debug.Log("yOU ARE INSIDE BUDDY!");       
        }
        else if (notePosition == gridManager.cellPositions[1])
        {
            Debug.Log("Fuck you!!!");
            
        }
        else if (notePosition == gridManager.cellPositions[2])
        {
            Debug.Log("I'm going to kill myself!");
        }
        else if (notePosition == gridManager.cellPositions[3])
        {
            Debug.Log("That's fair but you gotta try harder loser!!"); 
        }
        else if (notePosition == gridManager.cellPositions[4])
        {
                Debug.Log("Dude you are actually better than I thought! But don't get too excited..");
        }
        
    }
}
