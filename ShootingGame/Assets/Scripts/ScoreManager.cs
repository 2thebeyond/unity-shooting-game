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

    void Start()
    {
        currentScoreUI.text = "�������� : 0";

        // �ְ��� �ҷ�����
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "�ְ����� : " + bestScore;
    }

    void Update()
    {
        
    }

    public void SetScore(int value)
    {
        // ���������� value �Ҵ�
        currentScore = value;
        currentScoreUI.text = "�������� : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "�ְ��� : " + bestScore;

            // �ְ��� ����
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    // �������� ��ȯ
    public int GetScore()
    {
        return currentScore;
    }
}
