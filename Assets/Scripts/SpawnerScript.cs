using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public float spawnDelay = 10f;
    float spawnTimer;
    private bool canSpawn = true;
    public int health = 25;
    private GameObject player;

    public GameObject[] enemyArray;

    public GameObject hitParticle;
    public GameObject breakParticle;

    public float maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance (gameObject.transform.position, player.transform.position);

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            canSpawn = true;
        }

        if (canSpawn && distanceToPlayer <= 10) 
        {
            
            int randomEnemy = Random.Range(0, enemyArray.Length);

            Instantiate(enemyArray[randomEnemy], transform.position, transform.rotation);
            spawnTimer = 0;
            canSpawn = false;
            
        }

        if (health <= 0) 
        {
            Destroy(gameObject);
            Instantiate(breakParticle, gameObject.transform.position, gameObject.transform.rotation);
        }

        



    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            health -= 1;
            Destroy(collision.gameObject);
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
