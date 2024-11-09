using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour

{
    public static ScoreManager Instance;

 
    public GameObject endPanel;

    private int score;

    [SerializeField] TMP_Text scorePanel;




    private void Awake()
    {
        // Ensure there is only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the ScoreManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate if one already exists
        }
    }
    public void AddScore() {
        score++;
        scorePanel.text = score.ToString();

    }
    public void EndGame()
    {
        endPanel.SetActive(true);
        gameObject.GetComponent<SaveScore>().SetScore(score);
        Time.timeScale = 0f;
      
    }

    }
