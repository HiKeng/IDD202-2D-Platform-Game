using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : MonoBehaviour
{

    public float offset;
    public GetMousePosition MousePosition;
    public GameObject Mouse;

    public Transform differ;

    public float BulletRotation;

    public bool isFollow;

    // Start is called before the first frame update
    void Start()
    {
        //MousePosition = GameObject.Find("MousePosition").GetComponent<GetMousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 differnce = Camera.main.ScreenToWorldPoint(Input.mousePosition) - MousePosition.transform.position;


        //float rotZ = Mathf.Atan2(differnce.y, differnce.x) * Mathf.Rad2Deg;

        //if(rotZ < 0)
        //{
        //    rotZ += 360;
        //}

       // Debug.Log(rotZ);
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


       // BulletRotation = rotZ;

       /* if (differnce.z >= 0 && differnce.z <= -180)
        {
            isFollow = true;

        } else
        {
            isFollow = false;
        }
        

        if(isFollow)
        {
            float rotZ = Mathf.Atan2(differnce.y, differnce.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        } else
        {

        }*/

        
    }

    void Rotate()
    {
        

        
    }
}
