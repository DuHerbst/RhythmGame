using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this script talks to the hp canvas to reduce the hp of the player when they fail to click a piano key on time on the spaces that are successful on the grid
/// </summary>

public class PlayerHPManager : MonoBehaviour
{

    public int maxChances = 3;
    public int currentChances;

    public Image[] hearts; //an array to hold all the heart images on the scene
    
    //AUDIO
    [SerializeField] private AudioSource damageAudioSource;
    [SerializeField] private AudioClip damageSound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentChances = maxChances;
        UpdateHealthUI();
        
    }


    public void MissedNote(int damageAmount)
    {
        currentChances -= damageAmount;
        UpdateHealthUI();

        if (currentChances <= 0)
        {
            currentChances = 0; // health cant go lower than 0
            GameManager.Instance.GameOver();
            
        }
    }

    private void UpdateHealthUI()
    {
        for (int arrayIndex = 0; arrayIndex < hearts.Length; arrayIndex++)
        {
            if (arrayIndex < currentChances)
            {
                hearts[arrayIndex].color = Color.lightSeaGreen;
            }

            else
            {
                hearts[arrayIndex].color = Color.red;
            }
            
        }
    }
    
}
