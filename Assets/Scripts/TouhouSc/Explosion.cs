using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;

public class Explosion : MonoBehaviour
{
    private Stopwatch stopwatch;
    // Start is called before the first frame update
    void Start()//initialisation de l horloge
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()//l explosion disparait apres 1s
    {
        if (stopwatch.ElapsedMilliseconds > 1000)
            Destroy(gameObject);
    }
}
