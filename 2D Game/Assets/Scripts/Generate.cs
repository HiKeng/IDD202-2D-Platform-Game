using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{

    public GameObject Prefab;

    public Boss_Controller BC;

    // Start is called before the first frame update
    void Start()
    {
        BC = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject TestObject = Instantiate(Prefab, transform.position, Quaternion.identity);


        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            BC.RecieveDamage(99999);
        }
    }
}
