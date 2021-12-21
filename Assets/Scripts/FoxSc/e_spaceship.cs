using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class e_spaceship : MonoBehaviour//script pour géré le boss
{
    public int e_life = 1;
    public GameObject Projectil;
    public int Force = 600;



    Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();

        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch.ElapsedMilliseconds > 1000.0f)
        {
            GameObject Bullet = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;//pour faire tiré le boss
            Bullet.GetComponent<Rigidbody>().velocity = Vector3.back * Force * Time.deltaTime;
            Destroy(Bullet, 4f);
            stopwatch.Restart();
        }
    }
    void OnCollisionEnter(Collision Coll)//pour la vie du boss
    {
        e_life = e_life - 1;
        if (e_life <= 0)
        {
            GameManager.instance.OnDisable2();
            Destroy(gameObject);
            GameManager.instance.Victory();
        }
    }
}
