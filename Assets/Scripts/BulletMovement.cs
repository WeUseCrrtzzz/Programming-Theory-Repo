using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    private GameObject player;
    private EnemyScript enemyScript;
    public Vector3 awayFromContact;
    private CrateScript crateScript;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

        if (distance >= 1000) 
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

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.HitParticle();
            Destroy(gameObject);
            enemyScript.health -= damage;
        }

        if (collision.gameObject.CompareTag("Crate")) 
        {
            crateScript = collision.gameObject.GetComponent<CrateScript>();
            crateScript.HitParticle();
            Destroy(gameObject);
            crateScript.health -= damage;
        }
    


    }





}
