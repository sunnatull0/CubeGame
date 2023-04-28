using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public GameObject deathPanel;
    private AudioSource audioSource;
    
    public SpeedController speedController;
    public ObstacleManager obstacleManager;
    public EnemySpawner enemySpawner;
    public PlayerMovement playerMovement;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI dieRecordText;
    public TextMeshProUGUI recordText;
    
    [HideInInspector]public static float record;
    [HideInInspector]public float score;
    [SerializeField]private float scoreSpeed;

    bool isDead = false;
    bool isDone1 = false;
    bool isDone2 = false;

    private void Start()
    {
        speedController.ResetSpeed();
        audioSource = GetComponent<AudioSource>();
        record = PlayerPrefs.GetFloat("Record");
    }

    void Update()
    {
        dieRecordText.text = "RECORD: " + (int)record;
        
        recordText.text = "RECORD: " + (int)record;
        scoreText.text = "SCORE: " + (int)score;
        score += scoreSpeed * Time.deltaTime;
        if(score > record)
        {
            PlayerPrefs.SetFloat("Record", score);
            record = score;
        }

        if(score >= 500f && !isDone1)
        {
            speedController.ChangeSpeed(5f);
            obstacleManager.ChangeDelay(0.6f);
            enemySpawner.ChangeDelayEnemy(0.6f);
            playerMovement.ChangeReloadTime(0.25f);
            isDone1 = true;
        }
        else if (score >= 1000f && !isDone2)
        {
            speedController.ChangeSpeed(5f);
            obstacleManager.ChangeDelay(0.4f);
            enemySpawner.ChangeDelayEnemy(0.4f);
            playerMovement.ChangeReloadTime(0.25f);
            isDone2 = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDead == true)
        {
            ReloadScene();
        }
    }

    public void GameOver()
    {
        //YandexGame.NewLeaderboardScores("leader", (int)record);
        deathPanel.SetActive(true);
        isDead = true;
        Time.timeScale = 0;
    }

    void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }
    
}
