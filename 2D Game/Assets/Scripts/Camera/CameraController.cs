using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool isFollowPlayer;

    public Transform Player;
    public float ZOffset;
    public float YOffset;
    public float XOffset;

    public Collider Pan1;
    public GameObject PlayerCol;

    public Transform[] Panned_postion;

    public bool panned;

    public int cameraType;
    public int cameraNumber;

    // Start is called before the first frame update
    void Start()
    {
        cameraNumber = 0;
        cameraType = 0;

        isFollowPlayer = true;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
       //Pan1 = GameObject.Find("Camera_Pan").GetComponent<Collider>();

        if(Player)
        {
            ZOffset = transform.position.z - Player.position.z;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (cameraType == 0)
        {
            Follow();
        }

        if(cameraType == 1)
        {
            Panned();
        }

        if (cameraType == 2)
        {
            Lock();
        }



    }

    void Follow()
    {
        Vector3 TargetPosition = Player.transform.position + Vector3.forward * ZOffset;
        TargetPosition.y += YOffset;

        TargetPosition.x += XOffset;

        Vector3 Velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, 0.1f);
    }



    void Panned()
    {
        transform.position = Vector3.Lerp(transform.position, Panned_postion[cameraNumber].position, Time.deltaTime);
    }




    void Lock()
    {
        Vector3 TargetPosition = Player.transform.position + Vector3.forward * ZOffset;

        TargetPosition.y += YOffset;

        TargetPosition.x = transform.position.x;

        Vector3 Velocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, 0.1f);
       
    }


}
