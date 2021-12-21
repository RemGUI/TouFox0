using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class E_mouvement : MonoBehaviour//script pour crée le patern du boss
{
    Stopwatch patern;
    public int i;
    private float speed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
            i = 2;
            patern = new Stopwatch();

            patern.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 2)//pour faire allée le boss de gauche a droite
        {
            if (patern.ElapsedMilliseconds < 2500.0f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                i = 1;
                patern.Restart();
            }
        }
        if (i == 1)
        {
            if (patern.ElapsedMilliseconds < 5000.0f)
            {

                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                i = 0;
                patern.Restart();
            }
        }
        if (i == 0)
        {
            if (patern.ElapsedMilliseconds < 5000.0f)
            {

                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                i = 1;
                patern.Restart();
            }
        }
    }
}
