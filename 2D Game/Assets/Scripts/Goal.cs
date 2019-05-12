using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    public int sceneNumber;

    public string[] SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if(gameObject && player.tag == "Player")
        {
            SceneManager.LoadScene(SceneName[sceneNumber]);
        }
    }
}
