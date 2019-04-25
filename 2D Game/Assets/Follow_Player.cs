using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{

    public bool isFollowPlayer;

    public Transform Player;
    public float ZOffset;
    public float YOffset;



    // Start is called before the first frame update
    void Start()
    {
        isFollowPlayer = true;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Player)
        {
            ZOffset = transform.position.z - Player.position.z;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowPlayer)
        {
            Vector3 TargetPosition = Player.transform.position + Vector3.forward * ZOffset;
            TargetPosition.y += YOffset;

            Vector3 Velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider Pan)
    {
        if (Pan.gameObject.CompareTag("Player"))
        {
            isFollowPlayer = false;

        }
    }
}
