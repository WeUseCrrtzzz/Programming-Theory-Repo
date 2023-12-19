using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyScript
{

    public GameObject bullet;

    public float delay = 3f;
    float timer;
    private bool canShoot = true;

    private PlayerScript playerScript;

    

    void Update() 
    {

        // Calculate Distance To Player

        float distanceToPlayer = Vector3.Distance (gameObject.transform.position, player.transform.position);

        // Movement

        if (distanceToPlayer >= 5) 
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        // Death

        if (health <= 0) 
        {
            DeathParticle();
            playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
            playerScript.MoneyDrop(25, transform.position);
            Destroy(gameObject);
        }


        // Rotate Towards Player
        
        Vector3 targetDirection = player.transform.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);


        if (distanceToPlayer <= 7.5 && canShoot)
		{
            Fire();
        }



        timer += Time.deltaTime;
        if (timer >= delay)
        {
            canShoot = true;
        }

        void Fire()
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
            canShoot = false;
        }


    }



    
        


}