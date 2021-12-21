using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_f : MonoBehaviour//script pour géré les bullet de notre player
{
    public GameObject Projectil;
    public int Force = 600;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;//création de la bullet 
            Bullet.GetComponent < Rigidbody>().velocity = Vector3.forward    * Force * Time.deltaTime ;//pour que la bullet avance
            Destroy(Bullet, 2f);//pour détruire la bullet au bout d'un moment
        }

    }
}
