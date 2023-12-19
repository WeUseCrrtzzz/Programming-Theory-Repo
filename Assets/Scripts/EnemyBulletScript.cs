using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public float deleteDelay = 3f;
    float deleteTimer;
    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deleteTimer += Time.deltaTime;
        if (deleteTimer >= deleteDelay)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision) 
    {

        if (collision.gameObject.CompareTag("Obstacles")) 
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player")) 
        {
            playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (playerScript.canDamage)
            {
                playerScript.Damage(5);
                playerScript.PlayerHit();
            }
            playerScript.KnockBack(gameObject, -25);
            Destroy(gameObject);
            
        }
    


    }
}
