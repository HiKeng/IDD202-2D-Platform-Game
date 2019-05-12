using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isWin : MonoBehaviour
{

    public Boss_Controller BC;

    public bool StageClear;
    public int Count;

    public GameObject[] Prefab;

    // Start is called before the first frame update
    void Start()
    {
        BC = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss_Controller>();
        StageClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BC.isAlive == false)
        {
            StageClear = true;
            Debug.Log("asd");
        }


        if(StageClear)
        {
            if(Count == 0)
            {
                GameObject TestObject = Instantiate(Prefab[0], transform.position, Quaternion.identity);
                Count++;
                StartCoroutine("WhiteGlow");
            }
        }

        /*if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("TitileScreen");
        }*/
    }

    IEnumerator WhiteGlow()
    {
        
        GameObject WhiteGlow = Instantiate(Prefab[1], transform.position, Quaternion.identity);

        yield return new WaitForSeconds(27);

        SceneManager.LoadScene("TitileScreen");

    }
}
