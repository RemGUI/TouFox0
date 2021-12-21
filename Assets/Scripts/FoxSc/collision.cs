using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision Coll)//script pour géré les diférentes colision et ajouté du score
    {
        if (Coll.gameObject.tag == "asteroid")//pour les gros astéroides
        {
            GameManager.instance.AddScore(50);
        }
        else if (Coll.gameObject.tag == "asteroid1")//pour les petit astéroides
        {
            GameManager.instance.AddScore(20);
        }
        else if (Coll.gameObject.tag == "boss")//pour le boss
        {
            GameManager.instance.AddScore(20);
        }

        Destroy(gameObject);
    }
}
