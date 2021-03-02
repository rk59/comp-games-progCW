using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    private LevelComplete refCompleteLevel;

    public float currentScore = 0f;
    public float coinValue = 10f;
    public float maxScore = 50f;

    public float currentXP = 0f;
    public float killValue = 5f;

    public float currentPlayerHealth = 100f;
    public float enemyDealtDamage = 25f;

    public GameObject completeLevelUI;
    public GameObject failedLevelUI;

    [SerializeField] Text scoreCounter;
    [SerializeField] Text XPCounter;
    [SerializeField] Text playerHealthCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;
        currentXP = 0f;
        currentPlayerHealth = 100f;
        UpdateScore();
        UpdateXP();
        UpdateHealth();
        completeLevelUI.SetActive(false);
        failedLevelUI.SetActive(false);

    }

    public void AddScore()
    {
        currentScore += coinValue;
        UpdateScore();
        if (currentScore >= maxScore)
        {
            CompleteLevel();
        }
    }
    public void AddXP()
    {
        currentXP += killValue;
        UpdateXP();
    }

    public void DecHealth()
    {
        currentPlayerHealth -= enemyDealtDamage;
        UpdateHealth();

        if( currentPlayerHealth <= 0)
        {
            EndGame();
        }
    }


    public void UpdateScore()
    {        
        scoreCounter.text = currentScore.ToString("0");
    }
    public void UpdateXP()
    {
        XPCounter.text = currentXP.ToString("0");
    }

    public void UpdateHealth()
    {
        playerHealthCounter.text = currentPlayerHealth.ToString("0");
    }

    public void EndGame()
    {
        failedLevelUI.SetActive(true);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("CallNextLevel", 3);
        
        // add next level script
    }
    private void CallNextLevel()
    {
        refCompleteLevel.LoadNextLevel();
    }

}
   

