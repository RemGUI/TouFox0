using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int playerScore;
    private int highScore;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text hScoreText;
    void OnEnable()//recuperation des highscore et score pour les ecran de victoire et defeat
    {
        playerScore = PlayerPrefs.GetInt("score");
        highScore = PlayerPrefs.GetInt("highScore");
    }
    // Update is called once per frame
    void Update()//affichage des scores
    {
        scoreText.text = playerScore.ToString();
        hScoreText.text = highScore.ToString();
    }
}
