using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;

    public int HP = 100;
    public float InvincibilityTimer = 1f;
    public float WalkSpeed = 300.5f;
    public float JumpForce = 500f;
    public SpriteRenderer PlayerSprite;

    public bool isWalkLeft = false;

    public GameObject Bullet;
    public bool CanAttack;

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

        if(!isAlive)
        {
            return;
        }

        HP = Mathf.Clamp(HP, 0, 100);

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
        GetComponent<Rigidbody>().AddForce(Direction * WalkSpeed * Time.deltaTime, ForceMode.VelocityChange);

        GetComponent<Rigidbody>().AddForce(Direction * WalkSpeed * Time.deltaTime * 2);
            if(Direction.x < 0)
            {
                PlayerSprite.flipX = true;
            isWalkLeft = true;
            }
            else if (Direction.x > 0)
            {
                PlayerSprite.flipX = false;
            isWalkLeft = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(Direction.x));
       // anim.SetFloat("Attack");


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce); 
        }
    

        if(Input.GetMouseButtonDown(0))
        {
            GameObject NewBullte = Instantiate(Bullet, transform.position, Quaternion.identity);

            NewBullte.GetComponent<BulletController>().isMovingLeft = isWalkLeft;
        }


        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckRange, groundLayer);
       Debug.DrawRay(transform.position, Vector3.up * groundCheckRange);

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            StartCoroutine("TakeDamage", 10);
        }
    }

    IEnumerator TakeDamage(int damage)
    {
        Debug.Log("WW");
        HP -= damage; // HP = HP - damage;
        gameObject.layer = 11; // PlayerInvin
        PlayerSprite.color = Color.gray;

        yield return new WaitForSeconds(InvincibilityTimer);

        gameObject.layer = 10;
        PlayerSprite.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUp")
        {
            HP += 50;
            // Ammo += ?;
            Destroy(other.gameObject);
        }
    }

    public void RecieveDamage(int Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject); //1.cause Error
            anim.SetTrigger("Death"); // 2. if you have
            isAlive = false;

            PlayerSprite.color = Color.clear; // 3.1
            gameObject.SetActive(false); // 3.2

        } else
        {
            StartCoroutine("TakeDamage", 10);
        }
    }
}
