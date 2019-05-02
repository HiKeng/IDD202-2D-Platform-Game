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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Expire", LeftTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
   
        } else
        {
            transform.Translate(Vector3.right * Time.deltaTime);

        }
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

        if(!PlayerBullet && other.tag == "Player")
        {
            //Deal Damage to Player
            other.SendMessage("RecieveDamage", Damage);
            Destroy(this.gameObject);

        }
    }
}
