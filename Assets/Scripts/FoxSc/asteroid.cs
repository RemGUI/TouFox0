using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class asteroid : MonoBehaviour//script pour les deux astéroide
{
    private float speed = 1f;
    [SerializeField] private int live;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 15f);//pour que quand l'astéroide dépop quand il est plus dans l'écran
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * speed * Time.deltaTime);//pour déplacé les astéroide vers le personnage
    }
    void OnCollisionEnter(Collision Coll)//pour la vie des asstéroides
    {
        live--;
        if(live == 0)
            Destroy(gameObject);
    }
}

