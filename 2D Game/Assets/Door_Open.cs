using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{

    Animation anim;

    public float Time;
    public bool Tagged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Tagged)
        {
            // Time += Time.deltaTime;
            transform.position += Vector3.up;
        }
    }

    private void OnTriggerEnter(Collider Door)
    {
        if(Door.CompareTag("Player"))
        {
            Tagged = true;
        }
    }
}
