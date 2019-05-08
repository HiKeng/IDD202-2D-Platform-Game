using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{

    public GameObject particle;


    Vector3 MousePosition = Input.mousePosition;

    


    // Start is called before the first frame update
    void Start()
    {
        
        MousePosition = new Vector3(0, 0, 0);

       
    }

    // Update is called once per frame
    void Update()
    {


        FaceMouse();

        //if(Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray))
        //        Instantiate(particle, transform.position, transform.rotation);

        //    Debug.Log("Aim");
        //    Instantiate(particle, transform.position, transform.rotation);

        //}
    }

    void FaceMouse()
    {
        MousePosition = Input.mousePosition;
        transform.position = MousePosition;
      // MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        //Vector2 direction = new Vector2(
        //    MousePosition.x - transform.position.x,
        //    MousePosition.y - transform.position.y);



        //transform.up = direction;

        
    }
}
