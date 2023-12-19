using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{

    public int health = 10;
    public GameObject hitParticle;
    public GameObject breakParticle;
    public GameObject[] pickups;

    public float maxHealth = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            BreakParticle();

            int randomPickup = Random.Range(0, pickups.Length);

            Instantiate(pickups[randomPickup], transform.position, transform.rotation);

            Destroy(gameObject);
            
        }
    }

    public void HitParticle() 
    {
        Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void BreakParticle() 
    {
        Instantiate(breakParticle, gameObject.transform.position, gameObject.transform.rotation);
    }

}
