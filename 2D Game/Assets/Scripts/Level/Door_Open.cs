using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{

    public PlayerController PC;

    public Animator anim;

    public float Time;
    public bool Tagged;
    public bool unTagged;

    public BoxCollider BC;

    public int opened;



    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>();
        anim = gameObject.GetComponent<Animator>();

        BC = gameObject.GetComponent<BoxCollider>();

       // anim.SetBool("DoorOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Tagged)
        {
            // Time += Time.deltaTime;
            //transform.position += Vector3.up;
            anim.SetBool("DoorOpen", true);
            anim.SetBool("DoorClose", false);

        }

        if(unTagged)
        {
            anim.SetBool("DoorOpen", false);
            anim.SetBool("DoorClose", true);
        }
    }

    private void OnTriggerEnter(Collider Door)
    {
        if(Door.CompareTag("Player") && PC.KeyItem != 0)
        {
            Tagged = true;
            unTagged = false;
            opened++;

        } else
        {
            //Debug.Log("Key is missing");
        }
    }

    private void OnTriggerExit(Collider Door)
    {
        if (Door.CompareTag("Player") && PC.KeyItem != 0)
        {
            Tagged = false;
            unTagged = true;

            //Destroy(BC);
        }

    }
}
