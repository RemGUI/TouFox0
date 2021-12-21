using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using System.Threading;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Gameclear GameOverScript;
    public Gameclear Gameclear;

    [SerializeField] Slider healthBar;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gamePauseUI;

    private int maxHealth = 10;
    private int health = 10;
    private int score = 0;
    private Stopwatch stopwatch;

    public static bool gamePaused = false;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()//initialisation horloge
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }
    void OnDisable()//pour passer les score et highscore d'un scene a une autre
    {
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.GetInt("score")>PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
    }

    public void OnDisable2()//pour passer les score et highscore d'un scene a une autre
    {
        PlayerPrefs.SetInt("scores", score);
        if (PlayerPrefs.GetInt("scores") > PlayerPrefs.GetInt("highScores"))
            PlayerPrefs.SetInt("highScores", PlayerPrefs.GetInt("scores"));
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(0);
        AddScore(0);
        if (stopwatch.ElapsedMilliseconds > 300)//pour eviter les problemes de buffer
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (gamePaused)
                    Resume();
                else
                    Pause();
            }
            stopwatch.Restart();
        }
    }
    void Resume()//reprendre
    {
        gamePauseUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()//pause
    {
        gamePauseUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void TakeDamage(int damageValue)//barre d'hp et call gameover si 0 hp
    {
        health -= damageValue;

        healthBar.value = health / (float)maxHealth;
        if (health <= 0)
        {
            if ("TouhouProject" == SceneManager.GetActiveScene().name)
            {
                OnDisable();
                GameOver();
            }
            if("Foxproject" == SceneManager.GetActiveScene().name)
            {
                OnDisable2();
                GameOver2();
            }
        }   
    }
    public void BossDead()// boss mort = victoire
    {
        GameClear();
    }
    void GameOver()//defeat
    {
        StartCoroutine(LoadGameOver());
    }

    void GameClear()//win
    {
        StartCoroutine(LoadGameClear());
    }

    IEnumerator LoadGameOver()//attente 1s avant de charger defeat
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    IEnumerator LoadGameClear()
    {
        yield return new WaitForSeconds(1f);//attente 1s avant de charger win
        SceneManager.LoadScene(4);
    }
    public void GameOver2()//fonction pour l'affichage de l'ecran de game over
    {

        GameOverScript.Setup(score);
    }
    public void Victory()//fonction pour l'affichage de l'ecran de Victory
    {

        Gameclear.Setup(score);
    }
    public void AddScore(int bonusScore)//ajout de score
    {
        score += bonusScore;
        scoreText.text = score.ToString();
    }
}