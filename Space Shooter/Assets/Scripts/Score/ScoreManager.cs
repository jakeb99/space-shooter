using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<int> OnScoreUpdate;

    [SerializeField] private int totalScore;
    [SerializeField] public int highestScore;

    [SerializeField] private List<ScoreData> allScores = new List<ScoreData>();
    [SerializeField] private ScoreData latestScore;


    [Header("Score Values")]
    [SerializeField] private int scorePerRegularEnemy;
    [SerializeField] private int scorePerBossEnemy;
    [SerializeField] private int scorePerCoin;
    [SerializeField] private int scorePerPowerUp;

    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        player.HealthValue.OnDied.AddListener(RegisterScore);
        highestScore = PlayerPrefs.GetInt("Highscore"); // note we should not use player prefs for persistant data we care about losing

        // get latest score from player prefs (note defs not best practice to use player prefs for this type of stuff)
        string latestScoreInJson = PlayerPrefs.GetString("LatestScore");
        latestScore = JsonUtility.FromJson<ScoreData>(latestScoreInJson);
    }

    public void IncreaseScore(EScoreType scoreType)
    {
        switch(scoreType)
        {
            case EScoreType.RegularEnemyKilled:
                totalScore += scorePerRegularEnemy; break;
            case EScoreType.BossEnemyKilled: 
                totalScore += scorePerBossEnemy; break;
            case EScoreType.CoinCollected:
                totalScore += scorePerCoin; break;
            case EScoreType.PowerUpCollected:
                totalScore += scorePerPowerUp; break;
            default:
                // if no score type then default to reg enemy score
                totalScore += scorePerRegularEnemy; break;
        }

        // call on score event to let listeners know the score is updated
        OnScoreUpdate.Invoke(totalScore);
    }

    public void IncreaseScoreByAmount(int amount)
    {
        totalScore += amount;

        // call on score event to let listeners know the score is updated
        OnScoreUpdate.Invoke(totalScore);
    }

    private void RegisterScore()
    {
        latestScore = new ScoreData("playerName", totalScore);
        
        // convert new score to json and save to player prefs
        string latestScoreJson = JsonUtility.ToJson(latestScore);
        PlayerPrefs.SetString("Latestscore", latestScoreJson);

        if (totalScore > highestScore)
        {
            highestScore = totalScore;
            PlayerPrefs.SetInt("Highscore", highestScore);
            PlayerPrefs.SetString("Username", "Jake");
        }
    }
}
