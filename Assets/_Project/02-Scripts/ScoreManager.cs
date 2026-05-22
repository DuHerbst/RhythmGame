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
    [SerializeField] private PlayerHpManager playerHealth;
    [SerializeField] private int noteRow; // this is the row that the note is currently in, we need to get this from the note script, maybe make it public and reference it here?
    //score number
    [SerializeField] public int totalScore;
    [SerializeField] public int perfectScore;
    [SerializeField] public int goodScore;
    [SerializeField] public int fairScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
    }
    

    public void UpdateScore(Note pianoNote)
    {

        int noteRow = pianoNote.NoteRow; // get the row from the note script, we need to reference the note script here, maybe make it public and reference it here?
        
        if (noteRow == rhythmGrid.PerfectRow)
        {
            // give 5 points
            totalScore += perfectScore;
            Debug.Log("Perfect! +5 points");
        }
        else if (noteRow == rhythmGrid.GoodRow)
        {
            // give 3 points
            totalScore += goodScore;
            Debug.Log("Good! +3 points");
        }
        else if (noteRow == rhythmGrid.FairRow)
        {
            // give 1 point
            totalScore += fairScore;
            Debug.Log("Fair! +1 point");
        }
        
        else if (noteRow < rhythmGrid.FairRow)
        {
            // note missed, reduce player hp by 1
            Debug.Log("Missed! -1 HP");
            totalScore -= perfectScore;
            playerHealth.MissedNote(1);
        }
        
        scoreText.text = "Score: " + totalScore;
        
    }
    
    
    
}