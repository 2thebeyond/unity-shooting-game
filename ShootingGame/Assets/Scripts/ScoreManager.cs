using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public static ScoreManager Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentScoreUI.text = "현재점수 : 0";

        // 최고기록 불러오기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    void Update()
    {
        
    }

    public int Score
    {
        get
        {
            // 현재점수 반환
            return currentScore;
        }

        set
        {
            // 현재점수에 value 할당
            currentScore = value;
            currentScoreUI.text = "현재점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고기록 : " + bestScore;

                // 최고기록 저장
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
