using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Player;
    public float ZOffset;
    public float YOffset; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if(Player)
        {
            ZOffset = transform.position.z - Player.position.z;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPosition = Player.transform.position + Vector3.forward * ZOffset;
        TargetPosition.y += YOffset;

        Vector3 Velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, 0.1f);


    }
}
