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

    SpriteRenderer Bullet_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Expire", LeftTime);

      //  PlayerBullet = GameObject.Find("PlayerBullet 1").GetComponent<GameObject>();

        Bullet_Sprite = GetComponentInChildren<SpriteRenderer>();

       // rb = GameObject.Find("PlayerBullet 1").GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingLeft)
        {
            rb.AddForce(Vector3.left * Time.deltaTime * Speed);
            Bullet_Sprite.flipX = true;
        }
        else
        {
            rb.AddForce(Vector3.right * Time.deltaTime * Speed);
            Bullet_Sprite.flipX = false;
        }
        /*if(isMovingLeft)
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

    private void OnTriggerEnter(Collider other)
    {
        if(PlayerBullet && other.tag == "Enemy")
        {
            //Deal Damage to Enemy
            other.SendMessage("RecieveDamage", Damage);
            Destroy(this.gameObject);

        } 

        if(!PlayerBullet && other.tag != "Player")
        {
            //Deal Damage to Player
            other.SendMessage("RecieveDamage", Damage);
            Destroy(this.gameObject);

        }
    }
}
