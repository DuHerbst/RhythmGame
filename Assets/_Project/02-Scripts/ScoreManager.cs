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
    [SerializeField] private int earlyPenalty = 10; // penalty for hitting a note too early

    //particle reference
    [SerializeField] ParticleSystem vfxPrefab;
    
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
            totalScore += perfectScore;

            //particles implementation
            if (vfxPrefab != null)
            {
                vfxPrefab.Play();        
            }
        }
        else if (noteRow == rhythmGrid.GoodRow)
        {
            totalScore += goodScore;
           
        }
        else if (noteRow == rhythmGrid.FairRow)
        {
            totalScore += fairScore;
        }
        
        else if (noteRow < rhythmGrid.FairRow)
        {
            totalScore -= earlyPenalty; // if the player hits the note too early, they get a penalty to their score
            playerHealth.MissedNote(1);
        }
        
        scoreText.text = "Score: " + totalScore;
        
    }
    
    
    
}