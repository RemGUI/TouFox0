using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rbbl;
    public float m_VerticalSpeed = 7.5f;
    /*private float angle = 0f;
    private Vector2 movementSP;*/
    //[SerializeField] private float moveRate = 100;
    public float rotation;
    private Stopwatch stopwatch;

    void Awake()
    {
        rbbl = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//collision avec l enemy ajout de score + destruction de la balle + damage to enemy
        {
            GameManager.instance.AddScore(1000);
            collision.gameObject.GetComponent<Enemy>().Damage();
            Shine();
        }
        else if (collision.gameObject.tag == "Edge")//destruction de la balle des qu elle est en dehors du terrain
        {
            Shine();
        }
        else if (collision.gameObject.tag == "Players")//collision avec le joueur destruction de la balle + damage to player
        {
            collision.gameObject.GetComponent<Player>().Damage();
            Shine();
        }
        else if (collision.gameObject.tag == "Boss")//collision avec l enemy ajout de score + destruction de la balle + damage to enemy
        {
            GameManager.instance.AddScore(10000);
            collision.gameObject.GetComponent<Boss>().Damage();
            Shine();
        }
    }

    /*void SpiralPatern() //une des forces n'est pas assez consequente donc a retravailler
{

if (stopwatch.ElapsedMilliseconds > moveRate)
{
    float spX = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
    float spY = transform.position.y - Mathf.Sin((angle * Mathf.PI) / 180f);
    Vector3 movementSPV = new Vector3(spX, spY, 0f);
    movementSP = (movementSPV - transform.position).normalized;
    stopwatch.Restart();
    angle += 10;
}
transform.Translate(movementSP * m_VerticalSpeed * Time.deltaTime);
transform.Translate(Vector3.down * m_VerticalSpeed * 0.50f * Time.deltaTime); 


}*/
    void Shine()//destruction balle
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        if (gameObject.tag == "BulletB")
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        //InvokeRepeating("SpiralPatern", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "BulletP")
            transform.Translate(Vector3.up * m_VerticalSpeed * Time.deltaTime);
        
        if (gameObject.tag == "BulletE")
            transform.Translate(Vector3.down * m_VerticalSpeed * 0.50f * Time.deltaTime);
        
        if (gameObject.tag == "BulletB")
            transform.Translate(Vector3.down * m_VerticalSpeed * Time.deltaTime);
    }
}
