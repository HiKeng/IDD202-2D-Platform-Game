using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 1f;
    public float Damage = 5f;
    public bool isMovingLeft;
    public float LeftTime = 5f;

    public GameObject PlayerBullet;
    public Rigidbody rb;
    public Transform Gun_Position;
    public GunPosition GP;
    public PlayerController PC;

    public Transform MousePosition;


    public float BulletShoot;

    SpriteRenderer Bullet_Sprite;

    public bool isShoot = false;

    public int BlustNum;
    public GameObject[] BlustList;

    // Start is called before the first frame update
    void Start()
    {

        isShoot = true;

       // MousePosition = GameObject.Find("MousePosition").GetComponent<Transform>();

        PC = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>();

        Gun_Position = GameObject.Find("Gun_Fire").GetComponent<Transform>();

        GP = GameObject.Find("Gun_Fire").GetComponent<GunPosition>();

        transform.rotation = Gun_Position.rotation;

        StartCoroutine("Expire", LeftTime);

        //  PlayerBullet = GameObject.Find("PlayerBullet 1").GetComponent<GameObject>();

        Bullet_Sprite = GetComponentInChildren<SpriteRenderer>();


        // rb = GameObject.Find("PlayerBullet 1").GetComponent<Rigidbody>();

        BulletShoot = GP.BulletRotation * -1;

        /*if (PC.isWalkLeft && BulletShoot > 0 || PC.isWalkLeft == false && BulletShoot < 0)
        {
            BulletShoot *= -1;
        }*/

        // Debug.Log(BulletShoot);


        if (BulletShoot < 0)
        {
            //BulletShoot;
        }

        //rb.AddForce(BulletShoot, 0, 0, ForceMode.Impulse);
        //rb.AddForce(Vector3.left * 999);

    }

        
       



        // Update is called once per frame
        void Update()
        {
            //transform.position = Vector3.MoveTowards(transform.position, MousePosition.position,1);
            // transform.position = Vector3.Lerp(transform.position, MousePosition.position, Time.deltaTime * 20);


            if (isShoot)
            {
                if (isMovingLeft)
                {
                    rb.AddForce(Vector3.left * Time.deltaTime * Speed);

                    //Debug.Log("Shoot");
                    Bullet_Sprite.flipX = true;
                }
                else
                {
                    rb.AddForce(Vector3.right * Time.deltaTime * Speed);
                   // Debug.Log("Shoot");
                    Bullet_Sprite.flipX = false;
                }
            }

            //transform.Translate(Vector3.up * Time.deltaTime * Speed);
            // rb.AddForce( * Time.deltaTime * Speed);

           

            /*if (isMovingLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime);
                Bullet_Sprite.flipX = true;


            } else
            {
                transform.Translate(Vector3.right * Time.deltaTime);
                Bullet_Sprite.flipX = false;
            }*/
        }


        IEnumerator Expire(int timer)
        {

            yield return new WaitForSeconds(timer);
            Destroy(this.gameObject);
        }

        void OnTriggerEnter(Collider other)
        {
            if (PlayerBullet && other.tag == "Ground" || PlayerBullet && other.tag == "Wall")
             {
            BlustEffect();
            Destroy(gameObject);
            //Debug.Log("Destroy");
            }

        if (PlayerBullet && other.tag == "Enemy" || PlayerBullet && other.tag == "Boss")
            {
            //Deal Damage to Enemy
            BlustEffect();
            other.SendMessage("RecieveDamage", Damage);
                Destroy(this.gameObject);

            }

            if (!PlayerBullet && other.tag != "Player")
            {
            //Deal Damage to Player
            BlustEffect();
            other.SendMessage("RecieveDamage", Damage);
                Destroy(this.gameObject);

            }

        


        }

    void BlustEffect()
    {
        GameObject blustEffect = Instantiate(BlustList[BlustNum], transform.position, Quaternion.identity);

        Destroy(blustEffect, 3f);
    }
}
