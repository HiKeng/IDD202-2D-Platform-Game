using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool isFollowPlayer;

    public Transform Player;
    public float ZOffset;
    public float YOffset;

    public Collider Pan1;
    public GameObject PlayerCol;

    public Transform Panned1_postion;

    public bool panned;

    // Start is called before the first frame update
    void Start()
    {
        isFollowPlayer = true;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Pan1 = GameObject.Find("Camera_Pan").GetComponent<Collider>();

        if(Player)
        {
            ZOffset = transform.position.z - Player.position.z;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowPlayer)
        {
            Vector3 TargetPosition = Player.transform.position + Vector3.forward * ZOffset;
            TargetPosition.y += YOffset;

            Vector3 Velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, 0.1f);
        }

        if(panned)
        {
            Panned1();
        }

    }

    public void Panned1()
    {
        transform.position = Vector3.Lerp(transform.position, Panned1_postion.position, Time.deltaTime);
    }


}
