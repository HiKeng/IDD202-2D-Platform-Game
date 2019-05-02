using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour
{

    public int HP = 100;
    public bool ISWalkingLeft;
    public float WalkSpeed = 6000;

    public float groundCheckRange = 1f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    public SpriteRenderer EnemySprite;

    public Vector3 RayOffSet = Vector3.left;

    public float wallCheckRange = 1f;

    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(EnemySprite.flipX == true)
        //{
        //    ISWalkingLeft = true;
        //} else
        //{
        //    ISWalkingLeft = false;
        //}
       

        if (ISWalkingLeft)
        {
            CheckWall(Vector3.left);
            Debug.DrawRay(RayOffSet + transform.position, -Vector3.up * groundCheckRange, Color.red);
            if (Physics.Raycast(RayOffSet + transform.position, -Vector3.up , groundCheckRange, groundLayer))
            {
                
                //Debug.Log("Walking1");
                //Walk Left check Cliff On Left
                GetComponent<Rigidbody>().AddForce(Vector3.right * -WalkSpeed * Time.deltaTime);
                EnemySprite.flipX = true;
            } else
            {
                
                //Debug.Log("YOOO1");
                ISWalkingLeft = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }


        } else
        {
            CheckWall(Vector3.right);
            Debug.DrawRay(-RayOffSet + transform.position, -Vector3.up * groundCheckRange, Color.red);
            if (Physics.Raycast(-RayOffSet + transform.position, -Vector3.up , groundCheckRange, groundLayer))
            {
                
                //Debug.Log("Walking2");
                //Walk Left check Cliff On Left
                GetComponent<Rigidbody>().AddForce(Vector3.right * WalkSpeed * Time.deltaTime);
                EnemySprite.flipX = false;
            }
            else
            {
                
               // Debug.Log("YOOO2");
                ISWalkingLeft = true;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    void CheckWall (Vector3 direction)
    {
        Debug.DrawRay(transform.position, direction * wallCheckRange, Color.cyan);
        if (Physics.Raycast(transform.position, direction, wallCheckRange, wallLayer))
        {
            //Debug.Log("Wall1");
            if (ISWalkingLeft)
            {
                ISWalkingLeft = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
            else
            {
                ISWalkingLeft = true;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        } 
    }
}
