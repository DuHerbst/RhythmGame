using TMPro;
using UnityEngine;


/// <summary>
/// this script will dictate what score to give the player when they play a note on the grid
/// if in row 6 give 5 points, if its on row 5 it will give 3 points, if its on row 4 it will give 1 point, if its on row 3 or below it will count as fail and will take hte players hp down by 1
/// </summary>
/// 
public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] private RhythmGrid rhythmGrid;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Note noteLocation;
    [SerializeField] private int noteRow; // this is the row that the note is currently in, we need to get this from the note script, maybe make it public and reference it here?
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
    }
    
    void Update()
    {
        noteRow = noteLocation.NoteRow; // get the current row of the note from the Note script
    }

    public void UpdateScore()
    {
        
        if (noteRow == rhythmGrid.PerfectRow)
        {
            // give 5 points
            Debug.Log("Perfect! +5 points");
            Destroy(gameObject);
        }
        else if (noteRow == rhythmGrid.GoodRow)
        {
            // give 3 points
            Debug.Log("Good! +3 points");
            Destroy(gameObject);
        }
        if (noteRow == rhythmGrid.FairRow)
        {
            // give 1 point
            Debug.Log("Fair! +1 point");
            Destroy(gameObject);
        }
        
        else if (noteRow < rhythmGrid.FairRow)
        {
            // fail, take 1 hp
            Debug.Log("Missed! -1 HP");
            Destroy(gameObject);
        }
    }
    
}