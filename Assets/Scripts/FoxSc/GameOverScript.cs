using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour//script pour faire apparaitre le screen de game Over une fois le perso mort
{
    
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);//pour faire apparaitre le screen
        pointsText.text = score.ToString() + " POINTS";//pour affiché le score du jeu
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
