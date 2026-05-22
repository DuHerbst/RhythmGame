using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{        
    GridManager gridManager;
    Vector2Int notePosition;
    float timer;
    public float stepDelay = 2f;
    

    void Awake()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
    }

   
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= stepDelay)
        {
            noteMovement();
            timer = 0;
            CheckGridLocation();
        }
        
    }
    
    void CheckGridLocation()
    {
        int gridIndex = gridManager.cellPositions.IndexOf(notePosition);

        if (gridIndex == 0)
        {
            Debug.Log("yOU ARE INSIDE BUDDY!");       
        }
        else if (gridIndex == 1)
        {
            Debug.Log("Keep going!");
        }
        else if (gridIndex == 2)
        {
            Debug.Log("Halfway there!");
        }
        else if (gridIndex == 3)
        {
            Debug.Log("That's fair but you gotta try harder!!"); 
        }
        else if (gridIndex == 4)
        {
            Debug.Log("Dude you are actually better than I thought! But don't get too excited..");
        }
        else
        {
            Debug.Log("You are outside the grid!");
        }
    }

    void noteMovement()
    {
        transform.Translate(0, -1, 0);

        
        notePosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));

        if (notePosition.y <= -5)
        {
            Destroy(gameObject);    
        }
    }
}
