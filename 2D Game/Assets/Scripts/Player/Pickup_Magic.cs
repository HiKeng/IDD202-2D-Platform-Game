using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Magic : MonoBehaviour
{

    public bool playerIsEnter;

    public GameObject Player;
    public PlayerController PC;

    public int MPAdd;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<GameObject>();
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerIsEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerIsEnter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PickMagic();
            }
        }

    }

    private void OnTriggerEnter(Collider magic)
    {
        if(magic.CompareTag("Player"))
        {
            playerIsEnter = true;
            Debug.Log("Enter");
        }

        
    }

    private void OnTriggerExit(Collider magic)
    {
        if (magic.CompareTag("Player"))
        {
            playerIsEnter = false;
            Debug.Log("Exit");
        }

        
    }

    void PickMagic()
    {
        Debug.Log("Pick Item!");
        PC.MP += MPAdd;
        Destroy(gameObject);
    }
}
