using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{

    public BoxCollider BulletCollider;
    public Transform Player_position;
    public GameObject Delay_position;

    public GameObject Aim_Position;

    public Rigidbody rb;
    public float Speed;
    public int Damage;
    public float LifeTime;

    public int MovementNumber;

    public GameObject[] Prefab;

    public bool tagged;

    public int Count;

    public bool isShoot1;
    public float Shoot1TimeCount;
    public int Shoot1TimeNum;

    // Start is called before the first frame update
    void Start()
    {
        BulletCollider = gameObject.GetComponent<BoxCollider>();
        rb = gameObject.GetComponent<Rigidbody>();

        Player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementNumber == 0)
        {
            Move0();
        }

        if (MovementNumber == 1)
        {
            Move1();
        }

        if (MovementNumber == 2)
        {
            Move2();
        }

        if (MovementNumber == 3)
        {
            isShoot1 = true;
            Move3();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && other.tag == "Ground" || gameObject && other.tag == "Wall" || gameObject && other.tag == "Floating")
        {
            tagged = true;
            // Destroy(BulletCollider);
        }

        if (gameObject && other.tag == "Player")
        {
            other.SendMessage("RecieveDamage", Damage);
            tagged = true;
           // Destroy(BulletCollider);
        }
    }

    void Move0()
    {
        rb.AddForce(Vector3.left * Time.deltaTime * Speed);

        if(tagged)
        {
            GameObject Skill1 = Instantiate(Prefab[0], transform.position, Quaternion.identity);
            GameObject Skill2 = Instantiate(Prefab[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    void Move1()
    {
        rb.AddForce(Vector3.left * Time.deltaTime * Speed);
        StartCoroutine("Expire", LifeTime);
    }


    void Move2()
    {
        rb.AddForce(Vector3.right * Time.deltaTime * Speed);
        StartCoroutine("Expire", LifeTime);
    }

    void Move3()
    {
        
        if(isShoot1 && Shoot1TimeCount < 3)
        {
            Shoot1TimeCount += Time.deltaTime;
        } else
        {
            isShoot1 = false;
        }

        if(Shoot1TimeCount < 1 && Shoot1TimeNum == 0)
        {
            GameObject Bomb = Instantiate(Prefab[0], Player_position.position, Quaternion.identity);
            Shoot1TimeNum++;
        }

        if (Shoot1TimeCount > 1 && Shoot1TimeCount < 2 && Shoot1TimeNum == 1)
        {
            GameObject Bomb = Instantiate(Prefab[0], Player_position.position, Quaternion.identity);
            Shoot1TimeNum++;
        }

        if (Shoot1TimeCount > 2 && Shoot1TimeCount < 3 && Shoot1TimeNum == 2)
        {
            GameObject Bomb = Instantiate(Prefab[0], Player_position.position, Quaternion.identity);
            Shoot1TimeNum++;
        }

        /*if (Shoot1TimeCount < 0.5 || Shoot1TimeCount > 0.5 && Shoot1TimeCount < 1.00 || Shoot1TimeCount >= 1.00)
        {
            if(Shoot1TimeNum < 3)
            {
                GameObject Bomb = Instantiate(Prefab[0], Player_position.position, Quaternion.identity);
                Shoot1TimeNum++;
            }
            
        }*/


        
    }

    void Move99()
    {
        int warp = 0;
        
        if(warp == 0)
        {
            
            //Delay_position.transform.position = Player_position.position;
            warp++;
        }

        // Vector3 Velocity = Vector3.zero;
        //Delay_position.transform.rotation = Quaternion.RotateTowards(Delay_position.transform.rotation, Player_position.transform.rotation, Time.deltaTime * 1);
        Delay_position.transform.position = Vector3.Lerp(Delay_position.transform.position, Player_position.position, Time.deltaTime);

        transform.LookAt(Delay_position.transform.position);
    }


    IEnumerator Expire(int timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
