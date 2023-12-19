using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{

    public bool yes = false;
    public float number = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yes == true) 
        {
            number += 1;
            //gameObject.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            gameObject.GetComponent<Light>().range += 0.01f;
        }

        if (yes == false) 
        {
            number -= 1;
            //gameObject.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            gameObject.GetComponent<Light>().range -= 0.01f;
        }

        if (number >= 500) 
        {
            yes = false;
        }

        if (number <= 0) 
        {
            yes = true;
        }
    }
}
