using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{

    public int HP;
    public int MaxHP;
    public bool isAlive;

    public SpriteRenderer BossSprite;
    public float InvincibilityTimer = 0.25f;

    public float CastingCount;
    public float castingCooldown;

    public int castingNumber;

    public GameObject[] Prefab_Skill;


    public Transform Skill1_Position;

    public Rigidbody rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;

        HP = MaxHP;

        BossSprite = gameObject.GetComponent<SpriteRenderer>();

        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (CastingCount < castingCooldown)
            {
                CastingCount += Time.deltaTime;
            }
            else if (CastingCount >= castingCooldown || Input.GetKeyDown(KeyCode.V))
            {
                casing();
            }


        }

    }


    void casing()
    {
        castingNumber = Random.Range(1, 4);

        GameObject Skill1 = Instantiate(Prefab_Skill[castingNumber], Skill1_Position.position, Quaternion.identity);

        /*if (castingNumber == 1)
        {
            cast1();
        }
        if (castingNumber == 2)
        {
            cast2();
        }
        if (castingNumber == 3)
        {
            cast3();
        }
        if (castingNumber == 4)
        {
            cast4();
        }*/

       // Debug.Log("Casting " + castingNumber);
        CastingCount = 0;
    }

    /*void cast1()
    {
        


        Debug.Log("casting1");
    }
    void cast2()
    {
        Debug.Log("casting2");
    }
    void cast3()
    {
        Debug.Log("casting3");
    }
    void cast4()
    {
        Debug.Log("casting4");
    }*/



    IEnumerator EnemyTakeDamage(int damage)
    {
        //Debug.Log("Enemy Hit");
        HP -= damage;
        gameObject.layer = 13;
        BossSprite.color = Color.gray;

        yield return new WaitForSeconds(InvincibilityTimer);

        BossSprite.color = Color.white;
    }

    public void RecieveDamage(int Damage)
    {
        HP -= Damage;

        if (HP <= 0)
        {
            Death();
            Destroy(this.gameObject);
            

            //gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine("EnemyTakeDamage", 10);
        }
    }

    void Death()
    {
        isAlive = false;
    }
}
