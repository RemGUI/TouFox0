using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipscrept : MonoBehaviour//le scrip du personnage
{   
    private void Awake()
    {
        //m_MainCamera = transform.position;
    }
    public int life = 3;
    private float m_VerticalSpeed = 1.6f;
    private float m_Horizontalspeed = 1.2f;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void boost()//fonction pour déclanché l'animation barrel roll
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("doBarrelRoll");
        }

    }
    void PlayerControl()//fonction pour faire se déplacé le joueur
    {
        Vector3 viewPos = transform.position;
        if (Input.GetKey(KeyCode.Z))//pour le faire monté le perso
        {
            if(viewPos.y < 2)
                transform.Translate(Vector3.up * m_VerticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))//pour le faire déscendre le perso
        {
            if(viewPos.y > -2)
                transform.Translate(Vector3.down * m_VerticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))//pour le faire allé le perso a droite
        {
            if(viewPos.x < 2.5)
                transform.Translate(Vector3.left * m_Horizontalspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))//pour le faire allé le perso a gauche
        {
            if(viewPos.x > -2.5)
                transform.Translate(Vector3.right * m_Horizontalspeed * Time.deltaTime);
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
        boost();
    }
    void OnCollisionEnter(Collision Coll)//pour géré la perte de vie du perso ainsi que sa mort
    {
        life = life - 1;
        if(life == 0)
        {
            Destroy(gameObject);
        }
        GameManager.instance.TakeDamage(1);//relié au GameManager pour actualisé la barre de vie
    }
}
