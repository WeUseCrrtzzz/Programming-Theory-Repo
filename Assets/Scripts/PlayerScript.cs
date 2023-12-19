using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody playerRb;


    public float bulletSpeed = 500f;
    public GameObject bullet;


    public float delay = 3f;
    float timer;
    private bool canShoot = true;

    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;

    public int health = 100;

    public float damageDelay = 3f;
    float damageTimer;
    public bool canDamage = true;

    public float speedDelay = 10f;
    float speedTimer;

    public float fireRateDelay = 10f;
    float fireRateTimer;



    public Slider healthBar;

    public GameObject hitParticle;

    public GameObject loseOverlay;
    public GameObject winOverlay;

    public int weapon = 1;

    public GameObject healParticle;

    public Material playerMaterial;
    public Material playerSpeedMaterial;

    public float fireRate = 1;

    private BulletMovement bulletScript;

    public float enemyCount;
    public float spawnerCount;

    public GameObject winPortal;

    public GameObject fireRateParticles;

    //private bool hasWon = false;

    private GameManager gameManager;

    public GameObject moneyPrefab;

    public GameObject coinParticlePrefab;



   void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        healthBar = GameObject.Find("HealthBarBorder").GetComponent<Slider>();
        loseOverlay.SetActive(false);
        winOverlay.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }





    void Update() 
    {

        // Player Movement

        var dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _rb.velocity = dir * _speed;



        healthBar.value = health;


        
        if (health <= 0) 
        {
            loseOverlay.SetActive(true);
        }

        if (health > 100) 
        {
            health = 100;
        }

        if (_speed == 10)
        {
            gameObject.GetComponent<MeshRenderer>().material = playerSpeedMaterial;
        }
        else 
        {
            gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
        }

        if (fireRate == 1.5) 
        {
            fireRateParticles.SetActive(true);
        }
        else 
        {
            fireRateParticles.SetActive(false);
        }

        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        spawnerCount = FindObjectsOfType<SpawnerScript>().Length;

        if (spawnerCount == 0 && enemyCount == 0) 
        {
            winPortal.SetActive(true);
        }



        

    }




    void FixedUpdate()
    {

        //Rotate Towards Mouse

		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
		

		float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
		

		transform.rotation =  Quaternion.Euler (new Vector3(0f,-angle,0f));



        if (Input.GetKey("mouse 0") && canShoot)
		{
            Fire(weapon);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && weapon < 5) // forward
        {
            weapon ++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && weapon > 1) // backwards
        {
            weapon --;
        }



        timer += Time.deltaTime * fireRate;
        if (timer >= delay)
        {
            canShoot = true;
        }

        damageTimer += Time.deltaTime;
        if (damageTimer >= damageDelay)
        {
            canDamage = true;
        }

        speedTimer += Time.deltaTime;
        if (speedTimer >= speedDelay && _speed == 10)
        {
            _speed = 6;
        }

        fireRateTimer += Time.deltaTime;
        if (fireRateTimer >= fireRateDelay && fireRate == 1.5)
        {
            fireRate = 1;
        }



        void Fire(int number)
        {

            if (number == 1) 
            {
                Instantiate(bullet, transform.position, transform.rotation);
                timer = 0;
                canShoot = false;
            }

            if (number == 2) 
            {
                Instantiate(bullet, transform.position, transform.rotation);
                timer = 0.25f;
                canShoot = false;
            }

            if (number == 3) 
            {
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-90, 90)));
                timer = 0.4f;
                canShoot = false;
            }

            if (number == 4) 
            {
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-45, 45)));
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-45, 45)));
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-45, 45)));
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-45, 45)));
                Instantiate(bullet, transform.position, transform.rotation * new Quaternion(0, Random.Range(-5, 5), 0, Random.Range(-45, 45)));
                timer = -1f;
                canShoot = false;
            }

            if (number == 5) 
            {
                Instantiate(bullet, transform.position, transform.rotation);
                timer = -2.5f;
                canShoot = false;
            }
            
            

        }


        
	}


        float AngleBetweenPoints(Vector3 a, Vector3 b)
         { return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg; }

    
    void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.CompareTag("Obstacles")) 
        {

        }

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (canDamage)
            {
                Damage(10);
            }
            KnockBack(collision.gameObject, 100);
        }

    }


    void OnTriggerEnter(Collider collision) 
    {

            if (collision.gameObject.CompareTag("Health") && health < 100) 
        {
            Instantiate(healParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            health += 10;
        }

        if (collision.gameObject.CompareTag("Speed") && _speed == 6) 
        {
            Instantiate(healParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            speedTimer = 0;
            _speed = 10;
        }

        if (collision.gameObject.CompareTag("FireRate") && fireRate == 1) 
        {
            Instantiate(healParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            fireRateTimer = 0;
            fireRate = 1.5f;
        }

        if (collision.gameObject.CompareTag("Finish")) 
        {
            Win();
        }

        if (collision.gameObject.CompareTag("Coin")) 
        {
            Instantiate(coinParticlePrefab, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            gameManager.money += 25;
        }

    }


    public void Damage(int Damage) 
    {
        health -= Damage;
        damageTimer = 0;
        canDamage = false;
        Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void KnockBack(GameObject Object, float strength) 
    {
        Vector3 awayFromContact = transform.position - Object.transform.position;
        playerRb.AddForce(awayFromContact * strength, ForceMode.Impulse);

    }

    public void PlayerHit() 
    {
        //Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void Win() 
    {
        winOverlay.SetActive(true);
        //hasWon = true;
    }

    public void MoneyDrop(int Value, Vector3 Position) 
    {
        Instantiate(moneyPrefab, Position, transform.rotation);
    } 



}
