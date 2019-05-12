using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;

    public int HP; 
    public int MaxHP = 100;
    public float InvincibilityTimer = 1f;
    public float WalkSpeed = 300.5f;
    public float JumpForce = 500f;
    public float DownForce = 600f;
    public SpriteRenderer PlayerSprite;
    public Transform Player;

    public float MP;
    public int MaxMP;

    public bool isWalkLeft = false;

    public GameObject Bullet;
    public GameObject SpecialBullet;
    public bool CanAttack;

    public Animator anim;

    public Transform GroundChecker;

    public bool isGrounded;
    public float groundCheckRange = 1f;
    public LayerMask groundLayer;

    public bool isWalking;

    public Transform Gun_Position;
    private float Fire_CooldownCount;
    public float Fire_Cooldown;

    public bool isCharging = false;
    public bool ChargeFull = false;
    public float MaxChargeTime;
    public float ChargeTimeCount;

    public float MPRegenSpeed;

    public bool IsWon;
    public bool IsLose;

    public int KeyItem;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        Player = gameObject.GetComponent<Transform>();

        isCharging = false;

        HP = MaxHP;
        MP = MaxMP;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Fire_CooldownCount);

            MPRegen();

            if (!isAlive)
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
            if (Input.GetKey(KeyCode.LeftControl) && isGrounded == true)
            {
                Charge();
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                CancelCharge();

            }

            if (isCharging != true)
            {


                Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                GetComponent<Rigidbody>().AddForce(Direction * WalkSpeed * Time.deltaTime, ForceMode.VelocityChange);

                GetComponent<Rigidbody>().AddForce(Direction * WalkSpeed * Time.deltaTime * 2);

                if (Direction.x < 0)
                {
                //PlayerSprite.flipX = true;
                Player.localScale = new Vector3(-1f, 1, 1); 
                    isWalkLeft = true;
                }
                else if (Direction.x > 0)
                {
                    //PlayerSprite.flipX = false;
                Player.localScale = new Vector3(1, 1, 1);
                isWalkLeft = false;
                }

                anim.SetFloat("Speed", Mathf.Abs(Direction.x));
                // anim.SetFloat("Attack");


                if (Input.GetKeyDown(KeyCode.W) && isGrounded)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
                }

                if (Input.GetKeyDown(KeyCode.S) && isGrounded == false)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.down * DownForce);
                }
            }



            // Fire Bullet
            if (Input.GetMouseButtonDown(0))
            {
                if (Fire_CooldownCount <= 0)
                {

                    if (isCharging && ChargeFull)
                    {
                        SpecialFire();
                    }
                    else
                    {
                        NormalFire();
                    }

                }
                else
                {
                    //Debug.Log("On Cooldown");
                }

            ChargeTimeCount = 0;
            }

            if(ChargeTimeCount < MaxChargeTime)
        {
            ChargeFull = false;
        }

            // Cooldown
            if (Fire_CooldownCount > 0)
            {
                Fire_CooldownCount -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Cooldown Finish!");
            }


            //isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckRange, groundLayer);
            Debug.DrawRay(transform.position, Vector3.up * groundCheckRange);

            isGrounded = Physics.CheckSphere(GroundChecker.position, groundCheckRange, groundLayer);

            anim.SetBool("Grounded", isGrounded);

            if (isGrounded)
            {
                //  GetComponentInChildren<SpriteRenderer>().color = Color.white;

            }
            else
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
        //Debug.Log("WW");
        HP -= damage; // HP = HP - damage;
        gameObject.layer = 11; // PlayerInvin
        PlayerSprite.color = Color.gray;

        yield return new WaitForSeconds(InvincibilityTimer);

        gameObject.layer = 11;
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
            IsLose = true;

            PlayerSprite.color = Color.clear; // 3.1
            gameObject.SetActive(false); // 3.2

        } else
        {
            StartCoroutine("TakeDamage", 10);
        }
    }

    void NormalFire()
    {
        if(MP >= 5)
        {
            GameObject NewBullte = Instantiate(Bullet, Gun_Position.position, Quaternion.identity);

            NewBullte.GetComponent<BulletController>().isMovingLeft = isWalkLeft;

            Fire_CooldownCount = Fire_Cooldown;

            MP -= 5;
        } else
        {
            //Debug.Log("MP is out");
        }
        
    }

    void SpecialFire()
    {
        if (MP >= 5)
        {
            GameObject SpeBullet = Instantiate(SpecialBullet, Gun_Position.position, Quaternion.identity);

            SpeBullet.GetComponent<BulletController>().isMovingLeft = isWalkLeft;

            Fire_CooldownCount = Fire_Cooldown;

            MP -= 5;
        }
        else
        {
            Debug.Log("MP is out");
        }

    }

    void MPRegen()
    {

        if(isCharging == false)
        {
            if (MP < MaxMP)
            {
                MP += Time.deltaTime * MPRegenSpeed;
            }

            if (MP > MaxMP)
            {
                MP = MaxMP;
            }
        }
        
        
    }

    void Charge()
    {
        isCharging = true;
        GetComponent<Rigidbody>().mass = 999;

        if(ChargeTimeCount < MaxChargeTime)
        {
            ChargeTimeCount += Time.deltaTime;

        } else
        {
            ChargeFull = true;
        }
     
        

    }

    void CancelCharge()
    {
        isCharging = false;
        GetComponent<Rigidbody>().mass = 15;

        ChargeTimeCount = 0;
    }

    void CheckCharge()
    {
        if(isCharging && ChargeTimeCount < MaxChargeTime)
        {
            ChargeTimeCount += Time.deltaTime * 2;
        }

        //if(isCharging)
        //    Camera.main.ScreenPointToRay()
    }
    


}
