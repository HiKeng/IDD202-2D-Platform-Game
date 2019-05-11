using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{

    public Transform TestPosition;
    public Transform Cam;
    public float Zoffset;


    void Start()
    {
        TestPosition = gameObject.GetComponent<Transform>();

        Cam = GameObject.Find("Main Camera").GetComponent<Transform>();

        Zoffset = Cam.position.z;

    }

    void Update()
    {

        Zoffset = Cam.position.z;

        if(Zoffset < 0)
        {
            Zoffset *= -1;
        }

        CheckMousePosition();

        /*if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = -Vector3.one;


            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Zoffset));


            /*  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if(Physics.Raycast(ray, out hit))
              {
                  clickPosition = hit.point;
              }

            clickPosition.z = 0f;

            TestPosition.position = clickPosition;

            Debug.Log(clickPosition);
        } */
    }

    void CheckMousePosition()
    {
        Vector3 MousePosition = Vector3.one;

        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Zoffset));

        MousePosition.z = 0;

        TestPosition.position = MousePosition;

        //Debug.Log(MousePosition);

    }
}
