using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour//script pour faire apparaitre le screen de victoire une fois le boss mort
{
    // Start is called before the first frame update
    public Text pointsText;
    public Text highText;
    private int highScore;

    void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("highScores");
    }
    public void Setup(int score)
    {
        gameObject.SetActive(true);//pour faire apparaitre le screen
        pointsText.text = "    Score "+ score.ToString() + " POINTS";//pour affiché le score du jeu
        highText.text = "HighScore " + highScore.ToString() + " POINTS";
    }
    public void RestartButton()//fonction pour faire fonctioné le bouton restart du l'ecran victory 
    {
        SceneManager.LoadScene("Foxproject");//pour restart le jeu
    }
    public void ExitButton()//fonction pour faire fonctioné le bouton main menu du l'ecran victory 
    {
        //SceneManager.LoadScene("MainMenu");//pour revenir au menu du jeu
    }
}
