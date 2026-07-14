using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    //[SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject gameOverPanel;

    // Awake() Called when this gameobject is enabled in the scene
    private void Awake()
    {
        ToggleGameOverUI(false);
        // Check Singleton
        // If there is no other instance of this script in the scene...
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy any duplicates of this script
            Destroy(gameObject);
        }
    } 

     public void ToggleGameOverUI(bool flag)
    {
        gameOverPanel.SetActive(flag);
    }

    public void UpdateScore(int score)
    {
        // Update the score text object with the given score
        //scoreText.text = $"Score: {score}";
    }
}
