using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    private EnemyScript enemyScript;



    // Start is called before the first frame update
    void Start()
    {
        enemyScript = gameObject.GetComponentInParent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((enemyScript.health / enemyScript.maxHealth ), 0.25f, 0.01f);
    }
}
