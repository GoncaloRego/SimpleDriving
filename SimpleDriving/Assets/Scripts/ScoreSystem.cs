using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;
    [SerializeField] private int scoreMultiplier;
    public const string HighestScoreKey = "HighestScore";

    // Update is called once per frame
    void Update()
    {
        score += scoreMultiplier * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        int currentHighestScore = PlayerPrefs.GetInt(HighestScoreKey, 0);

        if (score > currentHighestScore)
        {
            PlayerPrefs.SetInt(HighestScoreKey, Mathf.FloorToInt(score));
        }
    }
}
