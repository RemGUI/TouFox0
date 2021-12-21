using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;

public class Boss : MonoBehaviour
{
    GameObject shoot1;
    public GameObject bullet;
    [SerializeField] private float m_VerticalSpeed = 1.0f;
    [SerializeField] private float m_HorizontalSpeed = 2.0f;
    [SerializeField] private float health = 1000;
    [SerializeField] private float fireRate = 1000;
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;
    [SerializeField] private int nbBullet;
    [SerializeField] private float m_VerticalBSpeed = 1.0f;
    float[] rotations;
    private Stopwatch stopwatch;
    private int i = 1;

    void Awake()
    {
        shoot1 = transform.Find("shoot1").gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Players")//collision avec le joueur
        {
            collision.gameObject.GetComponent<Player>().Damage();
            Damage();
        }
    }
    public void Damage()//perte de point de vie un par 1
    {
        health--;
        if (health == 0)
        {
            Shine();
            GameManager.instance.BossDead();
        }
    }
    public float[] DistributedRotations()//initialisation des différents degrées de tir
    {
        for (int j = 0; j < nbBullet; j++)
        {
            var fraction = (float)j / ((float)nbBullet - 1);
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[j] = fractionOfDifference + minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    void Shoot()//creation de la balle avec ses parametres
    {
        GameObject[] spawnBullet = new GameObject[nbBullet];
        for (int k = 0; k < nbBullet; k++)
        {
            spawnBullet[k] = Instantiate(bullet, shoot1.transform.position, Quaternion.identity);
            var b = spawnBullet[k].GetComponent<Bullet>();
            b.rotation = rotations[k];
            b.m_VerticalSpeed = m_VerticalBSpeed;
        }
    }
    void Shine()//destruction du boss
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        rotations = new float[nbBullet];
        DistributedRotations();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 3)
            transform.Translate(Vector3.down * m_VerticalSpeed * Time.deltaTime);
        else if (i == 1)
        {
            transform.Translate(Vector3.left * m_HorizontalSpeed * Time.deltaTime);
            if (this.transform.position.x < -7)
                i = 2;
        }
        else if (i == 2)
        {
            transform.Translate(Vector3.right * m_HorizontalSpeed * Time.deltaTime);
            if (this.transform.position.x > 7)
                i = 1;
        }
        if (stopwatch.ElapsedMilliseconds > fireRate)
        {
            Shoot();
            stopwatch.Restart();
        }
    }
}
