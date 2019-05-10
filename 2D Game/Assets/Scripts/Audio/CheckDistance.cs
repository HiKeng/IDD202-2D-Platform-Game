using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    public GameObject Player;
    public GameObject Audio;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Audio = GameObject.FindGameObjectWithTag("Audio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
