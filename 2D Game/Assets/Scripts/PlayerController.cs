using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int HP = 100;
    public float WalkSpeed = 300.5f;
    public float JumpForce = 500f;
    public SpriteRenderer PlayerSprite;

    public Animator anim;

    public Transform GroundChecker;

    public bool isGrounded;
    public float groundCheckRange = 1f;
    public LayerMask groundLayer;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.A))
        //{
        //    GetComponent<Rigidbody>().AddForce(Vector3.right * -WalkSpeed * Time.deltaTime);
        //    PlayerSprite.flipX = true;
        //    if(isGrounded == true)
        //    {
        //        anim.SetBool("isWalk", true);
        //    }

        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    GetComponent<Rigidbody>().AddForce(Vector3.right * WalkSpeed * Time.deltaTime);
        //    PlayerSprite.flipX = false;

        //    if (isGrounded == true)
        //    {
        //        anim.SetBool("isWalk", true);
        //    }
        //}

        //if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        //{
        //    anim.SetBool("isWalk", false);
        //}

        Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);



        GetComponent<Rigidbody>().AddForce(Direction * WalkSpeed * Time.deltaTime);
            if(Direction.x < 0)
            {
                PlayerSprite.flipX = true;
            }
            else if (Direction.x > 0)
            {
                PlayerSprite.flipX = false;
            }

        anim.SetFloat("Speed", Mathf.Abs(Direction.x));
       // anim.SetFloat("Attack");


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce); 
        }

        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckRange, groundLayer);
        //Debug.DrawRay(transform.position, Vector3.up * groundCheckRange);

        isGrounded = Physics.CheckSphere(GroundChecker.position, groundCheckRange, groundLayer);

        anim.SetBool("Grounded", isGrounded);

        if(isGrounded)
        {
          //  GetComponentInChildren<SpriteRenderer>().color = Color.white;

        } else
        {
            //GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
