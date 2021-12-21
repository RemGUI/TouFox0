using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Quit()//pas utiliser
    {
        Application.Quit();
    }
    public void Start()//chargement scene jeu touhou
    {
        SceneManager.LoadScene(1);
    }

    public void Screen()//chargement menu
    {
        SceneManager.LoadScene(0);
    }
    public void Credit()//chargement credit
    {
        SceneManager.LoadScene(3);
    }
    public void Setting()//chargement setting
    {
        SceneManager.LoadScene(5);
    }

    public void Fox()//chargement setting
    {
        SceneManager.LoadScene(6);
    }

}
