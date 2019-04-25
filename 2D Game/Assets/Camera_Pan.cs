using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Pan : MonoBehaviour
{
    CameraController CC;

    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Pan)
    {
        if(Pan.CompareTag("Player"))
        {
            Debug.Log("Hello");

            CC.isFollowPlayer = false;
            CC.panned = true;
        }
    }

    private void OnTriggerExit(Collider Pan)
    {
        if (Pan.CompareTag("Player"))
        {
            Debug.Log("Hello2");

            CC.isFollowPlayer = true;
            CC.panned = false;
        }
    }
}
