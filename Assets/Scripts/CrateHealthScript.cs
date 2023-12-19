using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHealthScript : MonoBehaviour
{

    private CrateScript crateScript;

    // Start is called before the first frame update
    void Start()
    {
        crateScript = gameObject.GetComponentInParent<CrateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((crateScript.health / crateScript.maxHealth ), 0.25f, 0.01f);
    }
}
