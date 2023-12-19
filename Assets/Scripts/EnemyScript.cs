using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float health = 10f;
    public float speed = 10f;
    public float rotationSpeed = 1.0f;
    public GameObject hitParticle;
    public GameObject deathParticle;
    public GameObject player;

    public float maxHealth = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DamageEnemy() 
    {
        health -= 1;
    }



    public void HitParticle() 
    {
        Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void DeathParticle() 
    {
        Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
    }
}



