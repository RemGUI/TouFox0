using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;

public class Player : MonoBehaviour
{
    GameObject shoot1;
    public GameObject bullet;
    public GameObject explosion;
    [SerializeField] float m_VerticalSpeed = 2.0f;
    [SerializeField] float m_HorizontalSpeed = 3.0f;
    [SerializeField] private int health = 2;
    [SerializeField] private float fireRate = 200;
    private Stopwatch stopwatch;

    void Awake()
    {
        shoot1 = transform.Find("shoot1").gameObject;
    }
    void PlayerControl()//player movement 
    {
        if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.up * m_VerticalSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * m_VerticalSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.left * m_HorizontalSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * m_HorizontalSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            Shoot();
    }

    public void Damage()//degat prit par le joueur 
    {
        health--;
        if(health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        GameManager.instance.TakeDamage(1);
    }

    void Shoot()//creation de la balle
    {
        if (stopwatch.ElapsedMilliseconds > fireRate)
        {
            Instantiate(bullet, shoot1.transform.position, Quaternion.identity);
            stopwatch.Restart();
        }
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
        PlayerControl();

    }
}
