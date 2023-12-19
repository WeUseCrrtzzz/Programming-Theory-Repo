using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart() 
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (sceneBuildIndex:scene);
    }

}
