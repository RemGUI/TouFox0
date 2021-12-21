using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float rate;
    [SerializeField] private int wave = 1;
    [SerializeField] private int spawnRate;
    public GameObject[] enemies;
    private Stopwatch stopwatch;
    private int i, r, spw;

    void Patern(int c)
    {
        
        if (stopwatch.ElapsedMilliseconds > spawnRate && wave < 9 && c == 0)//horizontal patern
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length-1)], new Vector3(i-2+spw, 6, 0), Quaternion.identity);
            }
            stopwatch.Restart();
            r = UnityEngine.Random.Range(0, 2);
            spw = UnityEngine.Random.Range(-7, 7);
            wave++;
        }
        if (stopwatch.ElapsedMilliseconds > spawnRate && wave < 9 && c == 1)//v spawn patern
        {
            if (i == 0)
            {
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length - 1)], new Vector3(0 + spw, 6, 0), Quaternion.identity);
                i++;
            }
            else if (stopwatch.ElapsedMilliseconds > spawnRate + 500 && i == 1)
            {
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length - 1)], new Vector3(1 + spw, 6, 0), Quaternion.identity);
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length - 1)], new Vector3(-1 + spw, 6, 0), Quaternion.identity);
                i++;
            }
            else if (stopwatch.ElapsedMilliseconds > spawnRate + 1000)
            {
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length - 1)], new Vector3(2 + spw, 6, 0), Quaternion.identity);
                Instantiate(enemies[(int)UnityEngine.Random.Range(0, enemies.Length - 1)], new Vector3(-2 + spw, 6, 0), Quaternion.identity);
                stopwatch.Restart();
                r = UnityEngine.Random.Range(0, 2);
                spw = UnityEngine.Random.Range(-7, 7);
                i = 0;
                wave++;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
        stopwatch = new Stopwatch();
        stopwatch.Start();
        i = 0;
        r = UnityEngine.Random.Range(0, 2);
        spw = UnityEngine.Random.Range(-7, 7);
    }

    void SpawnEnemy()//spawn enemy puis le boss ap la 9e vague
    {
        Patern(r);
        if(stopwatch.ElapsedMilliseconds > spawnRate && wave == 9)
        {
            Instantiate(enemies[(int)UnityEngine.Random.Range(4, 4)], new Vector3(0, 6, 0), Quaternion.identity);
            wave++;
        }
    }
}
