using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    public float Speed = 1f;
    public float Damage = 5f;
    public bool isMovingLeft;
    public float LeftTime = 5f;

    public GameObject EnemyBullet;
    public Rigidbody rb;

    public Enemy_Control Enemy;
    private bool ShootLeft;

    SpriteRenderer Bullet_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Expire", LeftTime);
        Bullet_Sprite = GetComponentInChildren<SpriteRenderer>();
        Enemy = GameObject.Find("Lance").GetComponent<Enemy_Control>();

        if(Enemy.ISWalkingLeft)
        {
            ShootLeft = true;
        } else
        {
            ShootLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootLeft)
        {
            rb.AddForce(Vector3.left * Time.deltaTime * Speed);
            Bullet_Sprite.flipX = true;
        }
        else
        {
            rb.AddForce(Vector3.right * Time.deltaTime * Speed);
            Bullet_Sprite.flipX = false;
        }
    }

    IEnumerator Expire(int timer)
    {

        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EnemyBullet && other.tag == "Player")
        {
            //Deal Damage to Enemy
            other.SendMessage("RecieveDamage", Damage);
            Destroy(this.gameObject);

        }

        if (!EnemyBullet && other.tag != "Enemy")
        {
            //Deal Damage to Player
            other.SendMessage("RecieveDamage", Damage);
            Destroy(this.gameObject);

        }
    }
}
