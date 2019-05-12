using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_UI_Controller : MonoBehaviour
{
    public Image HP_Bar;
    public int BossHP;
    public int BossMaxHP;


    public GameObject Boss;
    public Boss_Controller BC;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");

        if(Boss)
        {
            BC = Boss.GetComponent<Boss_Controller>();
            BossMaxHP = BC.MaxHP;
            BossHP = BC.HP;
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        BossHP = BC.HP;


        HP_Bar.fillAmount = (float)BossHP / BossMaxHP;

        if (BC.isAlive == false)
        {
            Debug.Log(BC.isAlive);
            gameObject.SetActive(false);
        }
    }
}
