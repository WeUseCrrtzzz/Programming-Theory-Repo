using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealthScript : MonoBehaviour
{

    private SpawnerScript spawnerScript;



    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = gameObject.GetComponentInParent<SpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((spawnerScript.health / spawnerScript.maxHealth ), 0.25f, 0.01f);
    }
}
