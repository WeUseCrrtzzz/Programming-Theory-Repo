using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyScript
{

    private PlayerScript playerScript;

    void Update() 
    {

        
        // Movement

        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

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

        
    }
        
}
