using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;

public class Enemy : MonoBehaviour
{
    //Rigidbody2D rben;
    GameObject shoot1;
    public GameObject bullet;
    public GameObject explosion;
    [SerializeField] private float m_VerticalSpeed = 1.0f;
    [SerializeField] private float m_HorizontalSpeed;
    [SerializeField] private float fireRate = 1000;
    [SerializeField] private float health;
    private Stopwatch stopwatch;

    void Awake()
    {
        shoot1 = transform.Find("shoot1").gameObject;//position du tir
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Players")//la collilision avec le joueur engendre la mort de l enemy
        {
            collision.gameObject.GetComponent<Player>().Damage();
            Shine();
        }
        if (collision.gameObject.tag == "EdgeEnemy")//destruction de l'enemy une fois dehors du cadre
        {
            Shine();
        }
    }

    public void Damage() //perds des point de vie 1 par 1
    {
        health--;
        if(health == 0)
        {
            Shine();
        }
    }
    void Shoot()//cree des tirs à une certaine cadence
    {
        if (stopwatch.ElapsedMilliseconds > fireRate)
        {
            Instantiate(bullet, shoot1.transform.position, Quaternion.identity);
            stopwatch.Restart();
        }
    }
    void Shine()//destroy enemy
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * m_VerticalSpeed * Time.deltaTime);
        Shoot();
    }
}
