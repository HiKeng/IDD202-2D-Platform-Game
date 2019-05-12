using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_BossRoom : MonoBehaviour
{

    public GameObject Boss;
    public GameObject UI_Boss;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<GameObject>();
        UI_Boss = GameObject.Find("Boss_UI").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Enter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && other.tag == "Player")
        {
            Enter();
        }
    }

    void Enter()
    {
        Boss.SetActive(true);
        UI_Boss.SetActive(true);
        Destroy(gameObject);
    }
}
